/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace inheritance_sharp
{
    // инетрфейсы (реализуем)
    public class Human
    {
        int id;
        string FN;
        string LN;
        DateTime BD;
        public Human(string fn, string ln)
        {
            FN = fn;
            LN = ln;
        }

        public Human(string fn, string ln, int id_, DateTime bd)
        {
            FN = fn;
            LN = ln;
            id = id_;
            BD = bd;
        }

        *//*public override string ToString()
        {
            return $"{FN} {LN} {BD.ToShortDateString()} {id}";
        }*//*

        public void Print()
        {
            WriteLine($" {FN} {LN} {BD.ToShortDateString()} {id}");
        }
    }



   sealed public class Employee : Human // sealed - запрет на наследование класса в дальнейшем
    {
        double salary;
        public Employee(string fn, string ln) : base(fn, ln)
        {
            *//*FN = fn;
            LN = ln;
            id = id_;
            salary = salary_;*//*
        }

        public Employee(string fn, string ln, double salary_) : base(fn, ln)
        {
            salary = salary_;
        }

        public Employee(string fn, string ln, double salary_, DateTime dt, int id_) : base(fn, ln, id_, dt) // в том же порядке, что и родительский коуструктор!!!
        {

        }

        *//* public override string ToString()
         {

             return base.ToString() + $" {salary}"; // либо base.ToString() в качестве параметра в фигурных скобках
         }*//*

        public new void Print()
        {
            base.Print();
            WriteLine($"{salary}");
        }

    }



    

    internal class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new Employee("Sof", "Sur");
            Employee e2 = new Employee("Sof", "Sur", 23456);
            Employee e3 = new Employee("Sof", "Sur", 23456, DateTime.Now, 6);

            Employee[] employees = { e1, e2, e3 };

            foreach (var item in employees)
            {
                item.Print();
            }
        }
    }

}*/

/////////////////////////////////////////////////////////// 2 /////////////////////////////////////////////////////////
///
/// 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
namespace PV_ssh_221
{

    public class Human
    {
        string FName;
        string LName;
        DateTime BD;
        public Human(string _fn, string _ln)
        {
            FName = _fn;
            LName = _ln;
        }
        public Human(string _fn, string _ln, DateTime _date)
        {
            FName = _fn;
            LName = _ln;
            BD = _date;
        }
        //public override string ToString()
        //{
        //    return $" {id} {FName} {LName} {BD.ToShortDateString()}";
        //}
        public void Print()
        {
            Write($"  {FName} {LName} {BD.ToShortDateString()}");
        }

    }
    public class Employee : Human
    {
        double salary;
        public Employee(string fn, string ln) : base(fn, ln) { }
        public Employee(string fn, string ln, double _salary) : base(fn, ln)
        {
            salary = _salary;
        }
        public Employee(string fn, string ln, DateTime _date, double _salary) : base(fn, ln, _date)
        {
            salary = _salary;
        }

        //public override string ToString()
        //{
        //   return  $" {base.ToString()}  {salary}  ";
        //}
        public new void Print()
        {
            base.Print();
            WriteLine($" {salary} ");
        }
    }

    class Manager : Employee
    {
        string _fieldActivity;
        public Manager(string fName, string lName, DateTime date, double salary, string activity) : base(fName, lName, date, salary)
        {
            _fieldActivity = activity;
        }
        public void ShowManager()
        {
            WriteLine($"Менеджер. Сфера деятельности:{_fieldActivity}");
        }
    }
    class Scientist : Employee
    {
        string _scientificDirection;
        public Scientist(string fName, string lName, DateTime date, double salary, string direction) : base(fName, lName, date, salary)
        {
            _scientificDirection = direction;
        }
        public void ShowScientist()
        {
            WriteLine($"Ученый. Научное направление: {_scientificDirection}");
        }
    }
    class Specialist : Employee
    {
        string _qualification;
        public Specialist(string fName, string lName, DateTime date, double salary, string qualification) : base(fName, lName, date, salary)
        {
            _qualification = qualification;
        }
        public void ShowSpecialist()
        {
            WriteLine($"Специалист. Квалификация: { _qualification}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee manager = new Manager("John", "Doe", new DateTime(1995, 7, 23), 3500, "продукты питания");
            Employee[] employees = { manager,
                                       new Scientist("Jim", "Beam",new DateTime(1956,3,15), 4253, "история"),
                                       new Specialist("Jack", "Smith",new DateTime(1996,11,5), 2587.43,"физика")
};
            foreach (Employee item in employees)
            {
                item.Print();
                //item.ShowScientist(); Error
                //try
                //{
                //    ((Specialist)item). // явно приводим айтем к специалисту 
                //    ShowSpecialist(); // Способ №1
                //}
                //catch
                //{
                //}

                //Scientist scientist = item as Scientist; // Способ №2
                //if (scientist != null)
                //{
                //    scientist.ShowScientist();
                //}

                if (item is Manager) // Способ №3
                {
                    (item as Manager).ShowManager();
                }

                if (item is Scientist) // Способ №3
                {
                    (item as Scientist).ShowScientist();
                }

                if (item is Specialist) // Способ №3
                {
                    (item as Specialist).ShowSpecialist();
                }

            }
        }
    }
}
