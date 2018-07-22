using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone1
{

    class Program
    {

        static string GetUserInput(string prompt)   //Works
        {

            Console.WriteLine(prompt);
            return Console.ReadLine();

        }

        static string ValidUserInput()              //Works
        {

            string output = "";

            do
            {

                output = GetUserInput("Please enter a word or sentence to translate to Pig Latin");

            } while (output == "");

            return output;

        }

        static string[] StringToWords(string inputString)
        {

            string[] words = inputString.Split(' ');
            return words;

        }

        static bool[] CaseDetector(string word)
        {

            char[] check = word.ToCharArray();
            bool[] returnVal = new bool[check.Length];

            for (int i = 0; i < check.Length; i++)
            {

                if(char.IsLower(check[i]))
                {

                    returnVal[i] = false;

                }
                else
                {

                    returnVal[i] = true;

                }

            }

            return returnVal;

        }

        static string PigFormat(string input, int type)
        {

            if (type == 0)          //Things like emails
            {

                return input;

            }

            else if (type == 1)     //Starts with a vowel
            {



            }

            else if (type == 2)     //Consonant
            {



            }

            else                    //I don't know how you got this.
            {

                return "ERROR " + type;

            }

        }

        static string[] ToPigLatin(string[] words)
        {

            string[] output = new string[words.Length];

            //List<string> tempLetters = new List<string>();

            for (int i = words.Length - 1; i >= 0; i--)
            {

                //Here is fine. Console.WriteLine(words[i]);

                if(words[i].Contains("*") || words[i].Contains("(") || words[i].Contains(")") || words[i].Contains("1") || words[i].Contains("2") || words[i].Contains("3") || words[i].Contains("4") || words[i].Contains("5") || words[i].Contains("6") || words[i].Contains("7") || words[i].Contains("8") || words[i].Contains("9") || words[i].Contains("0") || words[i].Contains("&") || words[i].Contains("^") || words[i].Contains("%") || words[i].Contains("$") || words[i].Contains("#") || words[i].Contains("@"))
                {

                    output[i] = PigFormat(words[i], 0);

                }

                else if(words[i].ToLowerInvariant().Substring(0,1).Contains("a")|| words[i].ToLowerInvariant().Substring(0,1).Contains("e") || words[i].ToLowerInvariant().Substring(0,1).Contains("i") || words[i].ToLowerInvariant().Substring(0,1).Contains("o") || words[i].ToLowerInvariant().Substring(0,1).Contains("u"))
                {

                    output[i] = PigFormat(words[i], 1);
                    //Console.WriteLine(output[i]);

                }

                else
                {

                    output[i] = PigFormat(words[i], 2);
                    //Console.WriteLine(output[i]);

                }

            }

            return output;

        }

        static void Main(string[] args)
        {

            //Console.WriteLine(ValidUserInput());      //Test

            //var wordArray = ToPigLatin(StringToWords(ValidUserInput()));

            //for (int i = wordArray.Length - 1; i >= 0; i--)
            //{

            //    Console.WriteLine(wordArray[wordArray.Length - 1 - i]);

            //}

            char goAgain = 'y';

            do
            {

                string[] output = ToPigLatin(StringToWords(ValidUserInput()));

                for (int i = output.Length - 1; i >= 0; i--)
                {

                    Console.Write(output[output.Length - 1 - i] + " ");

                }

                Console.WriteLine();
                Console.WriteLine("Would you like to play again? (Y/N)");
                goAgain = Char.Parse(Console.ReadLine());

            } while (Char.ToLowerInvariant(goAgain) == 'y');

    {

            }

        }

    }

}
