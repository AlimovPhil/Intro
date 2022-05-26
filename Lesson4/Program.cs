using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    internal class Program
    {

        /// <summary>
        /// 1. Написать метод GetFullName(string firstName, string lastName, string  patronymic), принимающий на вход ФИО в разных аргументах 
        /// и возвращающий объединённую строку с ФИО.Используя метод, написать программу, выводящую в консоль 3–4 разных ФИО.
        /// </summary>
        static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return $"- {firstName} {lastName} {patronymic}";
        }

        static void Task1()
        {
            (string firstName, string lastName, string patronymic)[] data =
{
                ("Питер", "Паркер", "Пауканович"),
                ("Брюс", "Уэйн", "Мышевич"),
                ("Натан", "Дрейк", "Графикович"),
                ("Алан", "Уэйк", "Фонарикович"),
            };
            for (int i = 0; i < data.Length; i++)
            {
                Console.WriteLine(GetFullName(data[i].firstName, data[i].lastName, data[i].patronymic));
            }
        }

        /// <summary>
        /// 2. Написать программу, принимающую на вход строку — набор чисел, разделенных пробелом, и возвращающую число — сумму всех чисел в строке.
        /// Ввести данные с клавиатуры и вывести результат на экран.
        /// </summary>
        static string[] separator = { ",", ".", " ", "?", "!", ";", ":" };

        static int[] StringToNums(string input) //Метод преобразования строки в числа
        {
            string[] chars = input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = Array.ConvertAll(chars, int.Parse);
            return numbers;
        }

        static int NumSum(int[] array) //Метод подсчета суммы чисел
        {
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                sum += array[i];
            }
            return sum;
        }

        static void Task2()
        {
            Console.Write("Введите набор чисел через пробел: ");
            string str = Console.ReadLine();
            int[] numbers = StringToNums(str);
            int sum = NumSum(numbers);
            Console.WriteLine(sum);
        }

        /// <summary>
        /// 3. Написать метод по определению времени года. На вход подаётся число – порядковый номер месяца.
        /// На выходе — значение из перечисления(enum) — Winter, Spring, Summer, Autumn.
        /// Написать метод, принимающий на вход значение из этого перечисления и возвращающий название времени года(зима, весна, лето, осень).
        /// Используя эти методы, ввести с клавиатуры номер месяца и вывести название времени года.
        /// Если введено некорректное число, вывести в консоль текст «Ошибка: введите число от 1 до 12».
        /// </summary>

        public enum YearSeason //Перечисление времен года
        {
            Error,
            Winter,
            Spring,
            Summer,
            Autumn
        }

        static YearSeason ByMonth(int a) //Определение времени года по введенным данным
        {
            if (a < 1 || a > 12)
            {
                Console.WriteLine("Ошибка!");
                Console.WriteLine("Введите число от 1 до 12!");
                return YearSeason.Error;
            }
            else
            {
                if ((a == 3) || (a == 4) || (a == 5))
                {
                    return YearSeason.Spring;
                }
                else
                {
                    if ((a == 6) || (a == 7) || (a == 8))
                    {
                        return YearSeason.Summer;
                    }
                    else
                    {
                        if ((a == 9) || (a == 10) || (a == 11))
                        {
                            return YearSeason.Autumn;
                        }
                        else
                        {
                            return YearSeason.Winter;
                        }
                    }
                }
            }
        }

        static string PrintSeason(YearSeason input) // Вывод в консоль названия времени года
        {
            switch (input)
            {
                case YearSeason.Spring:
                    return "Весна";
                case YearSeason.Winter:
                    return "Зима";
                case YearSeason.Autumn:
                    return "Осень";
                case YearSeason.Summer:
                    return "Лето";
                default: return "Ошибка!";
            }
        }

        static void Task3()
        {
            Console.Write("Введите номер текущего месяца: ");
            if (int.TryParse(Console.ReadLine(), out int num))
            Console.WriteLine($"Время года: {PrintSeason(ByMonth(num))}");
            else
            {
                Console.WriteLine("Ошибка! \nВведите число!");
                return;
            }
        }

        /// <summary>
        /// 4. (*) Написать программу, вычисляющую число Фибоначчи для заданного значения рекурсивным способом.
        /// Fn = Fn-1 + Fn-2, n<2
        /// </summary>
        static int F(int value)
        {
            Console.WriteLine(value);
            if (value < 2) return value;
            else return F(value - 1) + F(value - 2);
        }
        static void Task4()
        {
           Console.WriteLine("Введите число, что вычислить число Фибоначчи: ");
            if (int.TryParse(Console.ReadLine(), out int a))
            {
                Console.WriteLine("Результат: ");
                F(a);
            }
            else
            {
                Console.WriteLine("Ошибка, введите число!");
                return;
            }
        }

        static void Main(string[] args)
        {
            Console.Title = "Lesson 4";
            while (true)
            {
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("Список приложений: ");
                Console.WriteLine("1. Задание с GetFullName");
                Console.WriteLine("2. Сумма введенных чисел");
                Console.WriteLine("3. Определение времени года");
                Console.WriteLine("4. Число Фибонначи");
                Console.WriteLine("5. Выход из приложения");
                Console.WriteLine("----------------------------------------------------");
                Console.Write("Выберите пункт меню для запуска задания: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("----------------------------------------------------");
                            Task1();
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.WriteLine("----------------------------------------------------");
                            Task2();
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.WriteLine("----------------------------------------------------");
                            Task3();
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.WriteLine("----------------------------------------------------");
                            Task4();
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.WriteLine("----------------------------------------------------");
                            Console.WriteLine("Завершение работы приложения...");
                            Console.ReadKey();
                            return;

                        default:
                            Console.WriteLine("----------------------------------------------------");
                            Console.WriteLine("Введен неверный номер задания, попробуйте еще раз");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели недопустимый символ!");
                    Console.WriteLine("Завершение работы приложения...");
                    Console.ReadKey();
                    return;
                }

            }
        }
    }
}