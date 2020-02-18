using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessaXml.Entidade
{
    public class Xml
    {

        public Xml(DateTime data, decimal cliques, decimal impressoes, decimal views, decimal cPM, decimal cPC, decimal cTR, decimal conversoes, decimal investimento, Int64 idCampanha, string nomeCampanha)
        {
            Data = data;
            Cliques = cliques;
            Impressoes = impressoes;
            Views = views;
            CPM = cPM;
            CPC = cPC;
            CTR = cTR;
            Conversoes = conversoes;
            Investimento = investimento;
            IdCampanha = idCampanha;
            NomeCampanha = nomeCampanha;
        }

        public DateTime Data { get; private set; }
        public decimal Cliques { get; private set; }
        public decimal Impressoes { get; private set; }
        public decimal Views { get; private set; }
        public decimal CPM { get; private set; }
        public decimal CPC { get; private set; }
        public decimal CTR { get; private set; }
        public decimal Conversoes { get; private set; }
        public decimal Investimento { get; private set; }
        public Int64 IdCampanha { get; private set; }
        public string NomeCampanha { get; private set; }

    }
}
