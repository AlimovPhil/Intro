using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime CrntDate = DateTime.Now; //Объявляем метод, который будет выводить текущее время
            Console.Write("Пожалуйста, введите ваше имя: "); //Запрос имени у пользователя
            string Name = Console.ReadLine(); //Записываем введенное имя
            Console.WriteLine("************************************************************"); //Символы для лучшей читаемости последующего результата
            Console.WriteLine($"Здравствуйте, {Name}, сегодня {CrntDate.ToString("dddd, dd MMMM yyyy")}"); //Выводим полученное имя и сообщаем дату

            Console.ReadLine();
        }
    }
}
