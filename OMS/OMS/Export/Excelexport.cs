using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OMS.Classes;

namespace OMS.Export
{
    public class Excelexport
    {
        public void KreirajExcelDokument(string idKvara, string nazivElementa, string naponskiNivo, List<Akcija> spisakIzvrsenihAkcija)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Kvarovi");

                // Dodavanje naslova
                worksheet.Cells["A1"].Value = "ID kvara";
                worksheet.Cells["B1"].Value = "Naziv elementa";
                worksheet.Cells["C1"].Value = "Naponski nivo";
                worksheet.Cells["D1"].Value = "Spisak izvršenih akcija";

                // Popunjavanje podataka
                worksheet.Cells["A2"].Value = idKvara;
                worksheet.Cells["B2"].Value = nazivElementa;
                worksheet.Cells["C2"].Value = naponskiNivo;
                
                    for (int i = 0; i <= spisakIzvrsenihAkcija.Count(); i++)
                    {
                        int ik = i+ 2;
                        string str = "D" + Convert.ToString(ik);
                        worksheet.Cells[str].Value = spisakIzvrsenihAkcija[i];
                    }
                
                // Formatiranje
                using (var range = worksheet.Cells["A1:D1"])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                }

                // Sačuvajte Excel dokument
                var fileName = $"Kvar_{idKvara}.xlsx";
                var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
                package.SaveAs(new FileInfo(filePath));

                Console.WriteLine($"Excel exported to: {filePath}");
            }
        }
    }
}
