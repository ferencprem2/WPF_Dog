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
        private int lifespan;
        private int lastDocVisit;

        public Kutya(int id, int specId, int nameId, int lifespan, int lastDocVisit)
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
        public int Lifespan { get => lifespan; }
        public int LastDocVisit { get => lastDocVisit; }
    }
}
