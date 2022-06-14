using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Lesson9.Utils;

namespace Lesson9
{

    internal class Program
    {
        const int WINDOW_HEIGHT = 40; // Высота окна приложения;
        const int WINDOW_WIDTH = 140; // Ширина окна приложения
        private static string currentDir = Directory.GetCurrentDirectory();

        //TODO.. Set const buffer zone

        static void Main(string[] args)
        {
            Console.Title = "File Manager"; // Название окна

            Console.BackgroundColor = ConsoleColor.Black; // Цвет окна
            Console.ForegroundColor = ConsoleColor.DarkGreen; // Цвет шрифта

            Console.SetBufferSize(WINDOW_WIDTH, WINDOW_HEIGHT);
            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);

            DrawWindow(0,0,WINDOW_WIDTH,26);
            DrawWindow(0, 26, WINDOW_WIDTH, 10);
            UpdateConsole();

            Console.ReadLine();
        }

        /// <summary>
        /// Получить текущую позицию курсора
        /// </summary>
        /// <returns></returns>
        static (int left, int top) GetCursorPosition()
        {
            return (Console.CursorLeft,
                    Console.CursorTop);
        }

        /// <summary>
        /// Обработка процесса ввода команды
        /// </summary>
        /// <param name="width">Длина строки ввода</param>
        static void ProcessEnterCommand(int width)
        {
            (int left, int top) = GetCursorPosition();
            StringBuilder command = new StringBuilder();
            ConsoleKeyInfo keyInfo;
            char key;

            do
            {
                keyInfo = Console.ReadKey();
                key = keyInfo.KeyChar;

                if (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.UpArrow)
                    command.Append(key);

                (int currentLeft, int currentTop) = GetCursorPosition();

                if (currentLeft == width - 2)
                {
                    Console.SetCursorPosition(currentLeft - 1, top);
                    Console.Write(" ");
                    Console.SetCursorPosition(currentLeft - 1, top);
                }

                if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (command.Length > 0)
                        command.Remove(command.Length - 1, 1);
                    if (currentLeft >= left)
                    {
                        Console.SetCursorPosition(currentLeft, top);
                        Console.Write(" ");
                        Console.SetCursorPosition(currentLeft, top);
                    }
                    else
                    {
                        command.Clear();
                        Console.SetCursorPosition(left, top);
                    }
                }

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                //TODO вывод введенных команд нажатием стрелочки вверх
                }

            } 
            while (keyInfo.Key != ConsoleKey.Enter);
            
            ParseCommandString(command.ToString());
        }

        /// <summary>
        /// Обработка введенной команды
        /// </summary>
        /// <param name="command">Введенная команда</param>
        static void ParseCommandString(string command)
        {
            string[] commandParams = command.ToLower().Split(' ');
            if (commandParams.Length > 0)
            {
                switch (commandParams[0])
                {
                    case "cd":              //смена каталога и вывод дерева этого каталога
                        if (commandParams.Length > 1)
                            if (Directory.Exists(commandParams[1]))
                            {
                                currentDir = commandParams[1];
                                DrawTree(new DirectoryInfo(commandParams[1]), 1);
                                UpdateConsole();
                            }
                        break;

                    case "ls":              //вывод дерева введеного каталога с указанием начальной страницы отображения
                        if (commandParams.Length > 1 && Directory.Exists(commandParams[1]))
                            if (commandParams.Length > 3 && commandParams[2] == "-p" && int.TryParse(commandParams[3], out int n))
                            {
                                DrawTree(new DirectoryInfo(commandParams[1]), n);
                            }
                            else
                            {
                                DrawTree(new DirectoryInfo(commandParams[1]), 1);
                            }
                        break;

                    case "cp":
                        if (commandParams.Length > 1 && Directory.Exists(commandParams[1]))
                            if (commandParams.Length > 2) 
                            {
                               CopyDirectory(commandParams[1], commandParams[2]);
                            }

                        break;

                    // Копирование каталога
                    // cp C:\Source D:\Target

                    // Копирование файла
                    // cp C:\source.txt D:\target.txt

                    // Удаление каталога рекурсивно
                    // rm C:\Source

                    // Удаление файла
                    // rm C:\source.txt

                    // Вывод информации
                    // file C:\source.txt
                    case "help":
                        if (commandParams.Length == 1)
                            ShowHelp();
                        break;
                }
            }
            UpdateConsole();
        }

        /// <summary>
        /// Копирование всего каталога с вложенными папками и файлами
        /// </summary>
        /// <param name="sourceDir">Родительский каталог</param>
        /// <param name="destinationDir">Каталог назначения</param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        static void CopyDirectory(string sourceDir, string destinationDir)
        {
            // Собираем информацию о каталоге
            var dir = new DirectoryInfo(sourceDir);

            // Проверка на существование директории
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            // Собираем инфу о подпапках
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Создаем конечную папку (если её не существует)
            Directory.CreateDirectory(destinationDir);

            // Копируем все вложенные файлы в ориджин папке
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            // Рекурсивно проходим по вложенным папкам
            foreach (DirectoryInfo subDir in dirs)
            {
                string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                CopyDirectory(subDir.FullName, newDestinationDir);
            }
            
        }

        /// <summary>
        /// Вывод всех доступных команд
        /// </summary>
        static void ShowHelp()
        {
            string[] help = { "Список команд:",
                            "info - список всех команд",
                            "cd %path% - смена текущего каталога на введенный %путь%",
                            "ls %path% -p N - вывод дерева каталогов по указаному %пути% с указанием номера страницы",
                            "cp %source_path% %targer_path% - копирование каталога",
                            "cp %source_file_path% %target_file_path% - копирование файла",
                            "rm %path% - удаление каталога",
                            "rm %file_path% - удаление файла",
                            "file %file_path% - вывод инормации о файле" };
            for (int i = 0; i < help.Length; i++)
            {
                Console.SetCursorPosition(1, 1+i);
                Console.WriteLine(help[i]);
            }
        }

        /// <summary>
        /// Отобразить дерево каталогов
        /// </summary>
        /// <param name="dir">Директория</param>
        /// <param name="page">Страница</param>
        static void DrawTree(DirectoryInfo dir, int page)
        {
            StringBuilder tree = new StringBuilder();
            GetTree(tree, dir, "", true);
            
            DrawWindow(0, 0, WINDOW_WIDTH, 26);
            (int currentLeft, int currentTop) = GetCursorPosition();
            int pageLines = 24;
            string[] lines = tree.ToString().Split('\n');
            int pageTotal = (lines.Length + pageLines-1) / pageLines;
            if (page>pageTotal)
               page = pageTotal;

            for (int i = (page - 1)*pageLines, counter = 0; i < page*pageLines; i++, counter++)
            {
                if (lines.Length - 1 > i)
                {
                    Console.SetCursorPosition(currentLeft + 1, currentTop + 1 + counter);
                    Console.WriteLine(lines[i]);
                }
            }

            //Отрисуем футер
            string footer = $"┤ {page} of {pageTotal} ├";
            Console.SetCursorPosition(WINDOW_WIDTH / 2 - footer.Length / 2, 25);
            Console.WriteLine(footer);
        }

        /// <summary>
        /// Получение в виде строки иерархии всех файлов и папок по заданном пути
        /// </summary>
        /// <param name="tree">Строка с деревом папок и файлов</param>
        /// <param name="dir">Директория</param>
        /// <param name="indent">Отступ</param>
        /// <param name="lastDirectory">Проверка на конечность директории</param>
        static void GetTree(StringBuilder tree, DirectoryInfo dir, string indent, bool lastDirectory)
        {
            tree.Append(indent);
            if (lastDirectory)
            {
                tree.Append("└─");
                indent += "  ";
            }
            else
            {
                tree.Append("├─");
                indent += "│ ";
            }

            tree.Append($"{dir.Name}\n");


            FileInfo[] subFiles = dir.GetFiles();
            for (int i = 0; i < subFiles.Length; i++)
            {
                if (i == subFiles.Length - 1)
                {
                    tree.Append($"{indent}└─{subFiles[i].Name}\n");
                }
                else
                {
                    tree.Append($"{indent}├─{subFiles[i].Name}\n");
                }
            }


            DirectoryInfo[] subDirects = dir.GetDirectories();
            for (int i = 0; i < subDirects.Length; i++)
                GetTree(tree, subDirects[i], indent, i == subDirects.Length - 1);
        }

        /// <summary>
        /// Сокращение пути директории
        /// </summary>
        /// <param name="path">Путь к директории</param>
        /// <returns></returns>
        static string GetShortPath(string path)
        {
            StringBuilder shortPathName = new StringBuilder((int)API.MAX_PATH);
            API.GetShortPathName(path, shortPathName, API.MAX_PATH);
            return shortPathName.ToString();
        }


        /// <summary>
        /// Обновление ввода с консоли
        /// </summary>
        static void UpdateConsole()
        {
            DrawConsole(GetShortPath(currentDir), 0, 36, WINDOW_WIDTH, 3);
            ProcessEnterCommand(WINDOW_WIDTH);
        }

        /// <summary>
        /// Отрисовка области консоли
        /// </summary>
        /// <param name="dir">Начальная директория</param>
        /// <param name="x">Позиция окна Х</param>
        /// <param name="y">Позиция окна У</param>
        /// <param name="width">Ширина окна</param>
        /// <param name="height">Высота окна</param>
        static void DrawConsole(string dir, int x, int y, int width, int height)
        {
            DrawWindow(x, y, width, height);
            Console.SetCursorPosition(x + 1, y + 1);
            Console.Write($"{dir}>");
        }

        /// <summary>
        /// Отрисовка окна
        /// </summary>
        /// <param name="x">Начальная позиция по Х</param>
        /// <param name="y">Начальная позиция по У</param>
        /// <param name="width">Ширина окна</param>
        /// <param name="height">Высота окна</param>
        static void DrawWindow(int x, int y, int width, int height)
        {
            //шапка
            Console.SetCursorPosition(x,y);
            Console.Write("┌");
            for(int i = 0; i < width-2; i++)
                Console.Write("─");
            Console.Write("┐");

            //стенки
            Console.SetCursorPosition(x, y + 1);
            
            for (int i = 0; i < height-2; i++)
            {
                Console.Write("│");
                for (int j = x + 1; j < x + width - 1; j++)
                    Console.Write(" ");
                Console.Write("│");
            }

            ///подвал
            Console.Write("└");
            for (int i = 0; i < width - 2; i++)
                Console.Write("─");
            Console.Write("┘");
            Console.SetCursorPosition(x, y);
        }
    }
}
