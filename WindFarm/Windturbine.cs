using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindFarm
{
    public class Windturbine
    {
        
        public float HubHeight{ get; set; }
        public float RotorDiameter { get; set; }
        public string Name{ get; set; }

        public string Make { get; set; }

        public Windturbine() { }

        public Windturbine(float HH, float RD, string Name, string Make)
        {
            this.HubHeight = HH;
            this.RotorDiameter = RD;
            this.Name = Name;
            this.Make = Make;
        }

    }
}
