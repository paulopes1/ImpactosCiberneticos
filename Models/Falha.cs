using System;

namespace ImpactoCiberneticoFalhasEnergia.Models
{
    public class Falha
    {
        public DateTime Data { get; set; }
        public string Local { get; set; }
        public string Impacto { get; set; }
        public string ServicoAfetado { get; set; }

        public Falha(DateTime data, string local, string impacto, string servicoAfetado)
        {
            Data = data;
            Local = local;
            Impacto = impacto;
            ServicoAfetado = servicoAfetado;
        }

        public override string ToString()
        {
            return $"[{Data}] - Local: {Local}, Impacto: {Impacto}, Serviço: {ServicoAfetado}";
        }
    }
}