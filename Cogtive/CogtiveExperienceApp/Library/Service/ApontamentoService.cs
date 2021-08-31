using Library.BaseService;
using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service
{
    public class ApontamentoService : BaseApontamentos
    {
        public class GapDTO
        {
            public int QuantidadeGaps { get; set; }
            public string PeriodoTotal { get; set; }
        }

        public GapDTO Gaps()
        {
            GapDTO response = new GapDTO();

            try
            {
                if (_apontamentos != null && _apontamentos.Any())
                {
                    int gaps = 0;
                    TimeSpan periodo = new TimeSpan();

                    List<Apontamento> listaApontamentos = _apontamentos.OrderBy(o => o.IdApontamento).ToList();

                    DateTime? dataFimApontamentoAnterior = null;

                    for (int i = 0; i < listaApontamentos.Count; i++)
                    {
                        Apontamento horario = listaApontamentos[i];

                        if (dataFimApontamentoAnterior != null && horario.DataInicio.Day == dataFimApontamentoAnterior.Value.Day)
                        {
                            if (horario.DataInicio > dataFimApontamentoAnterior.Value)
                            {
                                gaps++;
                                TimeSpan diff = horario.DataInicio.Subtract(dataFimApontamentoAnterior.Value);
                                periodo = periodo.Add(diff);
                            }
                        }

                        dataFimApontamentoAnterior = horario.DataFim;
                    }

                    if (gaps > 0)
                    {
                        response.QuantidadeGaps = gaps;
                        response.PeriodoTotal = $"{(periodo.Days * 24) + periodo.Hours}:{periodo.Minutes.ToString("00")}:{periodo.Seconds.ToString("00")}";
                    }
                }
            }
            catch (Exception)
            {
            }

            return response;
        }

        public string Manutencao()
        {
            string response = string.Empty;

            try
            {
                if (_apontamentos != null && _apontamentos.Any())
                {
                    List<Apontamento> listaApontamentos = _apontamentos.Where(w => w.IdEvento == 19).ToList();

                    if (listaApontamentos != null && listaApontamentos.Any())
                    {
                        TimeSpan periodoManutencao = new TimeSpan();

                        foreach (Apontamento apontamentoManutencao in listaApontamentos)
                            periodoManutencao = periodoManutencao.Add(apontamentoManutencao.DataFim.Subtract(apontamentoManutencao.DataInicio));

                        response = $"{(periodoManutencao.Days * 24) + periodoManutencao.Hours}:{periodoManutencao.Minutes.ToString("00")}:{periodoManutencao.Seconds.ToString("00")}";
                    }
                }
            }
            catch (Exception)
            {
            }

            return response;
        }
    }
}
