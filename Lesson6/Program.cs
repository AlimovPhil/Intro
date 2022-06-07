using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lesson6
{
    internal class Program
    {
        /// <summary>
        /// Написать консольное приложение Task Manager (?), которое выводит на экран запущенные процессы и позволяет завершить указанный процесс. 
        /// Предусмотреть возможность завершения процессов спомощью указания его ID или имени процесса.
        /// </summary>
        
        // Вывод на экран всех запущенных процессов
        static void ListOfAllProcesses()
        {
            Console.WriteLine("Список всех выполняемых процессов: ");
            Process[] processes = Process.GetProcesses(".");
            foreach (Process p in processes)
            {
                string info = $"=> PID: {p.Id}\t Name: {p.ProcessName}";
                Console.WriteLine(info);
            }
            Console.WriteLine(String.Empty);
        }

        // Убиваем выбранный процесс
        static void KillProcess()
        {
            Console.WriteLine("Введите PID или Название процесса чтобы его закрыть: ");

            Process proc = null;
            string input = Console.ReadLine();

            if (int.TryParse(input, out int a))
            {
                try
                {
                    proc = Process.GetProcessById(a);
                    proc.Kill();
                }
                catch (ArgumentException ex) {Console.WriteLine(ex.Message);}
            }
            else
            {
                try
                {
                    foreach (var process in Process.GetProcessesByName(input))
                    {
                        process.Kill();
                    }
                }
                catch (InvalidOperationException ex) {Console.WriteLine(ex.Message);}
            }
            
            Console.WriteLine("Процесс завершен!\nВозврат в меню...");
        }
        static void Main(string[] args)
        {
            Console.Title = "Task Manager";
            while (true)
            {
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("TASK MANAGER");
                Console.WriteLine("1. Список всех запущенных процессов:");
                Console.WriteLine("2. Закрыть процесс");
                Console.WriteLine("0. Выход из приложения");
                Console.WriteLine("----------------------------------------------------");
                Console.Write("Выберите пункт меню для запуска задания: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("----------------------------------------------------");
                            ListOfAllProcesses();
                            break;
                        case 2:
                            Console.WriteLine("----------------------------------------------------");
                            KillProcess();
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
