using System;

namespace SeaBattle {
    class Button {
        private readonly int leftX, upY, sizeX, sizeY, returnValue;
        private readonly string name;
        private readonly ConsoleColor passiveColor, activeColor, textColor;
        public Button(string name, int returnValue, int leftX, int upY, int sizeX, int sizeY,
            ConsoleColor passiveColor, ConsoleColor activeColor, ConsoleColor textColor) {
            this.name = name;
            this.returnValue = returnValue;
            this.leftX = leftX;
            this.upY = upY;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.passiveColor = passiveColor;
            this.activeColor = activeColor;
            this.textColor = textColor;
        }
        public void Draw(bool active = false) {
            if (active) {
                Console.BackgroundColor = activeColor;
            }
            else {
                Console.BackgroundColor = passiveColor;
            }
            Console.ForegroundColor = textColor;
            for (int i = 0; i < sizeY; i++) {
                Console.SetCursorPosition(leftX, upY + i);
                for (int j = 0; j < sizeX; j++) {
                    Console.Write(' ');
                }
            }
            Console.SetCursorPosition(leftX, upY + sizeY / 2);
            Console.Write(name);
        }
        public int getValue() {
            return returnValue;
        }
    }
}