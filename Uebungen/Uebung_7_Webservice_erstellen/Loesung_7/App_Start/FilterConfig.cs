using System.Web;
using System.Web.Mvc;

namespace Webservice_erstellen_REST
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
