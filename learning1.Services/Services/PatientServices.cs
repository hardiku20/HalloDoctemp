using learning1.DBEntities.ViewModel;
using learning1.Repositories.IRepositories;
using learning1.Repositories.Repositories;
using learning1.Services.IServices;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.Services.Services
{
    public class PatientServices : IPatientServices
    {
        public readonly IPatientRepo _patientRepo;
        public PatientServices(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public void GetPatientRequestData(PatientRequestViewModel model)
        {
            _patientRepo.GetPatientRequests(model);
        }

        public int LoginMethod(string username, string password)
        {
            int userId = _patientRepo.LoginMethodRepo(username, password);
            return userId;
        }


        public void GetConciergeRequestData(ConciergeRequestViewModel model)
        {
            _patientRepo.GetConciergeRequests(model);
        }


        public void GetFamilyRequestData(Family_FriendRequestViewModel model)
        {
            _patientRepo.GetFamilyFriendRequests(model);
        }

        
        public PatientDashboardViewModel displayDashboard(int id)
        {
            string userName = _patientRepo.GetUserNameRepo(id);
            var repoData = _patientRepo.DisplayDashboardRepo(id);
            PatientDashboardViewModel model = new PatientDashboardViewModel()
            {
                UserName = userName,
                HistoryViewModel = repoData
            };

            return model;
        }

        public ViewDocumentViewModel GetviewDocuments(int requestId, int id)
        {
            string userName = _patientRepo.GetUserNameRepo(id);
            var model = _patientRepo.fetchviewDocuments(requestId, id);

            return model;
        }

        public void InsertviewDocuments(ViewDocumentViewModel model, int requestId)
        {
            _patientRepo.Uploaddocuments(model, requestId);

        }

        public PatientProfileViewModel DisplayPatientProfile(int id)
        {
            var model = _patientRepo.GetPatientProfile(id);
            return model;
        }

        public bool IsExistingUser(string email)
        {
            return _patientRepo.CheckExistingUser(email);
        }

        public void GetInformationMe(SubmitInformationMeViewModel model)
        {
            _patientRepo.GetInformationMeData(model);
        }

        public void GetInformationElse(SubmitInformationElseVIewModel model)
        {
            _patientRepo.GetInformationElseData(model);
        }

        public AdminDashboardViewModel DisplayAdminDashboard()
        {
            var temp = _patientRepo.DisplayAdminDashboardRepo().
                Select(x => new  AdminTableViewModel
                {
                    RequestId = x.RequestId,
                     RequestedDate = x.CreatedDate.ToString(),
                     Phone = x.PhoneNumber,
                     Name = x.FirstName + " " + x.LastName,
                     /*Address = x.RequestClients. + ", " + x.City + ", " + x.State + " - " + x.ZipCode*/
                     Requester = x.FirstName + " " + x.LastName,
            }).ToList();

            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                TableViewModel = temp
            };
            return model;
        }

        public ViewCaseViewModel DisplsyViewCase(int requestId)
        {
            var model = _patientRepo.DisplayViewCaseRepo(requestId);
           

            return model;
        }

        public void GetBusinesssRequestData(BusinessRequestViewModel model)
        {
            _patientRepo.GetBusinessrequest(model);
        }

        public UserInfoViewModel CheckValidUserWithRole(string email, string password)
        {
            var model = _patientRepo.GetRoleByAspNetId(email, password);
            return model;
        }
    }
}
