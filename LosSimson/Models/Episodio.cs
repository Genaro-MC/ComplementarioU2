using System;
using System.Collections.Generic;

#nullable disable

namespace LosSimson.Models
{
    public partial class Episodio
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public string NombreIngles { get; set; }
        public string Trama { get; set; }
        public string Fecha { get; set; }
        public int IdTemporada { get; set; }

        public virtual Temporadum IdTemporadaNavigation { get; set; }
    }
}
