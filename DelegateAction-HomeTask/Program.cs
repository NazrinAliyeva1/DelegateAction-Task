using DelegateAction_HomeTask.Models;

namespace DelegateAction_HomeTask
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Person class'i 
            List<Person> people = new List<Person>
            {
                new Person{Name="Kamil", Surname = "Kamranli", Age=21},
                new Person{Name ="Emil", Surname="Eliyeva",  Age=14},
                new Person{Name="Ayan", Surname="Ceferova", Age=20},
                new Person{Name="Sefa", Surname="Mikayilova", Age =46},
            };

            var searchPerson = people.Find(p => p.Name == "Sefa");
            if (searchPerson != null)
            {
                Console.WriteLine($"Person named which you are looking for: {searchPerson.Name} {searchPerson.Surname} {searchPerson.Age}");
            }
            else
            {
                Console.WriteLine("The name you are looking for is missing.");
            }


            var extnsionSurname = people.FindAll(p => p.Surname.EndsWith("ova") || p.Surname.EndsWith("ova"));
            Console.WriteLine("People with surname ending 'ov' or 'ova':");
            foreach (var person in extnsionSurname)
            {
                Console.WriteLine($"{person.Name} {person.Surname}");
            }

            var over20People = people.FindAll(p => p.Age > 20);
            Console.WriteLine("People aged older than 20:");
            foreach (var person in over20People)
            {
                Console.WriteLine($"{person.Name}");
            }

            Console.WriteLine("\n");
            //Exam

            List<Exam> exams = new List<Exam>
            {
                //new Exam { Subject ="Physics", ExamDuration=1, StartDate=DateTime.Now.AddDays(-2)},
                //new Exam { Subject ="Mathematics", ExamDuration=3, StartDate= DateTime.Now.AddDays(-7)},
                //new Exam { Subject = "chemistry", ExamDuration=2, StartDate = DateTime.Now.AddDays(-3)},
                new Exam { Subject ="Physics", ExamDuration=1},
                new Exam { Subject ="Mathematics", ExamDuration=3},
                new Exam { Subject = "chemistry", ExamDuration=2}

            };
            //just for ongoing exams:
            foreach(var exam in exams)
            {
                exam.Start();
            }


            Console.WriteLine("Recent exams within the last week:");
            var oneWeekAgo = DateTime.Now.AddDays(-7);
            var recentExams = exams.FindAll(e => e.StartDate >= oneWeekAgo && e.StartDate <= DateTime.Now);
            //var recentExams = exams.FindAll(e => (DateTime.Now - e.StartDate).TotalDays <= 7);
            foreach (var exam in recentExams)
            {
                Console.WriteLine($"Subject: {exam.Subject}, Duration: {exam.ExamDuration} hours.");
            }
            


            var longExams = exams.FindAll(e => e.ExamDuration > 2);
            Console.WriteLine("Exams lasting more than 2 hours:");
            foreach (var exam in longExams)
            {
                Console.WriteLine($"Subject: {exam.Subject}, Duration: {exam.ExamDuration}");

            }



            Console.WriteLine("Ongoing exams:");
            var ongoingExams = exams.FindAll(e => e.StartDate < DateTime.Now && DateTime.Now < e.EndDate);
            if (ongoingExams.Count > 0)
            {
                foreach (var exam in ongoingExams)
                {
                    Console.WriteLine($"Subject: {exam.Subject}, Duration: {exam.ExamDuration} hours");
                }
            }
            else
            {
                Console.WriteLine("No ongoing exams found.");
            }


        }
    }
}
