using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2WS
{
    class Program
    {
        private static readonly FileReader fileReader = new FileReader();
        private static readonly WordMatcher wordMatcher = new WordMatcher();

        static void Main(string[] args)
        {
            bool success = false;
            bool success2 = false;
            while (success == false)
            {
                try
                {
                    Console.WriteLine(Constants.WordOption);

                    string option = Console.ReadLine() ?? throw new Exception(Constants.StringNull);

                    switch (option.ToUpper())
                    {
                        case Constants.File:
                            Console.WriteLine(Constants.FilePath);
                            ExecuteScrambledWordsInFileScenario();
                           // Console.WriteLine("Test1"); Error appears so wont get to this line and thus success remains false.
                            success = true;
                            break;
                        case Constants.Manual:
                            Console.WriteLine(Constants.ManualPath);
                            ExecuteScrambledWordsManualEntryScenario();
                            success = true;
                            break;
                        default:
                            Console.WriteLine(Constants.FileManualError);
                            break;
                    }
                    if (success == true)
                    {
                        Console.WriteLine(Constants.ContinueQuestion);

                        while (success2 == false)
                        {
                            string optionAgain = Console.ReadLine() ?? throw new Exception(Constants.StringNull);

                            switch (optionAgain.ToUpper())
                            {
                                case Constants.Yes:
                                    success = false;
                                    success2 = true;
                                    break;
                                case Constants.No:
                                    success2 = true;
                                    break;
                                default:
                                    Console.WriteLine(Constants.FileManualError2);
                                    break;
                            }
                        }
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(Constants.ErrorMessage + e.Message);
                }
            }


        }

        private static void ExecuteScrambledWordsInFileScenario()
        {
            
            string fileName = Console.ReadLine();
            
            string[] scrambledWords = fileReader.Read(fileName);
            //Console.WriteLine("test");
            DisplayMatchedScrambledWords(scrambledWords);
            
        }

        private static void ExecuteScrambledWordsManualEntryScenario()
        {

            string userInput = Console.ReadLine();
            string[] scrambledWords = userInput.Split(',');
            DisplayMatchedScrambledWords(scrambledWords);

            // 1 get the user's input - comma separated string containing scrambled words

            // 2 Extract the words into a string (red,blue,green) 
            // 3 Call the DisplayMatchedUnscrambledWords method passing the scrambled words string array
        }
        private static void DisplayMatchedScrambledWords(string[] scrambledWords)
        {
            //Console.WriteLine("test4");
            string[] wordList = fileReader.Read(Constants.RegWordText); // Put in a constants file. CAPITAL LETTERS.  READONLY. THIS FILE IS READ 
            List<MatchedWord> matchedWords = new List<MatchedWord>();
            matchedWords =wordMatcher.Match(scrambledWords, wordList);

            //Console.WriteLine("test5");

            // Rule:  Use a formatter to display ... eg:  {0}{1}              
            // Rule:  USe an IF to determine if matchedWords is empty or not......
            //            if empty - display no words found message.
            //            if NOT empty - Display the matches.... use "foreach" with the list (matchedWords)
            if (!matchedWords.Any())
            {
                Console.WriteLine(Constants.NoMatch);
            }
            
            else
            {
                //Console.WriteLine("test6");
                foreach (var Matchedword in matchedWords)
                {
                    //from MatchedWord.cs ---->Matchedword.ScrambledWord, Matchedword.Word)
                  Console.WriteLine(String.Format(Constants.YesMatch, Matchedword.ScrambledWord, Matchedword.Word));
                    
                }
                
            }


        }
    }
}
