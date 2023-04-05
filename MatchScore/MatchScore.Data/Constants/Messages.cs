namespace MatchScore.Data.Constants
{
    public static class Messages
    {
        public const string DoesNotExistErrorLong = "{0} with {1} {2} does not exist!";

        public const string DoesNotExistErrorShort = "{0} {1} does not exist!";

        public const string AlreadyExistsError = "{0} with {1} {2} already exists!";

        public const string StringMinMaxLengthError = "{0} must be between {2} and {1} characters!";

        public const string StringMinLengthError = "{0} should be at least {1} characters!";

        public const string StringMaxLengthError = "{0} should be up to {1} characters!";

        public const string InvalidEmailError = "Invalid e-mail address!";

        public const string UsernameAlreadyExistsError = "Username {0} is already in use! Please select another username.";

        public const string UnauthorizedError = "You are not authorized to perform this action!";

        public const string DeactivatedUserError = "This user account has been deactivated by the admin! Contact the admin to activate it.";

        public const string AdminRequiredError = "Only admins can {0 {1}}!";

        public const string CompletedEventError = "Completed events cannot be modified or deleted!";

        public const string UnauthenticatedError = "Invalid username or password!";

        public const string RequiredError = "{0} is required!";

        public const string DateDisplay = "dd MMM yyyy";

        public const string ShortDateDisplay = "dd-MM-yyyy";

        public const string InputDateFormat = "yyyy-MM-yy";

        public const string InvalidDate = "{0} must be between 01.01.1960 and 31.12.2099";

        public const string InvalidEndDate = "End date cannot be earler than the start date";

        public const string ImageSrc = "data:image/jpg;base64,{0}";

        public const string DeleteConnectedEntityError = "{0} already connected to other entities and cannot be deleted!";

        public const string EventContainsMatches = "There are matches assigned to this event! Remove matches first.";

        public const string ItemNotAssigned = "{0} {1} is not part of {2} {3}!";

        public const string PlayersNotProperlyAssigned = "The event needs {0} {1} players to generate a valid matches scheme.";

        public const string CurrentPasswordError = "Wrong current password!";

        public const string PasswordsMatchError = "Passwords do not match!";

        public const string NoMatchesPlayed = "No matches have been played yet.";

        public const string NoMatchesWon = "No matches have been won yet.";

        public const string NoMatchesLost = "No matches have been lost yet.";

        public const string InvalidInfo = "Invalid information.";
    }
}
