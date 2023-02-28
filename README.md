# TicTacToe game
A simple game where the player plays against the CPU.

## Rules
The player starts and makes a first move. After the first move, the CPU makes his movie immediately. The goal of the game is to get three in a row.

## Gameplay
There are three ways a round can be ended
- the player wins by selecting three tiles in a row (horizontally, vertically or crossed)
- the CPU wins by selecting three tiles in a row (horizontally, vertically or crossed)
- the game ends in a tie if there is no clear winner

At the start the screen is empty and no scores are written.

![image](https://user-images.githubusercontent.com/12195753/221785538-7085edbf-cde3-4b59-bd74-f89cc6a2492e.png)

After the user made its first move, the computer executes one action on the board

![image](https://user-images.githubusercontent.com/12195753/221785944-d06a3bdb-0260-4741-b6f5-acc8d74ceb9b.png)

When the player or the CPU manages to get three in a row, the round ends and a message will pop up with the name of the designated winner.

![image](https://user-images.githubusercontent.com/12195753/221786020-6e8adaac-a335-427b-9f20-5539bd05c8fb.png)

After this message the board has been cleared and a new round will begin. The score from the previous round will be added to the designated winner.

![image](https://user-images.githubusercontent.com/12195753/221786074-148216a3-bd0c-467e-a164-7ef543819978.png)

The player can also reset the score with the `RESTART GAME` button. When this is pressed the board and the scores of the player and CPU will be cleared

![image](https://user-images.githubusercontent.com/12195753/221786674-53549af0-6a0d-4607-a54a-69300d9473a1.png)
