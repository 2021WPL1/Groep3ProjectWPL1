using System;
using TestingPlanner.Data;
using TestingPlanner.Classes;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var registryCon = new RegistryConnection(@"SOFTWARE\VivesBarco");
            var user = registryCon.GetValueObject<BarcoUser>("Control");

            Console.WriteLine(user.Name);
            Console.WriteLine(user.Division);
            Console.WriteLine(user.Function);

            user = registryCon.GetValueObject<BarcoUser>("Request");

            Console.WriteLine(user.Name);
            Console.WriteLine(user.Division);
            Console.WriteLine(user.Function);

            user = registryCon.GetValueObject<BarcoUser>("Test");

            Console.WriteLine(user.Name);
            Console.WriteLine(user.Division);
            Console.WriteLine(user.Function);
        }
    }
}
