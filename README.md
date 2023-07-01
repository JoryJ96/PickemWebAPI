# Pick 'Em project

Current solution contains both the DB/API projects (PickemDB, PickemWebAPI, and PickemWebAPI.Library) and the frontend projects (PickemWPFUI and PickemWPFUI.Library). Those will be seperated for the final build, and  the DB/API will be run on a machine 24/7 to allow users constant access to make their picks

The way the project is currently setup, a user (once an account can be created) logs in and is immediately granted an API token. This is required to make calls to the API/DB.

Currently WIP is the Games page, which the user is taken to after logging in. It is simply a list of buttons side by side, Home team on the left and Away team on the right. The spread will be displayed underneath the team names.
WIP is to setup the bindings for the buttons stackPanel text contents, which will read from a Games table in the DB to auto-populate. The games table will be filled out manually.

Some limits to selecting games include not allowing both teams in a single game to be selected (If a user tries to select the second team, their pick will simply be changed to that team, and the original will be un-selected);
The submit button will not be available until one MNF game is selected, one SNF game is selected, the DAL game is selected (if not on SNF/MNF), and the other optionals are selected

Other pages available to the user will be leaderboards, and possibly a more comprehensive break down of picks on a seperate page depending on how information-dense the leaderboard looks

If there is enough time to stylize the app thoroughly before the start of the season, I would like for each button to have the teams primary color (with some transparency/wash-out to not overpower the text) and the teams logo in the background)

In season development could include the possibility to create/join multiple leagues for other sports. The overall design of current project should be developed with this in mind (Generic labels/bindings for buttons/leaderboards, with pick set rules being determined based on LeagueID(?))
