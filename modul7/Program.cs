using System;
using System.IO;
using System.Linq;

namespace modul7
{
    internal class Program
    {
        public static void Sort(string[] lines, Worker[] workerSort)
        {
            for (int j = 0; j < lines.Length; j++)
            {
                Console.WriteLine($"{workerSort[j].ID} {workerSort[j].AddDate} {workerSort[j].FIO} {workerSort[j].Age} {workerSort[j].Growth} {workerSort[j].BirthDate} {workerSort[j].BirthPlace}");
            }
        }

        static void Main(string[] args)
        {
            string path = @"data.txt"; //файл

            StreamWriter sw1 = (File.Exists(path)) ? File.AppendText(path) : File.CreateText(path); //проверка файла, создание если нет
            sw1.Close();

            Repository rep = new Repository(path);
            // rep.GetAllWorkers(); //загрузка файла
            Console.WriteLine("Запущен ежедневник, выберите опцию:");
        afterLoops:
            Console.WriteLine("1 - вывод на экран всего файла ежедневника," +
                " \n2 - вывод на экран по ID," +
                " \n3 - создание записи," +
                " \n4 - удаление записи," +
                " \n5 - вывод в рамках заданных дат" +
                " \n6 - вывод с сортировкой заданных полей");
            Console.Write("Опция: ");
            int vibor = Int32.Parse(Console.ReadLine());
            while (true)
            {
                if (vibor == 1) //вывод на экран всего файла
                {
                    rep.PrintDbToConsole();

                    Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню");
                    if (Console.ReadLine() == "")
                    {
                        goto afterLoops;
                    }
                }

                else if (vibor == 2) //вывод на экран по ID
                {
                    while (true)
                    {
                        Console.Write("Введите ID сотрудника: ");
                        int ID = Int32.Parse(Console.ReadLine());
                        rep.GetWorkerById(ID);

                        Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню");
                        if (Console.ReadLine() == "")
                        {
                            goto afterLoops;
                        }
                    }
                }

                else if (vibor == 3) //создание записи
                {
                    rep.AddWorker(new Worker(rep.id, rep.addDate, rep.fio, rep.age, rep.growth, rep.birthDate, rep.birthPlace));

                    Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню");
                    if (Console.ReadLine() == "")
                    {
                        goto afterLoops;
                    }
                }

                else if (vibor == 4) //удаление записи
                {
                    Console.Write("Введите ID сотрудника, которого необходимо удалить: ");
                    int ID = Int32.Parse(Console.ReadLine());
                    rep.DeleteWorker(ID);

                    Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню");
                    if (Console.ReadLine() == "")
                    {
                        goto afterLoops;
                    }
                }

                else if (vibor == 5) //вывод с выборкой по дате
                {
                    Console.Write("Введите начальную дату: ");
                    DateTime dateFrom = Convert.ToDateTime(Console.ReadLine());

                    Console.Write("Введите конечную дату: ");
                    DateTime dateTo = Convert.ToDateTime(Console.ReadLine());

                    rep.GetWorkersBetweenTwoDates(dateFrom, dateTo);

                    Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню");
                    if (Console.ReadLine() == "")
                    {
                        goto afterLoops;
                    }
                }

                else if (vibor == 6) //вывод с сортировкой полей
                {
                    string[] lines = File.ReadAllLines(path);
                    Worker[] worker = new Worker[lines.Length];
                    int i = 0;
                    foreach (string line in lines)
                    {
                        string[] items = line.Split("#");
                        worker[i].ID = Convert.ToInt32(items[0]);
                        worker[i].AddDate = Convert.ToDateTime(items[1]);
                        worker[i].FIO = items[2];
                        worker[i].Age = Convert.ToInt32(items[3]);
                        worker[i].Growth = Convert.ToInt32(items[4]);
                        worker[i].BirthDate = Convert.ToDateTime(items[5]);
                        worker[i].BirthPlace = items[6];
                        i++;
                    }

                    Console.WriteLine("\nВведите опцию сортировки: \n1 - ID " +
                        "\n2 - дата создания " +
                        "\n3 - ФИО " +
                        "\n4 - возраст " +
                        "\n5 - рост " +
                        "\n6 - дата рождения " +
                        "\n7 - место рождения");
                    Console.Write("Опция: ");
                    string sort = Console.ReadLine();

                    switch (sort)
                    {
                        case "1":
                            Worker[] worker1 = worker.OrderBy(w => w.ID).ToArray();
                            Sort(lines, worker1);
                            break;
                        case "2":
                            Worker[] worker2 = worker.OrderBy(w => w.AddDate).ToArray();
                            Sort(lines, worker2);
                            break;
                        case "3":
                            Worker[] worker3 = worker.OrderBy(w => w.FIO).ToArray();
                            Sort(lines, worker3);
                            break;
                        case "4":
                            Worker[] worker4 = worker.OrderBy(w => w.Age).ToArray();
                            Sort(lines, worker4);
                            break;
                        case "5":
                            Worker[] worker5 = worker.OrderBy(w => w.Growth).ToArray();
                            Sort(lines, worker5);
                            break;
                        case "6":
                            Worker[] worker6 = worker.OrderBy(w => w.BirthDate).ToArray();
                            Sort(lines, worker6);
                            break;
                        case "7":
                            Worker[] worker7 = worker.OrderBy(w => w.BirthPlace).ToArray();
                            Sort(lines, worker7);
                            break;
                        default:
                            Console.WriteLine("Неверный ввод");
                            break;
                    }

                    Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню");
                    if (Console.ReadLine() == "")
                    {
                        goto afterLoops;
                    }
                }
                Console.ReadKey();
            }




        }

    }
}