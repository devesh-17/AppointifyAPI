using Hangfire.Dashboard;
using CityConnect.Business.Helpers;

namespace AAT.API.Filters
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            return new AppSettings().EnableHangfire;
        }
    }
}
