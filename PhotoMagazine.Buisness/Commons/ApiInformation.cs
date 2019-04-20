using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoMagazine.Business.Commons
{
    public class ApiInformation
    {
        public string Name { get; set; }

        public string Contact { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            var property = GetType().GetProperties();
            return string.Join("\n", property.
                Select(v => string.Concat(new[] { v.Name, ": ", v.GetValue(this) })));
        }
    }
}
