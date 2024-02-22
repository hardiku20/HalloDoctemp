using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using learning1.DBEntities.ViewModel;

namespace learning1.Services.IServices
{
    public interface IPatientServices
    {
        void GetFamilyRequestData(Family_FriendRequestViewModel model);
        void GetPatientRequestData(PatientRequestViewModel model);

        int LoginMethod(string username, string password);
    }
}
