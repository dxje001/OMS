using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS
{
    internal class Kvar
    {
        public int Id { get; set; }
        public string KvarId { get; set; }
        public DateTime VremeKreiranja { get; set; }
        public string Status { get; set; } = "Nepotvrđen";
        public string KratakOpis { get; set; }
        public string ElektricniElement { get; set; }
        public string OpisKvara { get; set; }
    }
}
