using System;
using System.Runtime.InteropServices.ComTypes;

namespace MongoWithCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
//            Console.WriteLine("Hello World!");

            MongoCRUD db = new MongoCRUD("AddressBook");

/*            PersonModel person = new PersonModel
            {
                FirstName = "Mary",
                LastName = "Leen",
                AddressDetail = new AddressModel
                {
                    Country = "NZ",
                    Region = "North Shore",
                    Street = "Sunnynook road"
                }
            };
            db.InsertRecord("Users", person);*/

//            var records = db.LoadRecord<PersonModel>("Users");

//            foreach (var rec in records)
//            {
//                Console.WriteLine($"{rec.id}: {rec.FirstName} {rec.LastName}");
//
//                if (rec.AddressDetail != null)
//                {
//                    Console.WriteLine(rec.AddressDetail.Country);
//                }
//
//                Console.WriteLine();
//            }
//
//            var rec = db.LoadRecordById<PersonModel>("Users", new Guid("cd9c1b0b-ec80-46ed-b4f3-3cf5e3374a05"));
//            rec.DateOfBirth = new DateTime(1999, 12, 12, 0, 0, 0, DateTimeKind.Utc);
//            db.UpsertRecord("Users", rec.id, rec);
//            db.DeleteRecord<PersonModel>("Users",rec.id);

            var records = db.LoadRecord<NameModel>("Users");
            foreach (var rec in records)
            {
                Console.WriteLine($"{rec.FirstName}, {rec.LastName}");
            }

            Console.ReadLine();
        }
    }
}
