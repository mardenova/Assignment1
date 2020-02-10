using System;
using System.Collections.Generic;

namespace Assignment1_Spring2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Question 1:");
            int n = 5;
            PrintPattern(n);

            Console.WriteLine("Question 2:");

            int n2 = 6;
            PrintSeries(n2);

            Console.WriteLine();
            Console.WriteLine("Question 3:");

            string s = "09:15:35PM";
            string t = UsfTime(s);
            Console.WriteLine(t);

            Console.WriteLine("Question 4:");

            int n3 = 110;
            int k = 11;
            UsfNumbers(n3, k);

            Console.WriteLine();
            Console.WriteLine("Question 5:");

            string[] words = new string[] { "abcd", "dcba", "lls", "s", "sssll" };
            PalindromePairs(words);

            Console.WriteLine();
            Console.WriteLine("Question 6:");

            int n4 = 5;
            Stones(n4);
        }


        private static void PrintPattern(int n)
        {
            try
            {
                // If input value is negative or equal to 0:
                if (n <= 0)
                {
                    // Write N/A
                    Console.WriteLine("N/A");
                }
                else
                {
                    // Loop through all n natural numbers in descending order
                    for (int i = n; i >= 1; i--)
                    {
                        // Print each n natural number in the loop
                        Console.Write(i);
                    }
                    // Check if n is greater or equal to 1
                    if (n > 1)
                    {
                        // Write new empty line
                        Console.WriteLine();
                        // Call the same function again and pass new value less than previous value by 1
                        PrintPattern(n - 1);
                    }
                    else
                    {
                        // Write new empty line
                        Console.WriteLine();
                        // When value reaches 1, print N/A
                        Console.WriteLine("N/A");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception Occurred while computing printPattern");
            }
        }

        private static void PrintSeries(int n2)
        {
            try
            {
                // If input value is less than or equal to 0:
                if(n2 <=0 )
                {
                    // Write N/A
                    Console.WriteLine("N/A");
                }
                // If input value is greater than 0
                else
                {
                    // Set new variable to hold sum of n natural numbers
                    int sum = 0;
                    // Loop through all natural numbers until input value of natural numbers is reached
                    for (int i = 1; i <= n2; i++)
                    {
                        // Add each number to a variable sum
                        sum = sum + i;
                        // Write sum variable at each step. Added space to a more clean look
                        Console.Write(sum + " ");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception Occurred while computing printSeries");
            }
        }


        public static string UsfTime(string s)
        {
            try
            {
                // Check if input value does NOT follow the formatting
                if (System.Text.RegularExpressions.Regex.IsMatch(s, "[0 - 1][0 - 9]:[0 - 5][0 - 9]:[0-5] [0-9] [paPA] [Mm]"))
                {
                    // If yes, then write N/A
                    Console.WriteLine("N/A");
                }
                // If it DOES, then:
                else
                {
                    // Create new variables to use throughout the method
                    int hours = 0;
                    int hSec = 0;
                    int minutes = 0;
                    int mSec = 0;
                    int seconds = 0;
                    int totalSec = 0;
                    int usfH = 0;
                    int usfM = 0;
                    int usfS = 0;
                    int modulo = 0;
                    string time = "";
                    string secTime = "";
                    string result = "";
                    int i = s.IndexOf(":");
                    int f = s.LastIndexOf(":");
                    // Take hours value from the input string
                    hours = Convert.ToInt32(s.Substring(0, i));
                    // Take seconds and AM or PM value from the input string
                    time = s.Substring(f + 1);
                    secTime = time.Substring(0, time.Length / 2);
                    time = time.Substring(time.Length / 2);
                    // If input string contains PM value, then add 12 to hours value
                    if (time == "PM")
                    {
                        hours = hours + 12;
                    }
                    // Calculate equivalent seconds value to hours value
                    hSec = hours * 60 * 60;
                    // Take minutes from the input string
                    minutes = Convert.ToInt32(s.Substring(i + 1, f - 3));
                    // Calculate equivalent seconds value to minutes value
                    mSec = minutes * 60;
                    // Convert seconds value from the input string
                    seconds = Convert.ToInt32(secTime);
                    // Sum up all values in seconds
                    totalSec = hSec + mSec + seconds;
                    // Find USF hours value from the total amount of seconds in Earth time
                    usfH = Convert.ToInt32(Math.Floor(Convert.ToDecimal(totalSec) / (60 * 45)));
                    // Take what is left to calculate USF minutes and seconds
                    modulo = totalSec % (usfH * 60 * 45);
                    // Find USF minutes value
                    usfM = Convert.ToInt32(Math.Floor(Convert.ToDecimal(modulo) / 45));
                    // Find USF seconds value
                    usfS = modulo - (usfM * 45);
                    // Combine the result value to follow specific format
                    result = Convert.ToString(usfH) + ":" + Convert.ToString(usfM) + ":" + Convert.ToString(usfS);
                    // Output the result string value
                    return result;
                }
            }
            catch
            {
                Console.WriteLine("Exception Occurred while computing UsfTime");
            }
            return null;
        }

        public static void UsfNumbers(int n3, int k)
        {
            try
            {
                // New string array to hold all values
                string[] numArray = new string[n3];
                // Loop to populate numArray
                for (int m = 1; m <= n3; m++)
                {
                    if (m % 3 == 0)
                    {
                        if (m % 5 == 0)
                        {
                            if (m % 7 == 0)
                            {
                                // If value is a multiple of 3, 5 and 7 change it to USF
                                numArray[m - 1] = "USF";
                            }
                            else
                            {
                                // If value is a multiple of 3 and 5 change it to US
                                numArray[m - 1] = "US";
                            }
                        }
                        else
                        {
                            // If value is a multiple of 3 change it to U
                            numArray[m - 1] = "U";
                        }
                    }
                    else
                    {
                        if (m % 5 == 0)
                        {
                            if (m % 7 == 0)
                            {
                                // If value is a multiple of 5 and 7 change it to SF
                                numArray[m - 1] = "SF";
                            }
                            else
                            {
                                // If value is a multiple of 5 change it to S
                                numArray[m - 1] = "S";
                            }
                        }
                        else
                        {
                            if (m % 7 == 0)
                            {
                                if (m % 3 == 0)
                                {
                                    // If value is a multiple of 3 and 7 change it to UF
                                    numArray[m - 1] = "UF";
                                }
                                else
                                {
                                    // If value is a multiple of 7 change it to F
                                    numArray[m - 1] = "F";
                                }
                            }
                            else
                            {
                                // If value is not multiple of 3, 5 or 7 then populate with a count number
                                numArray[m - 1] = Convert.ToString(m);
                            }
                        }
                    }
                }
                // Loop to go through all values in array
                for (int f = 0; f < n3; f++)
                {
                    if (f % k == 0)
                    {
                        // If a value is in position equal to k then write new line
                        Console.WriteLine();
                    }
                    // Write a value in an array
                    Console.Write(numArray[f] + " ");
                }
            }
            catch
            {
                Console.WriteLine("Exception Occurred while computing UsfNumbers()");
            }
        }

        public static void PalindromePairs(string[] words)
        {
            try
            {
                // Create new list to hold the output
                List<string> indexList = new List<string>();
                // Loop through all values in input array
                for (int i = 0; i < words.Length; i++)
                {
                    // Loop through all values in input array
                    for (int k = 0; k < words.Length; k++)
                    {
                        // If index in first loop is not equal to index in second loop, then check if method IsPalindrome returns true
                        if (i != k)
                        {
                            if (IsPalindrome(words, i, k))
                            {
                                // If method IsPalindrome returns true, then add new item to the list [index at first loop, index at second loop]
                                indexList.Add("[" + i + ", " + k + "]");
                            }
                        }
                    }
                }
                // Output each item in the list
                indexList.ForEach(Console.Write);
            }
            catch
            {

                Console.WriteLine("Exception Occurred while computing     PalindromePairs()");
            }
        }

        public static bool IsPalindrome(string[] words, int i, int k)
        {
            // Concatenate two items from array into str
            string str = words[i] + words[k];
            // If str has even amount of characters then:
            if (str.Length % 2 == 0)
            {
                // Calculate which index is the middle index
                int half = Convert.ToInt32(str.Length / 2);
                // Take first half of the string
                string firstHalf = str.Substring(0, half);
                // Take second half of the string
                string secondHalf = str.Substring(half);
                // Convert second half of the string into array of characters
                char[] charArray = secondHalf.ToCharArray();
                // Reverse the array
                Array.Reverse(charArray);
                // Save reversed array of characters back into second half of the string
                secondHalf = new string(charArray);
                // Compare two halves
                if (string.Compare(firstHalf, secondHalf, true) == 0)
                {
                    // If they are the same, then return true
                    return true;
                }
                else
                {
                    // If they are not equal, return false
                    return false;
                }
            }
            // Else, str has odd amount of characters
            else
            {
                // Calculate which index is the middle index
                int middle = Convert.ToInt32(Math.Floor(Convert.ToDecimal(str.Length) / 2));
                // Take first half of the string before the middle index
                string firstHalf = str.Substring(0, middle - 1);
                // Take second half of the string after the middle index
                string secondHalf = str.Substring(middle + 1);
                // Convert second half of the string into array of characters
                char[] charArray = secondHalf.ToCharArray();
                // Reverse the array
                Array.Reverse(charArray);
                // Save reversed array of characters back into second half of the string
                secondHalf = new string(charArray);
                // Compare two halves
                if (string.Compare(firstHalf, secondHalf, true) == 0)
                {
                    // If they are the same, then return true
                    return true;
                }
                else
                {
                    // If they are not equal, return false
                    return false;
                }
            }
        }

        public static void Stones(int n4)
        {
            try
            {
                // Check if input value is a multiple of 4 or if it less than 4:
                if (n4 % 4 == 0 || n4 < 4)
                {
                    // If yes, write N/A
                    Console.WriteLine("N/A");
                }
                else
                {
                    // If no call a recursive function to display all possible moves
                    CalculateMoves(n4);
                }
            }
            catch
            {
                Console.WriteLine("Exception Occurred while computing Stones()");
            }
        }

        public static void CalculateMoves(int n4)
        {
            // Create variables to hold move values and result "last" values
            int move = 1;
            int last;
            // If remainder of division n4 by 4 is 3, then assign 3 to move variable
            if (n4 % 4 == 3)
            {
                move = 3;
            }
            // If remainder of division n4 by 4 is 2, then assign 2 to move variable
            if (n4 % 4 == 2)
            {
                move = 2;
            }
            // If remainder of division n4 by 4 is 1, then assign 1 to move variable
            if (n4 % 4 == 1)
            {
                move = 1;
            }
            // Loop through all possible moves by opponent (1, 2 or 3)
            for (int i = 1; i <= 3; i++)
            {
                // Sum up your and opponent's moves
                last = move + i;
                // If amount of all remaining stones are greater than 4:
                if (n4 - last > 4)
                {
                    // If yes, call the same function again and pass remaining amount of stones
                    CalculateMoves(n4 - last);
                }
                else
                {
                    // If not, write all possible combination of moves
                    Console.WriteLine(move + ", " + i + ", " + (n4 - last));
                }
            }
        }
    }
}
