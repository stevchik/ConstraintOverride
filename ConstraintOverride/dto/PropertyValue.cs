using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstraintOverride.dto
{
   

    public class PropertyValue 
    {
        public string PropertyName { get; set; }
        public string PropertyMap { get; set; }
        public object Value { get; set; }
        public FilterOperator Operator { get; set; }

    }

    //public abstract class PropertyValue
    //{
    //}

    //public class PropertyValue<T> : PropertyValue where T : struct
    //{
    //    public string PropertyName { get; set; }
    //    public string PropertyMap { get; set; }
    //    public T Value { get; set; }


    //}
}
