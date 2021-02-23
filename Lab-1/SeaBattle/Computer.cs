using System;

namespace SeaBattle {
    static class Computer {
        static char[,] computerShips = new char[10, 10];
        public static char[,] GenerateComputerShips() {
            for (int i = 0; i < 10; i++) {
                for (int j = 0; j < 10; j++) {
                    computerShips[i, j] = 'O';
                }
            }
            int coordinateX, coordinateY, rotation;      //rotaion 1 - left, 2 - right, 3 - up, 4 - down
            Random rnd = new Random();
            do {
                coordinateX = rnd.Next(0, 10);
                coordinateY = rnd.Next(0, 10);
                rotation = rnd.Next(1, 4);
            } while (!CanPlace(4, coordinateX, coordinateY, rotation));
            Place(4, coordinateX, coordinateY, rotation);
            for (int i = 0; i < 2; i++) {
                do {
                    coordinateX = rnd.Next(0, 9);
                    coordinateY = rnd.Next(0, 9);
                    rotation = rnd.Next(1, 4);
                } while (!CanPlace(3, coordinateX, coordinateY, rotation));
                Place(3, coordinateX, coordinateY, rotation);
            }
            for (int i = 0; i < 3; i++) {
                do {
                    coordinateX = rnd.Next(0, 9);
                    coordinateY = rnd.Next(0, 9);
                    rotation = rnd.Next(1, 4);
                } while (!CanPlace(2, coordinateX, coordinateY, rotation));
                Place(2, coordinateX, coordinateY, rotation);
            }
            for (int i = 0; i < 4; i++) {
                do {
                    coordinateX = rnd.Next(0, 9);
                    coordinateY = rnd.Next(0, 9);
                    rotation = rnd.Next(1, 4);
                } while (!CanPlace(1, coordinateX, coordinateY, rotation));
                Place(1, coordinateX, coordinateY, rotation);
            }
            return computerShips;
        }
        private static bool CanPlace(int size, int coordinateX, int coordinateY, int rotation) {
            bool deployable = true;
            if (rotation == 1) {
                if (coordinateX < size - 1) {
                    deployable = false;
                }
                if (deployable) {
                    for (int i = -1; i < size + 1; i++) {
                        if (coordinateY > 0 && coordinateX - i >= 0 && coordinateX - i <= 9 && computerShips[coordinateX - i, coordinateY - 1] == '#') {
                            deployable = false;
                        }
                        if (coordinateX - i >= 0 && coordinateX - i <= 9 && computerShips[coordinateX - i, coordinateY] == '#') {
                            deployable = false;
                        }
                        if (coordinateY < 9 && coordinateX - i >= 0 && coordinateX - i <= 9 && computerShips[coordinateX - i, coordinateY + 1] == '#') {
                            deployable = false;
                        }
                    }
                }
            }
            else if (rotation == 2) {
                if (coordinateX > 10 - size) {
                    deployable = false;
                }
                if (deployable) {
                    for (int i = -1; i < size + 1; i++) {
                        if (coordinateY > 0 && coordinateX + i >= 0 && coordinateX + i <= 9 && computerShips[coordinateX + i, coordinateY - 1] == '#') {
                            deployable = false;
                        }
                        if (coordinateX + i >= 0 && coordinateX + i <= 9 && computerShips[coordinateX + i, coordinateY] == '#') {
                            deployable = false;
                        }
                        if (coordinateY < 9 && coordinateX + i >= 0 && coordinateX + i <= 9 && computerShips[coordinateX + i, coordinateY + 1] == '#') {
                            deployable = false;
                        }
                    }
                }
            }
            else if (rotation == 3) {
                if (coordinateY < size - 1) {
                    deployable = false;
                }
                if (deployable) {
                    for (int i = -1; i < size + 1; i++) {
                        if (coordinateX > 0 && coordinateY - i >= 0 && coordinateY - i <= 9 && computerShips[coordinateX - 1, coordinateY - i] == '#') {
                            deployable = false;
                        }
                        if (coordinateY - i >= 0 && coordinateY - i <= 9 && computerShips[coordinateX, coordinateY - i] == '#') {
                            deployable = false;
                        }
                        if (coordinateX < 9 && coordinateY - i >= 0 && coordinateY - i <= 9 && computerShips[coordinateX + 1, coordinateY - i] == '#') {
                            deployable = false;
                        }
                    }
                }
            }
            else if (rotation == 4) {
                if (coordinateY > 10 - size) {
                    deployable = false;
                }
                if (deployable) {
                    for (int i = -1; i < size + 1; i++) {
                        if (coordinateX > 0 && coordinateY + i >= 0 && coordinateY + i <= 9 && computerShips[coordinateX - 1, coordinateY + i] == '#') {
                            deployable = false;
                        }
                        if (coordinateY + i >= 0 && coordinateY + i <= 9 && computerShips[coordinateX, coordinateY + i] == '#') {
                            deployable = false;
                        }
                        if (coordinateX < 9 && coordinateY + i >= 0 && coordinateY + i <= 9 && computerShips[coordinateX + 1, coordinateY + i] == '#') {
                            deployable = false;
                        }
                    }
                }
            }
            return deployable;
        }
        private static void Place(int size, int coordinateX, int coordinateY, int rotation) {
            if (rotation == 1) {
                for (int i = 0; i < size; i++) {
                    computerShips[coordinateX - i, coordinateY] = '#';
                }
            }
            else if (rotation == 2) {
                for (int i = 0; i < size; i++) {
                    computerShips[coordinateX + i, coordinateY] = '#';
                }
            }
            else if (rotation == 3) {
                for (int i = 0; i < size; i++) {
                    computerShips[coordinateX, coordinateY - i] = '#';
                }
            }
            else if (rotation == 4) {
                for (int i = 0; i < size; i++) {
                    computerShips[coordinateX, coordinateY + i] = '#';
                }
            }
        }
        public static int[] AttackProposal(char[,] playerCells, int complexcity = 0) {
            int[] coordinates = new int[2];
            int coordinateX, coordinateY;
            Random rnd = new Random();
            bool canFire = false, needhit = false;
            int luckiness = rnd.Next(0, 5);
            if (complexcity == 1 && luckiness < 2) {
                needhit = true;
            }
            if (complexcity == 2 && luckiness < 3) {
                needhit = true;
            }
            do {
                coordinateX = rnd.Next(0, 10);
                coordinateY = rnd.Next(0, 10);
                if (playerCells[coordinateX, coordinateY] != '*') {
                    canFire = true;
                }
                if (needhit && canFire && playerCells[coordinateX, coordinateY] != '#') {
                    canFire = false;
                }
            } while (!canFire);
            coordinates[0] = coordinateX;
            coordinates[1] = coordinateY;
            return coordinates;
        }
        public static int[] AttackProposal(char[,] playerCells, int previousX, int previousY, int complexcity = 0) { //used after succesful attack, but enemy ship isn't destroyed
            int[] coordinates = new int[2];
            bool hit = true;
            Random rnd = new Random();
            if (complexcity <= 2) {
                if (rnd.Next(0, 2) == 1) {
                    hit = false;
                }
            }
            bool canfire = false;
            for (int i = -1; i <= 1; i++) {
                for (int j = -1; j <= 1; j++) {
                    if (previousX + i >= 0 && previousX + i <= 9 && previousY + j >= 0 && previousY + j <= 9
                        && playerCells[previousX + i, previousY + j] != '*' && playerCells[previousX + i, previousY + j] != 'X') {
                        if (hit) {
                            if (playerCells[previousX + i, previousY + j] == '#') {
                                canfire = true;
                                coordinates[0] = previousX + i;
                                coordinates[1] = previousY + j;
                                break;
                            }
                        }
                        else {
                            canfire = true;
                            coordinates[0] = previousX + i;
                            coordinates[1] = previousY + j;
                        }
                    }
                }
            }
            if (!canfire) {
                coordinates = AttackProposal(playerCells, complexcity);
            }
            return coordinates;
        }
    }
}