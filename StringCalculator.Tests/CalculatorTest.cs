using FluentAssertions;
using StringCalculatorKata;
using Xunit;

namespace StringCalculator.Tests;

public class CalculatorTest
{
    [Theory]
    [InlineData("",0)]
    [InlineData("1",1)]
    [InlineData("1,2",3)]
    public void Adds_AddsUpToTwoNumbers_IfInputCorrect(string calculation, int expectation)
    {
        // Arrange
        var sut = new Calculator();
        
        // Act
        var result = sut.Add(calculation);
        
        //Assert
        result.Should().Be(expectation);
    }
}