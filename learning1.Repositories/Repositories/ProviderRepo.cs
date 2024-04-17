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

        public List<Request> DisplayProviderDashboardRepo()
        {
            var model = _context.Requests.Include(x => x.RequestClients).ToList();
            return model;
        }

        public List<string> DisplayRegions()
        {
            var Regions = _context.Regions.Select(x => x.Name).ToList();
            return Regions;
        }

        public ProviderDashboardViewModel RenderConcludeState(int status, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
        {
            Expression<Func<Request, bool>> predicate;
            var Count = SetCount();

            if (!string.IsNullOrEmpty(patientName) && !string.IsNullOrEmpty(regionName))
            {
                //predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status);
                predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.RequestClients.Any(x => x.State.ToLower().Contains(regionName.Trim().ToLower()))) && x.Status == status && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }

            else if (!string.IsNullOrEmpty(patientName))
            {
                //predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status);
                predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && x.Status == status && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }

            else if (!string.IsNullOrEmpty(regionName))
            {
                //predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status);
                predicate = x => (x.RequestClients.Any(x => x.State.ToLower().Contains(regionName.Trim().ToLower()))) && x.Status == status && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }

            else
            {
                predicate = x => (x.Status == status) && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
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
            }).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ProviderDashboardViewModel model = new ProviderDashboardViewModel()
            {
                TableViewModel = tempmodel,
                RequestCount = Count,
            };
            return model;
        }

        public ProviderDashboardViewModel RenderNewState(int status, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
        {
            Expression<Func<Request, bool>> predicate;
            var Count = SetCount();

            if (!string.IsNullOrEmpty(patientName) && !string.IsNullOrEmpty(regionName))
            {
                //predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status);
                predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.RequestClients.Any(x => x.State.ToLower().Contains(regionName.Trim().ToLower()))) && x.Status == status && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }

            else if (!string.IsNullOrEmpty(patientName))
            {
                //predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status);
                predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && x.Status == status && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }

            else if (!string.IsNullOrEmpty(regionName))
            {
                //predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status);
                predicate = x => (x.RequestClients.Any(x => x.State.ToLower().Contains(regionName.Trim().ToLower()))) && x.Status == status && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }

            else
            {
                predicate = x => (x.Status == status) && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
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
            }).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ProviderDashboardViewModel model = new ProviderDashboardViewModel()
            {
                TableViewModel = tempmodel,
                RequestCount = Count,
            };
            return model;
        }

        public ProviderDashboardViewModel RenderPendingState(int status, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
        {
            Expression<Func<Request, bool>> predicate;
           var Count = SetCount();

            if (!string.IsNullOrEmpty(patientName) && !string.IsNullOrEmpty(regionName))
            {
                //predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status);
                predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.RequestClients.Any(x => x.State.ToLower().Contains(regionName.Trim().ToLower()))) && x.Status == status && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }

            else if (!string.IsNullOrEmpty(patientName))
            {
                //predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status);
                predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && x.Status == status && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }

            else if (!string.IsNullOrEmpty(regionName))
            {
                //predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status);
                predicate = x => (x.RequestClients.Any(x => x.State.ToLower().Contains(regionName.Trim().ToLower()))) && x.Status == status && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }

            else
            {
                predicate = x => (x.Status == status) && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
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
            }).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ProviderDashboardViewModel model = new ProviderDashboardViewModel()
            {
                TableViewModel = tempmodel,
                RequestCount = Count,
            };
            return model;
        }

        public ProviderDashboardViewModel RenderToActiveState(int status1, int status2, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
        {
            Expression<Func<Request, bool>> predicate;
           var Count = SetCount();

            if (!string.IsNullOrEmpty(patientName) && !string.IsNullOrEmpty(regionName))
            {
                //predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status);
                predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.RequestClients.Any(x => x.State.ToLower().Contains(regionName.Trim().ToLower()))) && (x.Status == status1 || x.Status == status2) && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }

            else if (!string.IsNullOrEmpty(patientName))
            {
                //predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status);
                predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status1 || x.Status == status2) && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }

            else if (!string.IsNullOrEmpty(regionName))
            {
                //predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status);
                predicate = x => (x.RequestClients.Any(x => x.State.ToLower().Contains(regionName.Trim().ToLower()))) && (x.Status == status1 || x.Status == status2) && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }

            else
            {
                predicate = x => (x.Status == status1 || x.Status == status2) && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
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
             }).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ProviderDashboardViewModel model = new ProviderDashboardViewModel()
            {
                TableViewModel = tempmodel,
                RequestCount = Count,
            };
            return model;
        }

        public int GetCurrentStateCount(params int[] status)
        {
            int sum = 0;
            foreach (var item in status)
            {
                sum += _context.Requests.Where(e => e.Status == item).Count();
            }
            return sum;
        }


        public RequestCount SetCount()
        {
            RequestCount requestCount = new()
            {
                NewStateCount = GetCurrentStateCount(1),
                PendingStateCount = GetCurrentStateCount(2),
                ActiveStateCount = GetCurrentStateCount(4, 5),
                ConcludeStateCount = GetCurrentStateCount(6),
                ToCloseStateCount = GetCurrentStateCount(3, 7, 8),
                UnpaidStateCount = GetCurrentStateCount(9)
            };
            return requestCount;
        }
    }
}
