using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteLab
{

    public class Resultados
    {
        public int JogosRealizados { get; set; }
        public int TotalPontos { get; set; }
        public double MediaPontos { get; set; }
        public int MaiorPontuacao { get; set; }
        public int MenorPontuacao { get; set; }
        public int Recordes { get; set; }
        public DateTime DataJogoMax { get; set; }
        public DateTime DataJogoMin { get; set; }


    }
}