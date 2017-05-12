using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace OryxBudgetService.Utilties
{
    public class Helpers
    {

        public static object GetPropertyValue(object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName).GetValue(obj, null);
        }
    }
}
