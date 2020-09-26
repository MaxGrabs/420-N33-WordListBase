using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2WS
{
    class WordMatcher
    {
        public readonly struct s
        {

        }
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            List<MatchedWord> matchedWords = new List<MatchedWord>();

            foreach (string scrambledWord in scrambledWords)
            {
                foreach (string word in wordList)
                {
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                       matchedWords.Add(BuildMatchedWord(scrambledWord, word));


                        matchedWords.Add(new MatchedWord() { ScrambledWord = scrambledWord, Word = word });

                    }
                    else
                    {
                        StringBuilder newScrambleWord = new StringBuilder();
                        StringBuilder newWord = new StringBuilder();
                        
                         //convert strings into character arrays i.e. ToCharArray()
                        char [] scrambleArray = scrambledWord.ToCharArray();
                        char[] wordArray = word.ToCharArray();
                        //sort both character arrays
                        Array.Sort(scrambleArray);
                        Array.Sort(wordArray);
                        //convert sorted character arrays into strings (toString)
                        
                        for(int i=0; i<scrambleArray.Length; i++)
                        {
                            newScrambleWord.Append(scrambleArray[i]);
                        }
                        for (int i = 0; i < wordArray.Length; i++)
                        {
                            newWord.Append(wordArray[i]);
                        }
                        newScrambleWord.ToString();
                        newWord.ToString();
                        // string newScrambleWord= new string(scrambleArray);
                        //string newWord = new string(wordArray);

                        //compare the two sorted strings. If they match, build the MatchWord struct and add to matchedWords list.
                        if (newScrambleWord == newWord)
                        {
                            matchedWords.Add(BuildMatchedWord(scrambledWord, word));

                            matchedWords.Add(new MatchedWord() { ScrambledWord = scrambledWord, Word = word });
                        }

                    }

                }
            }

            return null;
        }

        MatchedWord BuildMatchedWord(string scrambledWord, string word)
        {
            MatchedWord matchedWord = new MatchedWord()
            {
                ScrambledWord = scrambledWord,
                Word = word
            };

            return matchedWord;
        }



    }
}
