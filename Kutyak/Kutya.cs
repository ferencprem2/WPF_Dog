using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kutyak
{
    internal class Kutya
    {
        private int id;
        private int specId;
        private int nameId;
        private double lifespan;
        private DateTime lastDocVisit;

        public Kutya(int id, int specId, int nameId, double lifespan, DateTime lastDocVisit)
        {
            this.id = id;
            this.specId = specId;
            this.nameId = nameId;
            this.lifespan = lifespan;
            this.lastDocVisit = lastDocVisit;
        }
       
        public int Id { get => id; }
        public int SpecId { get => specId; }
        public int NameId { get => nameId; }
        public double Lifespan { get => lifespan; }
        public DateTime LastDocVisit { get => lastDocVisit; }
    }
}
