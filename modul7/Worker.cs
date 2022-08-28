using System;

namespace modul7
{
    struct Worker
    {
        //поля
        private int id;
        private DateTime addDate;
        private string fio;
        private int age;
        private int growth;
        private DateTime birthDate;
        private string birthPlace;

        //конструкторы
        public Worker(int ID, DateTime Date, string FIO, int Age, int Growth, DateTime BirthDate, string BirthPlace)
        {
            this.id = ID;
            this.addDate = Date;
            this.fio = FIO;
            this.age = Age;
            this.growth = Growth;
            this.birthDate = BirthDate;
            this.birthPlace = BirthPlace;
        }

        //свойства
        public int ID { get { return this.id; } set { this.id = value; } }
        public DateTime AddDate { get { return this.addDate; } set { this.addDate = value; } }
        public string FIO { get { return this.fio; } set { this.fio = value; } }
        public int Age { get { return this.age; } set { this.age = value; } }
        public int Growth { get { return this.growth; } set { this.growth = value; } }
        public DateTime BirthDate { get { return this.birthDate; } set { this.birthDate = value; } }
        public string BirthPlace { get { return this.birthPlace; } set { this.birthPlace = value; } }
    }
}
