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
        /// Добавить корабль на игровое поле
        /// </summary>
        /// <param name="field">Игровое поле</param>
        /// <param name="deck">Кол-во палуб</param>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="dir">направление расположения (-1 => горизонтали + вправо/ 1 => вертикали + вниз)</param>
        static void AddShip(char[,] field, int deck, int x, int y, int dir)
        {
            /*
            |.|.|.|.|.|
            |.|.|.|.|.|
            |.|X|X|X|X|
            |.|X|.|.|.|
            |.|X|.|.|.|
            */
            // Проверка возможности добавления корабля, клетки должны быть свободны (O)
            if (field[x, y] != 'O') return;
            for (int i = 1; i < deck; i++)
                if (dir > 0 && (!IsCellValid(x + i, y) || 'O' != field[x + i, y])) return;
                else if (dir < 0 && (!IsCellValid(x, y + i) || 'O' != field[x, y + i])) return;

            // Добавляем корабль
            field[x, y] = 'X'; // Начальная точка
            for (int i = 1; i < deck; i++)
                if (dir > 0)
                    field[x + i, y] = 'X';
                else
                    field[x, y + i] = 'X';
        }
        /// </summary>
        /// Проверка валидности клетки игрового поля
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <returns>Результат проверки</returns>
        private static bool IsCellValid(int x, int y)
        {
            return x >= 0 && x < 10 && y >= 0 && y < 10;
        }

        /// <summary>
        /// 4*. «Морской бой»: вывести на экран массив 10х10, состоящий из символов X и O, где Х — элементы кораблей, а О — свободные клетки.
        /// </summary>
        static void Task4()
        {
            char[,] field = new char[10, 10];
            // Заполним все игровое поле свободными клетками (O)
            for (int i = 0; i < field.GetLength(0); i++)
                for (int j = 0; j < field.GetLength(1); j++)
                    field[i, j] = 'O';

            // Добавим корабли
            AddShip(field, 4, 0, 0, -1); // Четырехпалубный корабль по горизонтали
            AddShip(field, 3, 2, 5, 1); // Трехпалубный корабль по вертикали
            AddShip(field, 4, 6, 8, 1); // Четырехпалубный корабль по горизонтали

            // Распечатаем игровое поле
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                    Console.Write("{0}  ", field[i, j]);
                Console.WriteLine();
            }
            Console.ReadKey(true);
        }

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
                Console.WriteLine("4. Морской бой");
                Console.WriteLine("0. Выход из приложения");
                Console.WriteLine("----------------------------------------------------");
                Console.Write("Выберите пункт меню для запуска задания: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 0:
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
                        case 4:
                            Console.WriteLine("----------------------------------------------------");
                            Task4();
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
