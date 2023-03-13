namespace Person
{
    public struct Person
    {
        private string name;
        private string lastName;
        private int age;
        private Guid id = Guid.NewGuid();

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

        public DateTime DateCreation => DateTime.Now;

        public string Print()
        {
            return $"{this.id}. Привет, меня зовут {this.lastName} {this.name}. Мне {this.age} лет. Сейчас {DateCreation}  ";
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