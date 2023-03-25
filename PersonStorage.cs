namespace Person
{
    public struct PersonStorage
    {
        private Person[] _persons;

        public PersonStorage()
        {
            _persons = Array.Empty<Person>();
        }

        public PersonStorage(Person[] people)
        {
            _persons = people;
        }

        public void AddPerson(Person person)
        {
            var newSize = _persons.Length + 1;
            Array.Resize(ref _persons, newSize);
            _persons[newSize - 1] = person;
        }

        public void AddPersons(Person[] persons)
        {
            var oldSize = _persons.Length;

            ResizeArray(persons.Length);
            for (int i = 0; i < persons.Length; i++)
            {
                _persons[oldSize + i] = persons[i];
            }
        }
       

        public void ResizeArray(int length)
        {
            if (_persons.Length == 0)
            {
                Array.Resize(ref _persons, length);
                return;
            }
            int currentSize;
            do
            {
                currentSize = _persons.Length;
                Array.Resize(ref _persons, currentSize * 2);
            } while (_persons.Length < currentSize + length);
        }

        public bool DeletePersonById(Guid deletedPersonId)
        {
            if (_persons.Length == 0)
            {
                return false;
            }

            var index = Array.FindIndex(_persons, x => x.Id == deletedPersonId);

            if (index == -1)
            {
                return false;
            }
            Person[] newPersons = new Person[_persons.Length - 1];

            for (int i = 0; i < _persons.Length; i++)
            {
                if (i == index)
                {
                    continue;
                }
                else if (i > index)
                {
                    newPersons[i - 1] = _persons[i];
                    continue;
                }
                newPersons[i] = _persons[i];
            }
            _persons = newPersons;
            return true;
        }

        public bool DeletePersons(Guid[] ids)
        {
            // var index = Array.FindIndex(_persons, x => x.Ids[] == id);

            //if (index == -1)
            //{
            //    return false;
            //}

            return true;
        }

        public bool EditPerson(Guid id, Person person)
        {
            var index = Array.FindIndex(_persons, x => x.Id == id);

            if (index == -1)
            {
                return false;
            }
            _persons[index] = person;
            return true;
        }

        public Person[] GetPersons()
        {
            _persons = Array.FindAll(_persons, x => x.Id != Guid.Empty);
            return _persons;
        }

        public void SortByDate()
        {
            Array.Sort(_persons, SortDate);
                
        }

        private int SortDate(Person x, Person y)
        {
            return x.DateCreation < y.DateCreation ? -1 : x.DateCreation == y.DateCreation ? 0 : 1;
        }
    }
}