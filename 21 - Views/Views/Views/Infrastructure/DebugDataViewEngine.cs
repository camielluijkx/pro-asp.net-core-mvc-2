using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace Views.Infrastructure
{
    public class DebugDataViewEngine : IViewEngine
    {
        public ViewEngineResult GetView(string executingFilePath, string viewPath, 
            bool isMainPage)
        {
            string[] searchedLocations = new string[] { "(Debug View Engine - GetView)" };

            return ViewEngineResult.NotFound(viewPath, searchedLocations);
        }

        public ViewEngineResult FindView(ActionContext context, string viewName,
            bool isMainPage)
        {
            if (viewName == "DebugData")
            {
                IView view = new DebugDataView();

                return ViewEngineResult.Found(viewName, view);
            }
            else
            {
                string[] searchedLocations = new string[] { "(Debug View Engine - FindView)" };

                return ViewEngineResult.NotFound(viewName, searchedLocations);
            }
        }
    }
}