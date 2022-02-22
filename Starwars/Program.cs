using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Starwars
{
    class Program
    {
        private static List<Planet> planets = LoadData();

static void Main(string[] args)
        {



            //Task 1 - Selecting planets starting with char M
            GetPlanetsStartingWithLetterM();

            //Task 2 - Selecting planets with name containing the char y or Y
            GetPlanetsContainingY();

            //Task 3 - Selecting planets containing between 9 and 15 chars
            GetPlanetsBetween9And15Chars();

            //Task 4 - Selecting planets containing a at second index and ends with char e
            GetPlanetsContainingAAndEndsWithE();

            //Task 5 - Selecting planets where rotationPeriod is >40 order by rotationPeriod
            GetPlanetsByRotationPeriod();

            //Task 6 - Selecting planets where rotationPeriod is >10 && < 20 order by name
            GetPlanetsByRotationPeriodOrderedByName();

            //Task 7 - Selecting planets where rotationPeriod is >30, order by name and rotationPeriod
            GetPlanetsByRotationPeriodOrderedByName2();

            //Task 8 - Select Planets where rotationPeriod <30 or surfacewater > 50 and containing 'ba' in name
            //order by name,surfacewater,rotationPeriod
            GetPlanetsTask8();

            //Task 9 - Select planets where surfacewater > 0 order by surfacewater desc
            GetPlanetsTask9();

            //Task 10 - Select planets with diameter and population (4 * pi * r2)
            GetPlanetsTask10();

            //Task 11 - Select planets where rotationperiod is == 0 by using exept
            GetPlanetsTask11();

            //Task 12 - Select planets starting with a or ending with s
            //and join with planets with rainforest terrain
            GetPlanetsTask12();

            //Task 13 Select all planets where climate == desert.
            //There is no climate containing Desert, But i will supply planets with terrain such as deserts!
            //I did not manage to make this by using linq as it needed a subquery to accomplish
            GetPlanetsTask13();

            //Task 14 Select planets where climate == swamp
            //There is no climate such as swamp, so I will use the terrain instead. and ordering by rotationperiod and name
            //After getting an introduction to Any(), I have made this one with the subquery included in the lambda
            GetPlanetsTask14();

            //Task 15 - Select all planets containing double vocals (added Y just to apply the last planet with double vocals)
            GetPlanetsTask15();

            //Task 16 - Select all planets containing the doubl consonants kk, ll, rr or nn in the name of the planet
            //Order by name descending (Ord Mantell is missing in the example document)
            GetPlanetsTask16();
            

            Console.ReadKey();
        }







        //Selecting planets starting with char M
        private static void GetPlanetsStartingWithLetterM()
        {
            var planetsM = from planet in planets
                           where planet.Name[0] == 'M'
                           select planet.Name;
            Console.WriteLine("Planets starting with the character M");
            foreach (string planet in planetsM)
            {
                Console.WriteLine(planet);
            }
            Console.WriteLine();
        }




        //Selecting planets with name containing the char y or Y
        private static void GetPlanetsContainingY()
        {
            var planetsY = from planet in planets
                           where planet.Name.Contains('y') || planet.Name.Contains('Y')
                           select planet.Name;

            Console.WriteLine("Planets containing char y or Y");
            foreach (string planet in planetsY)
            {
                Console.WriteLine(planet);
            }
            Console.WriteLine();
        }




        //Selecting planets containing between 9 and 15 chars
        private static void GetPlanetsBetween9And15Chars()
        {
            var result = from planet in planets
                         where planet.Name.Length > 9 && planet.Name.Length < 15
                         select planet.Name;
            Console.WriteLine("planets containing between 9 and 15 chars");
            foreach (string planet in result)
            {
                Console.WriteLine(planet);
            }
            Console.WriteLine();
        }




        //Task 4 - Selecting planets containing a at second index and ends with char e
        private static void GetPlanetsContainingAAndEndsWithE()
        {
            var result = planets.Where(p => p.Name.ElementAt(1) == 'a' && p.Name.ElementAt(p.Name.Length - 1) == 'e');
            Console.WriteLine("planets containing a at second index and ends with char e");
            foreach (Planet planet in result)
            {
                Console.WriteLine(planet.Name);
            }
            Console.WriteLine();
        }




        //Task 5 - Selecting planets where rotationPeriod is >40 order by rotationPeriod
        private static void GetPlanetsByRotationPeriod()
        {
            var result = planets.Where(p => p.RotationPeriod > 40).OrderBy(p => p.RotationPeriod);
            Console.WriteLine("planets where rotationPeriod is >40 order by rotationPeriod");
            foreach (Planet planet in result)
            {
                Console.WriteLine($"{planet.Name}: {planet.RotationPeriod}");
            }
            Console.WriteLine();
        }




        //Task 6 - Selecting planets where rotationPeriod is >10 && < 20 order by name
        private static void GetPlanetsByRotationPeriodOrderedByName()
        {
            var result = planets.Where(p => p.RotationPeriod > 10 && p.RotationPeriod < 20).OrderBy(p => p.Name);
            Console.WriteLine("planets where rotationPeriod is >10 && < 20 order by name");
            foreach (Planet planet in result)
            {
                Console.WriteLine($"{planet.Name}: {planet.RotationPeriod}");
            }
            Console.WriteLine();
        }





        //Task 7 - Selecting planets where rotationPeriod is >30, order by name and rotationPeriod
        private static void GetPlanetsByRotationPeriodOrderedByName2()
        {
            var result = planets.Where(p => p.RotationPeriod > 30).OrderBy(p => p.Name).ThenBy(p => p.RotationPeriod);
            Console.WriteLine("planets where rotationPeriod is >30, order by name and rotationPeriod");
            foreach (Planet planet in result)
            {
                Console.WriteLine($"{planet.Name}: {planet.RotationPeriod}");
            }
            Console.WriteLine();
        }




        //Task 8 - Select Planets where rotationPeriod <30 or surfacewater > 50 and containing ba in name
        //order by name,surfacewater, rotationPeriod
        private static void GetPlanetsTask8()
        {
            var result = planets.Where(p => (p.RotationPeriod < 30 || p.SurfaceWater > 50) && p.Name.Contains("ba"))
                .OrderBy(p => p.Name).ThenBy(p => p.SurfaceWater).ThenBy(p => p.RotationPeriod);
            Console.WriteLine("Task 8 - Select Planets where rotationPeriod <30 or surfacewater > 50 and containing ba in name " +
                "order by name,surfacewater,rotationPeriod");
            foreach (Planet planet in result)
            {
                Console.WriteLine($"{planet.Name}: {planet.SurfaceWater}: {planet.RotationPeriod}");
            }
            Console.WriteLine();
        }




        //Task 9 - Select planets where surfacewater > 0 order by surfacewater desc
        private static void GetPlanetsTask9()
        {
            var result = planets.Where(p => (p.SurfaceWater > 0)).OrderByDescending(p => p.SurfaceWater);
            Console.WriteLine("Task 9 - Select planets where surfacewater > 0 order by surfacewater desc");
            foreach (Planet planet in result)
            {
                Console.WriteLine($"{planet.Name}: {planet.SurfaceWater}: {planet.RotationPeriod}");
            }
            Console.WriteLine();

        }




        //Task 10 - Select planets with diameter and population (4 * pi * r2)
        private static void GetPlanetsTask10()
        {
            var result = planets.Where(p => (p.Diameter > 0) && p.Population > 0).OrderBy(p => (Math.Pow(p.Diameter / 2, 2) * Math.PI * 4) / p.Population);
            Console.WriteLine("Task 10 - Select planets with diameter and population (4 * pi * r2)");
            foreach (Planet planet in result)
            {
                Console.WriteLine($"{planet.Name}: {(Math.Pow(planet.Diameter / 2, 2) * Math.PI * 4) / planet.Population}");
            }
            Console.WriteLine();
        }




        //Task 11 - Select planets where rotationperiod is == 0 by using exept
        private static void GetPlanetsTask11()
        {
            var result = planets.Except(planets.Where(p => (p.RotationPeriod > 0)));
            Console.WriteLine("Task 11 - Select planets where rotationperiod is == 0 by using exept");
            foreach (Planet planet in result)
            {
                Console.WriteLine($"{planet.Name}: {planet.RotationPeriod}");
            }
            Console.WriteLine();
        }




        //Task 12 - Select planets starting with a or ending with s,
        //and join with planets with rainforest terrain
        private static void GetPlanetsTask12()
        {
            var result1 = planets.Where(p => p.Name.StartsWith("a") || p.Name.StartsWith("A") || p.Name.EndsWith("s") || p.Name.EndsWith("S"));
            var result2 = planets.Where(p => p.Terrain != null && p.Terrain.Contains("rainforests"));
            var result = result1.Union(result2);
            Console.WriteLine("Task 12 - Select planets starting with a or ending with s, and join with planets with rainforest terrain");
            Console.WriteLine("planets with A or s");
            foreach (Planet planet in result1)
            {
                Console.WriteLine($"{planet.Name}: {planet.RotationPeriod}");
            }
            Console.WriteLine();
            Console.WriteLine("planets with rainforests");
            foreach (Planet planet in result2)
            {
                Console.WriteLine($"{planet.Name}: {planet.RotationPeriod}");
            }
            Console.WriteLine();
            Console.WriteLine("planets combined");
            foreach (Planet planet in result)
            {
                Console.WriteLine($"{planet.Name}: {planet.RotationPeriod}");
            }
            Console.WriteLine();
        }




        //Task 13 Select all planets where climate == desert.
        //There is no climate containing Desert, But i will supply planets with terrain such as deserts!
        //I did not manage to make this by using linq as it needed a subquery to accomplish
        private static void GetPlanetsTask13()
        {
            Console.WriteLine("Task 13 Select all planets where climate == desert.");
            Console.WriteLine("There is no climate containing Desert, But i will supply planets with terrain such as deserts!");
            Console.WriteLine("I did not manage to make this by using linq as it needed a subquery to accomplish");

            var result = from p in planets
                         where p.Terrain != null
                             from t in p.Terrain
                             where t.Contains("desert")
                         select p.Name;

            foreach (string planet in result)
            {
                Console.WriteLine(planet);
            }
            Console.WriteLine();
        }




        //Task 14 Select planets where climate == swamp
        //There is no climate such as swamp, so I will use the terrain instead. and ordering by rotationperiod and name
        //After getting an introduction to Any(), I have made this one with the subquery included in the lambda
        private static void GetPlanetsTask14()
        {
            Console.WriteLine("Task 14 Select planets where climate == swamp");
            Console.WriteLine("There is no climate such as swamp, so I will use the terrain instead. and ordering by rotationperiod and name");
            Console.WriteLine("After getting an introduction to Any(), I have made this one with the subquery included in the lambda");
            var result = planets.Where(p => p.Terrain != null).Where(p => p.Terrain.Any(str => str.Contains("swamp")))
                .OrderBy(p => p.RotationPeriod).ThenBy(p => p.Name);
            foreach (Planet planet in result)
            {
                Console.WriteLine(planet.Name);
            }
            Console.WriteLine();
        }




        //Task 15 - Select all planets containing double vocals (added Y just to apply the last planet with double vocals)
        private static void GetPlanetsTask15()
        {
            Regex regEx = new Regex(@"[aA]{2}|[eE]{2}|[iI]{2}|[oO]{2}|[uU]{2}|[yY]{2}");
            Console.WriteLine("Task 15 - Select all planets containing double vocals. (added Y just to apply the last planet with double vocals)");
            var result = from planet in planets
                         where regEx.IsMatch(planet.Name)
                         select planet.Name;
            foreach (string planet in result)
            {
                Console.WriteLine(planet);
            }
            Console.WriteLine();
        }




        //Task 16 - Select all planets containing the doubl consonants kk, ll, rr or nn in the name of the planet
        //Order by name descending (Ord Mantell is missing in the example document)
        private static void GetPlanetsTask16() {
            Regex regEx = new Regex(@"[kK]{2}|[lL]{2}|[rR]{2}|[nN]{2}");
            Console.WriteLine("Task 16 - Select all planets containing the doubl consonants kk, ll, rr or nn in the name of the planet, Order by name descending");
            Console.WriteLine("(Ord Mantell is missing in the example document)");
            var result = from planet in planets
                         where regEx.IsMatch(planet.Name)
                         orderby planet.Name descending
                         select planet.Name ;
            foreach (string planet in result)
            {
                Console.WriteLine(planet);
            }
            Console.WriteLine();
        }



        private static List<Planet> LoadData()
        {
            List<Planet> planets = new List<Planet>()
            {
                new Planet { Name="Corellia", Terrain= new List<string>{ "plains", "urban", "hills", "forests" },RotationPeriod=25,SurfaceWater=70, Diameter=11000, Population=3000000000},
                new Planet { Name="Rodia", Terrain= new List<string>{ "jungles", "oceans", "urban", "swamps" },RotationPeriod=29,SurfaceWater=60, Diameter=7549, Population=1300000000},
                new Planet { Name="Nal Hutta", Terrain= new List<string>{ "urban", "oceans", "bogs", "swamps" },RotationPeriod=87, Diameter=12150, Population=7000000000},
                new Planet { Name="Dantooine",Terrain= new List<string>{ "savannas", "oceans", "mountains", "grasslands" },RotationPeriod=25, Diameter=9830,Population=1000},
                new Planet { Name="Bestine IV",Terrain= new List<string>{ "rocky islands", "oceans" },RotationPeriod=26,SurfaceWater=98, Diameter=6400,Population=62000000},
                new Planet { Name="Ord Mantell",Terrain= new List<string>{ "plains", "seas","mesas" },RotationPeriod=26,SurfaceWater=10, Diameter=14050, Population=4000000000},
                new Planet { Name="Trandosha",Terrain= new List<string>{ "mountains", "seas","grasslands" ,"deserts"},RotationPeriod=25, Diameter=0, Population=42000000},
                new Planet { Name="Socorro", Terrain= new List<string>{ "mountains", "deserts"},RotationPeriod=20, Population=300000000},
                new Planet { Name="Mon Cala",Terrain= new List<string>{ "oceans", "reefs","islands"},RotationPeriod=21,SurfaceWater=100,Diameter=11030,Population=27000000000},
                new Planet { Name="Chandrila", Terrain= new List<string>{ "plains", "forests"},RotationPeriod=20,SurfaceWater=40,Diameter=13500,Population=1200000000},
                new Planet { Name="Sullust", Terrain= new List<string>{ "mountains", "volcanoes","rocky deserts"},RotationPeriod=20,SurfaceWater=5, Diameter=12780, Population=18500000000},
                new Planet { Name="Toydaria", Terrain= new List<string>{ "swamps", "lakes"},RotationPeriod=21, Diameter=7900, Population=11000000},
                new Planet { Name="Malastare",Terrain= new List<string>{ "swamps", "deserts","jungles","mountains"},RotationPeriod=26, Diameter=18880, Population=2000000000},
                new Planet { Name="Dathomir",Terrain= new List<string>{ "forests", "deserts","savannas"},RotationPeriod=24, Diameter=10480, Population=5200},
                new Planet { Name="Ryloth",Terrain= new List<string>{ "mountains", "valleys","deserts","tundra"},RotationPeriod=30,SurfaceWater=5,Diameter=10600, Population=1500000000 },
                new Planet { Name="Aleen Minor"},
                new Planet { Name="Vulpter",Terrain= new List<string>{ "urban", "barren"} ,RotationPeriod=22, Diameter=14900, Population=421000000},
                new Planet { Name="Troiken",Terrain= new List<string>{ "desert", "tundra","rainforests","mountains"} },
                new Planet { Name="Tund",Terrain= new List<string>{ "barren", "ash"} ,RotationPeriod=48, Diameter=12190},
                new Planet { Name="Haruun Kal",Terrain= new List<string>{ "toxic cloudsea", "plateaus","volcanoes"},RotationPeriod=25,Diameter=10120,Population=705300},
                new Planet { Name="Cerea",Terrain= new List<string>{ "verdant"},RotationPeriod=27,SurfaceWater=20,Population=450000000},
                new Planet { Name="Glee Anselm",Terrain= new List<string>{ "islands","lakes","swamps", "seas"},RotationPeriod=33,SurfaceWater=80, Diameter=15600,Population=500000000},
                new Planet { Name="Iridonia",Terrain= new List<string>{ "rocky canyons","acid pools"},RotationPeriod=29},
                new Planet { Name="Tholoth"},
                new Planet { Name="Iktotch",Terrain= new List<string>{ "rocky"},RotationPeriod=22},
                new Planet { Name="Quermia",},
                new Planet { Name="Dorin",RotationPeriod=22, Diameter=13400},
                new Planet { Name="Champala",Terrain= new List<string>{ "oceans","rainforests","plateaus"},RotationPeriod=27, Population=3500000000},
                new Planet { Name="Mirial",Terrain= new List<string>{ "deserts"}},
                new Planet { Name="Serenno",Terrain= new List<string>{ "rivers","rainforests","mountains"}},
                new Planet { Name="Concord Dawn",Terrain= new List<string>{ "jungles","forests","deserts"}},
                new Planet { Name="Zolan" },
                new Planet { Name="Ojom",Terrain= new List<string>{ "oceans","glaciers"},SurfaceWater=100, Population=500000000},
                new Planet { Name="Skako", Terrain = new List<string>{ "urban","vines"},RotationPeriod=27, Population=500000000000},
                new Planet { Name="Muunilinst",Terrain= new List<string>{ "plains","forests","hills","mountains"} ,RotationPeriod=28,SurfaceWater=25, Diameter=13800, Population=5000000000},
                new Planet { Name="Shili",Terrain= new List<string>{ "cities","savannahs","seas","plains"}},
                new Planet { Name="Kalee",Terrain= new List<string>{ "rainforests","cliffs","seas","canyons"},RotationPeriod=23, Diameter=13850, Population=4000000000},
                new Planet { Name="Umbara"},
                new Planet { Name="Tatooine",Terrain= new List<string>{ "deserts"},RotationPeriod=23,SurfaceWater=1, Diameter=10465, Population=200000 },
                new Planet { Name="Jakku",Terrain= new List<string>{ "deserts"}},
                new Planet { Name="Alderaan",Terrain= new List<string>{ "grasslands","mountains"},RotationPeriod=24,SurfaceWater=40, Diameter=12500, Population= 2000000000},
                new Planet { Name="Yavin IV", Terrain= new List<string>{ "rainforests","jungle"},RotationPeriod=24,SurfaceWater=8,Diameter=10200,Population=     1000},
                new Planet { Name="Hoth", Terrain= new List<string>{ "tundra","ice caves","mountain ranges"},RotationPeriod=23,SurfaceWater=100},
                new Planet { Name="Dagobah",Terrain= new List<string>{ "swamp","jungles"},RotationPeriod=23,SurfaceWater=8},
                new Planet { Name="Bespin",Terrain= new List<string>{ "gas giant"},RotationPeriod=12, Diameter=118000,Population=  6000000},
                new Planet { Name="Endor",Terrain= new List<string>{ "forests","mountains","lakes"},RotationPeriod=18,SurfaceWater=8, Diameter=4900, Population= 30000000},
                new Planet { Name="Naboo",Terrain= new List<string>{ "grassy hills","swamps","forests","mountains"},RotationPeriod=26,SurfaceWater=12, Diameter=12120, Population=  4500000000},
                new Planet { Name="Coruscant",Terrain= new List<string>{ "cityscape","mountains"},RotationPeriod=24,Diameter=12240,Population=1000000000000},
                new Planet { Name="Kamino",Terrain= new List<string>{ "ocean"},RotationPeriod=27,SurfaceWater=100,Diameter=19720, Population=1000000000},
                new Planet { Name="Geonosis",Terrain= new List<string>{ "rock","desert","mountain","barren"},RotationPeriod=30,SurfaceWater=5,Diameter=11370, Population=100000000000},
                new Planet { Name="Utapau",Terrain= new List<string>{ "scrublands","savanna","canyons","sinkholes"},RotationPeriod=27,SurfaceWater=0.9f,Diameter=12900,Population=  95000000},
                new Planet { Name="Mustafar",Terrain= new List<string>{ "volcanoes","lava rivers","mountains","caves"},RotationPeriod=36,  Diameter=4200, Population=20000},
                new Planet { Name="Kashyyyk",Terrain= new List<string>{ "jungle","forests","lakes","rivers"},RotationPeriod=26 ,SurfaceWater=60,Diameter=12765, Population=45000000},
                new Planet { Name="Polis Massa",Terrain= new List<string>{ "airless","asteroid"},RotationPeriod=24, Diameter=0, Population=1000000},
                new Planet { Name="Mygeeto",Terrain= new List<string>{ "glaciers","mountains","ice canyons"},RotationPeriod=12, Diameter=10088, Population=  19000000},
                new Planet { Name="Felucia",Terrain= new List<string>{ "fungus","forests"},RotationPeriod=34, Diameter=9100,Population=8500000},
                new Planet { Name="Cato Neimoidia",Terrain= new List<string>{ "mountains","fields","forests","rock arches"},RotationPeriod=25, Population=10000000},
                new Planet { Name="Saleucami",Terrain= new List<string>{ "caves", "deserts","mountains","volcanoes"},RotationPeriod=26, Population=1400000000, Diameter=14920},
                new Planet { Name="Stewjon",Terrain= new List<string>{ "grass"}},
                new Planet { Name="Eriadu",Terrain= new List<string>{ "cityscape"},RotationPeriod=24, Diameter=13490  , Population= 22000000000},
             };
            return planets;
        }
    }
}
