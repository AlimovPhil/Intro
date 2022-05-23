using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson03
{
    internal class Program
    {
        static void Task1()
        {
            Console.Write("Введите длину стороны квадратной матрицы: ");
            int a = int.Parse(Console.ReadLine());
            int b = a;
            int[,] array1 = new int[a, b]; //создание массива с заданным количеством элементов
            Random rnum = new Random();

            for (int i = 0; i < array1.GetLength(0); i++) //заполнение массива рандомными числами и вывод в консоль
            {
                for (int j = 0; j < array1.GetLength(1); j++)
                {
                    array1[i, j] = rnum.Next(10, 99);
                    Console.Write($"{array1[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Нажмите любую клавишу для отображения диагонали матрицы...");
            Console.ReadKey();
            Console.WriteLine("Диагональ матрицы: ");

            for (int i = 0; i < array1.GetLength(0); i++) //поиск и вывод диагонали
            {
                for (int j = 0; j < array1.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        Console.Write("{0}{1}", new string(' ', i), array1[i, j]);
                        //Console.Write(array1[i,j]); - выводит диагональ столбцом
                    }
                }
                Console.WriteLine();
            }

        }

        /// <summary>
        /// Задание 3. Написать программу, выводящую введённую пользователем строку в обратном порядке.
        /// </summary>
        static void Task3()
        {
            Console.Write("Введите слово/фразу для инвертирования: ");
            string phrase = Console.ReadLine();
            char[] chars = phrase.ToCharArray();
            Array.Reverse(chars);
            Console.Write("Результат: ");
            foreach (char c in chars)
            {
                Console.Write(c);
            }
            Console.WriteLine("");
        }

        /// <summary>
        /// Задание 2. Написать программу «Телефонный справочник»: создать двумерный массив 5х2, хранящий список телефонных контактов: 
        /// первый элемент хранит имя контакта, второй — номер телефона/email.
        /// </summary>
        static void Task2()
        {
            string[,] book = new string[5, 2];
            book[0, 0] = "Президент";
            book[1, 0] = "Механик";
            book[2, 0] = "Адвокат";
            book[3, 0] = "Робокоп";
            book[4, 0] = "Виталик";

            book[0, 1] = "gov@ru.ru";
            book[1, 1] = "statham@uk.com";
            book[2, 1] = "+7 999 568 23 44";
            book[3, 1] = "bostonrobotics@dr.dre";
            book[4, 1] = "+7 495 001 21 21";

            Console.WriteLine("Список контактов в справочнике: ");
            for (int i = 0, n = 1; i < book.GetLength(0); i++)
            {
                Console.Write($"{n++}. ");
                Console.Write($"{book[i, 0]} ");
                Console.WriteLine();
            }
            Console.Write("Выберите порядковый номер контакта для просмотра телефона/email: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"тел/email: {book[0, 1]}");
                        break;
                    case 2:
                        Console.WriteLine($"тел/email: {book[1, 1]}");
                        break;
                    case 3:
                        Console.WriteLine($"тел/email: {book[2, 1]}");
                        break;
                    case 4:
                        Console.WriteLine($"тел/email: {book[3, 1]}");
                        break;
                    case 5:
                        Console.WriteLine($"тел/email: {book[4, 1]}");
                        break;
                    default:
                        Console.WriteLine("Такого контакта не существует, попробуйте еще раз");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Вы ввели недопустимый символ!");
                Console.WriteLine("Завершение работы приложения...");
                return;
            }

        }

        /// <summary>
        /// 4*. «Морской бой»: вывести на экран массив 10х10, состоящий из символов X и O, где Х — элементы кораблей, а О — свободные клетки.
        /// </summary>
        //static void Task4()
        //{
        //    char[,] deck = new char[10, 10]; //создание массива с заданным количеством элементов
        //    deck[0, 0] = 'X';
        //    for (int i = 0; i < deck.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < deck.GetLength(1); j++)
        //        {
        //            Console.Write($"{deck[i, j]} ");
        //        }
        //        Console.WriteLine();
        //    }
        //}

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Title = "Lesson 3";
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("Список приложений: ");
                Console.WriteLine("1. Вывод диагонали заданного массива");
                Console.WriteLine("2. Телефонный справочник");
                Console.WriteLine("3. Вывод строки в обратном порядке");
                Console.WriteLine("4. Выход из приложения");
                Console.WriteLine("----------------------------------------------------");
                Console.Write("Выберите пункт меню для запуска задания: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 4:
                            Console.WriteLine("----------------------------------------------------");
                            Console.WriteLine("Завершение работы приложения...");
                            Console.ReadKey();
                            return;
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
