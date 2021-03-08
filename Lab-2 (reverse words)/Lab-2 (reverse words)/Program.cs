using System;
using System.Text;

namespace ReverseWords {
    class Program {
        static void Main(string[] args) {
            string words =" " + Console.ReadLine();
            StringBuilder reverseWords = new StringBuilder(words.Length + 1);
            for(int wordBegin = words.Length - 1, wordEnd = words.Length - 1; wordBegin >= 0; wordBegin--) {  
                if(words[wordBegin] == ' ') {
                    while(words[wordEnd] == ' ') {
                        if(wordEnd <= 0) {
                            break;
                        }
                        wordEnd--;
                    }
                    if(wordBegin < wordEnd) {
                        reverseWords.Append(words.Substring(wordBegin, wordEnd - wordBegin + 1));
                        if(wordBegin == 0) {
                            break;
                        } else {
                            wordEnd = wordBegin - 1;
                        }
                    }
                }
            }
            Console.WriteLine(reverseWords);
        }
    }
}
