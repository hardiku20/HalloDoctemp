using learning1.DBEntities.ViewModel;
using learning1.Repositories.IRepositories;
using learning1.Repositories.Repositories;
using learning1.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.Services.Services
{
    public class PatientServices: IPatientServices
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


        public void GetFamilyRequestData(Family_FriendRequestViewModel model)
        {
            _patientRepo.GetFamilyFriendRequests(model);
        }
    }
}
