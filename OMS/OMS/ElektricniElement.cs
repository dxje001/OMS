using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS
{
    internal class ElektricniElement
    {
        public int Id { get; set; }
        public string ElementId { get; set; }
        public string Naziv { get; set; }
        public string Tip { get; set; }
        public double GeografskaSirina { get; set; }
        public double GeografskaDuzina { get; set; }
        public string NaponskiNivo { get; set; } = "Srednji napon";
    }
}
