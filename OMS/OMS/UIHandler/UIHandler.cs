using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.UIHandler
{
    public class UIHandler
    {
        public void HandleMainMenu()
        {
            string answer;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Odaberite opciju:");
                Console.WriteLine("1 - Prikaz svih kvarova");
                Console.WriteLine("2 - Izaberi pojedinacni kvar");
                Console.WriteLine("3 - Unos novog kvara");
                Console.WriteLine("X - Izlazak iz programa");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        //TO DO
                        break;
                    case "2":
                        //TO DO
                        break;
                    case "3":
                        //TO DO
                        break;
                }

            } while (!answer.ToUpper().Equals("X"));
        }
    }
}
