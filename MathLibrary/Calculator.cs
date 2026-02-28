namespace MathLibrary;

/// <summary>
/// Основной класс математической библиотеки.
/// Содержит методы для базовых арифметических операций и проверки чисел.
/// </summary>
public static class Calculator
{
    // кэш факториалов для быстрых повторных вызовов (0! .. 20!)
    private static readonly double[] s_smallFacts = new double[]
    {
        1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880,
        3628800, 39916800, 479001600, 6227020800, 87178291200,
        1307674368000, 20922789888000, 355687428096000, 6402373705728000,
        121645100408832000, 2432902008176640000
    };

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
        if (double.IsNaN(a) || double.IsNaN(b))
            throw new ArgumentException("Аргументы не могут быть NaN.");

        if (b == 0)
            throw new DivideByZeroException("Делитель не может быть равен нулю.");

        if (double.IsInfinity(a) || double.IsInfinity(b))
            throw new ArgumentException("Аргументы не могут быть бесконечными.");

        return a / b;
    }
    /// <summary>
    /// Проверяет, является ли число простым.
    /// </summary>
    public static bool IsPrime(int number)
    {
        if (number <= 1) return false;

        if (number == 2) return true;
        if (number % 2 == 0) return false;

        int limit = (int)Math.Sqrt(number);
        for (int i = 3; i <= limit; i += 2)
            if (number % i == 0) return false;

        return true;
    }

    /// <summary>
    /// Возводит число в степень.
    /// </summary>
    public static double Power(double number, double power)
    {
        if (double.IsNaN(number) || double.IsNaN(power))
            throw new ArgumentException("Аргументы не могут быть NaN.");

        if (double.IsInfinity(number) || double.IsInfinity(power))
            throw new ArgumentException("Аргументы не могут быть бесконечными.");

        // метод реализован только для целого показателя
        if (power % 1 != 0)
            throw new NotSupportedException("Показатель степени должен быть целым числом.");

        // быстрый алгоритм: экспоненциальное возведение в степень
        long exp = (long)power;
        bool negative = exp < 0;
        exp = Math.Abs(exp);
        double res = 1;
        double baseVal = number;
        while (exp > 0)
        {
            if ((exp & 1) == 1)
                res *= baseVal;
            baseVal *= baseVal;
            exp >>= 1;
        }
        return negative ? 1 / res : res;
    }

    /// <summary>
    /// Вычисляет факториал числа.
    /// </summary>
    public static double Factorial(int n)
    {
        if (n < 0)
            throw new ArgumentOutOfRangeException(nameof(n), "Факториал не определен для отрицательных чисел.");

        // пример простой защиты от переполнения в double
        if (n > 170)
            throw new OverflowException("Результат слишком велик для типа double.");

        if (n < s_smallFacts.Length)
            return s_smallFacts[n];

        double result = s_smallFacts[^1];
        for (int i = s_smallFacts.Length; i <= n; i++)
            result *= i;

        return result;
    }

    /// <summary>
    /// Решает квадратное уравнение ax^2 + bx + c = 0
    /// </summary>
    public static bool SolveQuadratic(double a, double b, double c, out double? x1, out double? x2)
    {
        if (double.IsNaN(a) || double.IsNaN(b) || double.IsNaN(c))
            throw new ArgumentException("Коэффициенты не могут быть NaN.");

        if (a == 0)
            throw new ArgumentOutOfRangeException(nameof(a), "Коэффициент 'a' не может быть равен нулю.");

        if (double.IsInfinity(a) || double.IsInfinity(b) || double.IsInfinity(c))
            throw new ArgumentException("Коэффициенты не могут быть бесконечными.");

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