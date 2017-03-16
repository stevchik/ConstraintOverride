using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstraintOverride.dto
{
    public class Override
    {
        public string Name { get; set; }
        public List<Filter> Filters { get; set; }
        public List<PropertyValue> ConstraintOverrides { get; set; }
    }
}
