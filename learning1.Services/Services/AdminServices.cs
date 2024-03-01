﻿using learning1.DBEntities.ViewModel;
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
    public class AdminServices : IAdminServices
    {
        private readonly IAdminRepo _adminRepo;
        public AdminServices(IAdminRepo adminRepo)
        {
            _adminRepo = adminRepo;
        }

        public AdminDashboardViewModel DisplayAdminDashboard()
        
        
        {
            var temp = _adminRepo.DisplayAdminDashboardRepo().
                Select(x => new AdminTableViewModel
                {
                    RequestId = x.RequestId,
                    RequestedDate = x.CreatedDate,
                    Phone = x.PhoneNumber,
                    Name = x.FirstName + " " + x.LastName,
                    Address = x.RequestClients.Select(x =>x.Address).FirstOrDefault(),
                    Requester = x.FirstName + " " + x.LastName,
                    RequestType = (RequestType)x.RequestTypeId,
                }).ToList();

            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                TableViewModel = temp
            };
            return model;
        }

        public ViewCaseViewModel DisplayViewCase(int requestId)
        {
            var model = _adminRepo.DisplayViewCaseRepo(requestId);
            return model;
        }

        public AdminDashboardViewModel RenderActiveStateData(int status)
        {
            var model = _adminRepo.RenderToActiveState(status);
            return model;
        }

        public AdminDashboardViewModel RenderConcludeStateData(int status)
        {
            var model = _adminRepo.RenderConcludeState(status);
            return model;
        }

        public AdminDashboardViewModel RenderNewStateData(int status)
        {
            var model = _adminRepo.RenderNewState(status);
            return model;
        }

        public AdminDashboardViewModel RenderPendingStateData(int status)
        {
            var model = _adminRepo.RenderPendingState(status);
            return model;
        }

        public AdminDashboardViewModel RenderToCloseStateData(int status)
        {
            var model = _adminRepo.RenderToCloseState(status);
            return model;
        }

        public AdminDashboardViewModel RenderUnpaidStateData(int status)
        {
            var model = _adminRepo.RenderUnpaidState(status);
            return model;
        }
    }
}
