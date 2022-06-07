using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson8.TestLib;

namespace Lesson8
{
    internal class Program
    {

        // Создать консольное приложение, которое при старте выводит приветствие, записанное в настройках приложения(application-scope).
        // Запросить у пользователя имя, возраст и род деятельности, а затем сохранить данные в настройках.
        // При следующем запуске отобразить эти сведения.Задать приложению версию и описание.

        static void Main(string[] args)
        {
            OutputHelpers.HwHeader(8, "Алимов Филипп Рашидович"); // Вспомогательный метод из доп. библиотеки для вывода шапки

            Console.WriteLine(Properties.Settings.Default.Greeting); // Приветствие

            if (string.IsNullOrEmpty(Properties.Settings.Default.UserName)) // Имя
            {
                Console.Write("Введите имя пользователя: ");
                Properties.Settings.Default.UserName = Console.ReadLine();
                Properties.Settings.Default.Save();
            }

            if (Properties.Settings.Default.UserAge == 0) // Возраст
            {
                Console.Write("Введите возраст пользователя: ");
                Properties.Settings.Default.UserAge = int.Parse(Console.ReadLine());
                Properties.Settings.Default.Save();
            }

            if (string.IsNullOrEmpty(Properties.Settings.Default.UserOccupation)) // Род занятий
            {
                Console.Write("Введите род занятий: ");
                Properties.Settings.Default.UserOccupation = Console.ReadLine();
                Properties.Settings.Default.Save();
            }

            string userName = Properties.Settings.Default.UserName;
            int userAge = Properties.Settings.Default.UserAge;
            string userOccupation = Properties.Settings.Default.UserOccupation;
            Console.WriteLine($"Имя пользователя: {userName}\nВозраст: {userAge}\nРод деятельности: {userOccupation}");


            Console.ReadKey(true);
        }
    }
}
