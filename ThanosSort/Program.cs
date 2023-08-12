using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThanosSort
{
    internal class Program
    {
        static string[] thanosQuotes = {
            "You Should Have Gone For The Head.", "I Am Inevitable.", "'What Did It Cost?' 'Everything.'",
            "I'm A Survivor.", "I Ignored My Destiny Once, I Can Not Do That Again. Even For You. I’m Sorry, Little One.",
            "You Could Not Live With Your Own Failure, And Where Did That Bring You? Back To Me.",
            "Perfectly Balanced, As All Things Should Be.", "Fine. I'll Do It Myself.", "Reality Is Often Disappointing. Now, Reality Can Be Whatever I Want.",
            "The Hardest Choices Require The Strongest Wills.",
            "A small price to pay for salvation.", "All that for a drop of blood."
        };
        static void Main(string[] args)
        {
            Random random = new Random();
            int maxArrSize = random.Next(10, 30);
            int[] array = new int[maxArrSize];
            for (int i = 0; i < maxArrSize; i++)
            {
                array[i] = random.Next(100);
            }
            Console.WriteLine("Unsorted array");
            DisplayArray(array);

            Console.WriteLine(thanosQuotes[random.Next(thanosQuotes.Length)]);
            int[] sortedArray = ThanosSort(array);

            Console.WriteLine("Sorted array");
            DisplayArray(sortedArray);

            Console.ReadLine();
        }
        /// <summary><c>ThanosSort</c> is an efficient sorting algorithm, however it might loose some data.
        /// <para>
        /// Recursive sorting method that checks if the inputted array is sorted.
        /// If its not, half of the array is removed and
        /// again checked if the array is sorted.
        /// </para>
        /// Thus the cycle continues.
        /// </summary>
        /// <param name="array">An array of unsorted integers</param>
        /// <returns>An array of sorted integers</returns>
        static int[] ThanosSort(int[] array)
        {
            bool sorted = true;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] >= array[i + 1])
                {
                    sorted = false;
                    break;
                }
            }
            if (!sorted)
            {
                array = Snap(array);
                return ThanosSort(array);
            }
            return array;
        }
        /// <summary>
        /// Thanos snaps his fingers and deletes half of the array at random.
        /// </summary>
        /// <param name="array">Array to be 'modified'</param>
        /// <returns>Half of the inputted array</returns>
        static int[] Snap(int[] array)
        {
            Console.WriteLine();
            Console.WriteLine("Snap!");
            Random rnd = new Random();
            int[] removedIndices = new int[array.Length / 2];
            //casting array to a list
            var arrayList = new List<int>(array);

            //loop count is half the original arrays lenght
            for (int i = 0; i < array.Length / 2; i++)
            {
                //removes a random element by index
                int indexToRemove = rnd.Next(arrayList.Count - 1);
                removedIndices[i] = indexToRemove;
                arrayList.RemoveAt(indexToRemove);
            }
            DisplayArray(array, removedIndices);
            Console.WriteLine("v");
            DisplayArray(arrayList.ToArray());
            return arrayList.ToArray();
        }
        /// <summary>
        /// Writes out an array to the console on one line.
        /// <example>
        /// Example:
        /// <code>
        /// int[] arr = { 1, 2, 3 };
        /// DisplayArray(arr);
        /// </code>
        /// Will write <c>1; 2; 3; </c> in the console.
        /// </example>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="separator"></param>
        static void DisplayArray(int[] array, int[] highLightedIndices, string separator = ";")
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (highLightedIndices.Contains(i))
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }

                Console.Write(array[i] + separator);
                Console.ResetColor();
                Console.Write(' ');
            }
            Console.WriteLine();
        }
        //overload method to create optional parameter for non-optional argument
        static void DisplayArray(int[] array, string separator = ";")
        {
            DisplayArray(array, new int[] { }, separator);
        }
    }
}
