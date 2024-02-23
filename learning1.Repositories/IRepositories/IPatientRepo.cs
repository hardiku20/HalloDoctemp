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
        string GetUserNameRepo(int id);
        List<PatientHistoryViewModel> DisplayDashboardRepo(int id);
        void GetConciergeRequests(ConciergeRequestViewModel model);
        void GetFamilyFriendRequests(Family_FriendRequestViewModel model);
        void GetPatientRequests(PatientRequestViewModel model);
        int LoginMethodRepo(string username, string password);
        ViewDocumentViewModel fetchviewDocuments(int requestId, int id);

        ViewDocumentViewModel Uploaddocuments(ViewDocumentViewModel model, int requestId);
        PatientProfileViewModel GetPatientProfile(int id);
        bool CheckExistingUser(string email);
        void GetInformationMeData(SubmitInformationMeViewModel model);
        void GetInformationElseData(SubmitInformationElseVIewModel model);
    }
}
