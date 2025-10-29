# A_Morley_Kata_Minesweeper

# Purpose
A test recreation of Minesweeper

# How to use
1. run project
2. The program will ask for the column and row of your selection (between 0 and 7). This isn't a finished program, so it will break if you go out of bounds.
3. it will show the full grid and ask for your next selection

# Dependencies/setup
I don't think it has any

# state pattern
I chose the state pattern because it allows me to easily add more games to this system while keeping the main mechanics separate enough that they could be easily moved into a different system later. Also, because it's now built to have multiple games, it means it's easier to find places to add more patterns than if it were just the Minesweeper game.
