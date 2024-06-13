using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsTest {
    public class Member 
        {

        // Hver instans af klassen skal have en liste med hunde 
        public string Name { get; private set; }
        public int ID { get; private set; }
        public string Address { get; private set; }

        public DateTime BirthDate { get; private set; }

        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }

        public List<Dog> dogs { get; private set; }

        public int age=0;

        public Member (int id, string name, string address, string phonenumber, string email, DateTime Birthday) 
        {
            
            Name = name;
            ID = id;
            Address = address;
            BirthDate = Birthday;
            PhoneNumber = phonenumber;
            Email = email;
            dogs = new List<Dog> ();
        }

        //implementer ToString metode

        public override string ToString()
        {
            return $"Name: {Name}, ID: {ID}, Address: {Address}, Date of birth {BirthDate}, Phone number: {PhoneNumber}, Email: {Email}";
        }
        //Implementer følgende CRUD-funktioner:
            //void RegisterDog(Dog dog) metoden på klassen Member.Metoden skal tilføje dog.

        public void RegisterDog (Dog dog)
        {
            dogs.Add (dog);
            Console.WriteLine($"Dog:{dog.Name} was added ");
        }

            //void PrintDogs() metoden på klassen Member, som skriver alle reservationer ud på skærmen på vha.en foreach løkke.

        public void PrintDogs()
        {
            foreach (Dog dog in dogs)
            {
                Console.WriteLine(dog);
            }
        }
            //void RemoveDog(Dog dog) metoden på klassen Member.Metoden skal fjerne dog.

        public void RemoveDog(Dog dog) 
        {
            List<Dog> RemoveDogsList = new List<Dog> ();
            foreach(Dog d in dogs)
            {
                if (d.ID != dog.ID)
                {
                    RemoveDogsList.Add (d);
                }
            }
            dogs = RemoveDogsList;
        }

        //Test metoderne ved oprette et Member objekt i Main (C# filen program.cs) og derefter kalde dem.
        //Se program.cs


        public int Age()
        {
          
            //Tjekker personen har haft fødelsdag. De har haft fødseldag hvis måneden de havde fødselsdag
            //er mindre end den måned vi har i dag
            if (DateTime.Now.Month > BirthDate.Month)
            {
                //hvis de har haft fødselsdag er deres alder blot i års år minus fødselsåret
                age = DateTime.Now.Year-BirthDate.Year;
            }
            //hvis de har fødselsdag i samme måned som vi har nu:
            else if (DateTime.Now.Month == BirthDate.Month)
            {
                //Nu tjekker vi om fødselsdagen har været der eller var i dag
                if(DateTime.Now.Day >= BirthDate.Day)
                {
                    age = DateTime.Now.Year - BirthDate.Year;
                }
                else
                {
                    age = DateTime.Now.Year - BirthDate.Year -1;
                }
            }
            else
            {
                //hvis de ikke har haft fødseldag skrives deres alder som et år yngre
                age = DateTime.Now.Year - BirthDate.Year - 1;
            }
            return age;
        }


        //Funktionen skal returnere medlemskontingentet i DKK, på grundlag af basis
        //kontingentet, der som nævnt kan være enten 500 eller 1000 DKK, hvilket parameteren
        //baseFee angiver.
        //Test funktionen med variationer af følgende:
        //antal hunde som medlemmet er indmeldt med, givet ved Count property på
        //listen
        //medlemmets alder, givet ved Age property
        //Basiskontingentet, givet ved baseFee parameteren

        //Dette ses i member klassen
        public double MemberFee(double baseFee)
        {
            double fee = 0;
            if (age >= 65)
            {
                //hvis man er over 65 (eller 65), betaler man 500 pr hund man tilmelder
                fee = 500 * dogs.Count+baseFee;
            }
            else
            {
                if(dogs.Count == 1)
                {
                    //har man en hund komster det 1000 kr.
                    fee = 1000 +baseFee;
                }
                else if (dogs.Count == 0) 
                {
                    //hvis man har 0 koster det 0 og meddelse printes:
                    Console.WriteLine("Ingen hunde tilføjet");
                }
                {
                    //hvis man har mere end 1 hund koster det 500 pr. hund. Jeg tilføjer så 500, ekstra for den første hund
                    fee = 500 * dogs.Count + 500+baseFee;
                }
            }

            return fee;
        }

        //Opgave 7
        //Validier data:
        //Medlemmets alder er mindre end 18 år
        //Name, Address, Phone og Email er ikke udfyldte

        public bool validate()
        {
            bool ok = false;

            if(age > 18)
            {
                //hvis de er over 18, ser den om alle ting er udfyldt, er de det returneres der true:
                if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(PhoneNumber) && !string.IsNullOrEmpty(Address) && !string.IsNullOrEmpty(Email))
                {
                    ok = true;
                }

            }
            return ok;
        }
        public double VenueRental (DateTime date)
        {
            double pris = 0;
            double hverdagspris = 100;
            double weekendpris = hverdagspris + (hverdagspris * 50 / 100);
            //User story 3, leje af lokale en hverdag:
            //hvis ugedagen ikke er søndag eller lørdag koster det 100 kr:
            if (date.DayOfWeek != DayOfWeek.Sunday && date.DayOfWeek != DayOfWeek.Saturday) 
            {
                pris = hverdagspris;
            }
            else
            {
                pris = weekendpris;

            }
            return pris;
        }
    }
}
