using learning1.DBEntities.Models;
using learning1.DBEntities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.Repositories.IRepositories
{
    public interface IAdminRepo
    {
        List<Request> DisplayAdminDashboardRepo();
        ViewCaseViewModel DisplayViewCaseRepo(int requestId);
        AdminDashboardViewModel RenderConcludeState(int status);
        AdminDashboardViewModel RenderNewState(int status);
        AdminDashboardViewModel RenderPendingState(int status);
        AdminDashboardViewModel RenderToActiveState(int status);
        AdminDashboardViewModel RenderToCloseState(int status);
        AdminDashboardViewModel RenderUnpaidState(int status);
    }
}
