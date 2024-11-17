using System;

public class CalculationException : Exception
{
    private int _operand1;
    private int _operand2;

    private Exception _parent;

    public CalculationException(int operand1, int operand2, string message, Exception inner)
    {
        this._operand1 = operand1;
        this._operand2 = operand2;
        this._parent = inner;
    }

    public int Operand1 { get; }
    public int Operand2 { get; }

    public Exception Parent { get { return this._parent; } }
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
        try {
            Multiply(x, y);
            return "Multiply succeeded";
        } catch (CalculationException e) when (x < 0 && y < 0) {
            return $"Multiply failed for negative operands. {e.Parent.Message}";
        } catch (CalculationException e) when (x >= 0 || y >= 0) {
            return $"Multiply failed for mixed or positive operands. {e.Parent.Message}";
        }
    }

    public void Multiply(int x, int y)
    {
        try {
            this.calculator.Multiply(x, y);
        } catch (OverflowException e) {
            throw new CalculationException(x, y, "Ui ui ui", e);
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
