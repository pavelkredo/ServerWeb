using System;
using NLog;
using ArithmeticException = System.ArithmeticException;

namespace Log
{
    internal class MainClass
    {
        private static void Main()
        {
            // Создаем экземпляр логгера
            Logger logger = LogManager.GetCurrentClassLogger();

            try
            {
                // реализуем операцию деления
                // с вводом двух чисел через консоль

                Console.WriteLine("Введите первое число:");
                // Проверка, что первая введенная строка - это число
                if (!double.TryParse(Console.ReadLine(), out double numFirst))
                {
                    throw new ArgumentException("Было введено не число.");
                }
                logger.Info("Введенное первое число: " + numFirst);

                Console.WriteLine("Введите второе число:");
                // Проверка, что вторая введенная строка - это число
                if (!double.TryParse(Console.ReadLine(), out double numSecond))
                {
                    throw new ArgumentException("Было введено не число.");
                }
                logger.Info("Введенное второе число: " + numSecond);

                // Проверка, является ли второе число 0, чтобы исключить деление на 0
                if (numSecond == 0)
                {
                    throw new ArithmeticException("Ошибка деления на 0");
                }

                // полученный результат деления
                var divisionResult = numFirst / numSecond;

                logger.Info("Результат деления двух чисел: " + divisionResult);

                Console.ReadKey();
            }
            catch (ArgumentException argumentException)
            {
                logger.Error(argumentException.Message);

                Console.ReadKey();
            }
            catch (ArithmeticException arithmeticException)
            {
                logger.Error(arithmeticException.Message);

                Console.ReadKey();
            }
        }
    }
}