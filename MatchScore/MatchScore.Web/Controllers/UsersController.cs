using AutoMapper;
using MatchScore.Data.Constants;
using MatchScore.Data.Enums;
using MatchScore.Data.Helpers;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using MatchScore.Exceptions;
using MatchScore.Services.Services.Contracts;
using MatchScore.Web.Helpers;
using MatchScore.Web.ViewModels.EventViewModels;
using MatchScore.Web.ViewModels.PlayerViewModels;
using MatchScore.Web.ViewModels.RequestViewModels;
using MatchScore.Web.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MatchScore.Web.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IRequestsService requestsService;
        private readonly IPlayersService playersService;
        private readonly IEventsService eventsService;
        private readonly IMapper mapper;
        private readonly AuthHelper authHelper;

        public UsersController(IUsersService usersService, IRequestsService requestsService, IPlayersService playersService, IEventsService eventsService, IMapper mapper, AuthHelper authHelper)
        {
            this.usersService = usersService;
            this.requestsService = requestsService;
            this.playersService = playersService;
            this.eventsService = eventsService;
            this.mapper = mapper;
            this.authHelper = authHelper;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(UserRegisterVM userRegisterVM)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View(userRegisterVM);
                }

                if (this.usersService.GetByUsername(userRegisterVM.Username) != null)
                {
                    throw new DuplicateEntityException(string.Format(Messages.AlreadyExistsError, "User", "username", userRegisterVM.Username));
                }

                if (this.usersService.GetAll().FirstOrDefault(u => u.Email.Equals(userRegisterVM.Email, StringComparison.CurrentCultureIgnoreCase)) != null)
                {
                    throw new DuplicateEntityException(string.Format(Messages.AlreadyExistsError, "User", "e-mail", userRegisterVM.Email));
                }

                if (!userRegisterVM.Password.Equals(userRegisterVM.ConfirmPassword))
                {
                    throw new InvalidOperationException(Messages.PasswordsMatchError);
                }

                authHelper.CreatePasswordHash(userRegisterVM.Password, out byte[] passwordSalt, out byte[] passwordHash);

                User newUser = mapper.Map<User>(userRegisterVM);

                newUser.PasswordSalt = passwordSalt;

                newUser.PasswordHash = passwordHash;

                usersService.Create(newUser);

                return RedirectToAction("Index", "Home");
            }
            catch (DuplicateEntityException ex)
            {
                if (ex.Message.Contains("username"))
                {
                    this.ModelState.AddModelError("Username", ex.Message);
                }
                else if (ex.Message.Contains("email"))
                {
                    this.ModelState.AddModelError("Email", ex.Message);
                }

                return this.View(userRegisterVM);
            }
            catch (InvalidOperationException ex)
            {
                this.ModelState.AddModelError("Email", ex.Message);

                return this.View(userRegisterVM);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginVM userLoginVM)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View(userLoginVM);
                }

                User userToLogin = this.usersService.GetByUsername(userLoginVM.Username);

                if (userToLogin == null)
                {
                    throw new EntityNotFoundException(string.Format(Messages.DoesNotExistErrorLong, "User", "username", userLoginVM.Username));
                }
                else if (userToLogin.IsInactive == true)
                {
                    throw new UnauthorizedOperationException(string.Format(Messages.DeactivatedUserError));
                }
                else if (!this.authHelper.VerifyPasswordHash(userLoginVM.Password, userToLogin.PasswordSalt, userToLogin.PasswordHash))
                {
                    throw new UnauthorizedOperationException(string.Format(Messages.UnauthenticatedError));
                }

                ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

                identity.AddClaim(new Claim("UserId", userToLogin.UserId.ToString()));
                identity.AddClaim(new Claim("Username", userToLogin.Username));
                identity.AddClaim(new Claim("Role", userToLogin.Role.ToString()));

                HttpContext.User = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                User,
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.Now.AddMinutes(5)
                });

                return RedirectToAction("Index", "Home");
            }
            catch (EntityNotFoundException ex)
            {
                this.ModelState.AddModelError("Username", ex.Message);

                return this.View(userLoginVM);
            }
            catch (UnauthorizedOperationException ex)
            {
                this.ModelState.AddModelError("Username", ex.Message);

                return this.View(userLoginVM);
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index(UserQueryParameters userQueryParameters)
        {
            if (userQueryParameters.SortBy == null)
            {
                this.ViewData["SortOrder"] = "";
            }
            else if (userQueryParameters.IsHeader)
            {
                this.ViewData["SortOrder"] = string.IsNullOrEmpty(userQueryParameters.SortOrder) ? "desc" : "";
            }

            this.ViewData["PaginationSortOrder"] = userQueryParameters.PaginationSortOrder;

            this.ViewData["SortBy"] = userQueryParameters.SortBy;

            PaginatedList<User> users = this.usersService.FilterBy(userQueryParameters);

            List<UserIndexVM> userIndexVMs = users.Select(u => this.mapper.Map<UserIndexVM>(u)).ToList();

            UserListVM userListVM = new UserListVM
            {
                Users = userIndexVMs,
                CurrentPage = users.CurrentPage,
                HasPrevPage = users.HasPrevPage,
                HasNextPage = users.HasNextPage
            };

            return this.View(userListVM);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Details(int userId)
        {
            try
            {
                UserDetailsVM userToGet = this.mapper.Map<UserDetailsVM>(this.usersService.GetById(userId));

                if (userToGet == null)
                {
                    throw new EntityNotFoundException(string.Format(Messages.DoesNotExistErrorLong, "User", "Id", userId));
                }

                List<EventLongVM> eventIndexVMs = this.eventsService.GetAll()
                    .Where(e => e.DirectorId == userToGet.UserId)
                    .Select(e => this.mapper.Map<EventLongVM>(e))
                    .ToList();

                userToGet.Events = eventIndexVMs;

                return this.View(userToGet);
            }
            catch (EntityNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Edit(int userId)
        {
            try
            {
                UserEditVM userEditVM = this.mapper.Map<UserEditVM>(this.usersService.GetById(userId));

                if (userEditVM == null)
                {
                    throw new EntityNotFoundException(string.Format(Messages.DoesNotExistErrorLong, "User", "Id", userId));
                }

                List<UserIndexVM> users = this.usersService.GetAll().Select(u => this.mapper.Map<UserIndexVM>(u)).ToList();

                List<PlayerShortVM> players = this.playersService.GetAll().Select(p => this.mapper.Map<PlayerShortVM>(p)).ToList();

                List<RequestIndexVM> requests = this.requestsService.GetAll().Select(r => this.mapper.Map<RequestIndexVM>(r)).ToList();


                List<EventLongVM> events = this.eventsService.GetAll()
                    .Where(e => e.DirectorId == userEditVM.UserId)
                    .Select(e => this.mapper.Map<EventLongVM>(e))
                    .ToList();

                UserProfileVM userProfileVM = new UserProfileVM
                {
                    User = userEditVM,
                    Users = users,
                    Players = players,
                    Requests = requests,
                    Events = events
                };

                return this.View(userProfileVM);
            }
            catch (EntityNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult ChangePassword(UserEditVM userUpdates)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return this.View(userUpdates);
                }

                if (userUpdates.UserId != int.Parse(User.Claims.FirstOrDefault(c => c.Type.Equals("UserId")).Value))
                {
                    throw new UnauthorizedOperationException(string.Format(Messages.UnauthorizedError));
                }

                User userToUpdate = this.usersService.GetById(int.Parse(User.Claims.FirstOrDefault(c => c.Type.Equals("UserId")).Value));

                if (!this.authHelper.VerifyPasswordHash(userUpdates.CurrentPassword, userToUpdate.PasswordSalt, userToUpdate.PasswordHash))
                {
                    throw new UnauthorizedOperationException(Messages.CurrentPasswordError);
                }
                else if (!userUpdates.NewPassword.Equals(userUpdates.ConfirmNewPassword))
                {
                    throw new InvalidOperationException(Messages.PasswordsMatchError);
                }

                authHelper.UpdatePasswordHash(userUpdates.NewPassword, userToUpdate.PasswordSalt, out byte[] passwordHash);

                User userWithUpdates = userToUpdate;

                userWithUpdates.PasswordHash = passwordHash;

                usersService.Update(userUpdates.UserId, userWithUpdates);

                return RedirectToAction("Index", "Home");
            }
            catch (UnauthorizedOperationException ex)
            {
                this.ModelState.AddModelError("CurrentPassword", ex.Message);

                return this.View(userUpdates);
            }
            catch (InvalidOperationException ex)
            {
                this.ModelState.AddModelError("NewPassword", ex.Message);

                return this.View(userUpdates);
            }
        }

        [HttpGet]
        public IActionResult ChangeStatus(int id)
        {
            User userToUpdate = this.usersService.GetById(id);

            userToUpdate.IsInactive = !userToUpdate.IsInactive;

            this.usersService.Update(id, userToUpdate);

            return RedirectToAction("Index", "Users");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            this.usersService.Delete(id);

            return RedirectToAction("Index", "Users");
        }
    }
}
