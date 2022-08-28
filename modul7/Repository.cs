using System;
using System.IO;
using System.Linq;

namespace modul7
{
    internal class Repository
    {
        public Worker[] workers;
        private string path;
        int index;

        public int id;
        public DateTime addDate;
        public string fio;
        public int age;
        public int growth;
        public DateTime birthDate;
        public string birthPlace;

        public Repository(string Path)
        {
            this.path = Path;
            this.index = 0;
            this.workers = new Worker[100];
        }

        //запись данных из файла в массив
        public Worker[] GetAllWorkers()
        {
            using (StreamReader sr = new StreamReader(this.path))
            {

                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');
                    this.workers[index] = new Worker(Convert.ToInt32(args[0]), Convert.ToDateTime(args[1]), args[2], Convert.ToInt32(args[3]), Convert.ToInt32(args[4]), Convert.ToDateTime(args[5]), args[6]);
                    this.index++;
                }
            }
            return workers;
        }

        //печать по ID
        public Worker GetWorkerById(int ID)
        {
            using (StreamReader sr = new StreamReader(this.path))
            {
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');
                    if (Convert.ToInt32(args[0]) == ID)
                    {
                        Console.WriteLine($"{args[0]} {args[1]} {args[2]} {args[3]} {args[4]} {args[5]} {args[6]}");
                    }
                }
            }
            return this.workers[ID];
        }

        //печать в консоль
        public void PrintDbToConsole()
        {

            using (var sr = new StreamReader(this.path))
            {
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');
                    Console.WriteLine($"{args[0]} {args[1]} {args[2]} {args[3]} {args[4]} {args[5]} {args[6]}");
                    this.index++;
                }
            }

        }

        //удаление строки
        public void DeleteWorker(int ID)
        {
            using (StreamReader sr = new StreamReader(this.path))
            using (StreamWriter sw = new StreamWriter(@"data1.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');
                    if (Convert.ToInt32(args[0]) != ID)
                    {
                        sw.WriteLine($"{args[0]}#{args[1]}#{args[2]}#{args[3]}#{args[4]}#{args[5]}#{args[6]}");
                    }
                }
            }
            File.Delete(this.path);
            File.Move(@"data1.txt", this.path);
            PrintDbToConsole();
        }


        //добавление строки
        public void AddWorker(Worker worker)
        {
            Console.WriteLine("\nВведите данные сотрудника");

            Console.Write("ФИО: ", 5);
            string fio = Console.ReadLine();

            Console.Write("возраст: ", 5);
            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("рост: ", 5);
            int growth = Convert.ToInt32(Console.ReadLine());

            Console.Write("дата рождения: ", 5);
            DateTime birthDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("место рождения: ", 5);
            string birthPlace = Console.ReadLine();

            this.workers[index] = new Worker(id, DateTime.Now, fio, age, growth, birthDate, birthPlace);
            this.index++;


            var fileContent = new FileInfo(this.path); //проверка файла на содержимое
            if (fileContent.Length == 0)
            {
                using (StreamWriter sw = new StreamWriter(this.path, true))
                {
                    sw.WriteLine($"{"1"}#{DateTime.Now:g}#{fio}#{age}#{growth}#{birthDate.ToString("dd.MM.yyyy")}#{birthPlace}");
                    Console.WriteLine($"Сотрудник успешно добавлен, присвоен уникальный ID: 1");
                }
            }

            else
            {
                string lastLine = File.ReadAllLines(this.path).Last();
                string[] lastLineArr = lastLine.Split('#');
                int lastLineID = Convert.ToInt32(lastLineArr[0]);

                using (StreamWriter sw = new StreamWriter(this.path, true))
                {
                    sw.WriteLine($"{lastLineID + 1}#{DateTime.Now:g}#{fio}#{age}#{growth}#{birthDate.ToString("dd.MM.yyyy")}#{birthPlace}");
                    Console.WriteLine($"Сотрудник успешно добавлен, присвоен уникальный ID: {lastLineID + 1}");
                }
            }
                

            
            //Console.WriteLine("\nВведите данные следующего сотрудника:");

            
        }

        //выборка между дат
        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            using (StreamReader sr = new StreamReader(this.path, true))
            {

                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');
                    if ((Convert.ToDateTime(args[1]) > dateFrom) && (Convert.ToDateTime(args[1]) < dateTo))
                    {
                        Console.WriteLine($"{args[0]} {args[1]} {args[2]} {args[3]} {args[4]} {Convert.ToDateTime(args[5])} {args[6]}");
                    }
                    this.workers[index] = new Worker(Convert.ToInt32(args[0]), Convert.ToDateTime(args[1]), args[2], Convert.ToInt32(args[3]), Convert.ToInt32(args[4]), Convert.ToDateTime(args[5]), args[6]);
                    this.index++;
                }
                return this.workers;
            }
        }
    }
}
