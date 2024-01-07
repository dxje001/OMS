using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OMS.Classes
{
    public class Kvar
    {
        public int Idk { get; set; }
        public string KvarId { get; set; }
        public DateTime VremeKreiranja { get; set; }
        public string Status { get; set; } = "Nepotvrđen";
        public string KratakOpis { get; set; }
        public string ElektricniElement { get; set; }
        public string OpisKvara { get; set; }



        public void ListAll()
        {
            Console.WriteLine(Idk + "  " +KvarId + "  " + VremeKreiranja + "  " + Status + "  " + KratakOpis + "  " + ElektricniElement + "  " + OpisKvara);
        }

        public static string GetFormattedHeaderx()
        {
            return string.Format("{0,-4} {1,-15} {2,-20} {3,-20} {4,-15} {5,-20} {6, -25}",
                "Idk", "KvarId", "VremeKreiranja", "Status", "KratakOpis", "ElektricniElement", "OpisKvara");
        }


        public Kvar(int id, string kvarId, DateTime vremeKreiranja, string status, string kratakOpis, string elektricniElement, string opisKvara)
        {
            Idk = id;
            KvarId = kvarId;
            VremeKreiranja = vremeKreiranja;
            Status = status;
            KratakOpis = kratakOpis;
            ElektricniElement = elektricniElement;
            OpisKvara = opisKvara;
        }


        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
