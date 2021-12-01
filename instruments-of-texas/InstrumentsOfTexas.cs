using System;

[Serializable]
public class CalculationException : Exception
{
    public CalculationException() : base() { }
    public CalculationException(string message) : base(message) { }
    public CalculationException(string message, Exception inner) : base(message, inner) { }
    public CalculationException(int operand1, int operand2, string message, Exception inner)
        : base(message, inner)
    {
        Operand1 = operand1;
        Operand2 = operand2;
    }
    protected CalculationException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

    public int Operand1 { get; }
    public int Operand2 { get; }
}

public class CalculatorTestHarness
{
    private Calculator calculator;

    public CalculatorTestHarness(Calculator calculator)
    {
        this.calculator = calculator;
    }

    public string TestMultiplication(int x, int y)
    {
        try
        {
            Multiply(x, y);
            return "Multiply succeeded";
        }
        catch (CalculationException exception) when (exception.Operand1 < 0 && exception.Operand2 < 0)
        {
            return "Multiply failed for negative operands. " + exception.InnerException?.Message;
        }
        catch (CalculationException exception)
        {
            return "Multiply failed for mixed or positive operands. " + exception.InnerException?.Message;
        }
    }

    public void Multiply(int x, int y)
    {
        try
        {
            calculator.Multiply(x, y);
        }
        catch (OverflowException exception)
        {
            throw new CalculationException(x, y, string.Empty, exception);
        }
    }
}


// Please do not modify the code below.
// If there is an overflow in the multiplication operation
// then a System.OverflowException is thrown.
public class Calculator
{
    public int Multiply(int x, int y)
    {
        checked
        {
            return x * y;
        }
    }
}
