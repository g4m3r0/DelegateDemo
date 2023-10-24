namespace ConsolePersonFilter;

class Program
{
    
    public delegate bool FilterDelegate(Person p);
    
    
    
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>()
        {
            new Person() { Name = "Tim", Age = 12 },
            new Person() { Name = "Bob", Age = 18 },
            new Person() { Name = "Sue", Age = 33 },
            new Person() { Name = "Mary", Age = 76 },
        };
        
        Console.WriteLine("Hello People!");
        
        DisplayPeople("Children", people, IsMinor);
        DisplayPeople("Adults", people, IsAdult);
        DisplayPeople("Seniors", people, IsSenior);
    }
    
    private static void DisplayPeople(string title, List<Person> people, FilterDelegate filter)
    {
        Console.WriteLine(title);
        
        foreach (var person in people)
        {
            if (filter(person))
            {
                Console.WriteLine($"{person.Name} {person.Age}");
            }
        }

        Console.WriteLine();
    }

    static bool IsMinor(Person person)
    {
        return person.Age < 18;
    }
    
    static bool IsAdult(Person person)
    {
        return person.Age >= 18;
    }

    static bool IsSenior(Person person)
    {
        return person.Age >= 65;
    }
}

class Person
{
    public string Name { get; set; }

    public int Age { get; set; }
}
