namespace Person
{
    public struct Person
    {
        private string name;
        private string lastName;
        private int age;
        private Guid id = Guid.NewGuid();

        public string Name => this.name;
        public string LastName => this.lastName;

        public int Age => this.age;

        public Guid Id => this.id;

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