namespace StringCalculatorKata;

public class Calculator
{
    public int Add(string input)
    {
        var delimiters = new List<char> { ',', '\n' };
        if (input.StartsWith("//"))
        {
            // Split on New line appearance.
            var splitDelimiter = input.Split(new[] { '\n' }, 2);
            var customDelimiter = splitDelimiter[0].Replace("//", string.Empty).Single();
            delimiters.Add(customDelimiter);
            input = splitDelimiter[1];
        }
        var stringInput = input.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToList();
        
        var negativeNumbers = stringInput.Where(x => x < 0).ToList();
        if (negativeNumbers.Any())
        {
            throw new Exception($"Negative numbers not allowed: {string.Join(",",negativeNumbers)}");
        }
        
        return stringInput.Sum();
    }
}