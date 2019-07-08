using System.Web;
using System.Web.Mvc;

namespace ArenaFifa20.BatchServices.NET
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
