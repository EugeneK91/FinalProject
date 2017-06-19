using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Infrastructure.Filters
{
    public class NotNullOrEmptyPropertyStringAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var values = new List<object>() ;
            
            var type = value.GetType();
            var t = Type.GetType("System.String");
            var t1 = type.GetProperties()[0].PropertyType;
            var properties = type.GetProperties().Where(c=>c.PropertyType == Type.GetType("System.String")).ToList();
            foreach (var propertyValue in properties)
            {
                var propName = propertyValue.Name;
                values.Add(type.GetProperty(propName).GetValue(value, null));
            }
         
            var result = new List<object>();
            foreach (var val in values)
            {
                if (val != null)
                {
                    if (!string.IsNullOrEmpty((string)val))
                        result.Add(val);
                }
                
            }
            if (result.Any()) return true;
            return false;
       }
    }
}