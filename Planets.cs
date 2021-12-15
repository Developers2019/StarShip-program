using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace StarShip_program
{
   
    public class Planets
    {
        private const string planet = "P";
        private const string monster = "M";
        private const string habitable = "Y";
        private const string notHabitable = "N";
        private static readonly char[] randomString = (planet + monster).ToCharArray();
        private static readonly char[] randomHabitat = (habitable + notHabitable).ToCharArray();
        private static Timer aTimer;



        public int Locations { get { return 15000; } }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public string Coordinates { get; set; }
        public int PlanetSurfaceArea { get; set; }

        public string Results { get; set; }

        public Planets()
        {
            PlanetSurfaceArea = 0;

            X = 0;
            Y = 0;
            Z = 0;
            Coordinates = "";
        }

        public Planets(int area,int x, int y, int z, string coordinates)
        {
            PlanetSurfaceArea = area;
            X = x;
            Y = y;
            Z = z;
            Coordinates = coordinates;

        }


        /// <summary>
        /// Function to generate the new universe
        /// </summary>
        /// <returns></returns>
        public string GenerateNewPlanet()
        {

            var rnd = new Random();
            //Randomly populate the new coordinates for a new univers with the specified coordinate bounds

            int x = rnd.Next(1000000000);
            int y = rnd.Next(1000000000);
            int z = rnd.Next(1000000000);
            var result = $"New Universe:\n{x:000\\.000\\.00\\.0}-X\n{y:000\\.000\\.00\\.0}-Y\n{z:000\\.000\\.00\\.0}-Z";
            return result;
        }

        /// <summary>
        /// Function to generate the planet coordinates
        /// </summary>
        /// <returns></returns>
        public List<string> GeneratePlanets()
        {

            var rnd = new Random();
            var planets = new List<string>();
            string perc = "";
            for (int i = 0; i < Locations; i++)
            {
                //Randomly populate the new coordinates for all 15 000 locations
                X = rnd.Next(1000000000);
                Y = rnd.Next(1000000000);
                Z = rnd.Next(1000000000);

                //Populate the random planet surface area ranging from 1 to 100 million square kilometers
                PlanetSurfaceArea = rnd.Next(1, 100000000);


                var m = new List<string>();
                var p = new List<string>();
               
               
                //Cast the coordinates from int to a string 
                Coordinates = $"{X:000\\.000\\.00\\.0}-X\n{Y:000\\.000\\.00\\.0}-Y\n{Z:000\\.000\\.00\\.0}-Z";
                           

                string feedback;
                string planetSurfaceArea;
                if (PlanetOrMonster().Contains("P"))
                {
                    feedback = "Planet";
                    planetSurfaceArea = IsHabitable() ? PlanetSurfaceArea.ToString(@"0,000,000") : "";
                    p.Add(PlanetOrMonster());
                }
                else
                {
                    feedback = "Monster";
                    planetSurfaceArea = "";
                    perc = "";
                    m.Add(PlanetOrMonster());
                }
                SetTimer();
                string results = $"{feedback}\nHabitable: {YesorNo(IsHabitable())}\nCoordinates:\n{Coordinates}\nSurface Area: {planetSurfaceArea}\nPercentage:{perc}\n //////////////////////////";

                planets.Add(results);


               

            }
            return planets;
        }

        /// <summary>
        /// Gets the percentage of the surface area
        /// </summary>
        /// <returns></returns>
        public int InHabitabelLand()
        {
            var rnd = new Random();

            var perc = rnd.Next(100);

            return perc;
        }

        /// <summary>
        /// Function checks for planets or monsters
        /// </summary>
        /// <returns></returns>
        public string PlanetOrMonster()
        {

            StringBuilder planetOrMonster = new StringBuilder();
            Random rn = new Random();

            planetOrMonster.Append(randomString[rn.Next(randomString.Length)]);
            return planetOrMonster.ToString();
        }

        /// <summary>
        /// Function which checks whether a planet is habitable or not
        /// </summary>
        /// <returns>True if planet is habitable</returns>
        public  bool IsHabitable()
        {

            StringBuilder xx = new StringBuilder();
            Random rn = new Random();

            xx.Append(randomHabitat[rn.Next(randomHabitat.Length)]);

            var isHabitable = xx.ToString().Contains("Y");

            return isHabitable;
        }

        public  string YesorNo(bool answer)
        {
            return answer ? "Yes" : "No";
        }

        public void SetTimer()
        {
            // Create a timer.
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 43;

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            aTimer.AutoReset = false;

            // Start the timer
            aTimer.Enabled = true;

        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (InHabitabelLand() > 50)
            {
                var list = $"{InHabitabelLand()}% of the surface colonized at {0}";
                Console.WriteLine(list, e.SignalTime);

            }

        }

    }
}
