using System;
using System.Collections.Generic;

namespace Assignment_2_Variables_Changed
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] arr1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingValues = FindMissingNumbers(arr1);
            Console.WriteLine(string.Join(",", missingValues));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] arr2 = { 3, 1, 2, 4 };
            int[] paritySortedArray = SortArrayByParity(arr2);
            Console.WriteLine(string.Join(",", paritySortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] arr3 = { 2, 7, 11, 15 };
            int targetSum = 9;
            int[] resultIndices = TwoSum(arr3, targetSum);
            Console.WriteLine(string.Join(",", resultIndices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] arr4 = { 1, 2, 3, 4 };
            int maxProd = MaximumProduct(arr4);
            Console.WriteLine(maxProd);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNum = 42;
            string binaryString = DecimalToBinary(decimalNum);
            Console.WriteLine(binaryString);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] arr5 = { 3, 4, 5, 1, 2 };
            int minimumValue = FindMin(arr5);
            Console.WriteLine(minimumValue);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNum = 121;
            bool isPalindrome = IsPalindrome(palindromeNum);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int fibonacciInput = 4;
            int fibonacciResult = Fibonacci(fibonacciInput);
            Console.WriteLine(fibonacciResult);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            int length = nums.Length;
            List<int> missingNumbersList = new List<int>();

            for (int i = 0; i < length; i++)
            {
                int value = Math.Abs(nums[i]) - 1;
                if (nums[value] > 0)
                {
                    nums[value] = -nums[value];
                }
            }

            for (int i = 0; i < length; i++)
            {
                if (nums[i] > 0)
                {
                    missingNumbersList.Add(i + 1);
                }
            }

            return missingNumbersList;
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            int leftPointer = 0, rightPointer = nums.Length - 1;
            while (leftPointer < rightPointer)
            {
                if (nums[leftPointer] % 2 > nums[rightPointer] % 2)
                {
                    int temp = nums[leftPointer];
                    nums[leftPointer] = nums[rightPointer];
                    nums[rightPointer] = temp;
                }

                if (nums[leftPointer] % 2 == 0) leftPointer++;
                if (nums[rightPointer] % 2 == 1) rightPointer--;
            }
            return nums;
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> lookup = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int diff = target - nums[i];
                if (lookup.ContainsKey(diff))
                {
                    return new int[] { lookup[diff], i };
                }
                lookup[nums[i]] = i;
            }
            throw new ArgumentException("No two sum solution found.");
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            Array.Sort(nums);
            int len = nums.Length;
            return Math.Max(nums[0] * nums[1] * nums[len - 1], nums[len - 3] * nums[len - 2] * nums[len - 1]);
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            return Convert.ToString(decimalNumber, 2);
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            while (left < right)
            {
                int middle = left + (right - left) / 2;
                if (nums[middle] > nums[right])
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }
            return nums[left];
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int num)
        {
            if (num < 0 || (num % 10 == 0 && num != 0)) return false;

            int reversedHalf = 0;
            while (num > reversedHalf)
            {
                reversedHalf = reversedHalf * 10 + num % 10;
                num /= 10;
            }

            return num == reversedHalf || num == reversedHalf / 10;
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            if (n <= 1) return n;
            int first = 0, second = 1;
            for (int i = 2; i <= n; i++)
            {
                int temp = first + second;
                first = second;
                second = temp;
            }
            return second;
        }
    }
}
