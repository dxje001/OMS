using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Classes
{
    public class Kvar
    {
        public int Id { get; set; }
        public string KvarId { get; set; }
        public DateTime VremeKreiranja { get; set; }
        public string Status { get; set; } = "Nepotvrđen";
        public string KratakOpis { get; set; }
        public string ElektricniElement { get; set; }
        public string OpisKvara { get; set; }

        public Kvar(int id, string kvarId, DateTime vremeKreiranja, string status, string kratakOpis, string elektricniElement, string opisKvara)
        {
            Id = id;
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
