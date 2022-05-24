using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    internal class Program
    {

        /* 
        
        
        4. (*) Написать программу, вычисляющую число Фибоначчи для заданного значения рекурсивным способом.*/

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

        static void Task2()
        {
            Console.Write("Введите набор чисел через пробел: ");
            string str = Console.ReadLine();
            string[] chars = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = Array.ConvertAll(chars, int.Parse);

            int sum = 0;

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                sum += numbers[i];
            }
            Console.WriteLine(sum);
        }

        /// <summary>
        /// 3. Написать метод по определению времени года. На вход подаётся число – порядковый номер месяца.
        /// На выходе — значение из перечисления(enum) — Winter, Spring, Summer, Autumn.
        /// Написать метод, принимающий на вход значение из этого перечисления и возвращающий название времени года(зима, весна, лето, осень).
        /// Используя эти методы, ввести с клавиатуры номер месяца и вывести название времени года.
        /// Если введено некорректное число, вывести в консоль текст «Ошибка: введите число от 1 до 12».
        /// </summary>
        static void Task3()
        {
            
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
                Console.WriteLine("4. Выход из приложения");
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
                            //Task3();
                            Console.ReadKey();
                            break;
                        case 4:
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