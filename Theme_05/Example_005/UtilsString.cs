using System;
using System.Collections.Generic;

namespace Example_005
{
    /// <summary>
    /// Utility class for handling strings
    /// </summary>
    public static class UtilsString
    {
        public static string GetShortestWord(string text, char[] delimiterChars = null)
        {
            delimiterChars = delimiterChars ?? new [] {' ', ',', '.'};

            var words = text.Split(delimiterChars);
            string resString = null;
            
            foreach (var word in words)
            {
                if ((resString == null || resString.Length > word.Length) && word.Length > 0)
                {
                    resString = word;
                }
            }

            return resString ?? "";
        }  
        
        public static string[] GetLongestWords(string text, char[] delimiterChars = null)
        {
            delimiterChars = delimiterChars ?? new [] {' ', ',', '.'};

            var words = text.Split(delimiterChars);
            var listOfWords = new List<string>();
            int maxLengs = -1;
            //определяем длину самого длинного слова
            foreach (var word in words)
            {
                if ((maxLengs == -1 || maxLengs < word.Length) && word.Length > 0)
                {
                    maxLengs = word.Length;
                }
            }
            
            foreach (var word in words)
            {
                if (word.Length == maxLengs)
                {
                    listOfWords.Add(word);                    
                }
            }
            return listOfWords.ToArray();
        }

        public static string GroupTextByChars(string text)
        {
            var resText = "";
            if (text.Length == 0) return resText;
            var ch = text[0];
            for (var i = 1; i < text.Length; i++)
            {
                if (Char.ToUpper(text[i]) == Char.ToUpper(ch))
                {
                    ch = text[i]; //буква может совпадать, но регистр может отличаться
                    continue;
                } 
                    
                resText += ch;
                ch = text[i];
            }
            resText += ch;
            return resText;
        }
    }
}