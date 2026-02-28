using MathLibrary;

Console.WriteLine("ТЕСТИРОВАНИЕ MathLibrary\n");

// Арифметика
Console.WriteLine("Арифметика:");
Console.WriteLine($"10 + 5 = {Calculator.Add(10, 5)}");
Console.WriteLine($"10 - 5 = {Calculator.Subtract(10, 5)}");
Console.WriteLine($"10 * 5 = {Calculator.Multiply(10, 5)}");
Console.WriteLine($"10 / 5 = {Calculator.Divide(10, 5)}\n");

// Простые числа
Console.WriteLine("Простые числа:");
int[] nums = { 2, 3, 4, 5, 11, 17 };
foreach (int n in nums)
    Console.WriteLine($"{n} - {(Calculator.IsPrime(n) ? "простое" : "не простое")}");

// Power
Console.WriteLine("\nСтепени:");
Console.WriteLine($"2^5 = {Calculator.Power(2, 5)}");
Console.WriteLine($"2^(-2) = {Calculator.Power(2, -2)}");

// Factorial
Console.WriteLine("\nФакториал:");
Console.WriteLine($"5! = {Calculator.Factorial(5)}");
Console.WriteLine($"10! = {Calculator.Factorial(10)}");

// SolveQuadratic
Console.WriteLine("\nКвадратные уравнения:");
if (Calculator.SolveQuadratic(1, -5, 6, out double? x1, out double? x2))
    Console.WriteLine($"x² - 5x + 6 = 0: x₁={x1}, x₂={x2}");

if (!Calculator.SolveQuadratic(1, 0, 1, out x1, out x2))
    Console.WriteLine("x² + 1 = 0: нет действительных корней");

// Исключения
Console.WriteLine("\nТестирование исключений:");
try 
{ 
    Calculator.Divide(10, 0); 
}
catch (DivideByZeroException) 
{ 
    Console.WriteLine("DivideByZeroException"); 
}

try 
{ 
    Calculator.Power(2, 2.5); 
}
catch (NotSupportedException) 
{ 
    Console.WriteLine("NotSupportedException");
}

try 
{ 
    Calculator.Factorial(-5); 
}
catch (ArgumentOutOfRangeException) 
{ 
    Console.WriteLine("ArgumentOutOfRangeException"); 
}

try 
{ 
    Calculator.SolveQuadratic(0, 2, 1, out _, out _); 
}
catch (ArgumentOutOfRangeException) 
{ 
    Console.WriteLine("ArgumentOutOfRangeException"); 
}

Console.WriteLine("\nВсе тесты завершены");
