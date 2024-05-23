using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ESH.IncluirEmLote.Domain
{
    public static class Helper
    {
        public const string STRCONN = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=IncluirLoteDB;Integrated Security=True";
        public static async Task<(List<string>, bool)> StreamParcialAsync(this StreamReader sr, int quantidade)
        {
            List<string> parcial = new List<string>();
            int i = 0;
            bool ultimaParte = false;
            while (i < quantidade)
            {
                var linha = await sr.ReadLineAsync();
                if (linha == null)
                {
                    quantidade = i;
                    parcial.Remove(parcial.Last());
                    ultimaParte = true;
                }
                else if (linha != "")
                {
                    parcial.Add(linha);
                    i++;
                }
            }

            return (parcial, ultimaParte);

        }

    }
}
