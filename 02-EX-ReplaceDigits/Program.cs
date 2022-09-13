#region Assignment
/*
 * Write a method ReplaceDigits in the class Exercise that expects a string parameter called sentence and does the following:
For every occurrence of the digits '0', '1', '2', '3', '4', '5', '6', '7', '8', and '9',
replace them with the words 'zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', eight', or 'nine' respectively.
Return the modified sentence with all digits replaced, and insert spaces where appropriate.
So for the input string "4 score and 7 years ago, 8 men had the same PIN code: 6571",
I expect the following output:
"four score and seven years ago, eight men had the same PIN code: six five seven one"
The exercise.cs file contains a number of bugs,
and it is very inefficient in terms of memory use.
Your task is to fix the bugs, and refactor the code to minimize the number of string objects created on the heap. 
 * */
#endregion

using System.Diagnostics.SymbolStore;
using System.Text;
using System.Text.RegularExpressions;

var text = "44 score and 7 years ago, 8 men had the same PIN code: 6571";
Console.WriteLine("Got:");
Exercise.ReplaceDigits_REGEX(text);
//Console.WriteLine(Exercise.ReplaceDigits("4 score and 7 years ago, 8 men had the same PIN code: 6571"));
Console.WriteLine("Expected:\nfour score and seven years ago, eight men had the same PIN code: six five seven one");
//"four score and seven years ago, eight men had the same PIN code: six five seven one"

public class Exercise
{
    // TODO: fix this method - fix bugs, make more efficient, and return correct result
    public static string ReplaceDigits(string sentence)
    {
        string[] words = { "zero", "one", "two", "three", "four", "five", "six", " seven", "eight", "nine" };
        StringBuilder sb = new StringBuilder();
        var sentence_words = sentence.Split(' ').ToList();
        for (int i = 0; i < words.Length; i++)
        {
            sentence_words.ForEach(w =>
            {
                if (w == words[i])
                {
                    w = words[i];
                }
            }
            );
        }
        return string.Join(" ", sentence_words);
    }
    public static string ReplaceDigits_REGEX(string sentence)
    {
        string[] words = { "zero", "one", "two", "three", "four", "five", "six", " seven", "eight", "nine" };
        var sentence_words = sentence.Split(' ');
        foreach (var word in sentence_words)
        {
            //word
        }
        var numbers = Regex.Split(sentence, @"* ");
        //for (int i = 0; i < words.Length; i++)
        //{
        //    for (int j = 0; j < numbers.Count; j++)
        //    {
        //        sentence.Replace(numbers[j], words[i]);
        //    }
        //}
        return numbers.ToString(); 
        //return string.Join(" ", sentence_words);
    }
}

