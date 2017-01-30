using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstraintOverride.dto
{
    public enum FilterOperator : int
    {
        Skip = 0,
        Equals = 1,
        NotEquals = 2,
        Contains = 3,
        Excludes = 4

    }
}