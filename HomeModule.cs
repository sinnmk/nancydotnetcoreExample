using System.Collections.Generic;
using Nancy;

namespace CoreNancyExample
{
    public class HomeModule : NancyModule
    {
        public static int nPersonId = 1;
        public static List<Person> lst = new List<Person>();

        public HomeModule() : base("/person")
        {
            Get("/", args => "Hello World. This is pretty cool!");
            Get("/{id:int}", args => GetPersonById(args.Id));
            Post("/create/{name}", args =>
            {
                lst.Add(new Person() {Id = nPersonId++, Name = args.name});
                return lst;
            });
        }

        public Person GetPersonById(int id)
        {
            return lst.Find(p => p.Id == id);
        }

        public List<Person> GetPersonList()
        {
            lst.Add(new Person {Id = nPersonId++, Name = "NameOne"});
            lst.Add(new Person {Id = nPersonId++, Name = "NameTwo"});
            return lst;
        }

        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
