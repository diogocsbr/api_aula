using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consumidor.api01
{
    public class Item
    {
        public long Id { get; set; }
        public string? Nome { get; set; }
        public bool Finalizado { get; set; }
    }
}
