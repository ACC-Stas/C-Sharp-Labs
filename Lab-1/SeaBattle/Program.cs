using System;

namespace SeaBattle {
    class Program {
        static void Main(string[] args) {
            Menu mainMenu = new Menu();
            bool wantToPlay;
            wantToPlay = mainMenu.StartMenu();
            while (wantToPlay) {
                int complexcity = mainMenu.GetComplexcity();
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Clear();
                Field.CreateField();
                Field.SetShip(4);
                Field.SetShip(3);
                Field.SetShip(3);
                Field.SetShip(2);
                Field.SetShip(2);
                Field.SetShip(2);
                Field.SetShip(1);
                Field.SetShip(1);
                Field.SetShip(1);
                Field.SetShip(1);
                while (Field.Available()) {
                    while (Field.AttackForPlayer()) ;
                    bool computerHit = false;
                    do {
                        computerHit = Field.AttackForComputer(computerHit, complexcity);
                    } while (computerHit);
                }
                wantToPlay = mainMenu.StartMenu();
            }
        }
    }
}