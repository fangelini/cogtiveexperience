using Library.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CogtiveExperienceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(" ");
                Console.WriteLine(" COGTIVE EXPERIENCE");
                Console.WriteLine(" ...............................................................");
                Console.WriteLine(" ");

                Console.WriteLine(" 1 - Funcionalidade Calcular Gaps");
                Console.WriteLine(" ");
                ApontamentoService apontamentoService = new ApontamentoService();
                ApontamentoService.GapDTO gap = apontamentoService.Gaps();

                Console.WriteLine($" - Quantidade de Gaps: { gap.QuantidadeGaps.ToString("n0")}");
                Console.WriteLine($" - Período Total: { gap.PeriodoTotal}");

                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine(" 2 - Funcionalidade Calcular Quantidades Produzidas");
                Console.WriteLine(" ");

                ApontamentoProducaoService apontamentoProducaoService = new ApontamentoProducaoService();
                int quantidadeProduzida = apontamentoProducaoService.QuantidadeProduzidas();

                Console.WriteLine($" - Quantidade Total Produzida: { quantidadeProduzida.ToString("n0")}");

                List<ApontamentoProducaoService.ApontamentosProducaoDTO> ranking = apontamentoProducaoService.Ranking();

                if (ranking != null && ranking.Count > 0)
                {
                    for (int i = 0; i < ranking.Count; i++)
                        Console.WriteLine($" - {(i+1).ToString()}° Lote {ranking[i].Lote.ToString()} produziu {ranking[i].Quantidade.ToString("n0")}");
                }

                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine(" 3 - Funcionalidade Calcular Horas Manutenção");
                Console.WriteLine(" ");

                string periodoManutencao = apontamentoService.Manutencao();
                Console.WriteLine($" - Período Total de Manutenção {periodoManutencao}");

                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine(" ");

                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine(" Erro ao processar a aplicação, aperta qualquer tecla para continuar..");
            }
        }
    }
}
