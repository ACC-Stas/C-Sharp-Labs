using System;

namespace SeaBattle {
    class Menu {
        private int complexcity = 0;
        private readonly ConsoleColor textColor;
        private readonly ConsoleColor buttonsPassiveColor;
        private readonly ConsoleColor buttonsActiveColor;
        private Button start, settings, exit, easy, middle, hard;
        private int cursorPosition = 0;
        private int menuState = 0; // 0 - main menu, 1 - settings

        public Menu(ConsoleColor textColor = ConsoleColor.Black, ConsoleColor buttonsPassiveColor = ConsoleColor.White,
            ConsoleColor buttonsActiveColor = ConsoleColor.Yellow) {
            this.textColor = textColor;
            this.buttonsPassiveColor = buttonsPassiveColor;
            this.buttonsActiveColor = buttonsActiveColor;
            start = new Button("START", 1, 4, 1, 10, 3, buttonsPassiveColor, buttonsActiveColor, textColor);
            settings = new Button("SETTINGS", 2, 4, 5, 10, 3, buttonsPassiveColor, buttonsActiveColor, textColor);
            exit = new Button("EXIT", 0, 4, 9, 10, 3, buttonsPassiveColor, buttonsActiveColor, textColor);
            easy = new Button("EASY", 0, 4, 1, 10, 3, buttonsPassiveColor, buttonsActiveColor, textColor);
            middle = new Button("MIDDLE", 1, 4, 5, 10, 3, buttonsPassiveColor, buttonsActiveColor, textColor);
            hard = new Button("HARD", 2, 4, 9, 10, 3, buttonsPassiveColor, buttonsActiveColor, textColor);
        }
        public int GetComplexcity() {
            return complexcity;
        }
        public bool StartMenu() { //true - need to play
            bool play = false, showAgain;
            do {
                showAgain = false;
                Console.CursorVisible = false;
                DrawMenu();
                while (move()) ;
                if (cursorPosition == 0) {
                    play = true;
                }
                else if (cursorPosition == 1) {
                    if (menuState == 0) {
                        menuState = 1;
                        StartMenu();
                        menuState = 0;
                        showAgain = true;
                    }
                }
            } while (showAgain);
            Console.CursorVisible = true;
            return play;
        }
        private bool move() {
            bool needNextMove = true;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);
            ConsoleKeyInfo command = Console.ReadKey();
            switch (command.Key) {
                case ConsoleKey.UpArrow: {
                        if (cursorPosition > 0) {
                            cursorPosition--;
                            refresh();
                        }
                        break;
                    }
                case ConsoleKey.DownArrow: {
                        if (cursorPosition < 2) {
                            cursorPosition++;
                            refresh();
                        }
                        break;
                    }
                case ConsoleKey.Enter: {
                        needNextMove = false;
                        break;
                    }
                default:
                    break;
            }
            return needNextMove;
        }
        private void refresh() {
            bool first = false, second = false, third = false;
            if (cursorPosition == 0) {
                first = true;
            }
            else if (cursorPosition == 1) {
                second = true;
            }
            else if (cursorPosition == 2) {
                third = true;
            }
            if (menuState == 0) {
                start.Draw(first);
                settings.Draw(second);
                exit.Draw(third);
            }
            else {
                complexcity = cursorPosition;
                easy.Draw(first);
                middle.Draw(second);
                hard.Draw(third);
            }
        }
        private void DrawMenu() {
            Console.Clear();
            cursorPosition = 0;
            if (menuState == 0) {
                start.Draw(true);
                settings.Draw();
                exit.Draw();
            }
            else {
                easy.Draw(true);
                middle.Draw();
                hard.Draw();
            }
        }
    }
}