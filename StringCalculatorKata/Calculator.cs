namespace StringCalculatorKata;

public class Calculator
{
    public int Add(string input)
    {
        var delimiters = new List<char> { ',', '\n' };
        if (input.StartsWith("//"))
        {
            // Split on New line appearance.
            var splitdelimiter = input.Split(new[] { '\n' }, 2);
            var customDelimiter = splitdelimiter[0].Replace("//", string.Empty).Single();
            delimiters.Add(customDelimiter);
            input = splitdelimiter[1];
        }
        var stringInput = input.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse);
        return stringInput.Sum();
    }
}