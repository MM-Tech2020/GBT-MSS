using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utitlities
{
    public static class Map
    {
        public static object AutoMapper(object from, object to)
        {
            var fromProps = from.GetType().GetProperties();
            var propsNames = fromProps.Select(pro => pro.Name);
            foreach (var property in to.GetType().GetProperties())
            {
                if (propsNames.Contains(property.Name))
                {
                    property.SetValue(to, fromProps.Where(pp => pp.Name == property.Name).FirstOrDefault().GetValue(from));
                }
            }
            return to;
        }
    }
}
