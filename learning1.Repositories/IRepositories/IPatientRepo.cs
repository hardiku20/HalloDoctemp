using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using learning1.DBEntities.ViewModel;
namespace learning1.Repositories.IRepositories
{

    public interface IPatientRepo
    {
        void GetFamilyFriendRequests(Family_FriendRequestViewModel model);
        void GetPatientRequests(PatientRequestViewModel model);
        int LoginMethodRepo(string username, string password);
    }
}
