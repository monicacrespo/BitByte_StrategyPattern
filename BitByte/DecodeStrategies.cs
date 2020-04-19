namespace BitByte
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IDecodeStrategy
    {
        string DecodeNumber(int num);
    }

    /// <summary>
    /// This class represents an strategy and decodes a number to an string with the following criteria:
    /// * the number
    /// * 'bit' for numbers that are multiples of 3
    /// * 'byte' for numbers that are multiples of 5
    /// * 'bitbyte' for numbers that are multiples of 15
    /// A number divisible by 3 and 5 is also divisible by 3 * 5
    /// A number that divides by both three and five should already cause both Bit and Byte to print one after the other
    /// </summary>
    public class LoopStrategy : IDecodeStrategy
    {
        public string DecodeNumber(int num)
        {
            string output = string.Empty;

            if (num.IsMultipleOf(HelperStrategy.BITBYTENUMBER))
            {
                output = HelperStrategy.BITBYTELETTERS;
            }
            else if (num.IsMultipleOf(HelperStrategy.BITNUMBER))
            {
                output = HelperStrategy.BITLETTERS;
            }
            else if (num.IsMultipleOf(HelperStrategy.BYTENUMBER))
            {
                output = HelperStrategy.BYTELETTERS;
            }
            else
            { 
                output = num.ToString();
            }

            return output;
        }
    }   

    public class StringStrategy : IDecodeStrategy
    {
        // Strategy using Strings
        // One of the special characteristics of a string is that it is immutable, so it cannot be changed after it has been created.
        // Every change to a string will create a new string
        // Because of the immutability of the string type, all string operations return a new string
        // Immutability is useful in many scenarios. It cannot be modified so it is inherently thread-safe.
        // It is more secure because no one can mess with it.Suddenly something like creating undo-redo is much easier,
        // your data structure is immutable and you maintain only snapshots of your state.
        // But immutable data structures also have a negative side.The following loop code looks innocent, 
        // but it will create a new string for each iteration in your loop.
        // It uses a lot of unnecessary memory and shows why you have to use caution when working with strings
        // string s = string.Empty;  
        // for (int i = 0; i< 10000; i++) { s += “x”; }
        // x   loop 1
        // x | x    loop 2
        // x | x | x    loop 3
        // x | x | x | x   loop 4  => Multiple copies of memory
        // This code will run 10,000 times, and each time it will create a new string. 
        // The reference s will point only to the last item, so all other strings are immediately ready for garbage collection.
        // Because C# is aware of this problem, the compiler tries to optimize working with strings for you. 
        // When creating two identical string literals in one compilation unit, the compiler ensures that only one string object is created by the CLR.
        // This is called string interning, which is done only at compile time.
        // Doing it at runtime would incur too much of a performance penalty (searching through all strings every time you create a new one is too costly).
        public string DecodeNumber(int num)
        {           
            string output = string.Empty;

            if (num.IsMultipleOf(HelperStrategy.BITNUMBER))
            {
                output = HelperStrategy.BITLETTERS;
            }

            if (num.IsMultipleOf(HelperStrategy.BYTENUMBER))
            {
                output += HelperStrategy.BYTELETTERS;
            }

            return string.IsNullOrEmpty(output) ? num.ToString() : output;
        }       
    }

    public class StringBuilderStrategy : IDecodeStrategy
    {
        // Strategy using StringBuilder and Delegate <int, bool>
        // The StringBuilder class can be used when you are working with strings in a tight loop.
        // Instead of creating a new string over and over again,  StringBuilder uses a string buffer internally to improve performance.
        // The StringBuilder class even enables you to change the value of individual characters inside a string
        // StringBuilder s = new StringBuilder();
        // for (int i = 0; i< 10000; i++) { s.Append(“x”); }
        // x | x | x | x   => Only one copy of memory created
        // One thing to keep in mind is that the StringBuilder does not always give better performance.
        // When concatenating a fixed series of strings, the compiler can optimize this and combine individual concatenation operations into a single operation.
        // When you are working with an arbitrary number of strings, such as in the loop example, a StringBuilder is a better choice
        public string DecodeNumber(int num)
        {          
            StringBuilder output = new StringBuilder();

            if (HelperStrategy.IsBit(num))
            {
                output.Append(HelperStrategy.BITLETTERS);
            }

            if (HelperStrategy.IsByte(num))
            {
                output.Append(HelperStrategy.BYTELETTERS);
            }

            if (string.IsNullOrEmpty(output.ToString()))
            {
                output.Append(num.ToString());
            }

            return output.ToString();
        }
    }

    // Strategy using Delegate <int, int, bool> and Two-Dimensional Array 
    // Two-Dimensional Array with two different data types in C# (dictionary vs class vs anonymous type vs tuple)
    // Depending on how your application will use this data, a struct (instead of a class) may also be a possible solution.
    // The struct is passed by value and is allocated on the stack, instead of the heap. This means it is not really garbage collected 
    // but deallocated when the stack unwinds or when their containing type gets deallocated.
    // When the order matters do not use a KeyValuePair unless order by first. Best to use anonymous type
    // This is important because it's called "BitByte", not "ByteBit". Ordering matters here. 
    // We're using an array to indicate that "Bit" must come before "Byte" in the situation were both are triggered.
    // If order was not important, we could have used a hash (a.k.a.dictionary,..)
    public class TwoDimensionalArrayStrategy : IDecodeStrategy
    {       
        public string DecodeNumber(int num)
        {
            // Arrays of anonymous type new { integer Number, string Name }
            var markers = new[]
            {
                new { Number = HelperStrategy.BITBYTENUMBER, Name = HelperStrategy.BITBYTELETTERS }, 
                new { Number = HelperStrategy.BITNUMBER, Name = HelperStrategy.BITLETTERS },
                new { Number = HelperStrategy.BYTENUMBER, Name = HelperStrategy.BYTELETTERS }
            };

            // var names = markers.Where(kv => num % kv.Key == 0).Select(kv => kv.Value);
            var names = markers.Where(kv => HelperStrategy.IsMatch2(num, kv.Number)).Select(kv => kv.Name);

            return names.Any() ? names.FirstOrDefault() : num.ToString();
        }
    }

    public class TwoDimensionalArrayAndConditionStrategy : IDecodeStrategy
    {
        // Strategy using Delegate <int, int, bool> and Two-Dimensional Array including the condition       
        public string DecodeNumber(int num)
        {
            var markers = new[]
            {
                new { Name = HelperStrategy.BITBYTELETTERS, Condition = HelperStrategy.IsBitByteMatch(num) },
                new { Name = HelperStrategy.BITLETTERS, Condition = HelperStrategy.IsBitMatch(num) },
                new { Name = HelperStrategy.BYTELETTERS, Condition = HelperStrategy.IsByteMatch(num) },
                new { Name = num.ToString(), Condition = HelperStrategy.IsDefaultMatch(num) }
            };

            var names = markers.Where(kv => kv.Condition).Select(kv => kv.Name);

            return names.FirstOrDefault();
        }
    }

    public class DictionaryStrategy : IDecodeStrategy
    {
        public string DecodeNumber(int num)
        {
            List<KeyValuePair<int, string>> markers = new Dictionary<int, string>
            {                
                { HelperStrategy.BYTENUMBER, HelperStrategy.BYTELETTERS },
                { HelperStrategy.BITNUMBER, HelperStrategy.BITLETTERS }
            }
            .OrderBy(kv => kv.Key).ToList();

            // var names = markers.Where(kv => num % kv.Key == 0).Select(kv => kv.Value);
            var names = markers.Where(kv => HelperStrategy.IsMatch2(num, kv.Key)).Select(kv => kv.Value);

            return names.Any() ? string.Join(string.Empty, names) : num.ToString();
        }
    }
}