using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstraintOverride.dto
{
    public class Stop
    {
        public int SequenceNumber { get; set; }
        public Warehouse Warehouse { get; set; }
        public string StopType { get; set; }
    }
}
