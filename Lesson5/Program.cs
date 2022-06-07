using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;


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

        /// <summary>
        ///  2. Написать программу, которая при старте дописывает текущее время в файл «startup.txt»
        /// </summary>
        static void Task2()
        {
            string fileName = "startup.txt";
            DateTime time = DateTime.Now;
            File.AppendAllText(fileName, time.ToLongTimeString());
            File.AppendAllText(fileName, Environment.NewLine);
            Console.WriteLine("\nЗапись текущего времени в файл startup.txt прошла успешно!\n");

            Console.WriteLine("Вывести в консоль содержимое файла startup.txt?\n[1] - ДА\n[2] - НЕТ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        string fileText = File.ReadAllText(fileName);
                        Console.WriteLine(fileText);
                        Console.WriteLine("Завершение программы...");
                        break;
                    case 2: 
                        Console.WriteLine("Завершение программмы...");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Вы ввели недопустимый символ!");
                Console.WriteLine("Завершение программы...");
                return;
            }

            //Console.WriteLine(time.ToLongTimeString());
        }

        /// <summary>
        ///  3. Ввести с клавиатуры произвольный набор чисел(0...255) и записать их в бинарный файл.
        /// </summary>
        static string[] separator = { ",", ".", " ", "?", "!", ";", ":" };
        static byte[] StringToBytes(string input) //Метод преобразования строки в байты
        {
            string[] chars = input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            byte[] bytes = Array.ConvertAll(chars, byte.Parse);
            return bytes;
        }

        static void Task3()
        {
            string fileName = "bytes.bin";
            Console.WriteLine("Введите произвольный набор чисел от 0 до 255 через пробел");
            string input = Console.ReadLine();
            byte[] bytes = StringToBytes(input);
            File.WriteAllBytes(fileName, bytes);
            byte[] newData;
            using (var br = new BinaryReader(File.OpenRead(fileName)))
            {
                newData = br.ReadBytes(bytes.Length);
            }

            Console.Write($"Операция завершена!\nВы записали в файл {fileName} следующие данные:\n");
            for (var i = 0; i < newData.Length; i++)
            {
                Console.Write(newData[i] + " ");
            }
        }

        /// <summary>
        /// 4. (*) Сохранить дерево каталогов и файлов по заданному пути в текстовый файл — с рекурсией и без.
        /// </summary>
        static void Task4()
        {
            //ОПЕРАЦИИ С ДИРЕКТОРИЯМИ
            //DirectoryInfo directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            //Console.WriteLine("Full Name: {0}", directoryInfo.FullName);
            //Console.WriteLine("Name: {0}", directoryInfo.Name);
            //Console.WriteLine("Parent: {0}", directoryInfo.Parent);
            //Console.WriteLine("Creation time: {0}", directoryInfo.CreationTime);
            //Console.WriteLine("Attributes: {0}", directoryInfo.Attributes.ToString());
            //Console.WriteLine("Root: {0}", directoryInfo.Root);

            //Console.WriteLine(fileInfo.FullName);
            //Console.WriteLine(fileInfo.Name);
            //Console.WriteLine(fileInfo.CreationTime);
            //Console.WriteLine(fileInfo.Extension);

            //FileInfo[] fileInDir = directoryInfo.GetFiles(); //вывод всех файлов в заданной директории
            //for (var i = 0; i < fileInDir.Length; i++)
            //{
            //    Console.WriteLine(fileInDir[i].Name);
            //}

            Console.Clear();
            Console.WriteLine("Введите путь для сохранения.");
            string input = Console.ReadLine();
            PrintDir("dir.txt", new DirectoryInfo(input), "", true);
            Console.WriteLine("Запись в файл прошла успешно!");
            Console.ReadKey(true);

        }

        /// <summary>
        /// Распечатать список папок и файлов рекурсивным способом
        /// </summary>
        /// <param name="dir">Директория</param>
        /// <param name="indent">Отступ</param>
        /// <param name="lastDirectory">Признак "последней" директории</param>
        static void PrintDir(string fileName, DirectoryInfo dir, string indent, bool lastDirectory)
        {
            // Распечатываем отступ, далее переходим к печати ветви
            File.AppendAllText(fileName, indent);
            // В зависимости от признака lastDirectory, печатаем либо промежуточную ветвь, либо конечную
            File.AppendAllText(fileName, lastDirectory ? "└─" : "├─");
            indent += lastDirectory ? "  " : "│ ";
            // Распечатываем само наименование директории
            File.AppendAllText(fileName, $"{dir.Name}\n");

            // Получим все файлы текущей директории
            FileInfo[] subFiles = dir.GetFiles();
            // В цикле, пройдем по каждому файлу, распечатаем наименование файла как вложение к текущей директории
            for (int i = 0; i < subFiles.Length; i++)
                // Не забываем, и тут, файл тоже может оказаться последним в списке файлов
                if (i == subFiles.Length - 1)
                    File.AppendAllText(fileName, $"{indent}└─{subFiles[i].Name}\n");
                else
                    File.AppendAllText(fileName, $"{indent}├─{subFiles[i].Name}\n");

            // Теперь получим список всех поддерикторий текущей директории
            DirectoryInfo[] subDirects = dir.GetDirectories();
            for (int i = 0; i < subDirects.Length; i++)
                // И вот тут мы, рекурсивным способом, вызываем метод PrintDir
                PrintDir(fileName, subDirects[i], indent, i == subDirects.Length - 1);
        }
        

        /// <summary>
        /// 5. (*) Список задач(ToDo-list):
        /// ● написать приложение для ввода списка задач;
        /// ● задачу описать классом ToDo с полями Title и IsDone;
        /// ● на старте, если есть файл tasks.json/xml/bin(выбрать формат), загрузить из него массив имеющихся задач и вывести их на экран;
        /// ● если задача выполнена, вывести перед её названием строку «[x]»;
        /// ● вывести порядковый номер для каждой задачи;
        /// ● при вводе пользователем порядкового номера задачи отметить задачу с этим порядковым номером как выполненную;
        /// ● записать актуальный массив задач в файл tasks.json/xml/bin.
        /// </summary>



        static void Task5()
        {
            ToDo task1 = new ToDo();
            task1.AddTaskToTable();
            task1.ShowTask1();

        }

        static void Main(string[] args)
        {
            Console.Title = "Lesson 4";
            while (true)
            {
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("Список приложений: ");
                Console.WriteLine("1. Ввод с клавиатуры и сохранение в файл");
                Console.WriteLine("2. Дописать в файл Startup.txt текущее время");
                Console.WriteLine("3. Запись бинарного файла");
                Console.WriteLine("4*. Сохранение дерева каталогов и файлов в текстовый файл (с\\без рекурсии) (НЕ РЕШЕНО)");
                Console.WriteLine("5*. ToDo-list (НЕ РЕШЕНО)");
                Console.WriteLine("0. Выход из приложения");
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
                            Task5();
                            Console.ReadKey();
                            break;
                        case 0:
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
