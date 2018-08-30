# Sudoku Solver in C#

Having been solving sudokus for years - I stumbled across a book of "ultra difficult" sudokus. I started solving one but when I was almost done, it did not solve correctly, there was a conflict. So I erased everything and started from scratch, but once again I ran into a conflict - a new one this time. Starting to get a little annoyed I skipped that sudoku and went on the the next one. But again I ran into a conflict and now it was clear, I had to create a program that can solve sudokus.

Having created software in school that could solve mazes and working with other recursive algorithms - I was certain that this was the way to go. I quickly created a function that could validate the full state of a sudoku, so that any errors would result in a back-trace in the recursive algorithme. Other than that it was quit simple - just starting in one corner, is field not empty - then move to next field. If it is empty try inserting a '1' then validate - and if successfull, move to next field. If not successfull try a '2' and so on.

Simple solution - and very efficient.

# Running

Requires .NET core - and should run on any platform supported. Devloped using MacOS.

Go to the Sudoku folder and run:

dotnet run

Currently everything is hardcoded. It first generates the most simple Sudoku you can imagine - then it scramples it and clears 51 cells. The genrated puzzle actually has more solutions, so it does not match the original Sudoku generated before clearing cells.


