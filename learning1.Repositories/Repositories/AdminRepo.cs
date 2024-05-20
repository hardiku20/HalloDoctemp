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
using AspNetCoreHero.ToastNotification.Abstractions;
using System.Collections;
using System.Collections.Immutable;

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
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    email = x.Email,
                    phone = x.PhoneNumber,
                    Address = x.Address,
                    Region = x.State,
                    Patientnotes = x.Notes ?? "No Notes Available",
                }).FirstOrDefault();
            return Requests;
        }

        public ViewUploadViewModel FetchViewUploads(int requestId)
        {
            var userName = _context.RequestClients.Where(x => x.RequestId == requestId).FirstOrDefault();
            var documents = _context.RequestWiseFiles.Where(x => x.RequestId == requestId)
                .Select(x => new AdminDocumentViewModel
                {
                    CreatedDate = x.CreatedDate,
                    FileName = x.FileName,
                }).ToList();
            ViewUploadViewModel model = new ViewUploadViewModel()
            {
                UserName = userName.FirstName + " " + userName.LastName,
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
                Address = x.RequestClients.Select(x => x.Address).FirstOrDefault() ?? "No address available",
                Requester = x.FirstName + " " + x.LastName,
                RequestType = (DBEntities.ViewModel.RequestType)x.RequestTypeId,
                RequestNotes = x.RequestClients.Select(x => x.Notes).FirstOrDefault(),
            }).AsQueryable();

            var tempdata = tempmodel.Skip((page - 1) * pageSize).Take(pageSize).ToList().Count();
            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                TableViewModel = tempmodel.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                RequestCount = Count,
                TotalRecord = tempmodel.Count(),
                ShowRecords = tempdata
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
                Address = x.RequestClients.Select(x => x.Address).FirstOrDefault() ?? "No address available",
                Requester = x.FirstName + " " + x.LastName,
                RequestType = (DBEntities.ViewModel.RequestType)x.RequestTypeId,
                RequestNotes = x.RequestClients.Select(x => x.Notes).FirstOrDefault(),
            }).AsQueryable();


            var tempdata = tempmodel.Skip((page - 1) * pageSize).Take(pageSize).ToList().Count();
            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                TableViewModel = tempmodel.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                RequestCount = Count,
                TotalRecord = tempmodel.Count(),
                ShowRecords=tempdata
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
            var tempmodel = _context.Requests.Include(x => x.RequestClients).Include(x => x.RequestStatusLogs).Where(predicate).
            Select(x => new AdminTableViewModel()
            {
                RequestId = x.RequestId,
                RequestedDate = x.CreatedDate.ToString(),
                PhoneNumber = x.RequestClients.Select(x => x.PhoneNumber).FirstOrDefault(),
                Phone = x.PhoneNumber,
                Email = x.Email,
                Name = x.RequestClients.Select(x => x.FirstName + " " + x.LastName).FirstOrDefault(),
                Address = x.RequestClients.Select(x => x.Address).FirstOrDefault() ?? "No address available",
                Requester = x.FirstName + " " + x.LastName,
                RequestType = (DBEntities.ViewModel.RequestType)x.RequestTypeId,
                RequestNotes = x.RequestStatusLogs.Select(x => x.Notes).FirstOrDefault(),
            }).AsQueryable();

            var tempdata = tempmodel.Skip((page - 1) * pageSize).Take(pageSize).ToList().Count();
            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                TableViewModel = tempmodel.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                RequestCount = Count,
                TotalRecord = tempmodel.Count(),
                ShowRecords = tempdata
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
                 Address = x.RequestClients.Select(x => x.Address).FirstOrDefault() ?? "No address available",
                 Requester = x.FirstName + " " + x.LastName,
                 RequestType = (DBEntities.ViewModel.RequestType)x.RequestTypeId,
                 RequestNotes = x.RequestClients.Select(x => x.Notes).FirstOrDefault(),
             }).AsQueryable();

            var tempdata = tempmodel.Skip((page - 1) * pageSize).Take(pageSize).ToList().Count();
            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                TableViewModel = tempmodel.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                RequestCount = Count,
                TotalRecord = tempmodel.Count(),
                ShowRecords = tempdata
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
                 Address = x.RequestClients.Select(x => x.Address).FirstOrDefault() ?? "No address available",
                 Requester = x.FirstName + " " + x.LastName,
                 RequestType = (DBEntities.ViewModel.RequestType)x.RequestTypeId,
                 RequestNotes = x.RequestClients.Select(x => x.Notes).FirstOrDefault(),
             }).AsQueryable();

            var tempdata = tempmodel.Skip((page - 1) * pageSize).Take(pageSize).ToList().Count();
            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                TableViewModel = tempmodel.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                RequestCount = Count,
                TotalRecord = tempmodel.Count(),
                ShowRecords = tempdata
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
                Address = x.RequestClients.Select(x => x.Address).FirstOrDefault() ?? "No address available",
                Requester = x.FirstName + " " + x.LastName,
                RequestType = (DBEntities.ViewModel.RequestType)x.RequestTypeId,
                RequestNotes = x.RequestClients.Select(x => x.Notes).FirstOrDefault(),
            }).AsQueryable();

            var tempdata = tempmodel.Skip((page - 1) * pageSize).Take(pageSize).ToList().Count();
            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                TableViewModel = tempmodel.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                RequestCount = Count,
                TotalRecord = tempmodel.Count(),
                ShowRecords = tempdata
            };
            return model;
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
            var resetLink = "https://localhost:44352/home/reviewagreement?requestId=" + requestId;
            message.Body = "Click to view Agreement:"  + " "+ resetLink;
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
            var model = _context.Admins.Include(x => x.AdminRegions).Include(x=> x.AspNetUser).Where(x => x.AdminId == adminId).Select(x => new AdminProfileViewModel()
            {
                AdminAspID= x.AspNetUser.Id,
                AdminId = adminId,
                userName = x.AspNetUser.UserName,
                password = x.AspNetUser.PasswordHash,
                firstName = x.FirstName,
                lastName = x.LastName,
                Email = x.Email,
                confirmEmail = x.Email,
                Phone = x.Mobile,
                Address1 = x.Address1,
                Address2 = x.Address2,
                City = x.City,
                Zip = x.Zip,
                regionId = x.RegionId,
                MailingPhone = x.AltPhone,
                Region = region,
                AdminRegions = _context.AdminRegions.Where(x => x.AdminId == adminId).Select(b => b.RegionId).ToList(),
            }).FirstOrDefault();

            return model;
        }


        public void UpdateBillingRepo(AdminProfileViewModel model)
        {
            var data = _context.Admins.Include(x => x.AspNetUser).FirstOrDefault(x => x.AspNetUserId == model.AdminAspID);
            data.Address1 = model.Address1;
            data.Address2 = model.Address2;
            data.City = model.City;
            data.RegionId = model.regionId;
            data.AltPhone = model.MailingPhone;
            data.Zip = model.Zip;
            _context.SaveChanges();
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
                .Where(x => (patientName == null || x.RequestClients.FirstOrDefault().FirstName.ToLower().Contains(patientName.Trim().ToLower()) || x.RequestClients.FirstOrDefault().LastName.ToLower().Contains(patientName.Trim().ToLower())) && (providerName == null || x.Physician.FirstName.ToLower().Contains(providerName.Trim().ToLower()) || x.Physician.LastName.ToLower().Contains(patientName.Trim().ToLower())) &&
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

        public UserAccessViewModel GetUserAccessRepo(int RoleId)
        {
            var data = _context.AspNetUserRoles.Include(a => a.User).Where(a => a.RoleId != "3").Select(b => new UserAccessDetails()
            {
                AccountTypeId = int.Parse(b.RoleId),
                AspId = b.UserId,
                Name = b.User.UserName,
                PhoneNumber = b.User.PhoneNumber,
                Status = b.RoleId == 1.ToString() ? b.User.AdminAspNetUsers.First().Status : b.User.PhysicianAspNetUsers.First().Status,
                OpenRequest = b.RoleId == 1.ToString() ? _context.Requests.Where(a => a.Status == 1).Count() : _context.Requests.Where(a => a.PhysicianId == b.User.PhysicianAspNetUsers.First().PhysicianId).Count(),
                RoleId = b.RoleId == 1.ToString() ? b.User.AdminAspNetUsers.First().RoleId : b.User.PhysicianAspNetUsers.First().RoleId,
                //RoleName = int.Parse(b.RoleId) == 1 ? b.User.AdminAspNetUsers.First().Role.Name : b.User.PhysicianAspNetUsers.First().Role.Name,

            });

            if (RoleId != 0)
            {
                data = data.Where(a => a.RoleId == RoleId);
            }
            UserAccessViewModel access = new()
            {
                UserAccessList = data.ToList(),
                Roles = _context.Roles.ToList(),
            };

            return access;
        }











        public RecordsViewModel BlockDataRepo(string name, string date, string email, string phoneNumber)
        {
            var blockRecords = _context.Requests.Include(x => x.RequestClients).Include(x => x.BlockRequests)
                .Where(x => (x.Status == 11) && (name == null || x.RequestClients.FirstOrDefault().FirstName.ToLower().Contains(name.Trim().ToLower())
                || x.RequestClients.FirstOrDefault().LastName.ToLower().Contains(name.Trim().ToLower()))
                && (email == null || x.BlockRequests.FirstOrDefault().Email.ToLower().Contains(email.Trim().ToLower()))
                && (phoneNumber == null || x.BlockRequests.FirstOrDefault().PhoneNumber.ToLower().Contains(phoneNumber.Trim().ToLower())))
                .Select(x => new RecordsViewModel.BlockRecords()
                {
                    PatientName = x.RequestClients.FirstOrDefault().FirstName + " " + x.RequestClients.FirstOrDefault().LastName,
                    PhoneNumber = x.BlockRequests.FirstOrDefault().PhoneNumber,
                    Email = x.BlockRequests.FirstOrDefault().Email,
                    createdDate = x.BlockRequests.FirstOrDefault().CreatedDate.ToString(),
                    Notes = x.BlockRequests.FirstOrDefault().Reason,
                    isActive = x.BlockRequests.FirstOrDefault().IsActive,
                    RequestId = x.RequestId,
                    BlockRequestId = x.BlockRequests.FirstOrDefault().BlockRequestId,

                }).ToList();

            RecordsViewModel model = new RecordsViewModel()
            {
                blockRecords = blockRecords,
            };
            return model;
        }

        public CreateRoleViewModel GetRoleDetailsRepo()
        {
            CreateRoleViewModel model = new CreateRoleViewModel();
            return model;
        }

        public ProviderMenuViewModel GetProviderRepo(int regionId)
        {
            var provider = _context.Physicians.Include(x => x.PhysicianNotifications).Where(x => x.IsDeleted != true && (regionId==0||x.RegionId==regionId))
                .Select(x => new ProviderMenuDetailsViewModel()
                {
                    PhysicianId = x.PhysicianId,
                    Name = x.FirstName + " " + x.LastName,
                    Status = (PhysicianStatus)x.Status,
                    OnCallStatus = "Unavailable",
                    Notification = x.PhysicianNotifications.FirstOrDefault().IsNotificationStopped,
                }).ToList();

            //from phy in _context.Physicians
            //           join role in _context.Roles on phy.RoleId equals role.RoleId
            //           join phyNotification in _context.PhysicianNotifications on phy.PhysicianId equals phyNotification.PhysicianId
            //           where phy.IsDeleted != true
            //           orderby phy.PhysicianId
            //           select new ProviderMenuDetailsViewModel
            //           {
            //               PhysicianId = phy.PhysicianId,
            //               firstName = phy.FirstName,
            //               lastName = phy.LastName,
            //               Status = (PhysicianStatus)phy.Status,
            //               Role = (RoleName)role.RoleId,
            //              
            //           };

            ProviderMenuViewModel model = new ProviderMenuViewModel()
            {
                Details = provider,
            };
            return model;
        }

        

        public void CreateNewStateData(SchedulingViewModel model)
        {
           

            //DateTime combinedDate = new DateTime(year, month, date); // Combine year, month, and date
            var date = model.ShiftDate;
            DateTime shiftDate = date.ToDateTime(TimeOnly.MinValue); // Convert to DateOnly

            //Can also pass in Select but the list of physicians was not apearing in modal when tried to do so
            var regionId = _context.Regions.Where(x => x.Name == model.regionSelector).Select(x => x.RegionId).FirstOrDefault();

            var adminId = "ee0d64b2-e209-4f9f-b315-99221836598a";
            Shift shift = new()
            {
                PhysicianId = int.Parse(model.PhysicianName),   ///physician id 
                StartDate = (DateOnly)model.ShiftDate, //same ???????
                IsRepeat = model.IsRepeat,
                //WeekDays -- character -- no. of week days???? 
                RepeatUpto = model.RepeatEnd,
                //CreatedBy = vmodel.AdminId.ToString(),
                CreatedBy = adminId,

                CreatedDate = DateTime.Now
            };

            _context.Add(shift);
            _context.SaveChanges();

            if (model.IsRepeat)
            {

                List<DateOnly> days = new();
                days.Add(model.ShiftDate);

                var dayListString = model.SelectedDays;
                var daylist = dayListString.Split(',').Select(int.Parse).ToList();

                for (var i = 0; i < model.RepeatEnd; i++)
                {
                    for (int j = 0; j < daylist.Count; j++)
                    {

                        int temp;
                        switch (daylist[j])
                        {
                            case 1:
                                temp = (int)DayOfWeek.Sunday - (int)DateTime.Parse(days.Last().ToString()).DayOfWeek;
                                break;
                            case 2:
                                temp = (int)DayOfWeek.Monday - (int)DateTime.Parse(days.Last().ToString()).DayOfWeek;
                                break;
                            case 3:
                                temp = (int)DayOfWeek.Tuesday - (int)DateTime.Parse(days.Last().ToString()).DayOfWeek;
                                break;
                            case 4:
                                temp = (int)DayOfWeek.Wednesday - (int)DateTime.Parse(days.Last().ToString()).DayOfWeek;
                                break;
                            case 5:
                                temp = (int)DayOfWeek.Thursday - (int)DateTime.Parse(days.Last().ToString()).DayOfWeek;
                                break;
                            case 6:
                                temp = (int)DayOfWeek.Friday - (int)DateTime.Parse(days.Last().ToString()).DayOfWeek;
                                break;
                            default:
                                temp = (int)DayOfWeek.Saturday - (int)DateTime.Parse(days.Last().ToString()).DayOfWeek;
                                break;
                        }
                        if (temp <= 0)
                        {
                            temp += 7;
                        }
                        days.Add(days.Last().AddDays(temp));
                    }

                }

                foreach (var day in days)
                {
                    DateTime dayy = day.ToDateTime(TimeOnly.FromTimeSpan(DateTime.Now.TimeOfDay));

                    ShiftDetail shiftDetail1 = new()
                    {
                        ShiftId = shift.ShiftId,
                        ShiftDate = dayy,
                        StartTime = model.StartTime.Value,
                        EndTime = model.EndTime.Value,
                        IsDeleted = false,
                        RegionId = regionId,
                        Status = 1
                        //Status

                    };

                    //ShiftDetail.Add(shiftDetail1);
                    _context.Add(shiftDetail1);
                    _context.SaveChanges();
                }
            }
            else
            {
                ShiftDetail shiftDetail = new()
                {
                    ShiftId = shift.ShiftId,
                    ShiftDate = shiftDate,
                    StartTime = model.StartTime.Value,
                    EndTime = model.EndTime.Value,
                    IsDeleted = false,
                    RegionId = regionId,
                    Status = 1
                    //Status

                };

                _context.Add(shiftDetail);
                _context.SaveChanges();
            }
        }

        public void UpdateAdminInfoRepo(AdminProfileViewModel model)
        {
            var temp = _context.Admins.Include(x => x.AdminRegions).FirstOrDefault(x => x.AspNetUserId == model.AdminAspID);
            temp.FirstName = model.firstName;
            temp.LastName = model.lastName;
            temp.Mobile = model.Phone;
            _context.SaveChanges();

            Admin admin = _context.Admins.FirstOrDefault(x=>x.AspNetUserId==model.AdminAspID);
            List<AdminRegion> adminregionlist = _context.AdminRegions.Where(x=>x.AdminId==admin.AdminId).ToList();
            List<int> oldList = adminregionlist.Select(b => b.RegionId).ToList();
            foreach (var region in adminregionlist)
            {
                if (!model.AdminRegions.Contains(region.RegionId))
                {
                    _context.AdminRegions.Remove(region);

                }
            }

           
            foreach (var regionId in model.AdminRegions)
            {
                if (!oldList.Contains(regionId))
                {
                    AdminRegion adminRegionData = new AdminRegion
                    {
                        AdminId = admin.AdminId,
                        RegionId = regionId
                    };
                    _context.AdminRegions.Add(adminRegionData);

                }
            }
            _context.SaveChanges();
        }

        public ProviderLocationViewModel GetPhysicianLocationList()
        {
            ProviderLocationViewModel modal = new()
            {
                Physicianlocation = _context.PhysicianLocations.AsEnumerable(),
            };
            return modal;
        }


        public void CreateAdminRepo(CreateAdminAccountViewModel model)
        {
            AspNetUser aspNetUser = new AspNetUser()
            {
                Id = Guid.NewGuid().ToString(),
                Email = model.Email,
                PasswordHash = model.Password,
                UserName = model.UserName,
                CreatedDate = DateTime.Now,
                PhoneNumber = model.Phone,
            };

            _context.AspNetUsers.Add(aspNetUser);

            AspNetUserRole userRole = new AspNetUserRole()
            {
                UserId = aspNetUser.Id,
                RoleId = 1.ToString(),
            };

            _context.AspNetUserRoles.Add(userRole);

            Admin admin = new Admin()
            {
                AspNetUserId = aspNetUser.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Mobile = model.Phone,
                Address1 = model.Address1,
                Address2 = model.Address2,
                City = model.City,
                RegionId = model.regionId,
                Zip = model.Zip,
                AltPhone = model.MailingPhone,
                CreatedBy = "admin",
                CreatedDate = DateTime.Now,
                Status = 2,
                IsDeleted = new BitArray(new bool[] { false }),
                RoleId = 1,    /////////PLEASE CHANGE
            };
            _context.Admins.Add(admin);
            _context.SaveChanges();

            List<AdminRegion> adminRegions = new List<AdminRegion>();
            foreach (var items in model.AdminRegions)
            {
                adminRegions.Add(new AdminRegion() { AdminId = admin.AdminId, RegionId = items });
            };
            _context.AdminRegions.AddRange(adminRegions);
            _context.SaveChanges();
        }








        public void CreateProviderRepo(CreateProviderAccountViewModel model)
        {
            AspNetUser aspNetUser = new AspNetUser()
            {
                Id = Guid.NewGuid().ToString(),
                Email = model.Email,
                PasswordHash = model.Password,
                UserName = model.FirstName + " " + model.LastName,
                CreatedDate = DateTime.Now,
                PhoneNumber = model.Phone,
            };

            _context.AspNetUsers.Add(aspNetUser);
            //_context.SaveChanges();

            AspNetUserRole userRole = new AspNetUserRole();
            userRole.UserId = aspNetUser.Id;
            userRole.RoleId = 2.ToString();
            _context.AspNetUserRoles.Add(userRole);
            //_context.SaveChanges();

            Physician physician = new Physician()
            {
                AspNetUserId = aspNetUser.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Mobile = model.Phone,
                AdminNotes = model.AdminNotes,
                Address1 = model.Address1,
                Address2 = model.Address2,
                City = model.City,
                RegionId = model.RegionId,
                Zip = model.Zip,
                AltPhone = model.MailingPhone,
                CreatedBy= "004738d0-6f4d-48e0-b229-fcf209b2780f",
                CreatedDate = DateTime.Now,
                Status = 1,
                BusinessName = model.BussinessName,
                BusinessWebsite = model.BussinessWebsite,
                IsDeleted = false,
                RoleId= 2,
                Npinumber = model.NPINumber,
                //IsAgreementDoc = model.AgreementDoc != null,
                //IsBackgroundDoc = model.BackgroundDoc != null,
                //IsTrainingDoc = model.TrainingDoc != null,
                //IsNonDisclosureDoc = model.NonSiclosureDoc != null,
            };

            _context.Physicians.Add(physician);
            _context.SaveChanges();

            PhysicianLocation physicianLocation = new PhysicianLocation()
            {
                PhysicianId = physician.PhysicianId,
                CreatedDate = DateTime.Now,
                PhysicianName = physician.FirstName + " " + physician.LastName,
                Address = physician.City +" "+ physician.Zip,
            };
            _context.PhysicianLocations.Add(physicianLocation);


            PhysicianNotification physicianNotification = new PhysicianNotification()
            {
                PhysicianId = physician.PhysicianId,
                IsNotificationStopped = false,
            };
            _context.PhysicianNotifications.Add(physicianNotification);


            List<PhysicianRegion> regions = new List<PhysicianRegion>();
            foreach (var items in model.PhysicianRegions)
            {
                regions.Add(new PhysicianRegion() { PhysicianId = physician.PhysicianId, RegionId = items });
            }
            _context.PhysicianRegions.AddRange(regions);
            _context.SaveChanges();
        }

        public Admin GetAdminByMailRepo(string email, string password)
        {

            var temp = _context.AspNetUsers.Where(u => u.Email == email && u.PasswordHash == password).FirstOrDefault();
            if (temp != null)
            {
             Admin admin = _context.Admins.Where(a => a.AspNetUserId == temp.Id).FirstOrDefault();
                return admin;
            }
            else
            {
                return null;
            }
        }

        public UserInfoViewModel GetRoleByAspNetId(string username, string password)
        {
            UserInfoViewModel userInfo = new UserInfoViewModel();
            var Aspuser = _context.AspNetUsers.FirstOrDefault(u => u.Email == username && u.PasswordHash == password);

            var AspNetId = _context.AspNetUsers.Where(x => x.Email == username && x.PasswordHash == password).Select(x => x.Id).FirstOrDefault();
            string RoleName = "";
            if (_context.Admins?.FirstOrDefault(x => x.AspNetUserId == AspNetId) != null)
            {
                userInfo.UserId = AspNetId;
                userInfo.Email = Aspuser.Email;
                userInfo.Role = "Admin";
                userInfo.RoleId = _context.Admins.Where(x=>x.AspNetUserId == AspNetId).FirstOrDefault().RoleId;
            }
            else if (_context.Physicians.FirstOrDefault(x => x.AspNetUserId == AspNetId) != null)
            {
                userInfo.UserId = AspNetId;
                userInfo.Email = Aspuser.Email;
                userInfo.Role = "Physician";
            }
            else if (_context.Users.FirstOrDefault(x => x.AspNetUserId == AspNetId) != null)
            {
                userInfo.UserId = AspNetId;
                userInfo.Email = Aspuser.Email;
                userInfo.Role = "Patient";
            } 
            return userInfo;
        }

        public ViewNotesViewModel GetNoteDataById(int requestId)
        {
            var Notesdata = _context.RequestStatusLogs.Where(x => x.RequestId == requestId).ToList();
            var data = _context.RequestNotes.Where(e => e.RequestId == requestId).Select(b => new ViewNotesViewModel
            {
                RequestId = b.RequestId,
                PhysicianNotes = b.PhysicianNotes ?? "No Notes Available",
                AdminNotes = b.AdminNotes ?? "No Notes Available",
                CreatedDate = b.CreatedDate,
                CreatedBy = b.CreatedBy,
                TransferNotes = Notesdata

            }).FirstOrDefault();
            if (data == null)
            {
                ViewNotesViewModel NVM = new ViewNotesViewModel()
                {
                    RequestId = requestId,
                    TransferNotes = Notesdata
                };
                return NVM;
            }
            return data;
        }

        public RequestNote GetRquestNoteById(int requestId)
        {
            return _context.RequestNotes.Where(e => e.RequestId == requestId).FirstOrDefault();
        }

        public void UpdateNotes(RequestNote requestNote)
        {
            _context.RequestNotes.Update(requestNote);
            _context.SaveChanges();
        }

        public void AddRequestNote(RequestNote requestnote)
        {
            _context.RequestNotes.Add(requestnote);
            _context.SaveChanges();
        }

        public ShiftViewDetailDTO GetViewShift(int shiftDetailId)
        {
            ShiftDetail shiftDetail = _context.ShiftDetails.Include(m => m.Shift).ThenInclude(m => m.Physician).FirstOrDefault(m => m.ShiftDetailId == shiftDetailId);
            if (shiftDetail != null)
            {
                ShiftViewDetailDTO model = new ShiftViewDetailDTO()
                {
                    ShiftDetailId = shiftDetailId,
                    PhysicianRegionId = (int)shiftDetail.RegionId,
                    PhysicianRegionName = _context.Regions.FirstOrDefault(m => m.RegionId == shiftDetail.RegionId).Name,
                    PhysicianId = shiftDetail.Shift.PhysicianId,
                    PhysicianName = shiftDetail.Shift.Physician.FirstName + " " + shiftDetail.Shift.Physician.LastName,
                    ShiftDate = shiftDetail.ShiftDate.ToString("yyyy-MM-dd"),
                    StartTime = shiftDetail.StartTime,
                    EndTime = shiftDetail.EndTime,
                };
                return model;
            }
            return new ShiftViewDetailDTO();
        }

        public void ReturnViewShift(int shiftDetailId, int adminId)
        {
            var AdminAspNetId = _context.Admins.Where(x => x.AdminId == adminId).Select(X => X.AspNetUserId).First();
            ShiftDetail shiftDetail = _context.ShiftDetails.FirstOrDefault(m => m.ShiftDetailId == shiftDetailId);
            if (shiftDetail != null)
            {
                if (shiftDetail.Status == 1)
                {
                    shiftDetail.Status = 2;
                    shiftDetail.ModifiedBy = AdminAspNetId;
                    shiftDetail.ModifiedDate = DateTime.Now;
                }
                else
                {
                    shiftDetail.Status = 1;
                    shiftDetail.ModifiedBy = AdminAspNetId;
                    shiftDetail.ModifiedDate = DateTime.Now;
                }
                _context.ShiftDetails.Update(shiftDetail);
                _context.SaveChanges();
            }
        }

        public void DeleteViewShift(int shiftDetailId, int adminId)
        {
            var AdminAspNetId = _context.Admins.Where(x => x.AdminId == adminId).Select(X => X.AspNetUserId).First();
            ShiftDetail shiftDetail = _context.ShiftDetails.FirstOrDefault(m => m.ShiftDetailId == shiftDetailId);
            if (shiftDetail != null)
            {
                shiftDetail.IsDeleted = true;
                shiftDetail.ModifiedBy = AdminAspNetId;
                shiftDetail.ModifiedDate = DateTime.Now;

            }
            _context.ShiftDetails.Update(shiftDetail);
            _context.SaveChanges();
        }

        public void EditViewShift(ShiftViewDetailDTO shiftDetail, int adminId)
        {
            var AdminAspNetId = _context.Admins.Where(x => x.AdminId == adminId).Select(X => X.AspNetUserId).First();
            ShiftDetail shiftDetails = _context.ShiftDetails.FirstOrDefault(m => m.ShiftDetailId == shiftDetail.ShiftDetailId);
            if (shiftDetails != null)
            {
                shiftDetails.ShiftDate = DateTime.Parse(shiftDetail.ShiftDate);
                shiftDetails.StartTime = shiftDetail.StartTime;
                shiftDetails.EndTime = shiftDetail.EndTime;
                shiftDetails.ModifiedBy = AdminAspNetId;
                shiftDetails.ModifiedDate = DateTime.Now;
            }
            _context.ShiftDetails.Update(shiftDetails);
            _context.SaveChanges();
        }

        public List<Physician> GetPhysicianByRegion(int regionId)
        {
           return _context.Physicians.Where(x=>x.RegionId == regionId).ToList();
        }

        public void SaveNotificationRepo(List<int> idlist)
        {

                    List<PhysicianNotification> data = _context.PhysicianNotifications.ToList();
                    foreach (var item in idlist)
                    {


                        PhysicianNotification Nstatus = data.Where(x => x.PhysicianId == item).FirstOrDefault();
                    
                        Nstatus.IsNotificationStopped = Nstatus.IsNotificationStopped ? false : true;
                        _context.PhysicianNotifications.Update(Nstatus);
                    }
            _context.SaveChanges();
        }

        public CloseCaseViewModel GetCloseCaseRepo(int id)
        {
            RequestClient client = _context.RequestClients.Where(x => x.RequestId == id).FirstOrDefault();
            List<RequestWiseFile> RequestFiles = _context.RequestWiseFiles.Where(x => x.RequestId == id).ToList();
            CloseCaseViewModel modal = new()
            {
                ReqId = id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Email = client.Email,
                Phone = client.PhoneNumber,
                DateOfBirth = (client.IntDate + "/" + client.StrMonth + "/" + client.IntYear) ?? "12/12/2024",
                ConfirmationNumber = client.Request == null ? "" : client.Request.ConfirmationNumber,
                Files = RequestFiles
            };


            return modal;
        }

        public void SetCloseCaseRepo(CloseCaseViewModel modal)
        {
            RequestClient client = _context.RequestClients.Where(x => x.RequestId == modal.ReqId).FirstOrDefault();           
            client.PhoneNumber = modal.Phone;
            client.Email = modal.Email;
            _context.RequestClients.Update(client);
            _context.SaveChanges();
        }

        public Request GetRequestById(int id)
        {
            return _context.Requests.Where(x => x.RequestId == id).FirstOrDefault();
        }

        public void UpdateRequests(Request req)
        {
            _context.Requests.Update(req);
            _context.SaveChanges();
        }

        public void AddRequestStatusLog(RequestStatusLog requestStatusLog)
        {
            _context.RequestStatusLogs.Add(requestStatusLog);
            _context.SaveChanges();
        }

        public CreateRoleViewModel EditDetailsRepo(int accountType, int roleId)
        {
            CreateRoleViewModel model = new()
            {
                RoleId = roleId,
                RoleName = _context.Roles.Where(x=>x.RoleId==roleId).FirstOrDefault().Name,
                AccountType = accountType.ToString(),
                menulist = GetMenuRepo(accountType),
                SelectedMenus = _context.RoleMenus.Where(x => x.RoleId == roleId).Select(x => x.MenuId).ToList(),
                
            };

            return model;

        }

        public void EditRoleRepo(CreateRoleViewModel model)
        {
          Role role= _context.Roles.Where(x=>x.RoleId == model.RoleId).FirstOrDefault();
            role.AccountType = short.Parse(model.AccountType);
            role.Name = model.RoleName;
            _context.Roles.Update(role);

            List<RoleMenu> roleMenuslist = _context.RoleMenus.Where(x => x.RoleId == role.RoleId).ToList();
            List<int> oldList = roleMenuslist.Select(b => b.MenuId).ToList();
            foreach (var items in roleMenuslist)
            {
                if (!model.SelectedMenus.Contains(items.MenuId))
                {
                    _context.RoleMenus.Remove(items);

                }
            }


            foreach (var MenuId in model.SelectedMenus)
            {
                if (!oldList.Contains(MenuId))
                {
                    RoleMenu roleMenu = new RoleMenu
                    {
                        RoleId = role.RoleId,
                        MenuId = MenuId
                    };
                    _context.RoleMenus.Add(roleMenu);

                }
            }
            _context.SaveChanges();


        }

        public List<string> getListOfRoleMenu(int? roleId)
        {
            List<RoleMenu> roleMenus = _context.RoleMenus.Where(u => u.RoleId == roleId).ToList();
            if (roleMenus.Count > 0)
            {
                List<string> menus = new List<string>();
                foreach (var item in roleMenus)
                {
                    menus.Add(_context.Menus.FirstOrDefault(u => u.MenuId == item.MenuId).Name);
                }
                return menus;
            }
            else
            {
                return new List<string>();
            }
        }

        public void UnblockCaseRepo(int requestId)
        {
            RequestStatusLog blockdata = new RequestStatusLog()
            {
                RequestId =requestId,
                Status = 1,
                Notes = "Request is unblocked!!",
                CreatedDate = DateTime.Now,
            };

            _context.RequestStatusLogs.Add(blockdata);
            _context.SaveChanges();

            Request request = _context.Requests.Where(x => x.RequestId == requestId).First();
            request.Status = 1;

            _context.Requests.Update(request);
            _context.SaveChanges();

        }

        public EncounterFormViewModel GetEncounterformRepo(int requestId)
        {
            var data = _context.RequestClients.Where(x => x.RequestId == requestId).FirstOrDefault();
            EncounterFormViewModel model = new()
            {
                FirstName = data?.FirstName,
                LastName = data?.LastName,
                Location = data?.Address,
                Date = DateTime.Now,
                Email = data?.Email,
                Phone = data.PhoneNumber,
            };
            EncounterForm dbform = _context.EncounterForms.FirstOrDefault(x => x.RequestId == requestId);
            if (dbform == null)
            {
                EncounterForm encForm = new()
                {
                    RequestId = requestId
                };

                _context.EncounterForms.Add(encForm);
                _context.SaveChanges();

                model.Form = encForm;
            }
            else
            {
                model.Form = dbform;
            }

            return model;
        }

        public void EncounterFormRepo(EncounterFormViewModel model)
        {
            EncounterForm dbmodel = _context.EncounterForms.FirstOrDefault(x => x.RequestId == model.Form.RequestId);

            var Eform = model.Form;
            if (dbmodel != null)
            {
                dbmodel.HistoryIllness = Eform.HistoryIllness;
                dbmodel.MedicalHistory = Eform.MedicalHistory;
                dbmodel.Medications = Eform.Medications;
                dbmodel.Allergies = Eform.Allergies;
                dbmodel.Temp = Eform.Temp;
                dbmodel.Hr = Eform.Hr;
                dbmodel.Rr = Eform.Rr;
                dbmodel.BpS = Eform.BpS;
                dbmodel.BpD = Eform.BpD;
                dbmodel.O2 = Eform.O2;
                dbmodel.Pain = Eform.Pain;
                dbmodel.Heent = Eform.Heent;
                dbmodel.Cv = Eform.Cv;
                dbmodel.Chest = Eform.Chest;
                dbmodel.Abd = Eform.Abd;
                dbmodel.Extr = Eform.Extr;
                dbmodel.Skin = Eform.Skin;
                dbmodel.Neuro = Eform.Neuro;
                dbmodel.Other = Eform.Other;
                dbmodel.Diagnosis = Eform.Diagnosis;
                dbmodel.TreatmentPlan = Eform.TreatmentPlan;
                dbmodel.MedicationDispensed = Eform.MedicationDispensed;
                dbmodel.Procedures = Eform.Procedures;
                dbmodel.FollowUp = Eform.FollowUp;
                dbmodel.IsFinalized = Eform.IsFinalized;


                _context.EncounterForms.Update(dbmodel);
                _context.SaveChanges();

            }
        }

        public Payrate GetPayratesData(int physicianId)
        {
            return _context.Payrates.FirstOrDefault(x => x.PhysicianId == physicianId);
        }

        public void AddPayrates(Payrate payrate)
        {
            _context.Payrates.Add(payrate);
            _context.SaveChanges();
        }

        public void UpdatePayrates(Payrate oldpayrates)
        {
            _context.Payrates.Update(oldpayrates);
            _context.SaveChanges(); 
        }

        public Timesheet? GetTimesheetById(int timeSheetId)
        {
            return _context.Timesheets.FirstOrDefault(x => x.TimesheetId == timeSheetId);
        }

        public TimesheetDetail GetTimesheetDetailById(int timesheetDetailId)
        {
            return _context.TimesheetDetails.Find(timesheetDetailId);
        }

        public bool UpdateRangeTimesheetDetail(List<TimesheetDetail> timesheetDetailsUpdate)
        {
            try
            {
                _context.TimesheetDetails.UpdateRange(timesheetDetailsUpdate);
                _context.SaveChangesAsync();
                return true;

            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<TimesheetReimbursement> GetTimesheetReimbursementByTimeSheetId(int timesheetId)
        {
            return _context.TimesheetReimbursements.Where(x => x.TimesheetId == timesheetId).ToList();
        }

        public IEnumerable<TimeSheetDetailVM> GetTimeSheetData(int timesheetId, int physicianId)
        {
            return _context.TimesheetDetails.Where(x => x.TimesheetId == timesheetId).Select(b => new TimeSheetDetailVM
            {
                TimesheetDetailId = b.TimesheetDetailId,
                Shiftdate = b.Shiftdate,
                ShiftHours = b.ShiftHours,
                Housecall = b.Housecall,
                PhoneConsult = b.PhoneConsult,
                IsWeekend = b.IsWeekend[0],
                OnCallHours = _context.ShiftDetails.Where(x => DateOnly.FromDateTime(x.ShiftDate) == b.Shiftdate && x.Shift.PhysicianId == physicianId).Sum(x => (x.EndTime - x.StartTime).TotalHours)
            }).OrderBy(x => x.Shiftdate).ToList();
        }

        public IEnumerable<Physician> GetAllPhysician()
        {
            return _context.Physicians.Where(x => x.IsDeleted == false).ToList();
        }

        public Timesheet? GetTimesheetByDate(DateOnly firstDate, DateOnly lastDate, int providerId)
        {
            return _context.Timesheets.FirstOrDefault(x => x.Startdate == firstDate && x.Enddate == lastDate && x.PhysicianId == providerId);
        }

        public Physician GetPhyByPhysicianId(int providerId)
        {
            return _context.Physicians.Where(x => x.PhysicianId == providerId).FirstOrDefault();
        }

        public IEnumerable<TimeSheetDetailStatic>? GetTimeSheetDetailStaticData(int timesheetId)
        {
            return _context.TimesheetDetails.Where(x => x.TimesheetId == timesheetId).Select(b => new TimeSheetDetailStatic()
            {
                Shiftdate = b.Shiftdate,
                Shift = _context.ShiftDetails.Where(x => DateOnly.FromDateTime(x.ShiftDate) == b.Shiftdate && x.Shift.PhysicianId == b.Timesheet.PhysicianId).Count(),
                Housecall = (int)b.Housecall,
                PhoneConsult = (int)b.PhoneConsult,
                IsWeekend = b.IsWeekend[0]

            }).ToList();
        }

        public bool UpdateTimesheet(Timesheet timesheet)
        {
            try
            {
                if (timesheet != null)
                {
                    _context.Timesheets.Update(timesheet);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }

        public List<int> GetSelectedPhysicianRegionByPhysicianId(int physicianId)
        {
            return _context.PhysicianRegions.Where(x=>x.PhysicianId== physicianId).Select(b=>b.RegionId).ToList();
        }
    }
}