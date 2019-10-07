using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        /* 
         * 
         * Self Reflection :  
         
            1. Learnt how to properly do array manipulation
            2. Developed understanding on working with lists and dictionaries
            3. Understood what is Big oh Notation, how it affects the complexity of an algorithm/Program and how to work arround it to come to an optimal coding solution
            4. Learnt the basics of string manipulation and problem solving skills, programatically
         
             */
        static void Main(string[] args)
        {

            int target = 1;
            int[] nums = { 1, 3, 5, 6 };
            Console.Write("----------Question 1 - Search Insert----------");
            Console.Write("\n");
            Console.WriteLine("Position to insert {0} is = {1}", target, SearchInsert(nums, target));
            Console.Write("\n");

            Console.Write("\n");
            int[] arr2_1 = new int[] { 6, 3, 6, 7, 3, 5, 5, 4, 5, 5 };

            int[] arr2_2 = { 3, 6, 2, 5, 5, 5, 5 };
            Console.Write("----------Question 2 - Common Elements----------");
            Console.Write("\n");
            int[] result = Intersect(arr2_1, arr2_2);
            for (int i = 0; i < result.Length; i++)
                Console.Write(result[i] + " ");
            Console.Write("\n");

            Console.Write("\n");
            int[] arr3 = new int[] { 5, 1, 5, 8, 9, 6, 6, 8, 9, -1, -5 };
            Console.Write("----------Question 3 - Largest Unique Number----------");
            Console.Write("\n");
            int LargestNumber = LargestUniqueNumber(arr3);
            Console.Write(LargestNumber);
            Console.Write("\n");

            string keyboard = "abcdefghijklmnopqrstuvwxyz";
            string word = "cba";
            Console.Write("\n");
            Console.Write("----------Question 4 - Special Keyboard----------");
            Console.Write("\n");
            Console.WriteLine("Time taken to type with one finger = {0}\n", CalculateTime(keyboard, word));
            Console.Write("\n");


            int[,] A = {            {1,1,0,0},
                                    {1,0,0,1},
                                    {0,1,1,1},
                                    {1,0,1,0}
                                                      };



            int[,] res;

            Console.Write("----------Question 5 - Flipped and Inverted Matrix---------");
            Console.Write("\n");
            int rows = A.GetLength(0);
            int cols = A.GetLength(1);
            

            for (int i = 0; i <= rows - 1; i++)
            {
                for (int j = 0; j <= cols - 1; j++)
                {
                    Console.Write("{0} ", A[i, j]);
                }
                Console.WriteLine("");
            }

            res = FlipAndInvertImage(A);

            Console.WriteLine("Display Matrix (after flipping and Inverting ) :");
            int rows2 = res.GetLength(0);
            int cols2 = res.GetLength(1);
            

            for (int i = 0; i <= rows - 1; i++)
            {
                for (int j = 0; j <= cols - 1; j++)
                {
                    Console.Write("{0} ", res[i, j]);
                }
                Console.WriteLine("");
            }
            Console.Write("\n");

            int[,] intervals = { { 0, 30 }, { 5, 10 }, { 15, 20 } };
            int minMeetingRooms = MinMeetingRooms(intervals);
            Console.Write("----------Question 6 - Minimum Meeting Rooms----------");
            Console.Write("\n");
            Console.WriteLine("Minimum meeting rooms needed = {0}\n", minMeetingRooms);
            Console.Write("\n");


            Console.Write("\n");
            int[] arr7 = new int[] { -7, -3, 2, 3, 11 };
            Console.Write("----------Question 7 - Square of an Array----------");
            Console.Write("\n");
            SortedSquares(arr7);
            Console.Write("\n");

            string s = "abraarba";
            Console.Write("\n");
            Console.Write("----------Question 8 - Palindrome----------");
            Console.Write("\n");
            if (ValidPalindrome(s))
            {
                Console.WriteLine("The given string \"{0}\" can be made PALINDROME", s, "");
            }
            else
            {
                Console.WriteLine("The given string \"{0}\" CANNOT be made PALINDROME", s, "");
            }
        }




        //Method for question 1
        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int first = 0;
                int last = nums.Length;
                int index = 0;

                index = Array.IndexOf(nums, target);
                //If target value is present in the array, then return it's index and exit the method
                if (index >= 0)
                {
                    return index;
                }
                //if target value is not present in the array, find its position to insert the value
                else if (index < 0)
                {
                    //binary search to find the position of the target value
                    while (((last - first) / 2) > 0) //loop until we have exhausted the array
                    {
                        int mid = first + (last - first) / 2; //calculate the mid value.
                        if (nums[mid] < target)
                            first = mid + 1;
                        else
                            last = mid;
                    }
                    return nums[first] >= target ? first : last;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured while computing SearchInsert()" + e);
            }

            return 0;
        }


        // Method for question 2
        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            List<int> result = new List<int>();  //Creating a new list to hold the result of intersection
            Dictionary<int, int> myDict = new Dictionary<int, int>();  // Creating an integer type data dictionary
            foreach (int count in nums1)     //Iterating through each value of the first array
            {
                try
                {
                    myDict.Add(count, 1);   // Here we add the elements into the dictionary variable created
                }
                catch
                {
                    myDict[count]++;    
                }
            }

            foreach (int count in nums2)   //Iterating through each element of the second array
            {
                if (myDict.ContainsKey(count) && myDict[count] > 0)  // Simultaneously checking if thekey element from the first array is present in the second array and if the data dictionary contains an element
                {
                    myDict[count]--;             //If yes add the element in the result list        
                    result.Add(count);
                }
            }

            return result.ToArray();             // Convert the list to array and return it to the method
        }




        // Method for question 3
        public static int LargestUniqueNumber(int[] A)
        {
            Array.Sort(A);                               // First we sort the array in increasing order
            Array.Reverse(A);                            // Here we reverse the sorted array to get the array elements in Decending order
            int length = A.Length;
            int i;

            for (i = 0; i < length; i++)                 // We run a loop to check if our array has any repeated adjecent elements
            {

                if (Array.IndexOf(A, A[i]) < length - 1)
                {
                    if (A[i] == A[i + 1])                // If found we continue to traverse the loop
                    {
                        i = i + 1;
                    }
                    else if (A[i] != A[i + 1])           // If we don't find the consecutive elements similar we return the current element as the highest value, since our array is already sorted in descending order the value returned here will be the unique and largest element in the array
                    {
                        return A[i];
                    }
                }
                else                                     // Here we return our last element as it will be the largest unique element
                {
                    return A[i];
                }

            }
            return -1;                                   // If there isn't any unique element then we return -1
        }


        // Method for question 7
        public static int[] SortedSquares(int[] A)
        {

            int length = A.Length; // Finding the length of array
            int i;
            for (i = 0; i < length; i++) // Traversing through each element of the Array
            {
                A[i] = A[i] * A[i]; // Finding the square of each element of the array and assigning the values to the original array
            }
            Array.Sort(A); // After finding the square of each element of the array, sort the array in the ascending order
            for (i = 0; i < length; i++)
            {
                Console.Write(" " + A[i]); // Writes the squared array on the console
            }

            return A; // Return the array to the method

        }

        // Method for question 8
        public static bool ValidPalindrome(string s)
        {
            try
            {
                for (int c = 0; c < s.Length; c++)
                {
                    if (IsPalindrome(s.Remove(c, 1)))
                    {
                        // If so, return true. that is, it is a palindrome (or modified palindrome)
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured while computing ValidPalindrome(): " + e);
            }

            return false;
        }

        public static bool IsPalindrome(string str)
        {
            int min = 0;
            int max = str.Length - 1;
            while (true) //loop until it's false
            {
                if (min > max) //if we have reached the middle (or beyond middle) of the string, its a palindrome, and return true.
                {
                    return true;
                }
                char a = str[min]; //traversing forward, left to right in the string
                char b = str[max]; //traversing backwards, right to left, in the string
                if (a != b) // the exact character from either side should have the same value to qualify as palindrome
                {
                    return false; //if the values don't match, it's not a palindrome.
                }
                min++;
                max--;
            }
        }

        // Method for question 6

        public static int MinMeetingRooms(int[,] intervals)
        {
            try
            {
                //Sort the 2D array in ascending order, only by the first value of each row.
                for (int i = 0; i < intervals.GetLength(0) - 1; i++)
                {
                    for (int j = intervals.GetLength(1) - 1; j > 0; j--)
                    {
                        for (int k = 0; k < j; k++)
                        {
                            if (intervals[i, k] > intervals[i + 1, k])
                            {
                                //swap the first item of the pair
                                int myTemp1 = intervals[i, k];
                                intervals[i, k] = intervals[i + 1, k];
                                intervals[i + 1, k] = myTemp1;

                                //swap the second item of the pair
                                int myTemp2 = intervals[i, k + 1];
                                intervals[i, k + 1] = intervals[i + 1, k + 1];
                                intervals[i + 1, k + 1] = myTemp2;
                            }
                        }
                    }
                }
                //our meeting lists are now sorted in assending order
                //Count the meeting rooms required
                int meetingRooms = 1; //because we will need atleast 1 room for the meetings
                for (int i = 0; i < intervals.GetLength(0) - 1; i++) //for each row in the meetings list
                {
                    for (int j = intervals.GetLength(1) - 1; j > 0; j--) //for each column in the meeting list
                    {
                        for (int k = 0; k < j; k++)
                        {
                            if (intervals[i, k] < intervals[i + 1, k]) //if start time of meeting2 is after meeting1
                            {
                                if ((intervals[i, k + 1] > intervals[i + 1, k + 1])) //and if endtime if meeting2 is before meeting1
                                {
                                    meetingRooms += 1; //we will need one more meeting room due to timing overlap.
                                }

                            }
                        }
                    }
                }
                return meetingRooms;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured while computing MinMeetingRooms()" + ex.ToString());
            }

            return 0;
        }

        // Method for question 5
        public static int[,] FlipAndInvertImage(int[,] A)
        {
            Console.WriteLine("Flip Matrix Horizontally..");
            int rows = A.GetLength(0);
            int cols = A.GetLength(1);
            // Here we flip the matrix value horizontally by taking a temporary array and copying the value extracted into it
            for (int i = 0; i <= rows - 1; i++)
            {
                int j = 0;
                int k = cols - 1;
                while (j < k)
                {
                    int temp = A[i, j];
                    A[i, j] = A[i, k];
                    A[i, k] = temp;
                    j++;
                    k--;
                }
            }
            // Here we run a loop to invert the values in the matrix i.e 0 to1 AND vice versa
            for (int i = 0; i <= rows - 1; i++)
            {
                for (int j = 0; j <= cols - 1; j++)
                {

                    if (A[i, j] == 0)
                    {
                        A[i, j] = 1;

                    }

                    else if (A[i, j] == 1)
                        A[i, j] = 0;

                }

            }

            return A;         //The flipped and inverted matrix is returned



        }
        // Method for question 4


        public static int CalculateTime(string keyboard, string word)
        {
            try
            {
                int time = 0;
                int prevIndex = 0;
                foreach (char c in word) //for each character in the word
                {
                    // calculate the distance between the prev and current index, and add it to the running total called time.
                    time += Math.Abs(prevIndex - keyboard.IndexOf(c));
                    prevIndex = keyboard.IndexOf(c); //save the prev index value
                }
                return time; //return the time taken to traverse the keyboard
            }
            catch
            {
                Console.WriteLine("Exception occured while computing CalculateTime()");
            }

            return 0;
        }

    }
}