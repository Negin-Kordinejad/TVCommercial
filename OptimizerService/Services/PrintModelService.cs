using OptimizerService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizerService.Services
{
    public class PrintModelService : IPrintModel
    {
        private int tableWidth = 73;
        public void Print(PrintModel PrintModel)
        {
            Console.WriteLine("");
            Console.WriteLine(" Addvertiment Plan");
            PrintLine();
            PrintRow("Break", "Commercional", "Type", "Rate", "Demographic");
            PrintLine();
            foreach (var p in PrintModel.Placements)
            {

                PrintRow(p.Break.ToString(),
                         p.Commercional.Name.ToString(),
                         p.Commercional.CType.ToString(),
                         p.Rate.ToString(),
                         p.Commercional.Demographic.ToString());
            }
            PrintLine();
            Console.WriteLine("Total Rate :{0}", PrintModel.TotalRate.ToString());
            Console.WriteLine("");
            Console.WriteLine("");
        }

        private void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        private void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        private string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }

}

