// See https://aka.ms/new-console-template for more information
using MineSweepTest;
using MineSweepTest.Controller;
using MineSweepTest.View;

Console.WriteLine("Hello, World!");
//for(int i =  0; i < 5; i++)
//{
GameSelectorController controller = new GameSelectorController();
//    Console.WriteLine("\n");
//}


//MineSweepGame game = new MineSweepGame();
//bool firstTurn = true;
//bool cont = true;
//while (cont) {
//    int inputX;
//    int inputY;
//    Console.WriteLine("input column");
//    int.TryParse(Console.ReadLine(), out inputY);

//    Console.WriteLine("input row");
//    int.TryParse(Console.ReadLine(), out inputX);



//    if (firstTurn)
//    {
//        game.CreateBoard(inputX, inputY);
//        firstTurn = false;
//    }
//    else {
//        game.markItem(inputX, inputY);
//    }

//    for (int x = 0; x < game.Board.GetLength(0); x++) {
//        for (int y = 0; y < game.Board.GetLength(1); y++) {
//            Console.Write(game.Board[x,y].BombLabel + " ");
//        }
//        Console.WriteLine();
//    }

//    if (!cont) {
//        Console.WriteLine("\n\nBOMB HIT");
//    }

//}