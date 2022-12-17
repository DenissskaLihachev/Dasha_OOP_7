using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public abstract class  Human    //основной абстрактный класс, его наследуют классы Employee и Learner
    {
        public abstract string Name { get; set; }   //имя
        public abstract int Age { get; set; }   //возраст
        public abstract string Gender { get; set; } //пол
        public abstract void Print();   //вывод полей
    }
    ///////////////////////////////////////
    public abstract class Employee : Human  //абстрактный класс сотрудник, наследуется от абстрактного класса Human
    {
        private string name;    //имя
        //свойсво поля имя
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }   

        private int age;    //возраст
        //свойство поля возраст
        public override int Age
        {
            get { return age; }
            set { if (value > 18) age = value; }
        }   

        private string gender;  //пол
        //свойство поля пол
        public override string Gender
        {
            get { return gender; }
            set { gender = value; }
        }   

        private int salary; //зарплата
        //свойство поля пол
        public int Salary
        {
            get { return salary; }
            set { if (value >= 0) salary = value; }
        }   

        private int experience; //опыт работы
        //свойсво поля опыт работы
        public int Experience
        {
            get { return experience; }
            set { if (value >= 0) experience = value; }
        }

        public abstract int Calc_Salary();  //метод высчитывания заплаты

        //вывод полей
        public override void Print()
        {
            Console.WriteLine($"Имя - [{name}] | Возраст - [{age}] | Пол - [{gender}] | Стаж - [{experience}] | Оклад - [{salary}]");
        }
        //вывод полей вместе с зарплатой
        static public void Print_Salary(List<Employee> employees)
        {
            foreach (var employee in employees)
                Console.WriteLine($"Имя - [{ employee.Name}] | Возвраст - [{employee.Age}] | Пол - [{employee.Gender}] | Стаж - [{employee.Experience}] | Зарплата - [{employee.Calc_Salary()}]");
            Console.WriteLine();
        }
    }
    public class Director : Employee    //класс директор, наследуется от Employee
    {
        //конструктор по умолчанию
        public Director()
        {
            Name = "Undefined";
            Age = 100;
            Gender = "Undefined";
            Patronymic = "Undefined";
            Salary = 0;
            Experience = 0;
        }
        //конструктор с параметрами
        public Director(string name, string patronymic, int age, string gender, int salary, int experience)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Patronymic = patronymic;
            Salary = salary;
            Experience = experience;
        }

        private string patronymic;  //отчетсво
        //свойсто поля отчество
        public string Patronymic
        {
            get { return patronymic; }
            set { patronymic = value; }
        }
        //вывод полей
        public override void Print()
        {
            Console.WriteLine($"Имя - [{Name}] | Отчество - [{patronymic}] | Возраст - [{Age}] | Пол - [{Gender}] | Стаж - [{Experience}] | Оклад - [{Salary}]");
        }
        //вывод полей вместе с зарплатой
        public override int Calc_Salary()
        {
            double period_of_service = this.Experience > 20 ? 0.20 : this.Experience * 0.01;
            return (int)Math.Round(period_of_service * this.Salary + this.Salary);
        }
    }
    public class Worker : Employee  //класс работник наследуется от Employee
    {
        //конструктор по умолчанию
        public Worker()
        {
            Name = "Undefined";
            Age = 100;
            Gender = "Undefined";
            Post = "undefined";
            Salary = 0;
            Experience = 0;
        }
        //конструктор с параметрами
        public Worker(string name, int age, string gender, string post, int salary, int experience)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Post = post;
            Salary = salary;
            Experience = experience;
        }

        private string post;    //должность
        //свойство поля должность
        public string Post
        {
            get { return post; }
            set { post = value; }
        }
        //вывод полей
        public override void Print()
        {
            Console.WriteLine($"Имя - [{Name}] | Возраст - [{Age}] | Пол - [{Gender}] | Должность - [{Post}] | Стаж - [{Experience}] | Оклад - [{Salary}]");
        }
        //вывод полей вместе с зарплатой
        public override int Calc_Salary()
        {
            double period_of_service;
            if (this.Experience < 5)
                period_of_service = this.Experience * 0.01;
            else if (this.Experience == 5)
                period_of_service = 0.05;
            else if (this.Experience > 5 && this.Experience < 10)
                period_of_service = this.Experience * 0.01 + 0.05;
            else
                period_of_service = 0.1;
            return (int)Math.Round(period_of_service * this.Salary + this.Salary);
        }
    }
    ///////////////////////////////////////
    public abstract class Learner : Human   //абстрактный класс учащийся, наследуется от абстрактного класса Human
    {
        private string name;    //имя
        //свойство поля имя
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int age;    //возраст
        //свойство поля возраст
        public override int Age
        {
            get { return age; }
            set { age = value; }
        }

        private string gender;  //пол
        //свойство поля пол
        public override string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        //вывод полей
        public override void Print()
        {
            Console.WriteLine($"Имя - [{name}] | Возраст - [{age}] | Пол - [{gender}]");
        }
    }
    public class Schoolboy : Learner    //класс школьник, наследуется от класса Learner
    {
        //конструктор по умолчанию
        public Schoolboy()
        {
            Name = "Undefined";
            Age = 100;
            Gender = "Undefined";
            Clas = 0;
        }
        //конструктор с параметрами
        public Schoolboy(string name, int age, string gender, int clas)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Clas = clas;
        }

        private int?[] marks = new int?[11];    //массив среднегодовая оценка за класс (11 классов)
        //свойство поля оценки
        public int?[] Marks
        {
            get => marks;
            set
            {
                int j = 0;
                for (int i = 0; i < marks.Length; i++)
                {
                    if (value.Length <= i) marks[j] = null;
                    else if (value[i] < 6 && value[i] > 0) { marks[j] = value[i]; j++; }
                    else continue;
                }
            }
        }
        private int cur_class;  //текущий класс
        //свойство текущий класс
        public int Cur_Class
        {
            get
            {
                for (int i = 0; i < marks.Length; i++)
                    if (marks[i] != null)
                        cur_class = i + 1;
                return ++cur_class;
            }
        }
        private int next_mark;  //следующая оценка (прогноз оценки на текущий класс)
        //свойсвтво поля следующая оценка
        public int Next_Mark
        {
            get
            {
                next_mark = GeneralizedClass<Schoolboy>.Forecast(marks);
                return next_mark;
            }
        }


        private int clas;   //класс
        //свойство поля класс
        public int Clas
        {
            get { return clas; }
            set { if(value >= 0 && value < 11) clas = value; }
        }
        //вывод полей
        public override void Print()
        {
            Console.WriteLine($"Имя - [{Name}] | Возраст - [{Age}] | Пол - [{Gender}] | Класс - [{Clas}]");
        }
        //возвращает строку со всеми полями
        public override string ToString()
        {
            string marks = "";
            for (int i = 0; i < this.Marks.Length; i++)
                marks += this.Marks[i] + " ";
            return "Имя - [" + this.Name + "] | Возвраст - [" + this.Age + "] | Пол - [" + Gender + "] | Класс - [" + Clas + "] | Оценки - [" + marks + "] Прогноз оценики - [" + this.Next_Mark + "] Текущий класс - [" + this.Cur_Class + "]\n";
        }
    }
    public class Student : Learner  //класс студент, наследуется от класса Learner
    {
        //конструктор по умолчанию
        public Student()
        {
            Name = "Undefined";
            Age = 100;
            Gender = "Undefined";
            Specialization = "Undefined";
        }
        //конструктор с параметрами
        public Student(string name, int age, string gender, string specialization)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Specialization = specialization;
        }

        private int?[] marks = new int?[8]; //массив оценок за семестр
        //свойство поля оценка
        public int?[] Marks
        {
            get => marks;
            set
            {
                for (int i = 0; i < marks.Length; i++)
                {
                    if (value.Length <= i) marks[i] = null;
                    else marks[i] = value[i];
                }
            }
        }
        private int next_mark;  //следующая оценка (предсказание на оценку на текущий семестр)
        //свойство поля следующая оценка
        public int Next_Mark
        {
            get
            {
                ///////tut///////
                next_mark = GeneralizedClass<Student>.Forecast(marks);
                return next_mark;
            }
        }
        private int cur_semestr;    //текущий семестр
        //свойство поля текущий семестр
        public int Cur_Semestr
        {
            get
            {
                for (int i = 0; i < marks.Length; i++)
                    if (marks[i] != null)
                    {
                        if ((i + 1) % 2 == 0)
                            cur_semestr = (i) / 2;
                        else
                            cur_semestr = (i + 1) / 2;
                    }
                return ++cur_semestr;
            }
        }

        private string specialization;  //специальность
        //свойство поля специальность
        public string Specialization
        {
            get { return specialization; }
            set { specialization = value; }
        }
        //вывод полей
        public override void Print()
        {
            Console.WriteLine($"Имя - [{Name}] | Возраст - [{Age}] | Пол - [{Gender}] | Специальность - [{Specialization}]");
        }
        //возвращает строку со всеми полями
        public override string ToString()
        {
            string marks = "";
            for (int i = 0; i < this.Marks.Length; i++)
                marks += this.Marks[i] + " ";
            return "Имя - [" + this.Name + "] Возвраст - [" + this.Age + "] | Пол - [" + Gender + "] | Специальность - [" + this.Specialization + "] Оценки - [" + marks + "] Прогноз оценки - [" + this.Next_Mark + "] Текущий курс - [" + this.Cur_Semestr + "]\n";
        }
    }

    public static class GeneralizedClass<T> where T : Learner   //обобщенный класс
    {
        
        //Возврат элемент из массива данных (если индекс элемента неправильный, то вернуть null).
        //Вывести данные всех элементов массива (используйте метод Вывод).
        //Сделать Прогноз для каждого элемента массива.
        

        public static Learner Get(List<Learner> learners, int index)
        {
            if (index < learners.Count)
                return learners[index];
            else
                return null;
        }
        public static void Print(List<Learner> learners)
        {
            learners.ForEach(x => Console.WriteLine(x.ToString()));
        }
        public static int Forecast(int?[] marks)
        {
            int summ = 0;
            int count = 0;
            for (int i = 0; i < marks.Length; i++)
            {
                if (marks[i] == null) break;
                summ += (int)marks[i];
                count = i + 1;
            }
            return (int)summ / count;
        }
    }
}
