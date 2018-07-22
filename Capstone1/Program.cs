using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone1
{

    class Program
    {

        static string GetUserInput(string prompt)
        {

            Console.WriteLine(prompt);
            return Console.ReadLine();

        }

        static string ValidUserInput()
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

        static string CaseCorrector(string word, bool[] caseArr)
        {

            char[] temp = new char[word.Length];

            for(int i = 0; i < caseArr.Length; i++)
            {

                if (caseArr[i])
                {

                    temp[i] = Char.ToUpper(word[i]);

                }

                else
                {

                    temp[i] = Char.ToLower(word[i]);

                }

            }

            string output = new string(temp);

            return output;

        }

        static string[] ToPigLatin(string[] words)
        {

            string[] output = new string[words.Length];

            for (int i = words.Length - 1; i >= 0; i--)
            {

                char[] word = words[i].ToCharArray();

                //int punctPos;

                //for (int k = 0; k < word.Length; k++)
                //{

                //    if(word[k] == '.' || word[k] == ',' || word[k] == '?' || word[k] == '!')
                //    {

                //        punctPos = k;

                //    }

                //}         This will be punctuation stuff, maybe.

                for(int j = 0; j < word.Length;)
                {

                    if (Char.ToLowerInvariant(word[j]) == 'a' || Char.ToLowerInvariant(word[j]) == 'e' || Char.ToLowerInvariant(word[j]) == 'i' || Char.ToLowerInvariant(word[j]) == 'o' || Char.ToLowerInvariant(word[j]) == 'u')
                    {

                        if (j == 0)
                        {

                            string temp = new string(word);
                            output[i] = temp + "way";
                            j = word.Length;

                        }

                        else
                        {

                            string temp = new string(word);
                            output[i] = CaseCorrector(temp.Substring(j) + temp.Substring(0, j), CaseDetector(words[i])) + "ay";
                            j = word.Length;

                        }

                    }

                    else
                    {

                        j++;

                    }

                }

            }

            return output;

        }

        static void Main(string[] args)
        {

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
