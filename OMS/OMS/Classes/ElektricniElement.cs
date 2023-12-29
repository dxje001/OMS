using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Classes
{
    public class ElektricniElement
    {
        public int Id { get; set; }
        public string ElementId { get; set; }
        public string Naziv { get; set; }
        public string Tip { get; set; }
        public double GeografskaSirina { get; set; }
        public double GeografskaDuzina { get; set; }
        public string NaponskiNivo { get; set; } = "Srednji napon";

        public override string? ToString()
        {
            return base.ToString();
        }

        public ElektricniElement(int id, string elementId, string naziv, string tip, double geografskaSirina, double geografskaDuzina, string naponskiNivo)
        {
            Id = id;
            ElementId = elementId;
            Naziv = naziv;
            Tip = tip;
            GeografskaSirina = geografskaSirina;
            GeografskaDuzina = geografskaDuzina;
            NaponskiNivo = naponskiNivo;
        }

        public override bool Equals(object? obj)
        {
            return obj is ElektricniElement element &&
                   Id == element.Id &&
                   ElementId == element.ElementId &&
                   Naziv == element.Naziv &&
                   Tip == element.Tip &&
                   GeografskaSirina == element.GeografskaSirina &&
                   GeografskaDuzina == element.GeografskaDuzina &&
                   NaponskiNivo == element.NaponskiNivo;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, ElementId, Naziv, Tip, GeografskaSirina, GeografskaDuzina, NaponskiNivo);
        }
    }
}
