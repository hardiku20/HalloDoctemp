using learning1.DBEntities.Models;
using learning1.DBEntities.ViewModel;
using learning1.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
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
                Address = x.RequestClients.Select(x => x.Address).FirstOrDefault() ?? "No address available",
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
                Address = x.RequestClients.Select(x => x.Address).FirstOrDefault() ?? "No address available",
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
                Address = x.RequestClients.Select(x => x.Address).FirstOrDefault() ?? "No address available",
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
                 Address = x.RequestClients.Select(x => x.Address).FirstOrDefault() ?? "No address available",
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
                    Patientnotes = x.Notes ?? "No Notes Available",
                   
                }).FirstOrDefault();


            return modal;
        }

        public void acceptcase(int requestId)
        {
            //string? aspId = HttpContext.Session.GetString("UserId");
            var req = _context.Requests.FirstOrDefault(x => x.RequestId == requestId);

            //int phyId = _db.Physicians.Where(x => x.Aspnetuserid == aspId).Select(i => i.Physicianid).FirstOrDefault();

            Request? req_data = _context.Requests.Where(i => i.RequestId == requestId).FirstOrDefault();
            var reqStatLog = _context.RequestStatusLogs.Where(i => i.RequestId == requestId).FirstOrDefault();

            //int phyId = _context.Physicians.Where(x => x.Aspnetuserid == loginUserId).Select(x => x.Physicianid).FirstOrDefault();
            RequestStatusLog requestList = new RequestStatusLog()
            {
                RequestId = requestId,
                Status = req_data.Status,
                PhysicianId = 16,
                CreatedDate = DateTime.Now,
                Notes = "Request Accepted By physicion ",
            };
            _context.Add(requestList);
            req_data.Status = 2;

            _context.SaveChanges();


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
                UserName = (userName.FirstName.FirstOrDefault() + " " + userName.LastName.FirstOrDefault()) ?? "Test test",
                RequestId = requestId,
                DocumentsViewModel = documents
            };

            return model;
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

        public void TransferCaseRepo(ProviderDashboardViewModel model, int requestId)
        {
            var physician = _context.Requests.Include(x => x.Physician).Where(x => x.RequestId == requestId);

            Request request = _context.Requests.Where(x => x.RequestId == requestId).First();
            request.Status = 1;
            request.PhysicianId = null;
            request.ModifiedDate = DateTime.Now;
            request.CompletedByPhysician = false;
            request.DeclinedBy = physician.FirstOrDefault().FirstName + " " + physician.FirstOrDefault().LastName;


            _context.Requests.Update(request);
            _context.SaveChanges();

            string dateString = DateTime.Now.ToString("dd/mm/yyyy 'at' hh:mm:ss tt");
            string notetotransfer = "Physician Transfer request to Admin" + dateString;
            RequestStatusLog StatusData = _context.RequestStatusLogs.Where(x => x.RequestId == requestId).First();
            StatusData.TransToPhysicianId = null;
            StatusData.Status = 1;
            StatusData.TransToAdmin = true;

            _context.RequestStatusLogs.Update(StatusData);
            _context.SaveChanges();
        }


        public List<string> DisplayProfession()
        {
            var Profession = _context.HealthProfessionalTypes.Select(x => x.ProfessionName).ToList();
            return Profession;
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



        public List<Region> GetRegionTable()
        {
            return _context.Regions.ToList();
        }

        public ProviderProfileViewModel GetProviderProfileRepo(int physicianId)
        {
            var region = GetRegionTable();
            var model = _context.Physicians.Include(x => x.PhysicianRegions).Include(x => x.AspNetUser).Where(x => x.PhysicianId == physicianId).Select(x => new ProviderProfileViewModel()
            {
                AdminAspID = x.AspNetUser.Id,
                PhysicianId = physicianId,
                userName = x.AspNetUser.UserName,
                password = x.AspNetUser.PasswordHash,
                firstName = x.FirstName,
                lastName = x.LastName,
                Email = x.Email,
                Phone = x.Mobile,
                Address1 = x.Address1,
                Address2 = x.Address2,
                City = x.City,
                Zip = x.Zip,
                regionId = x.RegionId,
                MailingPhone = x.AltPhone,
                Region = region,
                PhysicianRegions = _context.PhysicianRegions.Where(x => x.PhysicianId == physicianId).Select(b => b.RegionId).ToList(),
            }).FirstOrDefault();

            return model;
        }
    }
}
