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
    
    [Theory]
    [InlineData("1,2,3",6)]
    [InlineData("34,21,55",110)]
    public void Adds_AddsUpToAnyNumber_IfStringIsValid(string calculation, int expectation)
    {
        // Arrange
        var sut = new Calculator();
        
        // Act
        var result = sut.Add(calculation);
        
        //Assert
        result.Should().Be(expectation);
    }
    
    [Theory]
    [InlineData("1\n,2,3",6)]
    [InlineData("34\n,21,55\n",110)]
    public void Adds_AddsNumbersUsingNewLineDelimeter_IfStringIsValid(string calculation, int expectation)
    {
        // Arrange
        var sut = new Calculator();
        
        // Act
        var result = sut.Add(calculation);
        
        //Assert
        result.Should().Be(expectation);
    }
    
    [Theory]
    [InlineData("//;\n1,2",3)]
    [InlineData("//;\n1,21",22)]
    public void Adds_AddsNumbersUsingCustomDelimiter_IfStringIsValid(string calculation, int expectation)
    {
        // Arrange
        var sut = new Calculator();
        
        // Act
        var result = sut.Add(calculation);
        
        //Assert
        result.Should().Be(expectation);
    }
    
    [Theory]
    [InlineData("1,2,-1","-1")]
    [InlineData("1,\n2,-4","-4")]
    [InlineData("//;\n1;-2,-5","-2,-5")]
    public void Add_ShouldThroeExceptionWhenANegativeNumberIsUsed(string calculation, string negativeNumbers)
    {
        // Arrange
        var sut = new Calculator();
        
        // Act
        Action action = () => sut.Add(calculation);
        
        //Assert
        action.Should().Throw<Exception>().WithMessage($"Negative numbers not allowed: {negativeNumbers}");
    }
}