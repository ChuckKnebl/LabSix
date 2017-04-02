using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSix
{
    class Program
    {
        //Task is to translate from English to Pig Latin.
        //App prompts the user for a word.
        //App translates the text to Pig Latin and displays it on the console.
        //App asks if user wants to translate another word.
        //Spec:  convert each word to lowercase before translating.
        //Spec:  If word begins with vowel, just add "way" to the ending.
        //Spec:  If word begins with consonant, move all consonants that appear before the first vowel
        //to end of word, then add "ay" to the end of the word.
        //Hint:  Treat "y" as a consonant. 
        static void Main(string[] args)
        {
            Boolean run = true;
            while (run == true)
            {
                Console.WriteLine("Please enter a word to convert to Pig Latin: ");
                string wordOne = Console.ReadLine();
                wordOne = wordOne.ToLower();
                string pigLatin = ToPigLatin(wordOne);

                Console.WriteLine(pigLatin);
                run = Continue();
            } 

        }
        public static Boolean Continue()
        {
            Boolean run;
            Console.WriteLine("Continue and translate another word?  Y/N");
            String answer = Console.ReadLine();
            answer = answer.ToLower();

            if (answer == "y")
            {
                run = true;
            }
            else if (answer == "n")
            {
                run = false;
                Console.WriteLine("Good Bye!");
            }
            else
            {
                Console.WriteLine("Sorry, I don't understand.  Let's try again");
                run = Continue();
            }
            return run;
        } 
        
        
        public static string ToPigLatin(string wordOne)
        {
            //Declare variables.
            const string WAY = "way";
            const string AY = "ay";
            const string vowels = "aeiou";
            //Returned variable.
            string modString = "";
            Boolean hasVowels = true;
            int position = 0;
            int count = 0;
            char letter = wordOne[0];

            //Process data.
            position = vowels.IndexOf(letter);
            
            while(position == -1 && count <= wordOne.Length)
            {
                if(position == -1 && count < wordOne.Length)
                {
                    ++count;
                    letter = wordOne[count - 1];
                    position = vowels.IndexOf(letter);
                    hasVowels = true;
                }
                else
                {
                    ++count;
                    hasVowels = false;
                }
            }
            letter = wordOne[0];
            position = vowels.IndexOf(letter);

            //Means it must be a vowel.
            if(position != -1)
            {
                modString = wordOne + WAY;
            }
            else if (hasVowels)
            {
                count = 0;
                while(position == -1 && count < wordOne.Length)
                {
                    ++count;
                    letter = wordOne[count];
                    position = vowels.IndexOf(letter);
                }

                //Create new string.
                modString = wordOne.Substring(count) + wordOne.Substring(0, count) + AY;
            }
            else
            {
                count = 0;

                //Create new string.
                modString = wordOne.Substring(count) + wordOne.Substring(0, count) + AY;
            }

            return modString;
        }
    }
}


           
