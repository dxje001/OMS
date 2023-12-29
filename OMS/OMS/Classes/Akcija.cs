using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Classes
{
    public class Akcija
    {
        public int Id { get; set; }
        public int KvarId { get; set; }
        public DateTime VremeAkcije { get; set; }
        public string OpisPosla { get; set; }

        public Akcija(int id, int kvarId, DateTime vremeAkcije, string opisPosla)
        {
            Id = id;
            KvarId = kvarId;
            VremeAkcije = vremeAkcije;
            OpisPosla = opisPosla;
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
