using System;
using System.Text;

namespace Day03
{
    internal class Program
    {
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        static void Main(string[] args)
        {
            #region problem1
            Console.Write("Please enter a number: ");
            string s = Console.ReadLine(); 

            try
            {
                
                int parsedValue = int.Parse(s);
                Console.WriteLine("Converted using int.Parse: " + parsedValue);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: The input is not a valid number for int.Parse.");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Error: The input is empty for int.Parse.");
            }

            try
            {
                
                int convertedValue = Convert.ToInt32(s);
                Console.WriteLine("Converted using Convert.ToInt32: " + convertedValue);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: The input is not a valid number for Convert.ToInt32.");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Error: The input is empty for Convert.ToInt32.");
            }

            
            Console.WriteLine("Program execution completed.");
            #endregion
            /*
             * Difference Between int.Parse and Convert.ToInt32 When Handling null?
               >> int.Parse: Cannot handle null and will throw an ArgumentNullException if the input is null. It expects a valid numeric string.

               >> Convert.ToInt32: Can handle null without throwing an exception. If the input is null, it returns 0 instead of an error.
             
             */

            #region problem2
            Console.Write("Please enter a number: ");
            string input = Console.ReadLine();
            Console.WriteLine("Problem 2");
            Console.WriteLine("----------------------------------");
            if (int.TryParse(input, out int result))
            {

                Console.WriteLine($"You entered a valid number: {result}");
            }
            else
            {

                Console.WriteLine("ERROR: Invalid input! ");

                Console.WriteLine("----------------------------------");
            }
            #endregion
            /*
              Why is TryParse Recommended Over Parse in User-Facing Applications?
                No Exceptions:
                TryParse is safer in user-facing applications because it does not throw exceptions.

                When you use int.Parse, an invalid input (such as a non-numeric string) results in a FormatException being thrown,
                which you need to handle with a try-catch block.

                This adds complexity and can make the application less responsive if errors are frequent.
                TryParse, on the other hand,simply returns false if the input is invalid,
                allowing you to handle the error without the overhead of exception handling.
            */

            #region problem3
            object obj;

