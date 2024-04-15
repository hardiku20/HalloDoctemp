using learning1.DBEntities.Models;
using learning1.DBEntities.ViewModel;
using learning1.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq.Expressions;
using System.Data;
using static learning1.DBEntities.ViewModel.VendorViewModel;

namespace learning1.Repositories.Repositories
{

    public class AdminRepo : IAdminRepo
    {
        private readonly DbHallodocContext _context;
        public AdminRepo(DbHallodocContext context)
        {
            _context = context;
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


        public void AssignCaseRepo(AdminDashboardViewModel model, int requestId)
        {
            var regionId = _context.Regions.First(x => x.Name.Equals(model.SelectedRegion)).RegionId;
            var physicianId = _context.Physicians.First(x => x.FirstName.Equals(model.SelectedPhysician)).PhysicianId;
            //int RequestTypeId = .Select(x=>x.RequestTypeId).FirstOrDefault();


            Request request = _context.Requests.Where(x => x.RequestId == requestId).First();
            request.Status = 2;
            request.PhysicianId = physicianId;
            request.ModifiedDate = DateTime.Now;
            request.CompletedByPhysician = false;

            _context.Requests.Update(request);
            _context.SaveChanges();

            RequestClient requestClient = _context.RequestClients.Where(x => x.RequestId == requestId).First();
            requestClient.RegionId = regionId;
            requestClient.State = model.SelectedRegion;
            _context.RequestClients.Update(requestClient);
            _context.SaveChanges(true);

            string dateString = DateTime.Now.ToString("dd/mm/yyyy");
            string notetotransfer = "Admin Transfer to Dr." + model.SelectedPhysician + dateString;
            RequestStatusLog StatusData = new RequestStatusLog()
            {
                RequestId = requestId,
                Status = 2,
                Notes = notetotransfer,
                TransToPhysicianId = physicianId,
                CreatedDate = DateTime.Now,
                TransToAdmin = false,

            };
            _context.RequestStatusLogs.Add(StatusData);
            _context.SaveChanges();

        }

        public void BlockCaseRepo(AdminDashboardViewModel model)
        {
            RequestStatusLog blockdata = new RequestStatusLog()
            {
                RequestId = model.RequestId,
                Status = 11,
                Notes = model.BlockNotes,
                CreatedDate = DateTime.Now,
            };

            _context.RequestStatusLogs.Add(blockdata);
            _context.SaveChanges();

            Request request = _context.Requests.Where(x => x.RequestId == model.RequestId).First();
            request.Status = 11;

            _context.Requests.Update(request);
            _context.SaveChanges();



            var temp = _context.Requests.Include(x => x.RequestClients).Where(x => x.RequestId == model.RequestId).First();
            BlockRequest blockRequest = new BlockRequest()
            {
                PhoneNumber = temp.RequestClients.First().PhoneNumber,
                Email = temp.RequestClients.First().Email,
                Reason = model.BlockNotes,
                RequestId = model.RequestId,
                CreatedDate = DateTime.Now,
                IsActive = false,
            };
            _context.BlockRequests.Add(blockRequest);
            _context.SaveChanges();
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



            Request request = _context.Requests.Where(x => x.RequestId == model.RequestId).First();
            request.Status = 3;


            _context.Requests.Update(request);
            _context.SaveChanges();
        }

        public void ClearCaseRepo(AdminDashboardViewModel model)
        {
            Request request = _context.Requests.Where(x => x.RequestId == model.RequestId).First();
            request.Status = 10;
            _context.Requests.Update(request);
            _context.SaveChanges();
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

        public List<string> DisplayProfession()
        {
            var Profession = _context.HealthProfessionalTypes.Select(x => x.ProfessionName).ToList();
            return Profession;
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

        public ViewUploadViewModel FetchViewUploads(int requestId)
        {
            var documents = _context.RequestWiseFiles.Where(x => x.RequestId == requestId)
                .Select(x => new AdminDocumentViewModel
                {
                    CreatedDate = x.CreatedDate,
                    FileName = x.FileName,
                }).ToList();
            ViewUploadViewModel model = new ViewUploadViewModel()
            {
                RequestId = requestId,
                DocumentsViewModel = documents
            };

            return model;
        }

        public List<string> GetAvailablePhysicianByRegionName(string regionName)
        {
            int regionId = _context.Regions.Where(x => x.Name == regionName).Select(x => x.RegionId).First();
            var PhysicianName = _context.Physicians.Where(x => x.RegionId == regionId).Select(x => x.FirstName).ToList();
            return PhysicianName;
        }

        public List<string> GetBusinessByProfessionName(string professionName)
        {
            int professionId = _context.HealthProfessionalTypes.Where(x => x.ProfessionName == professionName).Select(x => x.HealthProfessionalId).First();
            var BusinessName = _context.HealthProfessionals.Where(x => x.Profession == professionId).Select(x => x.VendorName).ToList();
            return BusinessName;
        }

        public SendOrderViewModel GetOrder(string businessName)
        {

            var Orderdetails = _context.HealthProfessionals.Where(x => x.VendorName == businessName)
                .Select(x => new SendOrderViewModel
                {
                    BusinessContact = x.BusinessContact,
                    Email = x.Email,
                    FaxNumber = x.FaxNumber,
                    VendorId = x.VendorId,

                }).First();

            SendOrderViewModel model = new SendOrderViewModel()
            {
                BusinessContact = Orderdetails.BusinessContact,
                Email = Orderdetails.Email,
                FaxNumber = Orderdetails.FaxNumber,
                VendorId = Orderdetails.VendorId,
            };
            return model;
        }

        public List<string> GetPhysicianByRegionName(string regionName)
        {
            int regionId = _context.Regions.Where(x => x.Name == regionName).Select(x => x.RegionId).First();
            var PhysicianName = _context.Physicians.Where(x => x.RegionId == regionId).Select(x => x.FirstName).ToList();
            return PhysicianName;
        }

        public ViewNotesViewModel GetViewNotesRepo(int requestId)
        {
            var requestStatus = _context.RequestStatusLogs.FirstOrDefault(r => r.RequestId == requestId);
            var requestNotes = _context.RequestNotes.Where(r => r.RequestId == requestId).Select(r => new { r.RequestId, r.AdminNotes, r.PhysicianNotes }).ToList();


            if (requestStatus?.PhysicianId != null)
            {
                var physicianName = _context.Physicians.Find(requestStatus.PhysicianId);

                var model = new ViewNotesViewModel
                {
                    RequestId = requestId,
                    TransferNotes = requestStatus.Notes,
                    PhysicianName = physicianName.FirstName + " " + physicianName.LastName,
                    CreatedDate = requestStatus.CreatedDate,
                    PhysicianNotes = requestNotes.FirstOrDefault()?.PhysicianNotes,
                    AdminNotes = requestNotes.FirstOrDefault()?.AdminNotes,
                };
                return model;
            }
            else
            {
                var model = new ViewNotesViewModel
                {
                    RequestId = requestId,
                    //TransferNotes = requestStatus.Notes,
                    //CreatedDate = requestStatus.CreatedDate,
                    PhysicianNotes = requestNotes.FirstOrDefault()?.PhysicianNotes,
                    AdminNotes = requestNotes.FirstOrDefault()?.AdminNotes,
                };
                return model;
            }
        }

        public void OrderDetailRepo(SendOrderViewModel model)
        {
            OrderDetail order = new OrderDetail()
            {
                VendorId = model.VendorId,
                FaxNumber = model.FaxNumber,
                Email = model.Email,
                BusinessContact = model.BusinessContact,
                Prescription = model.OrderNotes,
                NoOfRefill = model.No_of_Refills,
                CreatedDate = DateTime.Now,
                RequestId = model.RequestId,
                CreatedBy = "Admin"
            };

            _context.OrderDetails.Add(order);
            _context.SaveChanges();
        }

        //public void OrderdetailsRepo(SendOrderViewModel model)
        //{
        //    throw new NotImplementedException();
        //}

        //public Request GetRequestById(int requestId)
        //{
        //    return _context.Requests.Where(x => x.RequestId == requestId).FirstOrDefault();
        //}

        public AdminDashboardViewModel RenderConcludeState(int status, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
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
            Select(x => new AdminTableViewModel()
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

            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                TableViewModel = tempmodel,
                RequestCount = Count,
            };
            return model;
        }




        public AdminDashboardViewModel RenderNewState(int status, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
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
            Select(x => new AdminTableViewModel()
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

            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                TableViewModel = tempmodel,
                RequestCount = Count,
            };
            return model;
        }



        public AdminDashboardViewModel RenderPendingState(int status, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
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
            var tempmodel = _context.Requests.Include(x => x.RequestClients).Include(x=>x.RequestStatusLogs).Where(predicate).
            Select(x => new AdminTableViewModel()
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

            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                TableViewModel = tempmodel,
                RequestCount = Count,
            };
            return model;
        }

        public AdminDashboardViewModel RenderToActiveState(int status1, int status2, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
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
             Select(x => new AdminTableViewModel()
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

            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                TableViewModel = tempmodel,
                RequestCount = Count,
            };
            return model;
        }

        public AdminDashboardViewModel RenderToCloseState(int status1, int status2, int status3, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
        {
            Expression<Func<Request, bool>> predicate;
            var Count = SetCount();

            if (!string.IsNullOrEmpty(patientName) && !string.IsNullOrEmpty(regionName))
            {
                //predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status);
                predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.RequestClients.Any(x => x.State.ToLower().Contains(regionName.Trim().ToLower()))) && (x.Status == status1 || x.Status == status2 || x.Status == status3) && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }

            else if (!string.IsNullOrEmpty(patientName))
            {
                //predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status);
                predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status1 || x.Status == status2 || x.Status == status3) && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }

            else if (!string.IsNullOrEmpty(regionName))
            {
                //predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status);
                predicate = x => (x.RequestClients.Any(x => x.State.ToLower().Contains(regionName.Trim().ToLower()))) && (x.Status == status1 || x.Status == status2 || x.Status == status3) && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }

            else
            {
                predicate = x => (x.Status == status1 || x.Status == status2 || x.Status == status3) && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            }
            var tempmodel = _context.Requests.Include(x => x.RequestClients).Where(predicate).
             Select(x => new AdminTableViewModel()
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

            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                TableViewModel = tempmodel,
                RequestCount = Count,
            };
            return model;
        }

        public AdminDashboardViewModel RenderUnpaidState(int status, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
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
            Select(x => new AdminTableViewModel()
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

            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                TableViewModel = tempmodel,
                RequestCount = Count,
            };
            return model;
        }

        public void SetViewNotes(ViewNotesViewModel model, int requestId)
        {
            //var temp = from rn in _context.RequestNotes
            //           join rs in _context.RequestStatusLogs on rn.RequestId equals rs.RequestId into rgroup
            //           from r in rgroup
            //           select new ;
            var AdminId = _context.RequestStatusLogs.Where(x => x.RequestId == requestId).Select(x => x.AdminId)?.FirstOrDefault();
            var ExistingRequestId = _context.RequestNotes.Where(x => x.RequestId == requestId).Select(x => x.RequestId).FirstOrDefault();
            if (ExistingRequestId != 0)
            {
                RequestNote requestNote = _context.RequestNotes.Where(X => X.RequestId == requestId)?.FirstOrDefault();
                requestNote.AdminNotes = model.NewAdminNotes;
                requestNote.CreatedBy = "Hardikkk";
                requestNote.CreatedDate = DateTime.Now;
                _context.Update(requestNote);
                _context.SaveChanges();
            }

            else
            {
                RequestNote requestNote = new RequestNote()
                {
                    RequestId = requestId,
                    AdminNotes = model.NewAdminNotes,
                    CreatedBy = "Hardikkk",
                    CreatedDate = DateTime.Now,
                };
                _context.Add(requestNote);
                _context.SaveChanges();
            }
        }

        public void TransferCaseRepo(AdminDashboardViewModel model, int requestId)
        {
            var regionId = _context.Regions.First(x => x.Name.Equals(model.SelectedTransferRegion)).RegionId;
            var physicianId = _context.Physicians.First(x => x.FirstName.Equals(model.SelectedTransferPhysician)).PhysicianId;

            Request request = _context.Requests.Where(x => x.RequestId == requestId).First();
            request.Status = 2;
            request.PhysicianId = physicianId;
            request.ModifiedDate = DateTime.Now;
            request.CompletedByPhysician = false;

            _context.Requests.Update(request);
            _context.SaveChanges();

            string dateString = DateTime.Now.ToString("dd/mm/yyyy 'at' hh:mm:ss tt");
            string notetotransfer = "Admin Transfer to Dr." + model.SelectedPhysician + dateString;
            RequestStatusLog StatusData = _context.RequestStatusLogs.Where(x => x.RequestId == requestId).First();
            StatusData.TransToPhysicianId = physicianId;

            _context.RequestStatusLogs.Update(StatusData);
            _context.SaveChanges();
        }

        public ViewUploadViewModel Uploaddocuments(ViewUploadViewModel model, int requestId)
        {
            string fileName = requestId.ToString() + " - " + model.formFile.FileName;
            string filePath = Path.Combine("Files", "PatientDocs", fileName);
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                model.formFile.CopyTo(stream);
            }

            RequestWiseFile files = new RequestWiseFile()
            {
                RequestId = requestId,
                FileName = fileName,
                CreatedDate = DateTime.Now,
            };
            _context.RequestWiseFiles.Add(files);
            _context.SaveChanges();

            return model;

        }



        //public void Mails(string email, int reqId)
        //{
        //    var usr = _context.Users.Where(u => u.Email == email).FirstOrDefault();
        //    System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

        //    message.From = new System.Net.Mail.MailAddress("tatav.dotnet.hardikupadhyay@outlook.com");
        //    message.To.Add(new System.Net.Mail.MailAddress(email));
        //    message.Subject = "AGREEMENT";
        //    message.IsBodyHtml = true;
        //    var resetLink = "https://localhost:44352/home/reviewagreement?reqId=" + reqId;
        //    message.Body = resetLink + "Agreement";
        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Host = "smtp.office365.com";
        //    smtp.Port = 587;
        //    smtp.Credentials = new NetworkCredential("tatav.dotnet.hardikupadhyay@outlook.com", "Hardik@2003");
        //    smtp.EnableSsl = true;
        //    smtp.Send(message);
        //    smtp.UseDefaultCredentials = false;
        //}

        //public void SendLinkRepo(AdminDashboardViewModel model)
        //{  
        //    System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
        //    message.From = new System.Net.Mail.MailAddress("tatav.dotnet.hardikupadhyay@outlook.com");
        //    message.To.Add(new System.Net.Mail.MailAddress(model.PatientEmail));
        //    message.Subject = "AGREEMENT";
        //    message.IsBodyHtml = true;
        //    var resetLink = "https://localhost:44352/home/reviewagreement?reqId=";
        //    message.Body = resetLink + "Agreement";
        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Host = "smtp.office365.com";
        //    smtp.Port = 587;
        //    smtp.Credentials = new NetworkCredential("tatav.dotnet.hardikupadhyay@outlook.com", "Hardik@2003");
        //    smtp.EnableSsl = true;
        //    smtp.Send(message);
        //    smtp.UseDefaultCredentials = false;
        //}

        public AdminDashboardViewModel ListToExportAllData()
        {
            List<ExportDataViewModel> data;
            var query = from r in _context.Requests
                        join rc in _context.RequestClients on r.RequestId equals rc.RequestId
                        join u in _context.Users on r.UserId equals u.UserId
                        select new ExportDataViewModel
                        {
                            FirstName = rc.FirstName,
                            LastName = rc.LastName,
                            Intdate = rc.IntDate,
                            Intyear = rc.IntYear,
                            Strmonth = rc.StrMonth,
                            RequestorFirstname = r.FirstName,
                            RequestorLastname = r.LastName,
                            Createddate = r.CreatedDate,
                            Phonenumber = rc.PhoneNumber,
                            City = rc.City,
                            State = rc.State,
                            Street = rc.Street,
                            Zipcode = rc.ZipCode,
                            Notes = rc.Notes,
                            Status = r.Status,
                            Email = u.Email,
                            RequestTypeId = r.RequestTypeId,
                            RequestId = r.RequestId,
                            ConfirmationNumber = r.ConfirmationNumber
                        };
            data = query.ToList();

            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                ExportViewModel = data,
            };

            return model;
        }

