using Library.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace Library.BaseService
{
    public class BaseApontamentos
    {
        public List<Apontamento> _apontamentos = new List<Apontamento>();

        public BaseApontamentos()
        {
            CarregarApontamentos();
        }

        public bool CarregarApontamentos()
        {
            try
            {
                string filePath = $@"{AppDomain.CurrentDomain.BaseDirectory}\data.csv";

                if (!File.Exists(filePath))
                    return false;

                string[] contentFile = File.ReadAllLines(filePath);

                if (contentFile.Length == 0)
                    return false;

                foreach (string row in contentFile)
                {
                    string[] coluns = row.Split(';');

                    Apontamento ap = new Apontamento
                    {
                        IdApontamento = int.Parse(coluns[0].ToString()),
                        DataInicio = DateTime.Parse(coluns[1].ToString()),
                        DataFim = DateTime.Parse(coluns[2].ToString()),
                        NumeroLote = string.IsNullOrEmpty(coluns[3]) ? (int?)null : int.Parse(coluns[3].ToString()),
                        IdEvento = int.Parse(coluns[4].ToString()),
                        Quantidade = int.Parse(coluns[5].ToString())
                    };

                    _apontamentos.Add(ap);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
