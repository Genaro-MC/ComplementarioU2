using System;
using System.Collections.Generic;

#nullable disable

namespace LosSimson.Models
{
    public partial class Temporadum
    {
        public Temporadum()
        {
            Episodios = new HashSet<Episodio>();
        }

        public int Id { get; set; }
        public int Numero { get; set; }

        public virtual ICollection<Episodio> Episodios { get; set; }
    }
}
