using OMS.Classes;
using OMS.Service;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.UIHandler
{
    public class UIHandler
    { 
        private static readonly KvarService kvarService = new KvarService();
    
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
                Console.WriteLine("4 - Izbor kvarova u vremenskom opsegu");
                Console.WriteLine("5 - Unos novog elektricnog elementa");
                Console.WriteLine("X - Izlazak iz programa");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        ShowAll();
                        break;
                    case "2":
                        FindById();
                        break;
                    case "3":
                        //TO DO
                        break;
                    case "4":
                        FIndBYDate();
                        break;
                    case "5":
                        //TO DO
                        break;
                }

            } while (!answer.ToUpper().Equals("X"));
        }

        private void FIndBYDate()
        {
            try
            {
                foreach (Kvar kvar in kvarService.FindBYDate())
                {
                    Console.WriteLine(kvar);
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void FindById()
        {
            Console.WriteLine("IDKvara: ");
            string id = Console.ReadLine();

            try
            {
                Kvar kvar = kvarService.FindById(id);

                Console.WriteLine(kvar);
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ShowAll()
        {
        try
        {
            foreach (Kvar kvar in kvarService.FindAll())
            {
                Console.WriteLine(kvar);
            }
        }
        catch (DbException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    }
}
