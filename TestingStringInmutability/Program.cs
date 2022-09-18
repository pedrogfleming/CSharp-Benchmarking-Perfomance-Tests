using System;
using System.Collections.Generic;

/*
 * - Strings are represented by the String class in the NET Framework.
 * The class has a bunch of static- and instance methods to query and modify the string data.
- Strings are immutable - when you try to modify a string, the NET Framework actually creates a new string on the heap and leaves the original string unmodified.
This speeds up string comparisons but slows down modifications.
- If you make a lot of modifications to a string,
you should use the StringBuilder class instead.
The NET runtime stores string data in a block of memory on the heap.
Each Unicode character in the string is stored as a 16-bit word.
Strings use UTF-16 character encoding to represent Unicode characters above U+FFFF.
So here's an interesting question -
is it possible in C# to directly modify the contents of a string,
without going through the methods of the String class?
It must be possible, because this is what the StringBuilder class is doing internally.
But if this is possible,
then how does it affect string immutability?
Is the framework really going to allocate an entirely new string on the heap as soon as I try to modify a single character?
How would that even work?
 * 
 * 
 * */
public class Program
{
    // declare a const string - can we modify it? 
    

    static void Main(string[] args)
    {
        const string sentence = "The quick brown fox jumped over the lazy dog";
        //First, let's try to modify the contents of sentence  directly.
        //To do this, I mark the entire method as unsafe
        //and then use the fixed  keyword to obtain a pointer to the memory location where the string is stored.
        //I store that pointer in  pSentence :
        unsafe
        {
            fixed (char* pSentence = sentence)
            {
                // report initial state
                Console.WriteLine($"The original sentence is: {sentence}");
                Console.WriteLine($"The address of the sentence is: {(IntPtr)pSentence}");
                // modify the string...
                char* p = pSentence;
                for (var i = 0; i < sentence.Length; i++)
                {
                    *p = '*';
                    p++;
                }
                // report final state
                Console.WriteLine($"The final sentence is: {sentence}");
                Console.WriteLine($"The address of the sentence is: {(IntPtr)pSentence}");

                /*
                 * – You can directly modify string constants in C#, by using unsafe pointer operations.
                – This modifies the string in-situ, which breaks string immutability.
                String immutability is actually implemented in code, in every method that modifies a string.
                Calling Substring  or Replace  or Remove  simply creates a new modified string and leaves the original string unchanged.
                There’s no compiler or runtime magic going on to make strings immutable.
                It’s all manually implemented in the framework classes.
                And here’s another aha moment for you:
                the StringBuilder  class is nothing more than a wrapper for a bunch of unsafe pointer operations that modify the string directly in memory.
                By using the StringBuilder you get the benefit of being able to modify strings directly, without having to mark your code as unsafe.
                So both classes wrap a block of memory containing character data.
                The String  class enforces immutability, which allows you to very quickly compare strings and basically treats them as a value type.
                The StringBuilder  class uses pointers to directly modify the character data.
                This breaks immutability but lets you very quickly modify strings without flooding the heap with copies.
                 * 
                 */
            }
        }
    }
}