namespace Person
{
    public struct Person
    {
        private static Random random = new Random();
        private string name;
        private string lastName;
        private int age;
        private Guid id = Guid.NewGuid();
        private DateTime dateCreation = DateTime.Now - new TimeSpan(days: random.Next(30), hours: 0, minutes: 0, seconds: 0);

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        public Guid Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public DateTime DateCreation
        {
            get
            {
                return dateCreation;
            }
            set
            {
                dateCreation = value;
            }
        }

        public string Print()
        {
            return $"{this.id}. Привет, меня зовут {this.lastName} {this.name}. Мне {this.age} лет. Время записи {this.dateCreation}  ";
        }

        public Person(Guid id, string name, string lastName, int age) : this()
        {
            this.id = id;
            this.name = name;
            this.lastName = lastName;
            this.age = age;
        }
    }
}