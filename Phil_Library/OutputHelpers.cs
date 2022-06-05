using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8.TestLib
{
    public class OutputHelpers
    {
        public static void HwHeader(int lesson, string name)
        {
            Console.WriteLine($"Домашняя работа. Урок {lesson}.\nВыполнил студент: {name}.");
            Console.WriteLine("******************************************\n");
        }
    }
}
