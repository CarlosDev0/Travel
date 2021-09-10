using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Travelus.Tr.Utilities
{
    public class ConverterFunctions
    {
        public object CollectionToObject(IFormCollection form, System.Type modelClass)
        {
            var model = Activator.CreateInstance(modelClass);
            Type modelType = model.GetType();

            foreach (PropertyInfo propertyInfo in modelType.GetProperties())
            {
                var mykey = propertyInfo.Name;
                if (propertyInfo.CanRead && form.Keys.Contains(mykey))
                {
                    try
                    {
                        var value = form[mykey];
                        if (propertyInfo.PropertyType.Name.ToString() == "String")
                        {

                            propertyInfo.SetValue(model, value.ToString());
                        }
                        else if (propertyInfo.PropertyType.Name.ToString() == "Int32")
                        {
                            propertyInfo.SetValue(model, Convert.ToInt32(value));
                        }

                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
            }
            return model;
        }
    }
}
