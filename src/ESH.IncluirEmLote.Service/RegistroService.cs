using ESH.IncluirEmLote.DataAccess;
using ESH.IncluirEmLote.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ESH.IncluirEmLote.Service
{
    public class RegistroService
    {
        private readonly RegistroRepository _repository;
        public RegistroService()
        {
            _repository = new RegistroRepository();
        }
        public async Task ExecutarAsync(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                _ = await sr.ReadLineAsync();

                List<List<string>> streamSessao = new List<List<string>>();
                int threads = 0;
                bool finalArquivo = false;
                int lote = 1000;
                int quantidade = 0;

                while (!finalArquivo)
                {
                    threads++;
                    var streamParcial = await sr.StreamParcialAsync(lote);
                    streamSessao.Add(streamParcial.Item1);
                    var options = new ParallelOptions { MaxDegreeOfParallelism = threads };

                    if (threads == 10 || streamParcial.Item2)
                    {
                        await Parallel.ForEachAsync(streamSessao, parallelOptions: options, async (lista, ct) =>
                        {
                            var listaParaInclusao = TratarListas(lista);
                            await _repository.IncluirEmLoteAsync(listaParaInclusao);

                        });
                        threads = 0;
                        streamSessao.Clear();
                        quantidade += lote;
                        await Console.Out.WriteLineAsync($"Regitros Incluidos: {quantidade}");
                    }
                    finalArquivo = streamParcial.Item2;
                }
            }
        }

        private List<Registro> TratarListas(List<string> lista)
        {
            var novalista = new List<Registro>();
            foreach (var item in lista)
            {
                novalista.Add(Registro.GerarLinha(item));
            }

            return novalista;
        }
    }
}
