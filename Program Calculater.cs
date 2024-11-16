using System;

class Calculater
{
    public bool boolIsTrue(int choice)
    {
        switch (choice)
        {
            case 1:
                return GetNumber();
            case 2:
                return GetYesOrNo();
            case 3:
                return GetHomeControl();
            default:
                Console.WriteLine("Invalid choice.");
                return false;
        }
    }

    private bool GetNumber()
    {
        Console.WriteLine("Enter a number:");
        int num = int.Parse(Console.ReadLine());

        if (num < 1000)
        {
            if (IsPrime(num))
            {
                Console.WriteLine("The number is a simple prime:");
                return true;
            }
        }
        else if (num > 1000)
        {
            if (IsPrime(num))
            {
                Console.WriteLine("The number is a pro prime.");
                return true;
            }
        }

        if (IsPalindromeMethod1(num))
        {
            Console.WriteLine("The number is a palindrome (Method 1).");
            return true;
        }

        if (IsPalindromeMethod2(num))
        {
            Console.WriteLine("The number is a palindrome (Method 2).");
            return true;
        }

        return false;
    }


    private bool IsPrime(int n)
    {
        if (n <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0) return false;
        }
        return true;
    }

    private bool IsPalindromeMethod1(int n)
    {
        string str = n.ToString();
        char[] arr = str.ToCharArray();
        Array.Reverse(arr);
        return new string(arr) == str;
    }

    private bool IsPalindromeMethod2(int n)
    {
        int orginal = n;
        int reverse = 0;

        while (n > 0)
        {
            int digit = n % 10;
            reverse = reverse * 10 + digit;
            n /= 10;
        }

        return orginal == reverse;
    }

    private bool GetYesOrNo()
    {
        Console.WriteLine("Do you agree?(Yes/No)");
        string response = Console.ReadLine().ToLower();

        switch (response)
        {
            case "yes":
                return true;
            case "no":
                return false;
            default:
                Console.WriteLine("Invalid input.Please enter'Yes' or 'No'.");
                return GetYesOrNo();
        }
    }

    private bool GetHomeControl()
    {
        Console.WriteLine("Select an action:");
        Console.WriteLine("1) Trun on lights");
        Console.WriteLine("2) Trun off lights ");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine("Lights are now ON.");
                return true;
            case 2:
                Console.WriteLine("Lights are now OFF.");
                return true;
            default:
                Console.WriteLine("Invalid option. Please select 1 or 2.");
                return GetHomeControl();
        }
    }

}

class Program
{
    static void Main()
    {
        Calculater calculater = new Calculater();

        Console.WriteLine("Please select an option (1-3):");
        Console.WriteLine("1) Get Number (simple prime <1000, pro prime > 1000, palindrome number");
        Console.WriteLine("2) Get YesOrNo (using switch");
        Console.WriteLine("3) Get HomeControl");

        int choice = int.Parse(Console.ReadLine());

        bool result = calculater.boolIsTrue(choice);

        Console.WriteLine("Result:" + result);
    }
}
