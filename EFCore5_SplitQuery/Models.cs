using System.Collections.Generic;

namespace EFCore5_SplitQuery
{
    public class Etapa
    {
        public int EtapaId { get; set; }
        public string Cidade { get; set; }

        public List<Piloto> Pilotos { get; set; }
    }

    public class Piloto
    {
        public int PilotoId { get; set; }
        public string Nome { get; set; }
        public string Pais { get; set; }

        public int EtapaId { get; set; }
        public Etapa Etapa { get; set; }
    }
}