using System.Web;
using System.Web.Mvc;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