        public void Mails(int requestId)
        {
            var email = _context.Requests.Where(x => x.RequestId == requestId).Select(x => x.Email).FirstOrDefault();
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

            message.From = new System.Net.Mail.MailAddress("tatav.dotnet.hardikupadhyay@outlook.com");
            message.To.Add(new System.Net.Mail.MailAddress(email));
            message.Subject = "AGREEMENT";
            message.IsBodyHtml = true;
            var resetLink = "https://localhost:44352/home/reviewagreement?requsetId=" + requestId;
            message.Body = resetLink + "Agreement";
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "mail.etatvasoft.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("tatav.dotnet.hardikupadhyay@outlook.com", "Hardik@2003");
            smtp.EnableSsl = true;
            smtp.Send(message);
            smtp.UseDefaultCredentials = false;
        }

        public EncounterFormViewModel GetEncounterRepo(int requestId)
        {
            var Encounterdata = _context.RequestClients.Where(x => x.RequestId == requestId)
                .Select(x => new EncounterFormViewModel()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Location = x.Address,
                    Email = x.Email,
                    Phone = x.PhoneNumber,
                }).FirstOrDefault();

            EncounterFormViewModel model = new EncounterFormViewModel()
            {
                FirstName = Encounterdata.FirstName,
                LastName = Encounterdata.LastName,
                Location = Encounterdata.Location,
                Email = Encounterdata.Email,
                Phone = Encounterdata.Phone,
            };

