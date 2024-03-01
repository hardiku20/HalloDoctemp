using learning1.DBEntities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.Services.IServices
{
    public interface IAdminServices
    {
        AdminDashboardViewModel DisplayAdminDashboard();
        ViewCaseViewModel DisplayViewCase(int requestId);
        AdminDashboardViewModel RenderActiveStateData(int status);
        AdminDashboardViewModel RenderConcludeStateData(int status);
        AdminDashboardViewModel RenderNewStateData(int status);
        AdminDashboardViewModel RenderPendingStateData(int status);
        AdminDashboardViewModel RenderToCloseStateData(int status);
        AdminDashboardViewModel RenderUnpaidStateData(int status);
    }
}
