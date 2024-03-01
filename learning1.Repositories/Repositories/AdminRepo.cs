using learning1.DBEntities.Models;
using learning1.DBEntities.ViewModel;
using learning1.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.Repositories.Repositories
{
    public class AdminRepo : IAdminRepo
    {
        private readonly DbHallodocContext _context;
        public AdminRepo(DbHallodocContext context) { 
            _context = context;
        }

        public List<Request> DisplayAdminDashboardRepo()
        {
            var model = _context.Requests.Include(x => x.RequestClients).ToList();
            return model;
        }

        public ViewCaseViewModel DisplayViewCaseRepo(int requestId)
        {
            var Requests = _context.RequestClients.Include(y => y.Request).Where(x => x.RequestId == requestId)
                .Select(x => new ViewCaseViewModel()
                {
                    firstName = x.Request.FirstName,
                    lastName = x.Request.LastName,
                    email = x.Request.Email,
                    phone = x.PhoneNumber,
                }).FirstOrDefault();
            



            return Requests;
        }

        public AdminDashboardViewModel RenderConcludeState(int status)
        {
            var tempmodel = _context.Requests.Include(x => x.RequestClients).Where(x => x.Status == status).
            Select(x => new AdminTableViewModel()
            {
                RequestId = x.RequestId,
                RequestedDate = x.CreatedDate,
                Phone = x.PhoneNumber,
                Name = x.FirstName + " " + x.LastName,
                Address = x.RequestClients.Select(x => x.Address).FirstOrDefault(),
                Requester = x.FirstName + " " + x.LastName,
                RequestType = (DBEntities.ViewModel.RequestType)x.RequestTypeId,
            }).ToList();

            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                TableViewModel = tempmodel
            };
            return model;
        }

        public AdminDashboardViewModel RenderNewState(int status)
        {
            var tempmodel = _context.Requests.Include(x => x.RequestClients).Where(x => x.Status == status).
            Select(x => new AdminTableViewModel()
            {
                RequestId = x.RequestId,
                RequestedDate = x.CreatedDate,
                Phone = x.PhoneNumber,
                Name = x.FirstName + " " + x.LastName,
                Address = x.RequestClients.Select(x => x.Address).FirstOrDefault(),
                Requester = x.FirstName + " " + x.LastName,
                RequestType = (DBEntities.ViewModel.RequestType)x.RequestTypeId,
            }).ToList();

            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                TableViewModel = tempmodel
            };
            return model;
        }

        public AdminDashboardViewModel RenderPendingState(int status)
        {
            var tempmodel = _context.Requests.Include(x => x.RequestClients).Where(x => x.Status == status).
            Select(x => new AdminTableViewModel()
            {
                RequestId = x.RequestId,
                RequestedDate = x.CreatedDate,
                Phone = x.PhoneNumber,
                Name = x.FirstName + " " + x.LastName,
                Address = x.RequestClients.Select(x => x.Address).FirstOrDefault(),
                Requester = x.FirstName + " " + x.LastName,
                RequestType = (DBEntities.ViewModel.RequestType)x.RequestTypeId,
            }).ToList();

            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                TableViewModel = tempmodel
            };
            return model;
        }

        public AdminDashboardViewModel RenderToActiveState(int status)
        {
            var tempmodel = _context.Requests.Include(x => x.RequestClients).Where(x => x.Status == status).
             Select(x => new AdminTableViewModel()
             {
                 RequestId = x.RequestId,
                 RequestedDate = x.CreatedDate,
                 Phone = x.PhoneNumber,
                 Name = x.FirstName + " " + x.LastName,
                 Address = x.RequestClients.Select(x => x.Address).FirstOrDefault(),
                 Requester = x.FirstName + " " + x.LastName,
                 RequestType = (DBEntities.ViewModel.RequestType)x.RequestTypeId,
             }).ToList();

            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                TableViewModel = tempmodel
            };
            return model;
        }

        public AdminDashboardViewModel RenderToCloseState(int status)
        {
            var tempmodel = _context.Requests.Include(x => x.RequestClients).Where(x => x.Status == status).
             Select(x => new AdminTableViewModel()
             {
                 RequestId = x.RequestId,
                 RequestedDate = x.CreatedDate,
                 Phone = x.PhoneNumber,
                 Name = x.FirstName + " " + x.LastName,
                 Address = x.RequestClients.Select(x => x.Address).FirstOrDefault(),
                 Requester = x.FirstName + " " + x.LastName,
                 RequestType = (DBEntities.ViewModel.RequestType)x.RequestTypeId,
             }).ToList();

            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                TableViewModel = tempmodel
            };
            return model;
        }

        public AdminDashboardViewModel RenderUnpaidState(int status)
        {
            var tempmodel = _context.Requests.Include(x => x.RequestClients).Where(x => x.Status == status).
            Select(x => new AdminTableViewModel()
            {
                RequestId = x.RequestId,
                RequestedDate = x.CreatedDate,
                Phone = x.PhoneNumber,
                Name = x.FirstName + " " + x.LastName,
                Address = x.RequestClients.Select(x => x.Address).FirstOrDefault(),
                Requester = x.FirstName + " " + x.LastName,
                RequestType = (DBEntities.ViewModel.RequestType)x.RequestTypeId,
            }).ToList();

            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                TableViewModel = tempmodel
            };
            return model;
        }
    }
}
