﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    class Program
    {
        //Задание 2. Попытка сделать через enum, но не смог решить как преобразовать в тип string названия месяцев для отображения в кириллице.
        /* public enum Month
         {
             Error = 0,
             Jan = 1,
             Feb = 2,
             Mar = 3,
             Apr = 4,
             May = 5,
             Jun = 6,
             Jul = 7,
             Aug = 8,
             Sep = 9,
             Oct = 10,
             Nov = 11,
             Dec = 12
         }

         static void Task2()
         {
             Console.Write("Введите порядковый номер текущего месяца: ");
             int monthNum = int.Parse(Console.ReadLine());

             if (monthNum == 0)
             {
                 Console.WriteLine("Ошибка, такого месяца не существует");
             }
             else
             {
                 Console.WriteLine($"The current month is {(Month)monthNum}");
             }
         }
        */

        /// <summary>
        /// Задание 1. Запросить у пользователя минимальную и максимальную температуру за сутки и вывести среднесуточную температуру
        /// </summary>
        static void Task1()
        {

            Console.Write("Введите минимальную температуру сегодня: ");
            float min = float.Parse(Console.ReadLine());

            Console.Write("Введите максимальную температуру сегодня: ");
            float max = float.Parse(Console.ReadLine());

            float average = (min + max) / 2; //формула вычисления средней темп

            Console.WriteLine($"Среднесуточная температура: {average}");
        }


        /// <summary>
        /// Задание 1, 2, 5. Пока не понятно, как вытаскивать данные, нужно учить Поля и get\set
        /// </summary>
        static void Task125()
        {
            //Задание 1.Запросить у пользователя минимальную и максимальную температуру за сутки и вывести среднесуточную температуру
            Console.Write("Введите минимальную температуру сегодня: ");
            float min = float.Parse(Console.ReadLine());

            Console.Write("Введите максимальную температуру сегодня: ");
            float max = float.Parse(Console.ReadLine());
            float average = (min + max) / 2; //формула вычисления средней темп

            Console.WriteLine($"Среднесуточная температура: {average}");


            //Задание 2. Запрос у пользователя номера месяца.
            Console.Write("Введите порядковый номер текущего месяца: ");
            int monthNum = int.Parse(Console.ReadLine());
            string monthName;
            switch (monthNum)
            {
                case 1:
                    monthName = "Январь";
                    Console.Write($"На дворе {monthName}");
                    break;

                case 2:
                    monthName = "Февраль";
                    Console.Write($"На дворе {monthName}");
                    break;

                case 3:
                    monthName = "Март";
                    Console.WriteLine($"На дворе {monthName}");
                    break;

                case 4:
                    Console.WriteLine("На дворе Апрель"); //если не нужно сохранять значение monthName, 3 кэйса описал так нарочно.
                    break;

                case 5:
                    Console.WriteLine("На дворе Май");
                    break;

                case 6:
                    Console.WriteLine("На дворе Июнь");
                    break;

                case 7:
                    monthName = "Июль";
                    Console.WriteLine($"На дворе {monthName}");
                    break;

                case 8:
                    monthName = "Август";
                    Console.WriteLine($"На дворе {monthName}");
                    break;

                case 9:
                    monthName = "Сентябрь";
                    Console.WriteLine($"На дворе {monthName}");
                    break;

                case 10:
                    monthName = "Октябрь";
                    Console.WriteLine($"На дворе {monthName}");
                    break;

                case 11:
                    monthName = "Ноябрь";
                    Console.WriteLine($"На дворе {monthName}");
                    break;

                case 12:
                    monthName = "Декабрь";
                    Console.Write($"На дворе {monthName}");
                    break;
            }


            // Задание 5. Дождливая ли зима? Вывод результата проверки через созданый метод ниже. 
            string weather = RainyWeather(average, monthNum);
            Console.WriteLine(weather);
        }

        /// <summary>
        /// Задание 5. Метод проверки.Проверка на дождливу погоду
        /// </summary>
        /// <param name="average">Средняя температура за день</param>
        /// <param name="monthNum">Номер текущего месяца</param>
        /// <returns></returns>
        static string RainyWeather(float average, int monthNum)
        {
            if ((average > 0) && (monthNum == 1) || (monthNum == 2) || (monthNum == 12))
            {
                return ", за окном дождливая зима...";
            }
            else
            {
                return "";
            }
        }


        /// <summary>
        /// Задание 3. Определить, является ли введённое пользователем число чётным.
        /// </summary>
        static void Task3()
        {
            Console.Write("Введите число: ");
            int a = int.Parse(Console.ReadLine());
            bool chet = a % 2 == 0;
            if (chet)
            {
                Console.WriteLine("Число четное");
            }
            else
            {
                Console.WriteLine("Число нечетное");
            }

        }

        /// <summary>
        /// Задание 4. Вывод чека в консоль.
        /// </summary>
        static void Task4()
        {
            DateTime Date = new DateTime(2022, 04, 22, 19, 11, 26);
            string item1 = "Number 9 large";
            string item2 = "Number 6 with extra dip";
            string item3 = "Number 45";
            string item4 = "Large soda";
            float price1 = 150.25F;
            float price2 = 102F;
            float price3 = 73.30F;
            float price4 = 54.75F;
            short amount1 = 1;
            short amount2 = 1;
            short amount3 = 2;
            short amount4 = 4;

            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("CLUCKIN' BELL");
            Console.WriteLine("Кассовый чек");

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте, Станислав!");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Меню: ");
            Console.WriteLine("1. Задания 1, 2, 5");
            Console.WriteLine("2. Задание 3");
            //Console.WriteLine("3. Задание 4");
            Console.WriteLine("4. Выход из приложения");
            Console.WriteLine("----------------------------------------------------");
            Console.Write("Выберите пункт меню для запуска задания: ");

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 4:
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine("...Завершение работы приложения...");
                    break;
                case 1:
                    Console.WriteLine("----------------------------------------------------");
                    Task125();
                    break;
                case 2:
                    Console.WriteLine("----------------------------------------------------");
                    Task3();
                    break;
                //case 3:
                //    Console.WriteLine("----------------------------------------------------");
                //    Task4();
                //    break;

            }

            //Task1();
            Console.ReadKey();
        }
    }
}
