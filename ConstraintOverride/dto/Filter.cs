using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstraintOverride.dto
{
    public class Filter
    {
        public string Name { get; set; }
        public List<PropertyValue> FilterConditions { get; set; }
        public int Priority { get; internal set; }
    }
}
