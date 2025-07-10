// See https://aka.ms/new-console-template for more information
using System;

public class Solution
{
    public bool IsPalindrome(string s)
    {
        int left = 0, right = s.Length - 1;

        while (left < right)
        {
            while (left < right && !char.IsLetterOrDigit(s[left]))
                left++;
            while (left < right && !char.IsLetterOrDigit(s[right]))
                right--;

            if (char.ToLower(s[left]) != char.ToLower(s[right]))
                return false;

            left++;
            right--;
        }
        return true;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();

        // Test cases
        Console.WriteLine(solution.IsPalindrome("A man, a plan, a canal: Panama"));
        Console.WriteLine(solution.IsPalindrome("race a car")); 
        Console.WriteLine(solution.IsPalindrome("")); 
        Console.WriteLine(solution.IsPalindrome("a")); 
        Console.WriteLine(solution.IsPalindrome(null)); 
    }
}
