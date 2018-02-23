using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
/*
 Мартиросян Тигран
 БПИ176
 Вариант 1
 */


namespace Martirosyan1
{
    class Program
    {
        // генератор случайных чисел
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            
            do
            {
                int n = InputInt("введите положиельное число.");
                int prob = 0;
                double k;
                double permk1;
                double permk2;
                for (int i = 0; i < n; i++)
                {
                    k = rnd.Next(-5, 5) + rnd.NextDouble();
                    permk1 = rnd.Next(-5, 5) + rnd.NextDouble();
                    permk2 = rnd.Next(-5, 5) + rnd.NextDouble();
                    prob = rnd.Next(4);
                    try {
                        switch (prob)
                        {
                            case 0:
                                {
                                    var x = Calculate(k, new Add(permk1), new Add(permk2));
                                    Console.WriteLine();
                                    break;
                                }
                            case 1:
                                {
                                    var x = Calculate(k, new Add(permk1), new Divide(permk2));
                                    Console.WriteLine();
                                    break;
                                }
                            case 2:
                                {
                                    var x = Calculate(k, new Divide(permk1), new Add(permk2));
                                    Console.WriteLine();
                                    break;
                                }
                            case 3:
                                {
                                    var x = Calculate(k, new Divide(permk1), new Divide(permk2));
                                    Console.WriteLine();
                                    break;
                                }
                        }       
                    }
                    catch(DivideByZeroException e)
                    {
                        Console.WriteLine(e);
                        Console.WriteLine("Такое преобразовние невозможно.");
                    }
                }

                Console.WriteLine("ESC чтобы выйти. Что угодно чтобы продолжить.");
            } while (Console.ReadKey().Key!=ConsoleKey.Escape);
        }

        /// <summary>
        /// Метод который выполняет преобразования и выводит результат.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="perf1"></param>
        /// <param name="perf2"></param>
        /// <returns></returns>
        static double Calculate(double number, ICalculation perf1, ICalculation perf2)
        {
            var a= perf1.Perform(number);
            if(perf1 is Add)
            {
                Console.WriteLine($"#1 сложение: было:{number:f3}, стало: {a:f3}");
            }
            a = perf2.Perform(a);
            if(perf2 is Divide)
            {
                Console.WriteLine($"#2 деление: было:{number:f3}, стало: {a:f3}");
            }
            return perf2.Perform(a);
        }

        /// <summary>
        /// Метод для получения значений от пользователя
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static int InputInt(string s)
        {
            int n;
            do
            {
                Console.WriteLine(s);
            } while (!int.TryParse(Console.ReadLine(), out n)||n<=0);
            return n;
        }
    }
}
