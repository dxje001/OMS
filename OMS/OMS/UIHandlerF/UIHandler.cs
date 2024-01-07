using Microsoft.VisualBasic;
using OMS.Classes;
using OMS.Service;
using OMS.Export;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.UIHandlerF
{
    public class UIHandler
    { 
        private static readonly KvarService kvarService = new KvarService();
        private static readonly ElektricniElementService elektricniElementService = new ElektricniElementService();
        private static readonly AkcijaService akcijaService = new AkcijaService();
        private static readonly Excelexport excelexport = new Excelexport();
        private static readonly PdfExport pdfExport = new PdfExport();
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
                        InsertNewKvar();
                        break;
                    case "4":
                        FIndBYDate();
                        break;
                    case "5":
                        InsertNewElement();
                        break;
                }

            } while (!answer.ToUpper().Equals("X"));
            if (answer.ToUpper().Equals("X"))
            {
                Environment.Exit(0);
            }
        }

        private void InsertNewElement()
        {
            string answer;
            string nivo = "";
            
                Console.WriteLine("Odaberite status:");
                Console.WriteLine("1 - Srednji nivo");
                Console.WriteLine("2 - Visoki napon");
                Console.WriteLine("3 - Niski napon");
                Console.WriteLine("X - Povratak nazad");
                answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        nivo = "Srednji_nivo";
                        break;
                    case "2":
                        nivo = "Visoki_napon";
                        break;
                    case "3":
                        nivo = "Niski_napon";
                        break;
                    case "X":  
                        HandleMainMenu();
                    break; 
                    

                }
                
            

           int ide = elektricniElementService.GetCount() + 1;

            string element = $"E{ide:D3}";


            Console.WriteLine("Naziv:");
            string naziv = Console.ReadLine();
            Console.WriteLine("Tip:");
            string tip = Console.ReadLine();
            Console.WriteLine("Geografska sirinia:");
            float geosir = (float)Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Geografska duzina:");
            float geoduz = (float)Convert.ToDouble(Console.ReadLine());
      
            try
            {
                int inserted = elektricniElementService.Save(new ElektricniElement(ide, element, naziv,tip,geosir,geoduz,nivo));
                {
                    Console.WriteLine("Element unet");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void InsertNewKvar()
        {
            string answer;
            string status = "";
           
                Console.WriteLine("Odaberite status:");
                Console.WriteLine("1 - Nepotvrdjen");
                Console.WriteLine("2 - U popravci");
                Console.WriteLine("3 - Testiranje");
                Console.WriteLine("4 - Zatvoreno");
                Console.WriteLine("X - Povratak nazad");
                answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        status = "Nepotvrdjen";
                        break;
                    case "2":
                        status = "U_popravci";
                        break;
                    case "3":
                        status = "Testiranje";
                        break;
                    case "4":
                        status = "Zatvoreno";
                        break;
                    case "X":
                    HandleMainMenu();
                        break;
                


                }
            

            Console.WriteLine("Kratak opis kvara:");
            string kratakOpis = Console.ReadLine();
            Console.WriteLine("Elektricni Element:");
            string elektricniElement = Console.ReadLine();
            Console.WriteLine("Opis kvara:");
            string opis = Console.ReadLine();

            string date = DateTime.Today.ToString("yyyyMMdd");

            Console.WriteLine(kvarService.GetCount(date));
            int idk = kvarService.GetCount(date) + 1;
            string dateTimeFormat = "yyyyMMddhhmmss";
            string formattedDateTime = DateTime.Now.ToString(dateTimeFormat);
            string kvarId = $"{formattedDateTime}_{idk:D2}";



            
            try
            {
                int inserted = kvarService.InsertNewKvar(new Kvar(idk,kvarId, DateTime.Now, status, kratakOpis, elektricniElement,opis));
                if(inserted != 0)
                {
                    Console.WriteLine("Kvar unet");
                }
            }catch(Exception ex) { Console.WriteLine(ex.Message); }

        }

        private void FIndBYDate()
        {

            try
            {
                foreach (Kvar kvar in kvarService.FindBYDate())
                {
                    kvar.ListAll();
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
            int id =Convert.ToInt32( Console.ReadLine());
            string ananas;
            try
            {
                Kvar kvar = kvarService.FindById(id);
                ElektricniElement element = elektricniElementService.FindById(kvar.ElektricniElement);
                List<Akcija> spisak = new List<Akcija>();
                spisak = akcijaService.GetAll(kvar.KvarId);
               
                kvar.ListAll();
               
                if (kvar.Status.Equals("U_popravci"))
                {
                    int broj = akcijaService.GetCount(kvar.KvarId);
                    string s1 = DateTime.Today.ToString("yyyyMMdd");
                    string s2 = kvar.KvarId.Substring(8, kvar.KvarId.Length - 1);

                    int s1b = Convert.ToInt32(s1);
                    int s2b = Convert.ToInt32(s2);
                    int brojdana = s1b - s2b;
                    double ukupno = (brojdana + broj*0.5);
                    Console.WriteLine("Prioritet: " + ukupno);
                }
                
                    Console.WriteLine("Sta zelite da uradite sa ovim kvarom?");
                    Console.WriteLine("1-Azuriranje");
                    Console.WriteLine("2-Cuvanje u Excel-u");
                    Console.WriteLine("3-Cuvanje u PDF-u");
                    Console.WriteLine("X-Povratak nazad");
                    ananas = Console.ReadLine();
                    switch (ananas)
                    {
                        case "1":
                            if (kvar.Status == "Zatvoreno")
                            {
                                Console.WriteLine("Status kvara je zatvoren.\t Nije moguce azurirati ovaj kvar.");
                                break;
                            }
                            else
                            {
                                try
                                {

                                    string answer1;
                                    string status = "";

                                    Console.WriteLine("Odaberite status:");
                                    Console.WriteLine("1 - Nepotvrdjen");
                                    Console.WriteLine("2 - U popravci");
                                    Console.WriteLine("3 - Testiranje");
                                    Console.WriteLine("4 - Zatvoreno");
                                    Console.WriteLine("X - Povratak nazad");
                                    answer1 = Console.ReadLine();
                                    switch (answer1)
                                    {
                                        case "1":
                                            status = "Nepotvrdjen";
                                            break;
                                        case "2":
                                            status = "U_popravci";
                                            break;
                                        case "3":
                                            status = "Testiranje";
                                            break;
                                        case "4":
                                            status = "Zatvoreno";
                                            break;
                                        case "X":
                                        HandleMainMenu();
                                            break;

                                    }

                                    Console.WriteLine("Kratak opis kvara:");
                                    string kratakOpis = Console.ReadLine();
                                    Console.WriteLine("Opis kvara:");
                                    string opis = Console.ReadLine();

                                    int updated = kvarService.Update(new Kvar(kvar.Idk, kvar.KvarId, kvar.VremeKreiranja, status, kratakOpis, kvar.ElektricniElement, opis));
                                    if (updated != 0)
                                    {
                                        Console.WriteLine("Kvar \"{0}\" uspešno izmenjen.", kvar.KvarId);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Greska golema");
                                    }
                                }
                                catch (DbException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            break;

                        case "2":
                            excelexport.KreirajExcelDokument(kvar.KvarId, element.Naziv, element.NaponskiNivo, spisak);
                            break;
                        case "3":
                            pdfExport.ExportToPdf(kvar.KvarId, element.Naziv, element.NaponskiNivo, spisak);
                            break;
                        case "X":
                        HandleMainMenu();
                            break;
                    }
                

            }
            catch(DbException ex) { Console.WriteLine(ex.Message); }
        }

        private void ShowAll()
        {
            

        try
        {
            foreach (Kvar kvar1 in kvarService.FindAll())
            {
                kvar1.ListAll();
            }
        }
        catch (DbException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    }
}
