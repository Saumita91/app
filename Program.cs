using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static int SumEvenNumbers(List<int> numbers)
        {
            int sum = 0;
            foreach (int n in numbers)
            {
                if (n % 2 == 0)
                    sum += n;
            }

            return sum;
        }

        static long Factorial(int number)
        {
            if (number == 0 || number == 1)
                return 1;

            long result = 1;
            for (int i = 2; i <= number; i++)
                result *= i;
            return result;
        }

        static List<string> GetCapitalizedWords(List<string> words)
        {
            List<string> result = new List<string>();
            foreach (string word in words)
            {
                if (!string.IsNullOrEmpty(word) && char.IsUpper(word[0]))
                {
                    result.Add(word);
                }
            }
            return result;
        }

        static List<int> RemoveDuplicates(List<int> inputList)
        {
            List<int> result = new List<int>();

            foreach (int number in inputList)
            {
                if (!result.Contains(number))
                {
                    result.Add(number);
                }
            }

            return result;
        }

        static List<int> GetFibonacci(int count)
        {
            List<int> fib = new List<int>();
            if (count >= 1) fib.Add(0);
            if (count >= 2) fib.Add(1);

            for (int i = 2; i < count; i++)
                fib.Add(fib[i - 1] + fib[i - 2]);

            return fib;
        }

        static void PalindromeCheck()
        {
            Console.Write("Enter string or number: ");
            string input = Console.ReadLine();
            string reversed = new string(input.Reverse().ToArray());
            Console.WriteLine(input.Equals(reversed, StringComparison.OrdinalIgnoreCase)
                ? "Palindrome"
                : "Not a palindrome");
        }

        static void LargestSmallestInArray()
        {
            Console.Write("Enter numbers separated by spaces: ");
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int largest = arr[0], smallest = arr[0];
            foreach (int num in arr)
            {
                if (num > largest) largest = num;
                if (num < smallest) smallest = num;
            }

            Console.WriteLine($"Largest: {largest}, Smallest: {smallest}");
        }

        static void ExtractVowels()
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine().ToLower();
            string vowels = "aeiou";
            var found = input.Where(c => vowels.Contains(c)).ToArray();
            Console.WriteLine($"Vowels: {new string(found)}");
            Console.WriteLine($"Count: {found.Length}");
        }

        static void CountWords()
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine().Trim();
            int count = 0, i = 0;

            while (i < input.Length)
            {
                while (i < input.Length && input[i] == ' ') i++;
                if (i < input.Length) count++;
                while (i < input.Length && input[i] != ' ') i++;
            }

            Console.WriteLine($"Word count: {count}");
        }

        static void ReverseString()
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            Console.WriteLine($"Reversed: {new string(chars)}");
        }

        static void SumOfDigits()
        {
            Console.Write("Enter number: ");
            int num = int.Parse(Console.ReadLine());
            int sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }
            Console.WriteLine($"Sum of digits: {sum}");
        }

        static void PrimeCheck()
        {
            Console.Write("Enter number: ");
            int num = int.Parse(Console.ReadLine());
            if (num <= 1)
            {
                Console.WriteLine("Not a prime number");
                return;
            }
            bool isPrime = true;
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            Console.WriteLine(isPrime ? "Prime number" : "Not a prime number");
        }

        static void EvenOddCount()
        {
            Console.Write("Enter numbers separated by spaces: ");
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int evenCount = arr.Count(n => n % 2 == 0);
            int oddCount = arr.Length - evenCount;
            Console.WriteLine($"Even: {evenCount}, Odd: {oddCount}");
        }

        static void CountDigits()
        {
            Console.Write("Enter number: ");
            string num = Console.ReadLine();
            Console.WriteLine($"Number of digits: {num.Length}");
        }

        static void CheckVowelOrConsonant()
        {
            Console.Write("Enter a single character: ");
            char ch = char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();
            if ("aeiou".Contains(ch))
                Console.WriteLine($"{ch} is a vowel.");
            else if (char.IsLetter(ch))
                Console.WriteLine($"{ch} is a consonant.");
            else
                Console.WriteLine("Not a valid alphabet character.");
        }

        static void CharacterFrequency()
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine().ToLower();
            var freq = new Dictionary<char, int>();
            foreach (char c in input)
            {
                if (char.IsLetterOrDigit(c))
                {
                    if (freq.ContainsKey(c)) freq[c]++;
                    else freq[c] = 1;
                }
            }
            Console.WriteLine("Character Frequencies:");
            foreach (var pair in freq)
                Console.WriteLine($"{pair.Key}: {pair.Value}");
        }

        static void SecondLargestNumber()
        {
            Console.Write("Enter numbers separated by spaces: ");
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).Distinct().ToArray();
            if (arr.Length < 2)
            {
                Console.WriteLine("Not enough numbers to find second largest.");
                return;
            }
            Array.Sort(arr);
            Console.WriteLine($"Second Largest Number: {arr[arr.Length - 2]}");
        }

        static void Main(string[] args)
        {
            Q1: Sum of even numbers
            Console.Write("1. Enter numbers separated by comma for sum of even numbers: ");
            string[] inputNumbers = Console.ReadLine().Split(',');
            List<int> numbers = inputNumbers.Select(int.Parse).ToList();
            Console.WriteLine("Sum of even numbers: " + SumEvenNumbers(numbers));
            Console.WriteLine();

            // Q2: Factorial
            Console.Write("2. Enter a number to calculate factorial: ");
            int factInput = int.Parse(Console.ReadLine());
            Console.WriteLine("Factorial of " + factInput + ": " + Factorial(factInput));
            Console.WriteLine();

            // Q3: Capitalized Words
            Console.WriteLine("3. Enter a sentence to get Capitalized Words:");
            string[] inputText = Console.ReadLine().Split(' ');
            List<string> words = inputText.ToList();
            List<string> capitalizedWords = GetCapitalizedWords(words);
            Console.WriteLine("Capitalized words:");
            foreach (var word in capitalizedWords)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine();

            // Q4: Remove Duplicates
            Console.WriteLine("4. Enter a list of integers separated by comma which has duplicate entry:");
            string[] inputInt = Console.ReadLine().Split(',');
            List<int> numberInt = inputInt.Select(int.Parse).ToList();
            List<int> uniqueNumbers = RemoveDuplicates(numberInt);
            Console.WriteLine("List after removing duplicates:");
            foreach (int num in uniqueNumbers)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();

            // Q5: Fibonacci
            Console.Write("5. Enter count for Fibonacci series: ");
            int fibCount = int.Parse(Console.ReadLine());
            var fib = GetFibonacci(fibCount);
            Console.WriteLine($"First {fibCount} Fibonacci numbers: " + string.Join(", ", fib));
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}

