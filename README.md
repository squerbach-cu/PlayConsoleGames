## Play Console Games

 **Play Console Games** is the first application I build as a programming apprentice in Germany.
 The Program has been refactored multiple times as I have gotten more requirements or simply learned more.
 
### How do you play
#### Towers of Hanoi
The way the game is played in the program is, by pressing 1, 2 or 3 on the keyboard.
This will then remove the disk on top of the stack you selected. After that, the player can out put the disk onto another stack.
The game will end as soon as the player manages to put all the disks onto the right disk stack.
You can read about the specifics [here](https://en.wikipedia.org/wiki/Tower_of_Hanoi).
#### Connect Four
Two players, that can enter their names in the beginning of the game, take turns placing tokens in a 6 by 7 grid.
The players do this by pressing 1 to 7 on the keyboard

You can read about the specifics [here](https://en.wikipedia.org/wiki/Connect_Four).
#### Tic Tac Toe
Two players take turns placing Xs and Os.
By pressing 1 to 9 the players selects the field in which he wants to put his X or O
You can read about the specifics [here](https://en.wikipedia.org/wiki/Tic-tac-toe).
#### Saving the game
You can, by pressing 's' on your keyboard, save the game. This will create a JSON savegame file.
### Adding to the game
Adding to this program could be done by creating a game that implements the IGame.cs interface. The program does not detect the games automatically,
therefore, the new game also has to be added into the GameEngine.cs, so it then can be stated.
### Know Bugs
If the player pressed 's' a savegame file will be created, if the player then changes the savegame in a way that it can't be deserialized the game will crash.
