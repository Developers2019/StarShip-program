﻿using System;
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
        /* -	Given the problem, I first had to determine the new Coordinates of the new universe by randomly generating them given the Coordinate system range.
           -	From there, given the number of locations, I then decided to use a for loop to randomly generate the Coordinates for the new planets, 
                with the constraints provided, I then had to determine whether these are planets or monsters, for which, I created a function to randomly pick out the appropriate value.
           -	With each planet generated I had to create another function to determine if it is hospitable or not. I then created another function to randomly determine the results.

           -	With each discovered planet, I retrieved the Surface area value by randomly generating the values within the given range.

           -	For each function used to randomly generate these values, I used the Random class to provide me with the appropriate methods.

           These were the steps and interpretation of the given questions.
    */

        public static void Main(string[] args)
        {
            var fileName = $"StarShip {DateTime.Now:ddMMyyyy-HHmmss}.txt";

            var obj = new Planets();
            var rnd = new Random();

            Console.WriteLine(obj.GenerateNewPlanet());
            var list = obj.GeneratePlanets();
            list.Add(obj.GenerateNewPlanet());
            list.ForEach(i => Console.WriteLine(i));

            Console.WriteLine("\nPlease enter path to save file.");

            var path = Console.ReadLine();

            //File.WriteAllLines(@"C:/Users/ndlazim1/Desktop/StarShip/" + fileName + "", list);
            File.WriteAllLines($"{path}{fileName}" + "", list);

            Console.WriteLine("file saved successfully.");


        }



    }
}
