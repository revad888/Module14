using System.Linq;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            //  создаём пустой список с типом данных Contact
            var phoneBook = new List<Contact>();

            // добавляем контакты
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));


            while (true)
            {
                var input = Console.ReadKey().KeyChar;

                var pars = Int32.TryParse(input.ToString(), out int pageN);
                bool pageInRange =  pageN >= 1 && pageN <= 3;
                if(pars && pageInRange)
                {
                    Console.WriteLine();
                    var showContacts = phoneBook.Skip((pageN - 1) * 2).Take(2).OrderBy(c => c.Name).ThenBy(c =>  c.LastName);
                    foreach (var contact in showContacts)
                    {
                        Console.WriteLine($"{contact.Name} {contact.LastName} {contact.PhoneNumber}");
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Такой страницы не существует. Попробуйте снова.");
                }
            }
        }
    }
    public class Contact // модель класса
    {
        public Contact(string name, string lastName, long phoneNumber, String email) // метод-конструктор
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public String Name { get; }
        public String LastName { get; }
        public long PhoneNumber { get; }
        public String Email { get; }
    }
}