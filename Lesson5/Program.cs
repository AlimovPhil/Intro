using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

/* 2. Написать программу, которая при старте дописывает текущее время в файл
«startup.txt».
3. Ввести с клавиатуры произвольный набор чисел (0...255) и записать их в бинарный
файл.
4. (*) Сохранить дерево каталогов и файлов по заданному пути в текстовый файл — с
рекурсией и без.
5. (*) Список задач(ToDo-list):
● написать приложение для ввода списка задач;
● задачу описать классом ToDo с полями Title и IsDone;
● на старте, если есть файл tasks.json/xml/bin (выбрать формат), загрузить
из него массив имеющихся задач и вывести их на экран;
● если задача выполнена, вывести перед её названием строку «[x]»;
● вывести порядковый номер для каждой задачи;
● при вводе пользователем порядкового номера задачи отметить задачу с этим
порядковым номером как выполненную;
● записать актуальный массив задач в файл tasks.json/xml/bin.*/


namespace Lesson5
{
    internal class Program
    {
        /// <summary>
        /// 1.Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл.
        /// ***Добавил немного своего кода, чтобы закрепить методы работы с классом File.
        /// </summary>
        static void Task1()
        {
            string fileName = "Test_File.txt"; //Название текстового файла
            string input = Console.ReadLine();
            string txt1 = "WAKE UP, NEO...";
            string txt2 = "  FOLLOW THE WHITE RABBIT... \n";
            string[] txt3 = new string[] { "MORE TEXT. IS IT ENOUGH?" };
            
            File.WriteAllText(fileName, input); //Создание текстового файла с введенными даннами с клавиатуры (input)
            
            File.AppendAllText(fileName, Environment.NewLine); //Добавление в файл переноса строки 
            
            File.AppendAllText(fileName, txt1 + txt2); //Добавление в файл строк "txt1" и "txt2"
            
            File.AppendAllLines(fileName, txt3); //Добавление массива строк
            
            Console.WriteLine($"Данные записаны в файл {fileName}\nВ файле находится следующее содержимое:");
            string fileText = File.ReadAllText(fileName); //Открывает файл и считывает весь текст в виде строки
            //File.ReadAllLines(fileName); - Открывает файл и считывает весь текст в виде НАБОРА СТРОК
            Console.WriteLine(fileText);

        }

        static void Main(string[] args)
        {
            Console.Title = "Lesson 4";
            while (true)
            {
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("Список приложений: ");
                Console.WriteLine("1. Ввод с клавиатуры и сохранение в файл");
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
                            //Task2();
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.WriteLine("----------------------------------------------------");
                            //Task3();
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.WriteLine("----------------------------------------------------");
                            //Task4();
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