            return model;
        }

        public int LoginMethodRepo(string email, string password)
        {
            var temp = _context.AspNetUsers.Where(u => u.Email == email && u.PasswordHash == password).FirstOrDefault();
            if (temp != null)
            {
                int AdminId = _context.Admins.Where(a => a.AspNetUserId == temp.Id).Select(x => x.AdminId).FirstOrDefault();
                return AdminId;
            }
            else
            {
                return -1;
            }
        }

        public void SendlinkMail(AdminDashboardViewModel model)
        {
            var email = model.PatientEmail;
            var name = model.firstName + " " + model.lastName;
            var Createlink = "https://localhost:44352/home/reviewagreement";
            var emailbody = $@" 
<html>
        <head>
            <title>Agreement Form</title>
        </head>
        <body>
            <p>Hello {name},</p>
            <p>Please Create your account by clicking the link below:</p>
            <p>{Createlink}</p>
            <p>Sincerely,</p>
            <p>Admin</p>
        </body>
        </html>
";
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

            message.From = new System.Net.Mail.MailAddress("tatav.dotnet.hardikupadhyay@outlook.com");
            message.To.Add(new System.Net.Mail.MailAddress(email));
            message.Subject = "Create your Account";
            message.IsBodyHtml = true;
            message.Body = emailbody;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "mail.etatvasoft.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("tatav.dotnet.hardikupadhyay@outlook.com", "Hardik@2003");
            smtp.EnableSsl = true;
            smtp.Send(message);
            smtp.UseDefaultCredentials = false;
        }

