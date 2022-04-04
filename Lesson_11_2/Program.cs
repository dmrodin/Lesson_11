using System;

namespace Lesson_11_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int serial = 1234;
            int number = 123456;
            string issued = "Выдан УВД";
            DateTime issuedDate = DateTime.Now;

            Passport passport = new Passport();
            passport.Serial = serial;
            passport.Number = number;
            passport.Issued = issued;
            passport.IssuedDate = issuedDate;

            Console.WriteLine(passport.ToString());

            Passport pass2 = new Passport(4321, 654321, "неизвестно кем", new DateTime(2001, 4, 7), true);

            Console.WriteLine(pass2.ToString());
        }
    }
}
