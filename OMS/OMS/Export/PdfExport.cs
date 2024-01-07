using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using OMS.Classes;

namespace OMS.Export
{
    public class PdfExport
    {
        public void ExportToPdf(string idKvara, string nazivElementa, string naponskiNivo, List<Akcija> spisakIzvrsenihAkcija)
        {
            var fileName = $"Kvar_{idKvara}.pdf";
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

            using (var writer = new PdfWriter(filePath))
            {
                using (var pdf = new PdfDocument(writer))
                {
                    var document = new Document(pdf);

                    // Adding content to PDF
                    document.Add(new Paragraph($"ID kvara: {idKvara}"));
                    document.Add(new Paragraph($"Naziv elementa: {nazivElementa}"));
                    document.Add(new Paragraph($"Naponski nivo: {naponskiNivo}"));
                    for (int i = 0; i <= spisakIzvrsenihAkcija.Count(); i++)
                    {
                        document.Add(new Paragraph($"Spisak izvršenih akcija: {spisakIzvrsenihAkcija[i]}"));
                    }

                }
            }

            Console.WriteLine($"PDF exported to: {filePath}");
        }
    }
}