        public void CreateRequestRepo(CreateRequestViewModel model)
        {
            AspNetUser netUser = new AspNetUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.Phone,
                CreatedDate = DateTime.Now,
            };
            _context.AspNetUsers.Add(netUser);
            _context.SaveChanges();


            //User
            User user = new User
            {
                Email = model.Email,
                AspNetUserId = netUser.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Mobile = model.Phone,
                Street = model.Street,
                City = model.City,
                State = model.State,
                ZipCode = model.ZipCode,
                CreatedBy = "hardik",
                CreatedDate = DateTime.Now,
            };

            _context.Users.Add(user);
            _context.SaveChanges();



            Request request = new Request
            {
                UserId = user.UserId,
                RequestTypeId = 2,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.Phone,
                Email = model.Email,
                Status = 1,
                CreatedDate = DateTime.Now,

            };


            _context.Requests.Add(request);
            _context.SaveChanges();

            RequestClient requestClient = new RequestClient
            {

                RequestId = request.RequestId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.Phone,
                Email = model.Email,
                State = model.State,
                City = model.City,
                Street = model.Street,
                ZipCode = model.ZipCode,
                Address = model.Street + ", " + model.City + ", " + model.State + "- " + model.ZipCode
            };


            _context.RequestClients.Add(requestClient);
            _context.SaveChanges();
        }

        public List<Region> GetRegionTable()
        {
            return _context.Regions.ToList();
        }

        public AdminProfileViewModel GetAdminProfileRepo(int adminId)
        {
            var region = GetRegionTable();
            var model = _context.Admins.Include(x => x.AdminRegions).Where(x => x.AdminId == adminId).Select(x => new AdminProfileViewModel()
            {
                AdminId = adminId,
                firstName = x.FirstName,
                lastName = x.LastName,
                Email = x.Email,
                confirmEmail = x.Email,
                Phone = x.Mobile,
                Address1 = x.Address1,
                Address2 = x.Address2,
                City = x.City,

                Zip = x.Zip,
                MailingPhone = x.AltPhone,
                Region = region,
            }).FirstOrDefault();

            return model;
        }

        public List<Menu> GetMenuRepo(int accountType)
        {
            var menu = _context.Menus.ToList();
            if (accountType != 0)
            {
                menu = menu.Where(x => x.AccountType == accountType).ToList();
            }
            return menu;

        }

        public void CreateRoleRepo(CreateRoleViewModel model)
        {
            Role role = new Role()
            {
                Name = model.RoleName,
                AccountType = short.Parse(model.AccountType),
                CreatedBy = "hardik",
                CreatedDate = DateTime.Now,
                IsDeleted = false

            };

            _context.Roles.Add(role);
            _context.SaveChanges();

            if (role.AccountType != 3)
            {
                foreach (var item in model.SelectedMenus)
                {
                    RoleMenu roleMenu = new RoleMenu()
                    {
                        RoleId = role.RoleId,
                        MenuId = item,
                    };
                    _context.RoleMenus.Add(roleMenu);
                }
                _context.SaveChanges();
            }

        }

        public AccountAccessViewModel GetAccountAccessRepo()
        {
            AccountAccessViewModel model = new AccountAccessViewModel()
            {
                Roledata = _context.Roles.Where(x => x.IsDeleted == false).ToList(),

            };

            return model;

        }

        public CreateRoleViewModel GetRoleDetailsRepo(int roleId)
        {
            if (roleId != 0)
            {

                Role role = _context.Roles.Where(x => x.RoleId == roleId).FirstOrDefault();

                CreateRoleViewModel model = new CreateRoleViewModel()
                {
                    RoleId = roleId,
                    AccountType = role.AccountType.ToString(),
                    RoleName = role.Name,
                    SelectedMenus = _context.RoleMenus.Where(x => x.RoleId == roleId).Select(x => x.MenuId).ToList(),
                    menulist = _context.Menus.Where(x => x.AccountType == role.AccountType).ToList(),

                };
                return model;
            }

            else
            {
                CreateRoleViewModel model = new CreateRoleViewModel();


                return model;
            }






        }

        public void DeleteRoleRepo(int roleId)
        {
            var role = _context.Roles.Where(x => x.RoleId == roleId).FirstOrDefault();
            role.IsDeleted = true;

            _context.Roles.Update(role);
            _context.SaveChanges();

        }

        public List<ShiftDetail> GetScheduleData()
        {
            try
            {
                return _context.ShiftDetails.Include(m => m.Shift).Where(m => m.IsDeleted == false).ToList();
            }
            catch { return new List<ShiftDetail> { }; }
        }

        public List<ProviderMenuDetailsViewModel> ProviderMenuTableDetails(int regionId)
        {
            var temp = _context.Physicians.Where(x => regionId == 0 || x.RegionId == regionId).
               Select(x => new ProviderMenuDetailsViewModel
               {
                   PhysicianId = x.PhysicianId,
                   //Role = (RoleName)x.RoleId,
                   //Status = (PhysicianStatus)x.Status,
                   //OnCallStatus = "Unavailable",
                   Name = x.FirstName + " " + x.LastName,
               }).ToList();

            return temp;
        }

        public List<HealthProfessionalType> DisplayProfessionlist()
        {
            return _context.HealthProfessionalTypes.ToList();
        }

        public void AddBusinessRepo(AddBusinessViewModal modal)
        {
            HealthProfessional healthProfessional = new HealthProfessional()
            {
                VendorName = modal.BusinessName,
                Profession = modal.Profession,
                FaxNumber = modal.FaxNumber,
                PhoneNumber = modal.PhoneNumber,
                Email = modal.Email,
                BusinessContact = modal.BusinessContact,
                State = modal.State,
                City = modal.City,
                Zip = modal.Zipcode,
                CreatedDate = DateTime.Now,
                Address = modal.Street,
                IsDeleted = false,
            };

            _context.Add(healthProfessional);
            _context.SaveChanges();
        }



        public AddBusinessViewModal GetBusinessRepo(int vendorId)
        {
            var ProfessionType = _context.HealthProfessionalTypes.ToList();
            var temp = _context.HealthProfessionals.Where(x => x.VendorId == vendorId)
                .Select(x => new AddBusinessViewModal()
                {
                    VendorId = vendorId,
                    BusinessName = x.VendorName,
                    Profession = (int)x.Profession,
                    FaxNumber = x.FaxNumber,
                    PhoneNumber = x.PhoneNumber,
                    Email = x.Email,
                    BusinessContact = x.BusinessContact,
                    Street = x.Address,
                    City = x.City,
                    State = x.State,
                    Zipcode = x.Zip,
                    ProfessionalTypes = ProfessionType,

                }).FirstOrDefault();
            return temp;
        }

        public void UpdateBusinessRepo(AddBusinessViewModal modal)
        {
            HealthProfessional healthProfessional = _context.HealthProfessionals.Where(x => x.VendorId == modal.VendorId).FirstOrDefault();
            healthProfessional.Profession = modal.Profession;
            healthProfessional.VendorName = modal.BusinessName;
            healthProfessional.FaxNumber = modal.FaxNumber;
            healthProfessional.PhoneNumber = modal.PhoneNumber;
            healthProfessional.Email = modal.Email;
            healthProfessional.BusinessContact = modal.BusinessContact;
            healthProfessional.Address = modal.Street;
            healthProfessional.City = modal.City;
            healthProfessional.State = modal.State;
            healthProfessional.Zip = modal.Zipcode;
            healthProfessional.ModifiedDate = DateTime.Now;


            _context.HealthProfessionals.Update(healthProfessional);
            _context.SaveChanges();
        }

        public void DeleteBusinessRepo(int vendorId)
        {
            HealthProfessional healthProfessional = _context.HealthProfessionals.Where(x => x.VendorId == vendorId).FirstOrDefault();
            healthProfessional.IsDeleted = true;
            healthProfessional.ModifiedDate = DateTime.Now;

            _context.HealthProfessionals.Update(healthProfessional);
            _context.SaveChanges();
        }

        public VendorViewModel GetVendorRepo(int professionId, string vendorName)
        {

            Expression<Func<HealthProfessional, bool>> predicate;

            if (!string.IsNullOrEmpty(vendorName) && professionId != 0)
            {
                predicate = x => ((x.VendorName.ToLower().Contains(vendorName.Trim().ToLower())) && (x.Profession == professionId)) && (x.IsDeleted == false);
            }
            else if (!string.IsNullOrEmpty(vendorName))
            {
                predicate = x => ((x.VendorName.ToLower().Contains(vendorName.Trim().ToLower()))) && (x.IsDeleted == false);
            }
            else if (professionId != 0)
            {
                predicate = x => (x.Profession == professionId) && (x.IsDeleted == false);
            }
            else
            {
                predicate = x => (x.IsDeleted == false);
            }

            var ProfessionType = _context.HealthProfessionalTypes.ToList();
            var healthProfessionals = _context.HealthProfessionals.Where(predicate)
                .Select(x => new VendorTableViewModal()
                {
                    VendorId = x.VendorId,
                    Profession = (int)x.Profession,
                    BusinessName = x.VendorName,
                    Email = x.Email,
                    FaxNumber = x.FaxNumber,
                    PhoneNumber = x.PhoneNumber,
                    BusinessContact = x.BusinessContact,
                }).ToList();
            VendorViewModel modal = new VendorViewModel()
            {
                VendorTableViewModals = healthProfessionals,
                ProfessionalTypes = ProfessionType,
            };
            return modal;



            //Expression<Func<Request, bool>> predicate;
            //var Count = SetCount();

            //if (!string.IsNullOrEmpty(patientName))
            //{
            //    //predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && (x.Status == status);
            //    predicate = x => (x.RequestClients.Any(x => x.FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.LastName.ToLower().Contains(patientName.Trim().ToLower()))) && x.Status == status && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            //}

            //else
            //{
            //    predicate = x => (x.Status == status) && (requestType == DBEntities.ViewModel.RequestType.All ? true : x.RequestTypeId == (int)requestType);
            //}
        }

        public RecordsViewModel PatientHistoryRepo(string firstname, string lastname, string email, string phonenumber)
        {
            var users = _context.Users
                .Where(x => (firstname == null || x.FirstName.ToLower().Contains(firstname.Trim().ToLower())) &&
                (lastname == null || x.LastName.ToLower().Contains(lastname.Trim().ToLower())) &&
                (email == null || x.Email.ToLower().Contains(email.Trim().ToLower())) &&
                (phonenumber == null || x.Mobile.ToLower().Contains(phonenumber.Trim().ToLower())))
                .Select(x => new DBEntities.ViewModel.RecordsViewModel.PatientHistory()
                {
                    UserId = x.UserId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    PhoneNumber = x.Mobile,
                    Address = x.Street + " " + x.City + " " + x.State + " " + x.ZipCode,
                }).ToList();

            RecordsViewModel model = new RecordsViewModel()
            {
                patientHistory = users,
            };




            return model;
        }

        public RecordsViewModel PatientExploreRepo(int userId)
        {
            var Exploredata = _context.Requests.Include(x => x.User).Include(x => x.RequestClients).Include(x => x.Physician)
                .Where(x => x.UserId == userId).Select(x => new RecordsViewModel.PatientRecords()
                {
                    Client = x.RequestClients.FirstOrDefault().FirstName + " " + x.RequestClients.FirstOrDefault().LastName,
                    CreatedDate = x.CreatedDate,
                    ConfirmationNumber = x.ConfirmationNumber,
                    ProviderName = x.Physician.FirstName + " " + x.Physician.LastName,
                    Status = x.Status,
                    requestId = x.RequestId,
                }).ToList();


            RecordsViewModel model = new RecordsViewModel()
            {
                patientRecords = Exploredata,
            };

            return model;
        }

        public RecordsViewModel SearchDataRepo(string patientName, string providerName, string email, string phoneNumber)
        {
            var SearchData = _context.Requests.Include(x => x.RequestClients).Include(x => x.Physician).Include(x => x.RequestNotes)
                .Where(x => (patientName == null || x.RequestClients.FirstOrDefault().FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.RequestClients.FirstOrDefault().LastName.ToLower().Contains(patientName.Trim().ToLower())) && (providerName == null || x.Physician.FirstName.ToLower().Contains(providerName.Trim().ToLower()) || x.Physician.LastName.ToLower().Contains(patientName.Trim().ToLower()))  && 
                (email == null || x.RequestClients.FirstOrDefault().Email.ToLower().Contains(email.Trim().ToLower())) && (phoneNumber == null || x.RequestClients.FirstOrDefault().PhoneNumber.Contains(phoneNumber.Trim())))
                .Select(x => new RecordsViewModel.SearchRecords()
                {
                    PatientName = x.RequestClients.FirstOrDefault().FirstName + " " + x.RequestClients.FirstOrDefault().LastName,
                    Requester = x.LastName,
                    Email = x.RequestClients.FirstOrDefault().Email,
                    PhoneNumber = x.RequestClients.FirstOrDefault().PhoneNumber,
                    Address = x.RequestClients.FirstOrDefault().Street + " " + x.RequestClients.FirstOrDefault().City + " " + x.RequestClients.FirstOrDefault().State + " " + x.RequestClients.FirstOrDefault().ZipCode,
                    Zipcode = x.RequestClients.FirstOrDefault().ZipCode,
                    RequestStatus = x.Status,
                    Physician = x.Physician.FirstName + " " + x.Physician.LastName,
                    PhysicianNote = x.RequestNotes.Select(x => x.PhysicianNotes).First() ?? "Notessss",
                    AdminNote = x.RequestNotes.FirstOrDefault().AdminNotes ?? "Notessss",
                    RequestId = x.RequestId,
                }).ToList();


            RecordsViewModel model = new RecordsViewModel()
            {
                searchRecords = SearchData,
            };

            return model;
        }

        public UserAccessViewModel GetUserAccessRepo()
        {
            //var data = _context.AspNetUsers.Where(x => x.UserName != null).Include(x => x.AspNetUserRoles).Include(x => x.Admins).Include(x => x.Admins)
            //                 .Where(x => x.Physicians.FirstOrDefault().Isdeleted == null && x.Admins.FirstOrDefault().Isdeleted == null
            //                 && (x.Aspnetuserroles.FirstOrDefault().Roleid == 1 || x.Aspnetuserroles.FirstOrDefault().Roleid == 3))


            return new();
        }














        ///checkkk hereee
        //public RecordsViewModel BlockDataRepo(string name, string date, string email, string phoneNumber)
        //{
        //    var blockRecords = _context.Requests.Include(x => x.RequestClients).Include(x => x.BlockRequests)
        //        .Where(x => (name == null || x.RequestClients.FirstOrDefault().FirstName.ToLower().Contains(name.Trim().ToLower())
        //        && x.RequestClients.FirstOrDefault().LastName.ToLower().Contains(name.Trim().ToLower())
        //        && x.BlockRequests.FirstOrDefault().Email.ToLower().Contains(email.Trim().ToLower())
        //        && x.BlockRequests.FirstOrDefault().PhoneNumber.ToLower().Contains(phoneNumber.Trim().ToLower())))
        //        .Select(x => new RecordsViewModel.BlockRecords()
        //        {
        //            PatientName = x.RequestClients.FirstOrDefault().FirstName + " " + x.RequestClients.FirstOrDefault().LastName,
        //            PhoneNumber = x.BlockRequests.FirstOrDefault().PhoneNumber,
        //            Email = x.BlockRequests.FirstOrDefault().Email,
        //            createdDate = x.BlockRequests.FirstOrDefault().CreatedDate.ToString(),
        //            Notes= x.BlockRequests.FirstOrDefault().Reason,
        //            isActive = x.BlockRequests.FirstOrDefault().IsActive,
        //            RequestId = x.RequestId,
        //            BlockRequestId = x.BlockRequests.FirstOrDefault().BlockRequestId,

        //        }).ToList();

        //    RecordsViewModel model = new RecordsViewModel()
        //    {
        //        blockRecords = blockRecords,
        //    };
        //    return model;
        //}







        //public AccountAccessViewModel EditRoleRepo(int roleId)
        //{
        //   var model = _context.Roles.Where(x=>x.RoleId == roleId)
        //        .Select(x=> new AccountAccessViewModel()
        //   {
        //        Name = x.Name,
        //        RoleId = roleId,
        //        AccountType = x.AccountType.ToString(),
        //   }).FirstOrDefault();

        //    return model;
        //}

        //public List<string> GetMenuListRepo(int accountType)
        //{
        //    var Menulist = _context.Menus.Where(x => x.AccountType == accountType).Select(x=>x.Name).ToList();
        //    return Menulist;
        //}
    }
}