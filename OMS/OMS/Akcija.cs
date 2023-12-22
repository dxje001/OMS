using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS
{
    internal class Akcija
    {
        public int Id { get; set; }
        public int KvarId { get; set; }
        public DateTime VremeAkcije { get; set; }
        public string OpisPosla { get; set; }
    }
}
