# TicTacToe game
A simple game where the player plays against the CPU.

## Rules
The player starts and makes a first move. After the first move, the CPU makes his movie immediately. The goal of the game is to get three in a row.

## Gameplay
There are three ways a round can be ended
- the player wins by selecting three tiles in a row (horizontally, vertically or crossed)
- the CPU wins by selecting three tiles in a row (horizontally, vertically or crossed)
- the game ends in a tie if there is no clear winner

### Startscreen

When the application has started, the user will see a start screen where the user can type in its own player name and choose a difficulty between
- EASY
- INTERMEDIATE

If the player does not write a name or choose a difficulty, the defaults of `Player` and `EASY` are chosen.

![image](https://user-images.githubusercontent.com/12195753/225313636-7e7a0743-e381-4c01-8e4b-2b602248bdea.png)

### Gameboard

At the start the screen is empty and no scores are written.

![image](https://user-images.githubusercontent.com/12195753/225313787-639d41a7-9d88-405a-97d4-73dfbb1ca1fd.png)

After the user made its first move, the computer executes one action on the board

![image](https://user-images.githubusercontent.com/12195753/225313880-f13f021b-b24a-4ea4-a050-9b210604e8fe.png)

When the player or the CPU manages to get three in a row, the round ends and a message will pop up with the name of the designated winner.

![image](https://user-images.githubusercontent.com/12195753/225314037-32363cdd-3de8-476e-95ff-35e96114350d.png)

After this message the board has been cleared and a new round will begin. The score from the previous round will be added to the designated winner.

![image](https://user-images.githubusercontent.com/12195753/225314188-a880946d-dd41-4b75-a25d-14e1a3850b47.png)

The player can also reset the score with the `RESTART GAME` button. When this is pressed the board and the scores of the player and CPU will be cleared

![image](https://user-images.githubusercontent.com/12195753/225314258-e75f9b30-8393-4e4a-b985-f36f243d5f38.png)
