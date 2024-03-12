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
            string notetotransfer="Admin Transfer to Dr."+ model.SelectedPhysician + dateString;
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
                RequestId= model.RequestId,
                Status= 11,
                Notes = model.BlockNotes,
                CreatedDate = DateTime.Now,
            };

            _context.RequestStatusLogs.Add(blockdata);
            _context.SaveChanges();

            Request request =_context.Requests.Where(x=> x.RequestId == model.RequestId).First();
            request.Status = 11;

            _context.Requests.Update(request);
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



            Request request = _context.Requests.Where(x=>x.RequestId==model.RequestId).First();
            request.Status = 3;
                
            
            _context.Requests.Update(request);
            _context.SaveChanges();



            //Request request = new Request()
            //{
            //    Status =3,             
            //};

            //_context.Requests.Add(request);
            //_context.SaveChanges();

        }

        public void ClearCaseRepo(AdminDashboardViewModel model)
        {
            Request request = _context.Requests.Where(x=>x.RequestId == model.RequestId).First();
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
           var Profession = _context.HealthProfessionalTypes.Select(x=>x.ProfessionName).ToList();
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
            var documents = _context.RequestWiseFiles.Where(x=> x.RequestId == requestId)
                .Select(x => new AdminDocumentViewModel
                {
                    CreatedDate= x.CreatedDate,
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
            int professionId = _context.HealthProfessionalTypes.Where(x=> x.ProfessionName == professionName).Select(x=>x.HealthProfessionalId).First();
            var BusinessName = _context.HealthProfessionals.Where(x=>x.Profession == professionId).Select(x=>x.VendorName).ToList();
            return BusinessName;
        }

        public SendOrderViewModel GetOrder(string businessName)
        {

            var Orderdetails = _context.HealthProfessionals.Where(x => x.VendorName == businessName)
                .Select(x => new SendOrderViewModel
                {
                    BusinessContact= x.BusinessContact,
                    Email= x.Email,
                    FaxNumber= x.FaxNumber,
                    VendorId= x.VendorId,
                    
                }).First();

            SendOrderViewModel model = new SendOrderViewModel()
            {
                BusinessContact = Orderdetails.BusinessContact, 
                Email= Orderdetails.Email,
                FaxNumber = Orderdetails.FaxNumber,
                VendorId = Orderdetails.VendorId,
            };
            return model;
        }

        public List<string> GetPhysicianByRegionName(string regionName)
        {
            int regionId = _context.Regions.Where(x => x.Name == regionName).Select(x =>x.RegionId).First();
            var PhysicianName = _context.Physicians.Where(x => x.RegionId == regionId).Select(x => x.FirstName).ToList();
            return PhysicianName;
        }

        public ViewNotesViewModel GetViewNotesRepo(int requestId)
        {
            var requestStatus = _context.RequestStatusLogs.FirstOrDefault(r => r.RequestId == requestId);
            var requestNotes = _context.RequestNotes.Where(r => r.RequestId == requestId).Select(r => new { r.RequestId, r.AdminNotes, r.PhysicianNotes }).ToList();


            if(requestStatus?.PhysicianId != null)
            {
                var physicianName = _context.Physicians.Find(requestStatus.PhysicianId);

                var model = new ViewNotesViewModel
                {
                    RequestId= requestId,
                    TransferNotes= requestStatus.Notes,
                    PhysicianName= physicianName.FirstName + " " + physicianName.LastName,
                    CreatedDate= requestStatus.CreatedDate,
                    PhysicianNotes= requestNotes.FirstOrDefault()?.PhysicianNotes,
                    AdminNotes = requestNotes.FirstOrDefault()?.AdminNotes,
                };
                return model;
            }
            else
            {
                var model = new ViewNotesViewModel
                {
                    RequestId = requestId,
                    TransferNotes = requestStatus.Notes,
                    CreatedDate = requestStatus.CreatedDate,
                    PhysicianNotes = requestNotes.FirstOrDefault()?.PhysicianNotes,
                    AdminNotes= requestNotes.FirstOrDefault()?.AdminNotes,
                };
                return model;    
            }
        }

        public void OrderDetailRepo(SendOrderViewModel model)
        {
            OrderDetail order = new OrderDetail()
            {
                VendorId= model.VendorId,
                FaxNumber = model.FaxNumber,
                Email = model.Email,
                BusinessContact = model.BusinessContact,
                Prescription = model.OrderNotes,
                NoOfRefill = model.No_of_Refills,
                CreatedDate = DateTime.Now,
                RequestId = model.RequestId,
                CreatedBy ="Admin"
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

            RequestClient requestClient = _context.RequestClients.Where(x => x.RequestId == requestId).First();
            requestClient.RegionId = regionId;
            requestClient.State = model.SelectedRegion;
            _context.RequestClients.Update(requestClient);
            _context.SaveChanges(true);

            string dateString = DateTime.Now.ToString("dd/mm/yyyy 'at' hh:mm:ss tt" );
            string notetotransfer = "Admin Transfer to Dr." + model.SelectedPhysician + dateString;
            RequestStatusLog StatusData = _context.RequestStatusLogs.Where(x => x.RequestId==requestId).First();
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

        //public void updateRequest(Request request)
        //{
        //    _context.Requests.Update(request);
        //    _context.SaveChanges();
        //}
    }
}