            obj = 42;
            Console.WriteLine("Problem 3");
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"HashCode of int (42): {obj.GetHashCode()}");

            obj = "Hello, world!";
            Console.WriteLine($"HashCode of string ('Hello, world!'): {obj.GetHashCode()}");

            obj = 3.14159;
            Console.WriteLine($"HashCode of double (3.14159): {obj.GetHashCode()}");

            Console.WriteLine("----------------------------------");
            #endregion
            /*
            What is the Purpose of the GetHashCode() Method?
            The GetHashCode() method is a part of the base System.

            Object class, and it provides a hash value (an int) that is used for hashing-based operations.
            The primary purpose of GetHashCode() is as follows:
               Efficient Lookups in Hash-Based Collections,Object Comparison,Consistency and Uniqueness
           */

            #region problem4
            Person person1 = new Person();
            person1.Name = "Khalid";
            person1.Age = 21;

            Person person2 = person1;


            person1.Name = "Abowarda";
            person1.Age = 23;

            Console.WriteLine("Problem 4");
            Console.WriteLine("----------------------------------");

            Console.WriteLine($"Person2's Name: {person2.Name}, Age: {person2.Age}");

            Console.WriteLine($"Person1's Name: {person1.Name}, Age: {person1.Age}");

            Console.WriteLine("----------------------------------");

            /*
           ignificance of Reference Equality in .NET:
           In .NET, reference equality refers to the situation where two variables (references) point to the same memory location,
           they refer to the same object instance.
           The significance of reference equality includes the following:

           Shared Mutability,
           Memory Efficiency,
           Performance Considerations,
           Equality Comparison
           */
            #endregion

            #region problem5
            string message = "Hello";

            Console.WriteLine("Problem 5");
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Original message: {message}");
            Console.WriteLine($"GetHashCode before modification: {message.GetHashCode()}");

            // Concatenation creates a new string
            message = $"{message} {"Khalid"};



            Console.WriteLine($"Modified message: {message}");
            Console.WriteLine($"GetHashCode after modification: {message.GetHashCode()}");

            Console.WriteLine("----------------------------------");
            /*
              Why Is String Immutable in C#?
                Performance Benefits: Immutable strings help to conserve memory.
                Since strings are immutable, multiple references can point to the same string object 
                without risk of unintended modifications.
                This reduces the need to create multiple copies of the same string.
                Interning: C# uses string interning,
                which means that identical string literals are stored only once in memory. 
            */
            #endregion

            #region problem6
            StringBuilder sb = new StringBuilder("Hi Khalid");

            Console.WriteLine("Problem 6");
            Console.WriteLine("----------------------------------");

            Console.WriteLine($"Original StringBuilder: {sb.ToString()}");
            Console.WriteLine($"GetHashCode before modification: {sb.GetHashCode()}");

            // Append text
            sb.Append(" - Welcome to the C# World khalid !");

            // Print the GetHashCode after modification
            Console.WriteLine($"Modified StringBuilder: {sb.ToString()}");
            Console.WriteLine($"GetHashCode after modification: {sb.GetHashCode()}");

            Console.WriteLine("----------------------------------");

            /*
             * How StringBuilder Addresses Inefficiencies of String Concatenation:
                In C#, strings are immutable.This means that each time you modify a string,a new string is created, and the old string is discarded.
                This process can lead to significant inefficiencies when performing multiple concatenations,especially in loops or when dealing with large strings.
                Each concatenation involves allocating new memory, copying data from the old string,and then adding the new content. This can cause performance problems,
                particularly with large or numerous string modifications.
            */
            #endregion

            /*
             *  Question: Why is StringBuilder faster for large-scale string modifications?
             In C#, strings are immutable, meaning they cannot be changed once created. Any modification, such as concatenation or replacement, creates a new string object.

             This process involves:

                Allocating new memory for the modified string.
                Copying the original string.
                Appending new content, leading to performance overhead in repeated modifications.
                StringBuilder is much faster for large-scale modifications because:

                It works with the same memory space without creating new objects.
                Reduces memory allocation and copying overhead.

            */

            #region problem7

            Console.Write("Please Enter the first number: ");
            int input1 = int.Parse(Console.ReadLine());

            Console.Write("Please Enter the second number: ");
            int input2 = int.Parse(Console.ReadLine());

            int sum = input1 + input2;
            Console.WriteLine("Problem 7");
            Console.WriteLine("----------------------------------");
            // 1: Concatenation
            Console.WriteLine("Concatenation: Sum is " + input1 + " + " + input2 + " = " + sum);

            // 2: Composite formatting (string.Format)
            Console.WriteLine("Composite formatting: Sum is {0} + {1} = {2}", input1, input2, sum);

            // 3: String interpolation ($)
            Console.WriteLine($"String interpolation: Sum is {input1} + {input2} = {sum}");

            Console.WriteLine("----------------------------------");
            /*
              Which String Formatting Method is Most Used and Why?
                In modern C#,string interpolation ($) is generally considered the most preferred and commonly used string formatting method. Here's why:
                
                Clarity and Readability:
                String Interpolation is the most readable and straightforward method.
                It directly integrates expressions inside the string,
                making the code more intuitive to read and maintain.
                For example:
                Console.WriteLine($"Sum is {input1} + {input2} = {sum}");
                This is clear because you can directly see the expression inside the {} within the string.
            */
            #endregion

            #region problem8
            StringBuilder Sb = new StringBuilder("Hello World");

            Console.WriteLine("Problem 8");
            Console.WriteLine("----------------------------------");

            Sb.Append(" Welcome to .Net !");
            Console.WriteLine($"After Append: {Sb}");


            Sb.Replace("World", "Universe");
            Console.WriteLine($"After Replace: {Sb}");


            Sb.Insert(6, "Amazing ");
            Console.WriteLine($"After Insert: {Sb}");


            Sb.Remove(5, 7);
            Console.WriteLine($"After Remove: {Sb}");

            Console.WriteLine("Problem 8");
            Console.WriteLine("----------------------------------");
            /*
             How StringBuilder Handles Frequent Modifications:
                Internal Buffer:

                StringBuilder uses an internal buffer
                (a dynamically resizable array) to hold the string data.
                Instead of creating new string objects each time it is modified (like in the case of immutable strings),
                StringBuilder modifies the contents of its buffer.
                This reduces memory usage and eliminates the overhead of allocating and copying data each time a modification is made.
            */

            #endregion
        }
    }
}
