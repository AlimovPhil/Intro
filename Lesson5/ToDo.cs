﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
5. (*) Список задач(ToDo-list):
● написать приложение для ввода списка задач;
● задачу описать классом ToDo с полями Title и IsDone;
● на старте, если есть файл tasks.json/xml/bin (выбрать формат), загрузить из него массив имеющихся задач и вывести их на экран; -
● если задача выполнена, вывести перед её названием строку «[x]»; 
● вывести порядковый номер для каждой задачи;
● при вводе пользователем порядкового номера задачи отметить задачу с этим порядковым номером как выполненную;
● записать актуальный массив задач в файл tasks.json/xml/bin.*/
namespace Lesson5
{
    public class ToDo
    {
        #region Fields
        
        /// <summary>
        /// Название задачи
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Признак выполнения задачи
        /// </summary>
        public bool IsDone { get; set; }

        #endregion

        public ToDo() //конструктор
        {

        }

        /// <summary>
        /// Создает заметку с параметрами
        /// </summary>
        /// <param name="Title">Название задачи</param>
        /// <param name="IsDone">Признак выполнения</param>
        public ToDo(string Title)
        {
            this.Title = Title;

        }


        public List<string> Tasks = new List<string>();


        public void AddTaskToTable()
        {
            ToDo Task = new ToDo();
            Task.Title = Console.ReadLine();
            Tasks.Add(Title);
        }

        public void ShowTask1()
        {
            string output = Tasks[0];
            Console.WriteLine(output);
        }
        

        public string TaskDone(int a)
        {
            if (a == 1)
            {
                this.IsDone = true;
                return "[x]" + Title;
            }
            else return Title;
            
        }
        

    }
}
