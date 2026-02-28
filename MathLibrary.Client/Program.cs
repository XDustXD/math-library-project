// Подключаем пространство имен из нашей DLL
using MathLibrary;
Console.WriteLine("=== Демонстрация работы MathLibrary.dll ===\n");
double x = 10, y = 4;
// Используем статические методы из класса Calculator
Console.WriteLine($"Сложение: {x} + {y} = {Calculator.Add(x, y)}");
// Вызовы остальных методов
// Добавьте обработчик ошибки деления на ноль
try
{
    // Попробуем деление на ноль и выводим результат
    Calculator.Divide(x, 0);
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
}
Console.WriteLine("\n--- Проверка чисел на простоту ---");
// создаем массив целых чисел
int[] numbersToCheck = { 1, 2, 3, 4, 17, 25, 97 }
;
// проходимся по массиву проверяем числа
foreach (int num in numbersToCheck)
{
    bool isPrime = Calculator.IsPrime(num);
    Console.WriteLine($"Число {num} является простым? -> {isPrime}");
}

System.Console.WriteLine("\n--- Возведение в степень и факториал ---");

Console.WriteLine($"2^5 = {Calculator.Power(2, 5)}");
Console.WriteLine($"3^6 = {Calculator.Power(3, 6)}");
Console.WriteLine($"4^2 = {Calculator.Power(4, 2)}");

Console.WriteLine("\n--- Факториал ---");

Console.WriteLine($"5! = {Calculator.Factorial(5)}");
Console.WriteLine($"10! = {Calculator.Factorial(10)}");
Console.WriteLine($"3! = {Calculator.Factorial(3)}");

System.Console.WriteLine("\n--- Решение квадратного уравнения ---");

if (Calculator.SolveQuadratic(1, -3, 2, out double? x1, out double? x2))
    Console.WriteLine($"Корни уравнения: x1 = {x1}, x2 = {x2}");
else
    Console.WriteLine("Действительных корней нет");

if (Calculator.SolveQuadratic(1, 2, 1, out x1, out x2))
    Console.WriteLine($"Корни уравнения: x1 = {x1}, x2 = {x2}");
else
    Console.WriteLine("Действительных корней нет");