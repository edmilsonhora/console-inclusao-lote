namespace ESH.IncluirEmLote.Domain
{
    public class Registro
    {
        public Registro()
        {

        }

        protected Registro(string dataReferencia, string codigoInstrumento, string acaoAtualizacao,
                        string precoNegocio, string quantidadeNegociada, string horaFechamento,
                        string codigoIdentificadorNegocio, string tipoSessaoPregao, string dataNegocio,
                        string codigoParticipanteComprador, string codigoParticipanteVendedor)
        {
            this.DataReferencia = dataReferencia;
            this.CodigoInstrumento = codigoInstrumento;
            this.AcaoAtualizacao = acaoAtualizacao;
            this.PrecoNegocio = precoNegocio;
            this.QuantidadeNegociada = quantidadeNegociada;
            this.HoraFechamento = horaFechamento;
            this.CodigoIdentificadorNegocio = codigoIdentificadorNegocio;
            this.TipoSessaoPregao = tipoSessaoPregao;
            this.DataNegocio = dataNegocio;
            this.CodigoParticipanteComprador = codigoParticipanteComprador;
            this.CodigoParticipanteVendedor = codigoParticipanteVendedor;

        }
        public int Id { get; set; }
        public string DataReferencia { get; set; }
        public string CodigoInstrumento { get; set; }
        public string AcaoAtualizacao { get; set; }
        public string PrecoNegocio { get; set; }
        public string QuantidadeNegociada { get; set; }
        public string HoraFechamento { get; set; }
        public string CodigoIdentificadorNegocio { get; set; }
        public string TipoSessaoPregao { get; set; }
        public string DataNegocio { get; set; }
        public string CodigoParticipanteComprador { get; set; }
        public string CodigoParticipanteVendedor { get; set; }

        public static Registro GerarLinha(string linha)
        {
            var dados = linha.Split(";");

            return new Registro(dados[0], dados[1], dados[2], dados[3], dados[4],
                                dados[5], dados[6], dados[7], dados[8], dados[9],
                                dados[10]);
        }
    }
}
