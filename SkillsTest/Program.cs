using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace SkillsTest {
    internal class Program {
        static void Main(string[] args)
        {
            //Opgave 1: Tegn klassediagram over klasserne Member og Dog: (Det kan ses på word dokumentet der er tilkoblet)
            //Opgave 2: Implementer klassen Dog med instansfelter, properties og konstruktør. (oprettet)
                //Test klassen ved at lave nogle instanser af den (dog) og skriv dem ud i konsollen
                    //Jeg laver fire instanser af dog

            Dog dog1 = new Dog(1,"Bella", "Dansk-Svensk gårdhund",2015);
            Dog dog2 = new Dog(2, "Charlie", "Malteezer",2019);
            Dog dog3 = new Dog(3, "Aurora", "Blanding", 2021);
            Dog dog4 = new Dog(4, "Zooma", "labrador", 2023);

            Console.WriteLine("Udskriver 3 hunde");

            Console.WriteLine(dog1);
            Console.WriteLine(dog2);
            Console.WriteLine(dog3);
            Console.WriteLine(dog4);


            //Opgave 3
                //Opret klassen Member
                //Test klassen ved lave nogle instanser 
                // laver 3 members
            
            Console.WriteLine("Udskriver 3 members");

            Member member1 = new Member(1, "Tia", "Bakkekammen 2", "21434543", "mail@mail.dk", new DateTime(1962, 3, 13));
            Member member2 = new Member(2, "Line", "Rudersdalvej 16", "21478543", "mail2@mail.dk", new DateTime(1977, 6, 13));
            Member member3 = new Member(3, "Brian", "Hermodsgade 1", "4262118644", "mail3@mail.dk", new DateTime(1971, 8, 4));
            Console.WriteLine(member1);
            Console.WriteLine(member2);
            Console.WriteLine(member3);


            // Opgave 4:
                // Opret CRUD metoder på klassen Member.
                //registrerer de 3 hunde

            Console.WriteLine($"{member1.Name} added dog");
            member1.RegisterDog(dog1);
            member1.RegisterDog(dog3);
            Console.WriteLine($"{member2.Name} added dog");
            member2.RegisterDog(dog2);
            Console.WriteLine($"{member3.Name} added dog");
            member3.RegisterDog(dog4);

            //udskriver hundene:
            Console.WriteLine($"{member1.Name}, har følgende hund(e):");
            member1.PrintDogs();
            Console.WriteLine($"{member2.Name}, har følgende hund(e):");
            member2.PrintDogs();
            Console.WriteLine($"{member3.Name}, har følgende hund(e):");
            member3.PrintDogs();

            //fjerner hund

            Console.WriteLine($"{member1.Name}, fjerner hund: {dog1.Name}");
            member1.RemoveDog(dog1);
            Console.WriteLine($"{member1.Name}, har følgende hund(e):");
            member1.PrintDogs();


            //Opgave 5: lav sekvensdiagram
            //Kan ses i word-dokument



            //Opgave 6: Beregninger
            //I Member klassen implementeres følgene funktioner og properties:
            //Public int Age
            //Dette ses i member klassen

            Console.WriteLine($"{member1.Name} is {member1.Age()} years old");
            Console.WriteLine($"{member2.Name} is {member2.Age()} years old");
            Console.WriteLine($"{member3.Name} is {member3.Age()} years old");

            //public double MemberFee(double baseFee)
            // tilføjer en ekstra person der er over 65 år 
            Member member4 = new Member(4, "Gamle Ove", "gade 1", "444", null, new DateTime(1924, 2, 14));
            Console.WriteLine(member4);
            Console.WriteLine($"{member4.Name} is {member4.Age()} years old");

            member4.MemberFee(100);
            member4.RegisterDog(dog1);
            member4.RegisterDog(dog3);
            //tilføjer hund 1 igen til member1
            member1.RegisterDog(dog1);
            Console.WriteLine("To hunde, over 65 år, burde koste 1100");
            Console.WriteLine($"{member4.Name} has to pay: {member4.MemberFee(100)}");
            Console.WriteLine("To hunde, under 65 år, burde koste 1600");
            Console.WriteLine($"{member1.Name} has to pay: {member1.MemberFee(100)}");
            Console.WriteLine("en hunde, under 65 år, burde koste 1100");
            Console.WriteLine($"{member2.Name} has to pay: {member2.MemberFee(100)}");
            Console.WriteLine("en hunde, under 65 år, høj basefee: 400, burde koste 1400");
            Console.WriteLine($"{member3.Name} has to pay: {member3.MemberFee(400)}");

            // opgave 7

            //Lav en samlet funktion i Member klassen, der validerer et medlems data:
            // Da gamle Ove ikke har en mail er den null, vi forventer derfor at se false
            Console.WriteLine(member4.validate() );
            //her er alting ok
            Console.WriteLine(member2.validate());
            //laver en ny member der er under 18 år
            Member member5 = new Member(5, "Alva", "Hos sin mor", "428644", "mail99@mail.dk", new DateTime(2015, 8, 4));
            Console.WriteLine(member5.validate());


            //Opgave 8: (sprunget over pga af manglende tid)


            //opgave 9: 
            //Lav et par user stories. 
            //kan ses på word dokumentet

            //Opgave 10
            //Implementér dine egne user stories
            //User story 1: Leje lokale på en lørdag
            Console.WriteLine("Leje af lokale en lørdag");
            Console.WriteLine(member5.VenueRental(new DateTime(2024, 06, 15)));
            //User story 3, Leje lokale en hverdag:
            Console.WriteLine("Leje af lokale en hverdag");
            Console.WriteLine(member5.VenueRental(new DateTime(2024, 06, 13)));



        }
    }
}
