﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using learning1.DBEntities.ViewModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace learning1.Services.IServices
{
    public interface IPatientServices
    {
        UserInfoViewModel CheckValidUserWithRole(string email, string password);
        AdminDashboardViewModel DisplayAdminDashboard();
        PatientDashboardViewModel displayDashboard(int id);
        PatientProfileViewModel DisplayPatientProfile(int id);
        ViewCaseViewModel DisplsyViewCase(int requestId);
        void GetBusinesssRequestData(BusinessRequestViewModel model);
        void GetConciergeRequestData(ConciergeRequestViewModel model);
        void GetFamilyRequestData(Family_FriendRequestViewModel model);
        void GetInformationElse(SubmitInformationElseVIewModel model);
        void GetInformationMe(SubmitInformationMeViewModel model);
        void GetPatientRequestData(PatientRequestViewModel model);
      
        ViewDocumentViewModel GetviewDocuments(int requestId, int id);
        void InsertviewDocuments(ViewDocumentViewModel model, int requestId);
        bool IsExistingUser(string email);

        //Model InsertviewDocuments(ViewDocumentViewModel viewDocumentViewModel,int req);
        int LoginMethod(string username, string password);
    }
}
