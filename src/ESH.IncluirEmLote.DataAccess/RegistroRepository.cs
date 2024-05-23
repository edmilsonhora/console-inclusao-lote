using ESH.IncluirEmLote.Domain;
using FastMember;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ESH.IncluirEmLote.DataAccess
{
    public class RegistroRepository
    {

        public async Task IncluirEmLoteAsync(List<Registro> lista)
        {
            var dataTable = new DataTable();
            using (var reader = ObjectReader.Create(lista))
            {
                dataTable.Load(reader);
            }

            using (var conn = new SqlConnection(Helper.STRCONN))
            {
                conn.Open();

                using (var sqlBulk = new SqlBulkCopy(conn))
                {
                    sqlBulk.ColumnMappings.Add("DataReferencia", "DATA_REFERENCIA");
                    sqlBulk.ColumnMappings.Add("CodigoInstrumento", "CODIGO_INSTRUMENTO");
                    sqlBulk.ColumnMappings.Add("AcaoAtualizacao", "ACAO_ATUALIZACAO");
                    sqlBulk.ColumnMappings.Add("PrecoNegocio", "PRECO_NEGOCIO");
                    sqlBulk.ColumnMappings.Add("QuantidadeNegociada", "QUANTIDADE_NEGOCIADA");
                    sqlBulk.ColumnMappings.Add("HoraFechamento", "HORA_FECHAMENTO");
                    sqlBulk.ColumnMappings.Add("CodigoIdentificadorNegocio", "CODIGO_IDENTIFICADOR_NEGOCIO");
                    sqlBulk.ColumnMappings.Add("TipoSessaoPregao", "TIPO_SESSAO_PREGAO");
                    sqlBulk.ColumnMappings.Add("DataNegocio", "DATA_NEGOCIO");
                    sqlBulk.ColumnMappings.Add("CodigoParticipanteComprador", "CODIGO_PARTICIPANTE_COMPRADOR");
                    sqlBulk.ColumnMappings.Add("CodigoParticipanteVendedor", "CODIGO_PARTICIPANTE_VENDEDOR");

                    sqlBulk.DestinationTableName = "TB_REGISTROS";

                    sqlBulk.BulkCopyTimeout = 500;
                    await sqlBulk.WriteToServerAsync(dataTable);
                }
            }

        }

    }
}
