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

        public void CancelCaseRepo(AdminDashboardViewModel model)
        {
            RequestStatusLog canceldata = new RequestStatusLog()
            {
                RequestId = model.RequestId,
                Status = 3,
                Notes = model.CancelNotes,
                CreatedDate = DateTime.Now,

            };

            _context.RequestStatusLogs.Add(canceldata);
            _context.SaveChanges();


            //Request request = new Request()
            //{
            //    Status =3,             
            //};

            //_context.Requests.Add(request);
            //_context.SaveChanges();

        }

        //public void AddRequestStatusLog(RequestStatusLog requestStatusLog)
        //{
        //  _context.RequestStatusLogs.Add(requestStatusLog);
        //  _context.SaveChanges();
        //}

        //public void CancelCaseDataRepo(AdminDashboardViewModel model)
        //{
        //    //Console.WriteLine( something);
        //}

        public List<Request> DisplayAdminDashboardRepo()
        {
            var model = _context.Requests.Include(x => x.RequestClients).ToList();
            return model;
        }

        public List<string> DisplayCasetags()
        {
            var Casetags = _context.CaseTags.Select(x => x.Name).ToList();
            return Casetags;
        }

        public List<string> DisplayRegions()
        {
            var Regions = _context.Regions.Select(x => x.Name).ToList();
            return Regions;
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

        //public Request GetRequestById(int requestId)
        //{
        //    return _context.Requests.Where(x => x.RequestId == requestId).FirstOrDefault();
        //}

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

        public AdminDashboardViewModel RenderToActiveState(int status1, int status2)
        {
            var tempmodel = _context.Requests.Include(x => x.RequestClients).Where(x => x.Status == status1 || x.Status== status2).
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

        public AdminDashboardViewModel RenderToCloseState(int status1, int status2, int status3)
        {
            var tempmodel = _context.Requests.Include(x => x.RequestClients).Where(x => x.Status == status1 ||  x.Status == status2 ||  x.Status == status3).
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

        //public void updateRequest(Request request)
        //{
        //    _context.Requests.Update(request);
        //    _context.SaveChanges();
        //}
    }
}
