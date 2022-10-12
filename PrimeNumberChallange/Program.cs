using PrimeNumberLibrary;
using System.Text;




NumberModel numberToTest = new(AskUserForNumber());

PrimeCheck(numberToTest);

FactorsOfNumberCheck(numberToTest);

PrimeFactorsOfNumberCheck(numberToTest);

LargestPrimeFactorCheck(numberToTest);

Console.ReadLine();







int AskUserForNumber()
{
    int output;
    bool isIntValid = false;
    do
    {
        Console.Write("Write number: ");
        string numberString = Console.ReadLine();
        isIntValid = int.TryParse(numberString, out output);

        if (isIntValid == false)
        {
            Console.WriteLine("Please write a valid number !");
        }
    } while (isIntValid == false);

    return output;
}

void PrimeCheck(NumberModel number)
{
    if (number.IsPrime == true)
    {
        Console.WriteLine($"{number.Value} is a Prime Number");
    }
    else
    {
        Console.WriteLine($"{number.Value} is not a Prime Number");
    }
    Console.WriteLine();
}

void FactorsOfNumberCheck(NumberModel number)
{
    if(number.Factors.Count == 0)
    {
        Console.WriteLine($"Number {number.Value} has no factors.");
    }
    else
    {
        Console.WriteLine($"List of factors of number {number.Value}: ");
        StringBuilder sb = new();
        foreach (var factor in number.Factors)
        {
            sb.Append($"{factor.Value}, ");
        }
        sb.Remove(sb.Length - 2, 2);
        Console.WriteLine($"{sb}");
        Console.WriteLine();
    }
}

void PrimeFactorsOfNumberCheck(NumberModel number)
{
    if(number.PrimeFactors.Count != 0)
    {
        Console.WriteLine($"List of Prime factors of number {number.Value}: ");
        StringBuilder sb = new();
        foreach (var factor in number.PrimeFactors)
        {
            sb.Append($"{factor.Value}, ");
        }
        sb.Remove(sb.Length - 2, 2);
        Console.WriteLine($"{sb}");
        Console.WriteLine();
    }
}

void LargestPrimeFactorCheck(NumberModel number)
{
    if(number.PrimeFactors.Count != 0)
    {
        Console.Write($"Largest Prime factor of number {number.Value}: ");
        Console.WriteLine(number.PrimeFactors.Max()?.Value);
        Console.WriteLine();
    }
}



