namespace MathLibrary;

/// <summary>
/// Основной класс математической библиотеки.
/// Содержит методы для базовых арифметических операций и проверки чисел.
/// </summary>
public static class Calculator
{
    /// <summary>
    /// Складывает два числа.
    /// </summary>
    public static double Add(double a, double b) => a + b;
    /// <summary>
    /// Вычитает второе число из первого.
    /// </summary>
    public static double Subtract(double a, double b) => a - b;
    /// <summary>
    /// Умножает два числа.
    /// </summary>
    public static double Multiply(double a, double b) => a * b;
    /// <summary>
    /// Делит первое число на второе.
    /// </summary>
    public static double Divide(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("Делитель не может быть равен нулю.");

        return a / b;
    }
    /// <summary>
    /// Проверяет, является ли число простым.
    /// </summary>
    public static bool IsPrime(int number)
    {
        if (number <= 1) return false;

        int limit = (int)Math.Sqrt(number);
        for (int i = 2; i <= limit; i++)
            if (number % i == 0) return false;

        return true;
    }

    /// <summary>
    /// Возводит число в степень.
    /// </summary>
    public static double Power(double number, double power)
    {
        double result = 1;
        if (power > 0)
            for(int i = 1; i <= power; i++)
                result *= number;

        else if (power < 0)
            for(int i = 1; i <= -power; i++)
                result /= number;

        return result;
    }

    /// <summary>
    /// Вычисляет факториал числа.
    /// </summary>
    public static double Factorial(int n)
    {
        if (n < 0) throw new ArgumentException("Факториал не определен для отрицательных чисел.");

        double result = 1;
        for (int i = 2; i <= n; i++)
            result *= i;

        return result;
    }

    /// <summary>
    /// Решает квадратное уравнение ax^2 + bx + c = 0
    /// </summary>
    public static bool SolveQuadratic(double a, double b, double c, out double? x1, out double? x2)
    {
        if (a == 0)
            throw new ArgumentException("Коэффициент 'a' не может быть равен нулю.");

        double discriminant = b * b - 4 * a * c;

        if (discriminant < 0)
        {
            x1 = x2 = null;
            return false; // Нет действительных корней
        }

        double sqrtD = Math.Sqrt(discriminant);
        double denominator = 2 * a;

        x1 = (-b + sqrtD) / denominator;
        x2 = (-b - sqrtD) / denominator;
        return true; // Возвращаем дискриминант для информации
    }
}