﻿using learning1.DBEntities.Models;
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
    public class ProviderServices : IProviderServices
    {
        private readonly IProviderRepo _providerRepo;

        public ProviderServices(IProviderRepo providerRepo) { 
             _providerRepo = providerRepo;
        }

        public ProviderDashboardViewModel DisplayProviderDashboard(int PhysicianId)
        {
            var Casetags = _providerRepo.DisplayCasetags();
            var Regions = _providerRepo.DisplayRegions();
            var Count = _providerRepo.SetCount(PhysicianId);
            var temp = _providerRepo.DisplayProviderDashboardRepo(PhysicianId).
                Select(x => new ProviderTableViewModel
                {
                    RequestId = x.RequestId,
                    RequestedDate = x.CreatedDate.ToString(),
                    Phone = x.PhoneNumber,
                    Name = x.RequestClients.Select(x => x.FirstName + " " + x.LastName).FirstOrDefault(),
                    Address = x.RequestClients.Select(x => x.Address).FirstOrDefault(),
                    Requester = x.FirstName + " " + x.LastName,
                    PhoneNumber = x.PhoneNumber,
                    RequestType = (DBEntities.ViewModel.RequestType)x.RequestTypeId,
                }).ToList();

            ProviderDashboardViewModel model = new ProviderDashboardViewModel()
            {
                TableViewModel = temp,
               CancellationReason = Casetags,
               Region = Regions,
               RequestCount = Count,
            };
            return model;
        }

        public ProviderDashboardViewModel RenderActiveStateData(int status1, int status2, int physicianId, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
        {
            var model = _providerRepo.RenderToActiveState(status1, status2, physicianId,page, pageSize, patientName, regionName, requestType);
            return model;
        }

        public ProviderDashboardViewModel RenderConcludeStateData(int status, int physicianId, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
        {
            var model = _providerRepo.RenderConcludeState(status,physicianId ,page, pageSize, patientName, regionName, requestType);
            return model;
        }

        public ProviderDashboardViewModel RenderNewStateData(int status, int physicianId , int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
        {
            var model = _providerRepo.RenderNewState(status, physicianId, page, pageSize, patientName, regionName, requestType);
            return model;
        }

        public ProviderDashboardViewModel RenderPendingStateData(int status, int physicianId, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
        {
            var model = _providerRepo.RenderPendingState(status,physicianId ,page, pageSize, patientName, regionName, requestType);
            return model;
        }







        public ViewCaseViewModel DisplayViewCase(int requestId)
        {
            var model = _providerRepo.DisplayViewCaseRepo(requestId);
            return model;
        }

        public void acceptCase(int requestId)
        {
            _providerRepo.acceptcase(requestId);
        }

        public ViewUploadViewModel GetviewUploads(int requestId)
        {
            var model = _providerRepo.FetchViewUploads(requestId);
            return model;
        }

        public void InsertviewUploads(ViewUploadViewModel model, int requestId)
        {
            _providerRepo.Uploaddocuments(model, requestId);
        }

        public void GetTransferCaseData(ProviderDashboardViewModel model, int requestId)
        {
            _providerRepo.TransferCaseRepo(model, requestId);
        }
        public SendOrderViewModel GetOrderdetails()
        {
            var Profession = _providerRepo.DisplayProfession();
            SendOrderViewModel model = new SendOrderViewModel()
            {
                Profession = Profession,
            };
            return model;
        }

        public List<string> GetBusinessByProfession(string professionName)
        {
            var BusinessName = _providerRepo.GetBusinessByProfessionName(professionName);
            return BusinessName;
        }

        public SendOrderViewModel GetDetailsByBusiness(string businessName)
        {
            var Orderdetails = _providerRepo.GetOrder(businessName);
            return Orderdetails;
        }

        public void InsertOrderDetails(SendOrderViewModel model)
        {
            _providerRepo.OrderDetailRepo(model);
        }

        public ProviderProfileViewModel GetProviderProfileData(int physicianId)
        {
            var model = _providerRepo.GetProviderProfileRepo(physicianId);
            return model;
        }
    }
}
