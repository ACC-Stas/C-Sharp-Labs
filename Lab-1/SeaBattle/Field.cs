using System;

namespace SeaBattle {
    static class Field {
        static int coordinateY, coordinateX, playerScore = 0, compScore = 0;           //coordinates of cursor
        static char[,] playerCells = new char[10, 10];
        static char[,] playerShips = new char[10, 10];
        static char[,] computerCells = new char[10, 10];
        static char[,] computerShips = new char[10, 10];
        static bool available = false;
        public static bool Available() {
            return available;
        }
        public static void CreateField() {                   //Only create field, don't use after that
            available = true;
            Console.WriteLine("------------   ------------");
            for (int i = 0; i < 10; i++) {
                Console.WriteLine("|OOOOOOOOOO|   |OOOOOOOOOO|");
                for (int j = 0; j < 10; j++) {
                    playerCells[i, j] = 'O';
                    playerShips[i, j] = 'O';
                    computerCells[i, j] = 'O';
                }
            }
            Console.WriteLine("------------   ------------");
            coordinateX = 1;
            coordinateY = 1;
            Console.SetCursorPosition(coordinateX, coordinateY);
            computerShips = Computer.GenerateComputerShips();
        }
        public static void TransferControl() {
            if (coordinateX < 16) {
                coordinateX = 16;
            }
            else {
                coordinateX = 1;
            }
            coordinateY = 1;
            Console.SetCursorPosition(coordinateX, coordinateY);
        }
        public static bool Move() {   //can use at creation and fight phases, but not for computer's ship deployment
            char currentCell;
            bool needNextMove = true;
            if (coordinateX < 12) {      //12 - player's field size
                currentCell = playerCells[coordinateX - 1, coordinateY - 1];
            }
            else {
                currentCell = computerCells[coordinateX - 16, coordinateY - 1];
            }
            ConsoleKeyInfo command = Console.ReadKey();   //ReadKey delete cell
            Console.SetCursorPosition(coordinateX, coordinateY);
            Console.Write(currentCell);
            switch (command.Key) {
                case ConsoleKey.RightArrow: {
                        if ((coordinateX > 0 && coordinateX < 10) || (coordinateX > 15 && coordinateX < 25)) {
                            coordinateX++;
                        }
                        Console.SetCursorPosition(coordinateX, coordinateY);
                        break;
                    }
                case ConsoleKey.LeftArrow: {
                        if ((coordinateX > 1 && coordinateX < 11) || (coordinateX > 16 && coordinateX < 26)) {
                            coordinateX--;
                        }
                        Console.SetCursorPosition(coordinateX, coordinateY);
                        break;
                    }
                case ConsoleKey.UpArrow: {
                        if (coordinateY > 1) {
                            coordinateY--;
                        }
                        Console.SetCursorPosition(coordinateX, coordinateY);
                        break;
                    }
                case ConsoleKey.DownArrow: {
                        if (coordinateY < 10) {
                            coordinateY++;
                        }
                        Console.SetCursorPosition(coordinateX, coordinateY);
                        break;
                    }
                case ConsoleKey.Enter: {
                        Console.SetCursorPosition(coordinateX, coordinateY);
                        needNextMove = false;
                        break;
                    }
                default: {
                        PrintStatement("Unknown command");
                        break;
                    }
            }
            return needNextMove;
        } 
        public static void SetShip(int size) {
            PrintStatement("Setting ship with size: " + size);
            while (Move() || !IsSuitableForPlayer(size)) {
            }
            PrintStatement("Choose direction");
            while (ShipRotation(size)) ;
        }
        private static bool IsSuitableForPlayer(int size, int rotationWhish = 0) {     //0 - all diretcions, 1 - left, 2 - right, 3 - up, 4 - down
            bool canDeployR = true, canDeployL = true, canDeployUp = true, canDeployD = true;
            if (coordinateY < size) {
                canDeployUp = false;
            }
            if (coordinateY > 11 - size) {
                canDeployD = false;
            }
            if (coordinateX < size) {
                canDeployL = false;
            }
            if (coordinateX > 11 - size) {
                canDeployR = false;
            }
            for (int i = -1; i < size + 1; i++) {
                if (coordinateY + i - 1 >= 0 && coordinateY + i - 1 <= 9) {
                    if ((coordinateX - 1 - 1 >= 0 && coordinateX - 1 - 1 <= 9) && playerCells[coordinateX - 1 - 1, coordinateY + i - 1] == '#') {
                        canDeployD = false;
                    }
                    if ((coordinateX - 1 >= 0 && coordinateX - 1 <= 9) && playerCells[coordinateX - 1, coordinateY + i - 1] == '#') {
                        canDeployD = false;
                    }
                    if ((coordinateX + 1 - 1 >= 0 && coordinateX + 1 - 1 <= 9) && playerCells[coordinateX + 1 - 1, coordinateY + i - 1] == '#') {
                        canDeployD = false;
                    }
                }
                if (coordinateY - i - 1 >= 0 && coordinateY - i - 1 <= 9) {
                    if ((coordinateX - 1 - 1 >= 0 && coordinateX - 1 - 1 <= 9) && playerCells[coordinateX - 1 - 1, coordinateY - i - 1] == '#') {
                        canDeployUp = false;
                    }
                    if ((coordinateX - 1 >= 0 && coordinateX - 1 <= 9) && playerCells[coordinateX - 1, coordinateY - i - 1] == '#') {
                        canDeployUp = false;
                    }
                    if ((coordinateX + 1 - 1 >= 0 && coordinateX + 1 - 1 <= 9) && playerCells[coordinateX + 1 - 1, coordinateY - i - 1] == '#') {
                        canDeployUp = false;
                    }
                }
                if (coordinateX - i - 1 >= 0 && coordinateX - i - 1 <= 9) {
                    if ((coordinateY - 1 - 1 >= 0 && coordinateY - 1 - 1 <= 9) && playerCells[coordinateX - i - 1, coordinateY - 1 - 1] == '#') {
                        canDeployL = false;
                    }
                    if ((coordinateY - 1 >= 0 && coordinateY - 1 <= 9) && playerCells[coordinateX - i - 1, coordinateY - 1] == '#') {
                        canDeployL = false;
                    }
                    if ((coordinateY + 1 - 1 >= 0 && coordinateY + 1 - 1 <= 9) && playerCells[coordinateX - i - 1, coordinateY + 1 - 1] == '#') {
                        canDeployL = false;
                    }
                }
                if (coordinateX + i - 1 >= 0 && coordinateX + i - 1 <= 9) {
                    if ((coordinateY - 1 - 1 >= 0 && coordinateY - 1 - 1 <= 9) && playerCells[coordinateX + i - 1, coordinateY - 1 - 1] == '#') {
                        canDeployR = false;
                    }
                    if ((coordinateY - 1 >= 0 && coordinateY - 1 <= 9) && playerCells[coordinateX + i - 1, coordinateY - 1] == '#') {
                        canDeployR = false;
                    }
                    if ((coordinateY + 1 - 1 >= 0 && coordinateY + 1 - 1 <= 9) && playerCells[coordinateX + i - 1, coordinateY + 1 - 1] == '#') {
                        canDeployR = false;
                    }
                }
            }
            bool Deployable = false;
            if (canDeployL || canDeployR || canDeployUp || canDeployD) {
                Deployable = true;
            }
            switch (rotationWhish) {
                case 1: {
                        Deployable = canDeployL;
                        break;
                    }
                case 2: {
                        Deployable = canDeployR;
                        break;
                    }
                case 3: {
                        Deployable = canDeployUp;
                        break;
                    }
                case 4: {
                        Deployable = canDeployD;
                        break;
                    }
                default:
                    break;
            }
            return Deployable;
        }
        public static bool AttackForPlayer() {        //return true at successful attack
            if (coordinateX < 16 || coordinateX > 25 || coordinateY < 1 || coordinateY > 10) {
                coordinateX = 16;
                coordinateY = 1;
                Console.SetCursorPosition(coordinateX, coordinateY);
            }
            bool fired;
            do {
                fired = false;
                while (Move()) ;
                if (computerCells[coordinateX - 16, coordinateY - 1] == 'O') {
                    fired = true;
                }
            } while (!fired);
            bool damaged = false; ;
            if (computerShips[coordinateX - 16, coordinateY - 1] == '#') {
                damaged = true;
                computerCells[coordinateX - 16, coordinateY - 1] = 'X';
                Console.Write('X');
                PrintStatement("Nice shot");
            }
            else {
                computerCells[coordinateX - 16, coordinateY - 1] = '*';
                Console.Write('*');
            }
            bool destroyed = true;
            if (damaged) {
                for (int i = 0; computerShips[coordinateX - 16 - i, coordinateY - 1] == '#'; i++) {     //check left
                    if (computerCells[coordinateX - 16 - i, coordinateY - 1] != 'X') {
                        destroyed = false;
                    }
                    if (coordinateX - 16 - (i + 1) < 0) {
                        break;
                    }
                }
                for (int i = 0; computerShips[coordinateX - 16 + i, coordinateY - 1] == '#'; i++) {     //check right
                    if (computerCells[coordinateX - 16 + i, coordinateY - 1] != 'X') {
                        destroyed = false;
                    }
                    if (coordinateX - 16 + (i + 1) > 9) {
                        break;
                    }
                }
                for (int i = 0; computerShips[coordinateX - 16, coordinateY - 1 - i] == '#'; i++) {     //check up
                    if (computerCells[coordinateX - 16, coordinateY - 1 - i] != 'X') {
                        destroyed = false;
                    }
                    if (coordinateY - 1 - (i + 1) < 0) {
                        break;
                    }
                }
                for (int i = 0; computerShips[coordinateX - 16, coordinateY - 1 + i] == '#'; i++) {     //check down
                    if (computerCells[coordinateX - 16, coordinateY - 1 + i] != 'X') {
                        destroyed = false;
                    }
                    if (coordinateY - 1 + (i + 1) > 9) {
                        break;
                    }
                }
            }
            else {
                destroyed = false;
            }
            if (destroyed) {
                PrintStatement("Well done");
                bool[,] visited = new bool[10, 10];
                for (int i = 0; i < 10; i++) {
                    for (int j = 0; j < 10; j++) {
                        visited[i, j] = false;
                    }
                }
                DrawDeath(visited, computerCells, coordinateX - 16, coordinateY - 1);
                int tempX = coordinateX, tempY = coordinateY;
                coordinateX = 16;
                coordinateY = 1;
                for (int i = 0; i < 10; i++) {
                    for (int j = 0; j < 10; j++) {
                        Console.SetCursorPosition(coordinateX + i, coordinateY + j);
                        Console.Write(computerCells[i, j]);
                    }
                }
                coordinateX = tempX;
                coordinateY = tempY;
                Console.SetCursorPosition(coordinateX, coordinateY);
                playerScore++;
                if (playerScore >= 10) {
                    DrawMenu(true);
                    damaged = false;
                }
                if(compScore >= 10) {
                    damaged = false;
                }
            }
            return damaged;
        }
        public static void DrawMenu(bool victory = false) {
            Console.Clear();
            Console.SetCursorPosition(5, 12);
            if (victory) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Good job, commander. We are much oblijed");
            }
            else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("We need reinforcement, now!");
            }
            coordinateX = 1;
            coordinateY = 1;
            for (int i = 0; i < 10; i++) {
                for (int j = 0; j < 10; j++) {
                    Console.SetCursorPosition(coordinateX + i, coordinateY + j);
                    if (computerCells[i, j] == 'O') {
                        Console.Write(computerShips[i, j]);
                    }
                    else {
                        Console.Write(computerCells[i, j]);
                    }
                }
            }
            available = false;
        }
        public static bool AttackForComputer(bool wasDamaged = false, int complexcity = 0) { //complexcity ranges from 0 to 2
            int[] coordinates = new int[2];
            if (wasDamaged) {
                coordinates = Computer.AttackProposal(playerCells, coordinateX - 1, coordinateY - 1, complexcity);
            }
            else {
                coordinates = Computer.AttackProposal(playerCells, complexcity);
            }
            coordinateX = coordinates[0] + 1;
            coordinateY = coordinates[1] + 1;
            bool damaged = false; ;
            if (playerShips[coordinateX - 1, coordinateY - 1] == '#') {
                damaged = true;
                playerCells[coordinateX - 1, coordinateY - 1] = 'X';
                Console.SetCursorPosition(coordinateX, coordinateY);
                Console.Write('X');
                PrintStatement("We are under attack!");
            }
            else {
                playerCells[coordinateX - 1, coordinateY - 1] = '*';
                Console.SetCursorPosition(coordinateX, coordinateY);
                Console.Write('*');
            }
            System.Threading.Thread.Sleep(1000);
            bool destroyed = true;
            if (damaged) {
                for (int i = 0; playerShips[coordinateX - 1 - i, coordinateY - 1] == '#'; i++) {     //check left
                    if (playerCells[coordinateX - 1 - i, coordinateY - 1] != 'X') {
                        destroyed = false;
                    }
                    if (coordinateX - 1 - (i + 1) < 0) {
                        break;
                    }
                }
                for (int i = 0; playerShips[coordinateX - 1 + i, coordinateY - 1] == '#'; i++) {     //check right
                    if (playerCells[coordinateX - 1 + i, coordinateY - 1] != 'X') {
                        destroyed = false;
                    }
                    if (coordinateX - 1 + (i + 1) > 9) {
                        break;
                    }
                }
                for (int i = 0; playerShips[coordinateX - 1, coordinateY - 1 - i] == '#'; i++) {     //check up
                    if (playerCells[coordinateX - 1, coordinateY - 1 - i] != 'X') {
                        destroyed = false;
                    }
                    if (coordinateY - 1 - (i + 1) < 0) {
                        break;
                    }
                }
                for (int i = 0; playerShips[coordinateX - 1, coordinateY - 1 + i] == '#'; i++) {     //check down
                    if (playerCells[coordinateX - 1, coordinateY - 1 + i] != 'X') {
                        destroyed = false;
                    }
                    if (coordinateY - 1 + (i + 1) > 9) {
                        break;
                    }
                }
            }
            else {
                destroyed = false;
            }
            if (destroyed) {
                PrintStatement("Our ship is destroyed!");
                bool[,] visited = new bool[10, 10];
                for (int i = 0; i < 10; i++) {
                    for (int j = 0; j < 10; j++) {
                        visited[i, j] = false;
                    }
                }
                DrawDeath(visited, playerCells, coordinates[0], coordinates[1]);
                int tempX = coordinateX, tempY = coordinateY;
                coordinateX = 1;
                coordinateY = 1;
                for (int i = 0; i < 10; i++) {
                    for (int j = 0; j < 10; j++) {
                        Console.SetCursorPosition(coordinateX + i, coordinateY + j);
                        Console.Write(playerCells[i, j]);
                    }
                }
                coordinateX = tempX;
                coordinateY = tempY;
                compScore++;
                if (compScore >= 10) {
                    damaged = false;
                    DrawMenu();
                }
                if(playerScore >= 10) {
                    damaged = false;
                }
            }
            Console.SetCursorPosition(coordinateX, coordinateY);
            return damaged;
        }
        private static void DrawDeath(bool[,] visited, char[,] cells, int X, int Y) {   //require adapted coordinateX and coordinateY
            for (int i = -1; i <= 1; i++) {
                for (int j = -1; j <= 1; j++) {
                    if (X + i >= 0 && X + i <= 9 && Y + j >= 0 && Y + j <= 9 && !visited[X + i, Y + j]) {
                        visited[X, Y] = true;
                        visited[X + i, Y + j] = true;
                        if (cells[X + i, Y + j] == 'X') {
                            DrawDeath(visited, cells, X + i, Y + j);
                        }
                        else {
                            cells[X + i, Y + j] = '*';
                        }
                    }
                }
            }
        }
        private static bool ShipRotation(int size) {
            bool needRotation = true, deployable = false;
            char currentCell = playerCells[coordinateX - 1, coordinateY - 1];
            ConsoleKeyInfo command = Console.ReadKey();
            Console.SetCursorPosition(coordinateX, coordinateY);
            Console.Write(currentCell);
            switch (command.Key) {
                case ConsoleKey.LeftArrow: {
                        deployable = IsSuitableForPlayer(size, 1);
                        break;
                    }
                case ConsoleKey.RightArrow: {
                        deployable = IsSuitableForPlayer(size, 2);
                        break;
                    }
                case ConsoleKey.UpArrow: {
                        deployable = IsSuitableForPlayer(size, 3);
                        break;
                    }
                case ConsoleKey.DownArrow: {
                        deployable = IsSuitableForPlayer(size, 4);
                        break;
                    }
                case ConsoleKey.Enter: {
                        PrintStatement("Choose direction, commander");
                        break;
                    }
                default:
                    PrintStatement("Unknown command");
                    break;
            }
            if (deployable) {
                PrintStatement("Confirm?");
                ConsoleKeyInfo choose = Console.ReadKey();
                Console.SetCursorPosition(coordinateX, coordinateY);
                if (choose.Key == ConsoleKey.Enter || choose.Key == command.Key) {
                    needRotation = false;
                    if (command.Key == ConsoleKey.LeftArrow) {
                        for (int i = 0; i < size; i++) {
                            playerCells[coordinateX - i - 1, coordinateY - 1] = '#';
                            playerShips[coordinateX - i - 1, coordinateY - 1] = '#';
                            Console.SetCursorPosition(coordinateX - i, coordinateY);
                            Console.Write('#');
                        }
                    }
                    else if (command.Key == ConsoleKey.RightArrow) {
                        for (int i = 0; i < size; i++) {
                            playerCells[coordinateX + i - 1, coordinateY - 1] = '#';
                            playerShips[coordinateX + i - 1, coordinateY - 1] = '#';
                            Console.SetCursorPosition(coordinateX + i, coordinateY);
                            Console.Write('#');
                        }
                    }
                    else if (command.Key == ConsoleKey.UpArrow) {
                        for (int i = 0; i < size; i++) {
                            playerCells[coordinateX - 1, coordinateY - i - 1] = '#';
                            playerShips[coordinateX - 1, coordinateY - i - 1] = '#';
                            Console.SetCursorPosition(coordinateX, coordinateY - i);
                            Console.Write('#');
                        }
                    }
                    else if (command.Key == ConsoleKey.DownArrow) {
                        for (int i = 0; i < size; i++) {
                            playerCells[coordinateX - 1, coordinateY + i - 1] = '#';
                            playerShips[coordinateX - 1, coordinateY + i - 1] = '#';
                            Console.SetCursorPosition(coordinateX, coordinateY + i);
                            Console.Write('#');
                        }
                    }
                    PrintStatement("Ship is deployed");
                }
                else {
                    PrintStatement("Choose direction");
                }
            }
            return needRotation;
        }
        public static void ShowComputerShips() {
            coordinateX = 16;
            coordinateY = 1;
            for (int i = 0; i < 10; i++) {
                for (int j = 0; j < 10; j++) {
                    Console.SetCursorPosition(coordinateX + j, coordinateY + i);
                    Console.Write(computerShips[j, i]);
                }
            }
            Console.SetCursorPosition(coordinateX, coordinateY);
        }
        public static void PrintStatement(string statement) {
            Console.SetCursorPosition(0, 13);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("                                                         ");
            Console.SetCursorPosition(0, 13);
            Console.Write(statement);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(coordinateX, coordinateY);
        }
    }
}