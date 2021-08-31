using Library.BaseService;
using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service
{
    public class ApontamentoProducaoService : BaseApontamentos
    {
        private List<Apontamento> _apontamentosProducao = new List<Apontamento>();

        public ApontamentoProducaoService()
        {
            Producao();
        }

        public class ApontamentosProducaoDTO
        {
            public int Lote { get; set; }
            public int Quantidade { get; set; }
        }

        public bool Producao()
        {
            try
            {
                _apontamentosProducao = _apontamentos.Where(w => w.IdEvento == 1 || w.IdEvento == 2).ToList();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int QuantidadeProduzidas()
        {
            int quantidadeTotal = 0;

            if (_apontamentosProducao != null && _apontamentosProducao.Any())
                quantidadeTotal = _apontamentosProducao.Sum(s => s.Quantidade);

            return quantidadeTotal;
        }

        public List<ApontamentosProducaoDTO> Ranking()
        {
            List<ApontamentosProducaoDTO> dto = new List<ApontamentosProducaoDTO>();

            if (_apontamentosProducao != null && _apontamentosProducao.Any())
            {
                dto = (from a in _apontamentosProducao
                       group a by new
                       {
                           a.NumeroLote
                       } into grp
                       select new ApontamentosProducaoDTO
                       {
                           Lote = grp.Key.NumeroLote.Value,
                           Quantidade = grp.Sum(s => s.Quantidade)
                       })
                       .OrderByDescending(o => o.Quantidade)
                       .Take(3)
                       .ToList();
            }

            return dto;
        }

    }
}
