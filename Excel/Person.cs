namespace Excel
{
    internal class Person
    {
        public int Age { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public Person(int age, string surname, string name, string phone)
        {
            Age = age;
            Surname = surname;
            Name = name;
            Phone = phone;
        }
    }
}
