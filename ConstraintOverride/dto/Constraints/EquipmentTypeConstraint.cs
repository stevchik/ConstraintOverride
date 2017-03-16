using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstraintOverride.dto.Constraints
{
    public class EquipmentTypeConstraint
    {
        public string EquipmentType { get; set; }
        public decimal MinimumPallets { get; set; }
        public decimal MaximumWeight { get; set; }
    }
}
