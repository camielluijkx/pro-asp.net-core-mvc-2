using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;

namespace ConventionsAndConstraints.Infrastructure
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ActionNamePrefixAttribute : Attribute, IActionModelConvention
    {
        private string namePrefix;

        public ActionNamePrefixAttribute(string prefix)
        {
            namePrefix = prefix;
        }

        public void Apply(ActionModel action)
        {
            action.ActionName = namePrefix + action.ActionName;
        }
    }
}