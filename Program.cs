using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace StarShip_program
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var fileName = $"StarShip {DateTime.Now:ddMMyyyy-HHmmss}.txt";

            var obj = new Planets();
            var rnd = new Random();

            Console.WriteLine(obj.GenerateNewPlanet());
            var list = obj.GeneratePlanets();
            list.Add(obj.GenerateNewPlanet());
            list.ForEach(i => Console.WriteLine(i));

            File.WriteAllLines(@"C:/Users/ndlazim1/Desktop/StarShip/" + fileName + "", list);







        }

       

    }
}
