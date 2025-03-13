using System;
using System.Collections.Generic;

interface IFizzBuzzRule
{
    bool IsMatch(int number);
    string GetResult(int number);
}

class FizzRule : IFizzBuzzRule
{
    public bool IsMatch(int number) => number % 3 == 0 && number % 5 != 0;
    public string GetResult(int number) => "Fizz";
}

class BuzzRule : IFizzBuzzRule
{
    public bool IsMatch(int number) => number % 5 == 0 && number % 3 != 0;
    public string GetResult(int number) => "Buzz";
}

class FizzBuzzRule : IFizzBuzzRule
{
    public bool IsMatch(int number) => number % 3 == 0 && number % 5 == 0;
    public string GetResult(int number) => "FizzBuzz";
}

class DefaultRule : IFizzBuzzRule
{
    public bool IsMatch(int number) => true;
    public string GetResult(int number) => number.ToString();
}

class FizzBuzzProcessor
{
    private readonly List<IFizzBuzzRule> _rules;

    public FizzBuzzProcessor()
    {
        _rules = new List<IFizzBuzzRule>
        {
            new FizzBuzzRule(),
            new FizzRule(),
            new BuzzRule(),
            new DefaultRule()
        };
    }

    public string Process(int number)
    {
        foreach (var rule in _rules)
        {
            if (rule.IsMatch(number))
                return rule.GetResult(number);
        }
        return number.ToString();
    }
}

class Program
{
    static void Main()
    {
        var fizzBuzzProcessor = new FizzBuzzProcessor();

        for (int i = 1; i <= 20; i++)
        {
            Console.WriteLine(fizzBuzzProcessor.Process(i));
        }
    }
}