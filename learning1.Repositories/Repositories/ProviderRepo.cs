using learning1.DBEntities.Models;
using learning1.DBEntities.ViewModel;
using learning1.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace learning1.Repositories.Repositories
{
    public class ProviderRepo : IProviderRepo
    {
        private readonly DbHallodocContext _context;

        public ProviderRepo(DbHallodocContext context)
        {
            _context = context;
        }

        public List<string> DisplayCasetags()
        {
            var Casetags = _context.CaseTags.Select(x => x.Name).ToList();
            return Casetags;
        }

        public List<Request> DisplayProviderDashboardRepo(int PhysicianId)
        {
            var model = _context.Requests.Include(x => x.RequestClients).Where(x => x.PhysicianId == PhysicianId).ToList();
            return model;
        }

        public List<string> DisplayRegions()
        {
            var Regions = _context.Regions.Select(x => x.Name).ToList();
            return Regions;
        }

        public ProviderDashboardViewModel RenderConcludeState(int status, int physicianId, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
        {
            Expression<Func<Request, bool>> predicate;
            var Count = SetCount(physicianId);

            if (!string.IsNullOrEmpty(patientName) && !string.IsNullOrEmpty(regionName))
            {
                //predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status);
                predicate = x => (x.PhysicianId == physicianId) && (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.RequestClients.Any(x => x.State.ToLower().Contains(regionName.Trim().ToLower()))) && x.Status == status && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }

            else if (!string.IsNullOrEmpty(patientName))
            {
                //predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status);
                predicate = x => (x.PhysicianId == physicianId) && (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && x.Status == status && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }

            else if (!string.IsNullOrEmpty(regionName))
            {
                //predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status);
                predicate = x => (x.PhysicianId == physicianId) && (x.RequestClients.Any(x => x.State.ToLower().Contains(regionName.Trim().ToLower()))) && x.Status == status && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }

            else
            {
                predicate = x => (x.PhysicianId == physicianId) && (x.Status == status) && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }


            var tempmodel = _context.Requests.Include(x => x.RequestClients).Where(predicate).
            Select(x => new ProviderTableViewModel()
            {
                RequestId = x.RequestId,
                RequestedDate = x.CreatedDate.ToString(),
                PhoneNumber = x.RequestClients.Select(x => x.PhoneNumber).FirstOrDefault(),
                Phone = x.PhoneNumber,
                Email = x.Email,
                Name = x.RequestClients.Select(x => x.FirstName + " " + x.LastName).FirstOrDefault(),
                Address = x.RequestClients.Select(x => x.Address).FirstOrDefault(),
                Requester = x.FirstName + " " + x.LastName,
                RequestType = (DBEntities.ViewModel.RequestType)x.RequestTypeId,
                RequestNotes = x.RequestClients.Select(x => x.Notes).FirstOrDefault(),
            }).AsQueryable();


            var tempdata = tempmodel.Skip((page - 1) * pageSize).Take(pageSize).ToList().Count();
            ProviderDashboardViewModel model = new ProviderDashboardViewModel()
            {
                TableViewModel = tempmodel.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                RequestCount = Count,
                TotalRecord = tempmodel.Count(),
                ShowRecords = tempdata
            };
            return model;
        }

        public ProviderDashboardViewModel RenderNewState(int status,int physicianId, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
        {
            Expression<Func<Request, bool>> predicate;
            var Count = SetCount(physicianId);

            if (!string.IsNullOrEmpty(patientName) && !string.IsNullOrEmpty(regionName))
            {
                //predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status);
                predicate = x => (x.PhysicianId == physicianId) && (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.RequestClients.Any(x => x.State.ToLower().Contains(regionName.Trim().ToLower()))) && x.Status == status && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }

            else if (!string.IsNullOrEmpty(patientName))
            {
                //predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status);
                predicate = x => (x.PhysicianId == physicianId) && (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && x.Status == status && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }

            else if (!string.IsNullOrEmpty(regionName))
            {
                //predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status);
                predicate = x => (x.PhysicianId == physicianId) && (x.RequestClients.Any(x => x.State.ToLower().Contains(regionName.Trim().ToLower()))) && x.Status == status && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }

            else
            {
                predicate = x => (x.PhysicianId == physicianId) && (x.Status == status) && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }


            var tempmodel = _context.Requests.Include(x => x.RequestClients).Where(predicate).
            Select(x => new ProviderTableViewModel()
            {
                RequestId = x.RequestId,
                RequestedDate = x.CreatedDate.ToString("MMM dd, yyyy hh:mm tt"),
                PhoneNumber = x.RequestClients.Select(x => x.PhoneNumber).FirstOrDefault(),
                Phone = x.PhoneNumber,
                Email = x.Email,
                Name = x.RequestClients.Select(x => x.FirstName + " " + x.LastName).FirstOrDefault(),
                Address = x.RequestClients.Select(x => x.Address).FirstOrDefault(),
                Requester = x.FirstName + " " + x.LastName,
                RequestType = (DBEntities.ViewModel.RequestType)x.RequestTypeId,
                RequestNotes = x.RequestClients.Select(x => x.Notes).FirstOrDefault(),
            }).AsQueryable();


            var tempdata = tempmodel.Skip((page - 1) * pageSize).Take(pageSize).ToList().Count();
            ProviderDashboardViewModel model = new ProviderDashboardViewModel()
            {
                TableViewModel = tempmodel.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                RequestCount = Count,
                TotalRecord = tempmodel.Count(),
                ShowRecords = tempdata
            };
            return model;
        }

        public ProviderDashboardViewModel RenderPendingState(int status, int physicianId, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
        {
            Expression<Func<Request, bool>> predicate;
           var Count = SetCount(physicianId);

            if (!string.IsNullOrEmpty(patientName) && !string.IsNullOrEmpty(regionName))
            {
                //predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status);
                predicate = x => (x.PhysicianId == physicianId) && (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.RequestClients.Any(x => x.State.ToLower().Contains(regionName.Trim().ToLower()))) && x.Status == status && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }

            else if (!string.IsNullOrEmpty(patientName))
            {
                //predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status);
                predicate = x => (x.PhysicianId == physicianId) &&  (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && x.Status == status && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }

            else if (!string.IsNullOrEmpty(regionName))
            {
                //predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status);
                predicate = x => (x.PhysicianId == physicianId) && (x.RequestClients.Any(x => x.State.ToLower().Contains(regionName.Trim().ToLower()))) && x.Status == status && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }

            else
            {
                predicate = x => (x.PhysicianId == physicianId) && (x.Status == status) && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }
            var tempmodel = _context.Requests.Include(x => x.RequestClients).Include(x => x.RequestStatusLogs).Where(predicate).
            Select(x => new ProviderTableViewModel()
            {
                RequestId = x.RequestId,
                RequestedDate = x.CreatedDate.ToString(),
                PhoneNumber = x.RequestClients.Select(x => x.PhoneNumber).FirstOrDefault(),
                Phone = x.PhoneNumber,
                Email = x.Email,
                Name = x.RequestClients.Select(x => x.FirstName + " " + x.LastName).FirstOrDefault(),
                Address = x.RequestClients.Select(x => x.Address).FirstOrDefault(),
                Requester = x.FirstName + " " + x.LastName,
                RequestType = (DBEntities.ViewModel.RequestType)x.RequestTypeId,
                RequestNotes = x.RequestStatusLogs.Select(x => x.Notes).FirstOrDefault(),
            }).AsQueryable();


            var tempdata = tempmodel.Skip((page - 1) * pageSize).Take(pageSize).ToList().Count();
            ProviderDashboardViewModel model = new ProviderDashboardViewModel()
            {
                TableViewModel = tempmodel.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                RequestCount = Count,
                TotalRecord = tempmodel.Count(),
                ShowRecords = tempdata
            };
            return model;
        }

        public ProviderDashboardViewModel RenderToActiveState(int status1, int status2, int physicianId, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
        {
            Expression<Func<Request, bool>> predicate;
           var Count = SetCount(physicianId);

            if (!string.IsNullOrEmpty(patientName) && !string.IsNullOrEmpty(regionName))
            {
                //predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status);
                predicate = x => (x.PhysicianId == physicianId) && (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.RequestClients.Any(x => x.State.ToLower().Contains(regionName.Trim().ToLower()))) && (x.Status == status1 || x.Status == status2) && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }

            else if (!string.IsNullOrEmpty(patientName))
            {
                //predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status);
                predicate = x => (x.PhysicianId == physicianId) && (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status1 || x.Status == status2) && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }

            else if (!string.IsNullOrEmpty(regionName))
            {
                //predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status);
                predicate = x => (x.PhysicianId == physicianId) && (x.RequestClients.Any(x => x.State.ToLower().Contains(regionName.Trim().ToLower()))) && (x.Status == status1 || x.Status == status2) && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }

            else
            {
                predicate = x => (x.PhysicianId == physicianId) && (x.Status == status1 || x.Status == status2) && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }
            var tempmodel = _context.Requests.Include(x => x.RequestClients).Where(predicate).
             Select(x => new ProviderTableViewModel()
             {
                 RequestId = x.RequestId,
                 RequestedDate = x.CreatedDate.ToString(),
                 PhoneNumber = x.RequestClients.Select(x => x.PhoneNumber).FirstOrDefault(),
                 Phone = x.PhoneNumber,
                 Email = x.Email,
                 Name = x.RequestClients.Select(x => x.FirstName + " " + x.LastName).FirstOrDefault(),
                 Address = x.RequestClients.Select(x => x.Address).FirstOrDefault(),
                 Requester = x.FirstName + " " + x.LastName,
                 RequestType = (DBEntities.ViewModel.RequestType)x.RequestTypeId,
                 RequestNotes = x.RequestClients.Select(x => x.Notes).FirstOrDefault(),
             }).AsQueryable();


            var tempdata = tempmodel.Skip((page - 1) * pageSize).Take(pageSize).ToList().Count();
            ProviderDashboardViewModel model = new ProviderDashboardViewModel()
            {
                TableViewModel = tempmodel.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                RequestCount = Count,
                TotalRecord = tempmodel.Count(),
                ShowRecords = tempdata
            };
            return model;
        }

        public int GetCurrentStateCount(int physicianId, params int[] status)
        {
            int sum = 0;
            var requests = _context.Requests.Where(x => x.PhysicianId == physicianId);
            foreach (var item in status)
            {
                sum += requests.Where(e => e.Status == item).Count();
            }
            return sum;
        }


        public RequestCount SetCount(int physicianId)
        {
            RequestCount requestCount = new()
            {
                NewStateCount = GetCurrentStateCount(physicianId,1),
                PendingStateCount = GetCurrentStateCount(physicianId,2),
                ActiveStateCount = GetCurrentStateCount(physicianId, 4, 5),
                ConcludeStateCount = GetCurrentStateCount(physicianId, 6),
                ToCloseStateCount = GetCurrentStateCount(physicianId, 3, 7, 8),
                UnpaidStateCount = GetCurrentStateCount(physicianId, 9)
            };
            return requestCount;
        }

        public ViewCaseViewModel DisplayViewCaseRepo(int requestId)
        {
            var modal = _context.RequestClients.Include(x => x.Request).Where(x => x.RequestId == requestId)
                .Select(x => new ViewCaseViewModel()
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    email = x.Email,
                    phone = x.PhoneNumber,
                    Address = x.Address,
                    Region = x.State,
                }).FirstOrDefault();


            return modal;
        }

    }
}
