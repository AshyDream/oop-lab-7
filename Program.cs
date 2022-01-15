using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleClassConlsole
{
    class Worker
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public Company WorkPlace { get; set; }

        public Worker(string Name, int Year, int Month, string[] WorkPlace)
        {
            this.Name = Name;
            this.Year = Year;
            this.Month = Month;
            this.WorkPlace = new Company(WorkPlace);
        }
        public int GetWorkExperience()
        {
            int totalMonth;
            DateTime date1 = new DateTime();
            TimeSpan date3 = new TimeSpan();
            DateTime date2 = new DateTime();
            date1 = date1.AddYears(DateTime.Now.Year); date1 = date1.AddMonths(DateTime.Now.Month);
            date2 = date2.AddYears(Year);  date2 = date2.AddMonths(Month);
            date3 = date1.Subtract(date2);
            totalMonth = date3.Days / 30;
            return totalMonth;
        }

        public void GetTotalMoney(ref int totalMonth)
        {
            int totalMoney;
            totalMoney = WorkPlace.Salary * totalMonth;
            Console.WriteLine($"Total Money: {totalMoney}");
        }
    }

    class Company
    {
        public string Name;
        public string Position;
        public int Salary;
        private Company workPlace;

        public Company(string[] company)
        {
            this.Name = company[0];
            this.Position = company[1];
            this.Salary = Convert.ToInt32(company[2]);
        }

        public Company(Company workPlace)
        {
            this.workPlace = workPlace;
        }
    }
    class Program
    {
        static Array ReadWorkersArray()
        {
            Console.WriteLine("Input number of structures: ");
            int n, Year, Month;
            while (!int.TryParse(Console.ReadLine(),out n))
            {
                Console.WriteLine("Input number of structures: ");
            }
            Console.WriteLine();
            Worker[] array = new Worker[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Input Name №{i}: ");
                string Name = Console.ReadLine();
                while(true)
                {
                    Console.WriteLine($"Input Year №{i}:");
                    string YearStr = Console.ReadLine();
                    while(!int.TryParse(YearStr,out Year))
                    {
                        Console.WriteLine($"Input Year №{i}:");
                        YearStr = Console.ReadLine();
                    }
                    break;
                }
                while(true)
                {
                    Console.WriteLine($"Input Month №{i}:");
                    string MonthStr = Console.ReadLine();
                    while(!int.TryParse(MonthStr, out Month))
                    {
                        Console.WriteLine($"Input Month №{i}:");
                        MonthStr = Console.ReadLine();
                    }
                    break;
                }
                Console.WriteLine($"Input Company №{i}:");
                string[] WorkPlace = InputWorkPlace();
                array[i] = new Worker(Name, Year, Month, WorkPlace);
            }
            return array;
        }

        static string[] InputWorkPlace()
        {
            int Salary;
            string[] a = new string[3];
            Console.WriteLine("Input Name of Company:");
            a[0] = Console.ReadLine();
            Console.WriteLine("Input Position of Company:");
            a[1] = Console.ReadLine();
            while(true)
            {
                Console.WriteLine("Input Salary:");
                string SalaryStr = Console.ReadLine();
                while(!int.TryParse(SalaryStr, out Salary))
                {
                    Console.WriteLine("Input Salary:");
                    SalaryStr = Console.ReadLine();
                }
                break;
            }
            a[2] = Convert.ToString(Salary);
            return a;
        }

        static void PrintWorker(Worker worker)
        {
            Console.WriteLine($"Name: {worker.Name}");
            Console.WriteLine($"Year: {worker.Year}");
            Console.WriteLine($"Month: {worker.Month}");
            Console.WriteLine("Company:");
            Console.WriteLine($"Name: {worker.WorkPlace.Name}");
            Console.WriteLine($"Position: {worker.WorkPlace.Position}");
            Console.WriteLine($"Salary: {worker.WorkPlace.Salary}");
            Console.WriteLine("______________________________________________");
        }

        static void PrintWorkers(Worker[] worker)
        {
            for (int i = 0; i < worker.Length; i++)
            {
                Console.WriteLine($"Worker №{i}");
                PrintWorker(worker[i]);
            }
        }

        static void GetWorkersInfo(Worker[] workers, out int min, out int max)
        {
            min = 0; max = 0;
            min = workers[0].WorkPlace.Salary;
            for(int i = 0; i < workers.Length; i++)
            {
                int Salary = workers[i].WorkPlace.Salary;
                if (min > Salary)
                    min = Salary;
                if (max < Salary)
                    max = Salary;
            }
        }

        static void SortWorkerBySalary(ref Worker[] workers) 
        {
            Array.Sort(workers, new SalaryComparer()); 
        }

        static void SortWorkerByWorkExperience(ref Worker[] workers)
        {
            Array.Sort(workers, new ExperienceComparer());
        }

        static void Main(string[] args)
        {
            Worker[] worker = null;
            /* worker = (Worker[])ReadWorkersArray();
            PrintWorkers(worker);
            Console.WriteLine($"Total Experience: {worker[0].GetWorkExperience()}");
            int n = worker[0].GetWorkExperience();
            worker[0].GetTotalMoney(ref n); */
            int ch;
            do
            {
                ShowMenu();
                Console.WriteLine("\n->");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                        worker = (Worker[])ReadWorkersArray();
                        Console.ResetColor();
                        break;
                    case 2:
                        Console.Clear();
                        if (worker == null)
                        {
                            Console.WriteLine("ERROR, FIRST ADD INFORMATION");
                            break;
                        }
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        Console.WriteLine("1 - By ID");
                        Console.WriteLine("2 - All array");
                        Console.WriteLine("0 - Exit");
                        Console.WriteLine("\n->");
                        int check;
                        check = Convert.ToInt32(Console.ReadLine());

                        switch (check)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Write ID: ");
                                Console.WriteLine("\n->");
                                int nn;
                                nn = Convert.ToInt32(Console.ReadLine());
                                PrintWorker(worker[nn]);
                                break;
                            case 2:
                                Console.Clear();
                                PrintWorkers(worker);
                                break;
                        }
                        Console.ResetColor();
                        break;
                    case 3:
                        Console.Clear();
                        if (worker == null)
                        {
                            Console.WriteLine("ERROR, FIRST ADD INFORMATION");
                            break;
                        }
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("1 - By Salary");
                        Console.WriteLine("2 - By Experience");
                        Console.WriteLine("0 - Exit");
                        Console.WriteLine("\n->");
                        int chk;
                        chk = Convert.ToInt32(Console.ReadLine());
                        switch (chk)
                        {
                            case 1:
                                SortWorkerBySalary(ref worker);
                                break;
                            case 2:
                                SortWorkerByWorkExperience(ref worker);
                                break;
                        }
                        Console.ResetColor();
                        break;
                    case 4:
                        Console.Clear();
                        if (worker == null)
                        {
                            Console.WriteLine("ERROR, FIRST ADD INFORMATION");
                            break;
                        }
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                        int min, max;
                        GetWorkersInfo(worker, out min, out max);
                        Console.WriteLine($"Min Salary: {min} \n Max Salary: {max}");
                        Console.ResetColor();
                        break;
                }

            } while (ch != 0);
        }
        static void ShowMenu()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" MENU ");
            Console.WriteLine("1 - Read Workers Array\n" +
            "2 - Print Array\n" +
            "3 - Sort Workers Array\n" +
            "4 - Information about min and max Salary\n" +
            "0 - Exit\n");
            Console.ResetColor();
        }
    }

    class SalaryComparer : IComparer<Worker>
    {
        public int Compare(Worker worker1, Worker worker2)
        {
            int worker1Salary = worker1.WorkPlace.Salary;
            int worker2Salary = worker2.WorkPlace.Salary;
            if (worker1Salary > worker2Salary)
                return 1;
            else if (worker1Salary < worker2Salary)
                return -1;
            else
                return 0;
        }
    }
    
    class ExperienceComparer : IComparer<Worker>
    {
        public int Compare(Worker worker1, Worker worker2)
        {
            int worker1Experience = worker1.GetWorkExperience();
            int worker2Experience = worker2.GetWorkExperience();
            if (worker1Experience > worker2Experience)
                return 1;
            else if (worker1Experience < worker2Experience)
                return -1;
            else
                return 0;
        }
    }
}

