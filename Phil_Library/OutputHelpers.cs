using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8.TestLib
{
    public static class OutputHelpers
    {
        /// <summary>
        /// Выводит информацию по домашней работе.
        /// </summary>
        /// <param name="lesson"> Номер урока</param>
        /// <param name="name"> ФИО студента</param>
        public static void HwHeader(int lesson, string name)
        {
            Console.WriteLine($"Домашняя работа. Урок {lesson}.\nВыполнил студент: {name}.");
            Console.WriteLine("******************************************\n");
        }
    }
}
