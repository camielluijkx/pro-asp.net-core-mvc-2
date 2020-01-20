using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;
using System.Linq;

namespace ControllersAndActions.Controllers
{
    public class PocoController
    {
        [ControllerContext]
        public ControllerContext ControllerContext { get; set; }

        //public string Index()
        //{
        //    return "This is a POCO controller";
        //}

        public ViewResult Index()
        {
            ViewResult result = new ViewResult
            {
                ViewName = "Result",
                ViewData = new ViewDataDictionary(
                    new EmptyModelMetadataProvider(), 
                    new ModelStateDictionary())
                    {
                        Model = $"This is a POCO controller"
                    }
            };

            return result;
        }

        public ViewResult Headers()
        {
            Dictionary<string, string> model = ControllerContext.HttpContext.Request.Headers
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.First());

            ViewResult result = new ViewResult
            {
                ViewName = "DictionaryResult",
                ViewData = new ViewDataDictionary(
                    new EmptyModelMetadataProvider(), 
                    new ModelStateDictionary())
                    {
                        Model = model
                    }
            };

            return result;
        }
    }
}