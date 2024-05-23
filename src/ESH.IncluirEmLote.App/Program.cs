
using ESH.IncluirEmLote.Service;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
namespace ESH.IncluirEmLote.App
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                var path = "C:\\Teste\\21-05-2024_NEGOCIOSAVISTA.txt";
                var service = new RegistroService();
                await service.ExecutarAsync(path);
                await Console.Out.WriteLineAsync("Finalizou!");

                sw.Stop();
                await Console.Out.WriteLineAsync($"Minutos: {sw.Elapsed.TotalMinutes.ToString()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
