# "GAME POINT" Application
[Click for Youtube video](https://youtu.be/2IZ7qJQUDf0)


## Description

"GAME POINT" is a web application designated to manage basic gamers (both individuals and teams) profiles, organize gaming competitions and events and maintain performance statistics.

![Home Page](/ScreenShots/HomePage.JPG)

## Getting started

To use "GAME POINT", you may enter either as a guest user or as registered. As guest user you will have access to players repository, events and matches in read-only mode. As registered user, you have the option to associate your user's profile to a player's profile by sending a request to the application administrator. You can also send request to be granted a 'director' rights letting you manage your own events.

## Functionality
`USERS:`

- Use the "Register" menu to setup your user account. User name and password are mandatory. Mail address is also mandatory as it will be used by the application to communicate with you.
  
![Register Page](/ScreenShots/RegisterPage.JPG)

- Once registered, you can immediately log into the application, as no additional validated for your identity will be needed by mail or other means. You can use the "Login" menu to do so.

- When already inside the application, you can proceed with further amendment of your profile. You can use "Profile" menu to:
  - Request to have director's role. Use the "Send request" button under the option to submit request to the administrator. The administrator will receive a mail notification about your request and will decide whether to approve it or not.
  
  ![User Profile Page](/ScreenShots/ProfilePage.JPG)
  
  - You can also submit a request to be associated to a player's profile. List of players' profiles created in the application is available for selection. You must select the player's profile corresponding to you and submit the request. As above, the administrator will receive a mail notification about your request and will decide whether to approve it or not.
  - The statuses of your requests are then available on the profile page.
  - Use the "Profile" menu also to change your password.

`PLAYERS:`

- In "GAME POINT" players are managed as independent entities, separate from users. 
- "Players" menu offers as entry point a full list of players with their pictures and option to access their profiles. Search and sort criteria are available via the "Search" button. Authorized users can use the "Create" button to add new players.

  ![Player List Page](/ScreenShots/PlayersListPage.JPG)

- Player's details screen provides variable options and information:
  - For authorized users: to edit or delete the player's profile
  - For all users:
    - Users name, country and club
    - List of tournaments and matches where player took part

    ![Player Participation](/ScreenShots/PlayersParticipations.JPG)

    - Statistics about player's performance (wins, draws, losses)
    - Statistics about player's important opponents: opponent most played, most wins against and most losses against

- Only directors and administrators can create new players. Ordinary users have access to the creation page but will receive an error message if they try to create a new player entity.
- Attention on the player type: it should be stated during the creation whether the player is an individual or represents a team. This information will be later used during the event's management to filter out the possible participants in the event.
- An additional option for adding a new club is available in the player's creation screen. It allows a quick creation of a club only inserting its name, which then becomes immediately available in the "Club" dropdown menu for selection.

  ![New Player Page](/ScreenShots/NewPlayerPage.JPG)

  - Once a new player is created, it is still not possible to associate it immediately to a user. A request to the administrator must be submitted in such case (see the "Users" section above).

 `EVENTS:`

 - Event creation
   - Creation and management of events is reserved only for directors and administrators. 
     - Directors can create new events and manage only their own events. 
     - Administrators can create and manage all events
   - Creation of a new event is available through the "Event" -> "Create event" menu
     - This menu is available only for logged and authorized users
     - Ordinary users and guest users will be directed to the events list page if they try to use the "Event" menu
   - Once in the create menu, the user must select the necessary information. Specificities:
     - Three event types are maintained in the application: Single Match, League and Knockout. The event type will subsequently determine the matches scheme
     - Event main location: 
       - this is the location where, normally, the opening and/or closing ceremonies will take place and most of the matches will be played. 
       - Location can be selected from the drop-down list of available locations. The friendly Bing map control aside will center on that location. New locations can also be created, if needed.

       ![New Event Page](/ScreenShots/NewEventPage.JPG)

      - Scores for victory and draws: selecting a "League" as type of event will display two additional fields where the scores for win and draw result must be inserted.
      - Time limit and Score limit types of matches can be selected. The field "Match limit" will then indicate either the duration of the match or the number of points to be reached during the match.
      - A checkbox indicates whether the event is designated for competing teams or individuals.
      - Once the event is created, additional options are displayed on the event, including possibility to modify event's title, start and end date.
  
  - Assign players, awards and generate matches scheme
    - A drop-down list contains players that can join the event. Use the "Add player" button to assign a new player. Alternatively, you can use the "Create player" button for quick creation only with name
    - The event type makes rigorous check on players number. Each event has its requirement, which are displayed under "Participants List" title. A "Generate match scheme" button will appear at the bottom of the participants list only if this requirement is fulfilled.

    ![Event Participants](/ScreenShots/ParticipantsList.JPG)

    - Below the participants list, a table for award fund is available. Awardable rankings are displayed based on the event type
    - Generation of matches scheme automatically creates all matches of the event. The date and the location of each match must be individually maintained.

    ![Event Matches](/ScreenShots/MatchesList.JPG)

  - Maintain scores
    - At the bottom of the list with matches you will find a link directing to the match scheme, represented in the form of brackets. There you can maintain the result of each match individually.
    - In case of knockout matches, the inserted result will automatically determine the winner and assign it as participant for the next round.

    ![Event Scores](/ScreenShots/ScoresPage.JPG)

    - Note that knockout and single match events cannot have draw results: the "Save Score" button will not be available if draw score is inserted.
    - Once entered, score can be reset. A constraint for knockout events, though, prevents resetting scores for previous rounds in case the related match in the next round was already played.
    - For leagues, score update also updates the players' ranking for the event thus keeping information about the temporary rank list in real time. 

  - Closing the event
    - Once all scores for an event have been maintained, the event must be closed. 
    - Closing the event will finalize players ranking and will determine the champion.
    - Closing will also lock all possible changes of the event and will leave it in read-only mode.
    - If needed, an event can, however, be reopened for modifications.

  - Events index and event details
    - The event's index is available both for all logged and guest users. It represents a paginated table sortable by its headings and with search-by-title option.
    - The name of the champion is shown in the "Champion" column. In case if event is still on-going or about to start, this information is displayed in the same column

    ![Events Index Table](/ScreenShots/EventsIndexPage.JPG)

    - Buttons to edit and delete an event can be available in the last column but they will be visible only for administrators and for directors' own events.
    - The event title provides a hyperlink to the event details screen
    - The event details page displays main information about the event: The list of matches with their dates and locations, list of participants with ranking within the event, event's main information and location info.

    ![Event Details Control](/ScreenShots/EventDetails.jpg)

    ![Event Location Info](/ScreenShots/LocationInfo.jpg)

## Technological highlights
- Integration with Mailjet; a mail notification is automatically sent when:
  - associated player is assigned or removed to an event
  - associated player is assigned to a new match
  - match has been updated
  - request for director's access
  - request to associate a player with user's profile
  - notification about administrator's decision

- Integration with Open Weather API:
  - Weather forecast obtained for the event's main location 
  - 40 mini-forecasts are processed on bases of 120 forecasts provided by the API
  - Information synthesized and main features provided for 5 days ahead:
    - Min/Max temperature for each day
    - Predominant weather conditions for the day
    - Weather parameters now

- Users authentication
  - JWT authentication with bearing scheme used to access the REST API 
  - Identity with cookies keeping users' claims used for the MVC part
  - Password encrypted using SHA512 hashing algorithm and stored in the database

- Bing Maps API
  - Bing Maps control fetching data for the selected location
  - Bing Maps API integrated with application during locations creation; geographical coordinates are retrieved based on the high probability data provided in the API json result

- Automapper: Technic to automatically map the database models to view models

- Database diagram
![DB Diagram](/ScreenShots/DBDiagram.jpg)

  ## Credits to external resources
The following two free resources were used as bases for the site main theme and matches score functionality:
 - [Tournament Site Template](https://themewagon.com/themes/free-bootstrap-html5-sports-website-template-soccer/);
 - [Tournament Brackets Template](https://blog.codepen.io/2018/02/16/need-make-tournament-bracket/);