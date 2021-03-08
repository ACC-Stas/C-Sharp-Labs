using System;

namespace CurrentTime {
    class Program {
        static void Main(string[] args) {
            DateTime time = DateTime.Now;
            string time1;
            Console.WriteLine(time.ToString(System.Globalization.CultureInfo.InvariantCulture));
            Console.WriteLine(time.ToString());
            time1 = time.ToString(System.Globalization.CultureInfo.InvariantCulture);
            int[] numbers = new int[10];
            int current;
            for(int i = 0; i < time1.Length; i++) {
                current = Convert.ToInt32(time1[i]);
                if(current >= 48 && current <= 57) {     // 0 - 48,..., 9 - 57
                    numbers[current - 48]++;
                }
            }
            for(int i = 0; i < 10; i++) {
                Console.Write(numbers[i] + " ");
                numbers[i] = 0;
            }
            Console.WriteLine('\n' + time.ToString("F"));
            string time2 = time.ToString("F");
            for (int i = 0; i < time2.Length; i++) {
                current = Convert.ToInt32(time2[i]);
                if (current >= 48 && current <= 57) {
                    numbers[current - 48]++;
                }
            }
            for (int i = 0; i < 10; i++) {
                Console.Write(numbers[i] + " ");
                numbers[i] = 0;
            }
        }
    }
}
