namespace StringCalculatorKata;

public class Calculator
{
    public int Add(string input)
    {
        var stringInput = input.Split(new []{','},StringSplitOptions.RemoveEmptyEntries);

        if (!stringInput.Any())
        {
            return 0;
        }

        if (stringInput.Length == 1)
        {
          return int.Parse(stringInput[0]);
        }

        return int.Parse(stringInput[0]) + int.Parse(stringInput[1]);

    }
}