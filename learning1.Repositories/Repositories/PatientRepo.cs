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

    public class PatientRepo : IPatientRepo
    {
        private readonly DbHallodocContext _context;

        public PatientRepo(DbHallodocContext context)
        {
            _context = context;
        }






        public void GetPatientRequests(PatientRequestViewModel model)
        {
            if (model.Password != null && model.Password == model.ConfirmPassword)
            {
                AspNetUser netUser = new AspNetUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    CreatedDate = DateTime.Now,
                    PasswordHash = model.Password
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
                    Mobile = model.PhoneNumber,
                    Street = model.Street,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode,
                    CreatedBy = "hardik",
                    StrMonth = (model.DateofBirth.Month).ToString(),
                    IntDate = (model.DateofBirth.Day),
                    IntYear = (model.DateofBirth.Year),

                    CreatedDate = DateTime.Now,
                };

                _context.Users.Add(user);
                _context.SaveChanges();

            }


            var userId = _context.Users.Where(u => u.Email == model.Email).Select(u => u.UserId).FirstOrDefault();
            //request
            Request request = new Request
            {
                UserId = userId,
                RequestTypeId = 2,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
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
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                State = model.State,
                City = model.City,
                Street = model.Street,
                ZipCode = model.ZipCode,
                Address = model.Street + ", " + model.City + ", " + model.State + "- " + model.ZipCode,
                Notes = model.RequestNotes,
            };

            _context.RequestClients.Add(requestClient);
            _context.SaveChanges();

            if (model.formFile != null)
            {
                string fileName = request.RequestId.ToString() + " - " + model.formFile.FileName;
                string filePath = Path.Combine("Files", "PatientDocs", fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.formFile.CopyTo(stream);
                }

                RequestWiseFile files = new()
                {
                    RequestId = request.RequestId,
                    FileName = fileName,
                    CreatedDate = DateTime.Now,
                };
                _context.RequestWiseFiles.Add(files);
                _context.SaveChanges();

            }
        }


        public void GetFamilyFriendRequests(Family_FriendRequestViewModel model)
        {


            AspNetUser netUser = new AspNetUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                CreatedDate = DateTime.Now,
            };

            _context.AspNetUsers.Add(netUser);
            _context.SaveChanges();
            //User
            User user = new User
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Mobile = model.PhoneNumber,
                Street = model.Street,
                City = model.City,
                State = model.State,
                ZipCode = model.ZipCode,
                CreatedBy = "hardik",
                CreatedDate = DateTime.Now,
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            //request
            Request request = new Request
            {
                UserId = user.UserId,
                RequestTypeId = 3,
                FirstName = model.Fname,
                LastName = model.Lname,
                PhoneNumber = model.Phone,
                Email = model.Emailaddress,
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
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                State = model.State,
                City = model.City,
                Street = model.Street,
                ZipCode = model.ZipCode,
                Address = model.Street + ", " + model.City + ", " + model.State + "- " + model.ZipCode,
                Notes = model.RequestNotes,
            };

            _context.RequestClients.Add(requestClient);
            _context.SaveChanges();

        }




        public void GetConciergeRequests(ConciergeRequestViewModel model)
        {

            AspNetUser netUser = new AspNetUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                CreatedDate = DateTime.Now,
            };

            _context.AspNetUsers.Add(netUser);
            _context.SaveChanges();
            //User
            User user = new User
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Mobile = model.PhoneNumber,
                Street = model.Street,
                City = model.City,
                State = model.State,
                ZipCode = model.ZipCode,
                CreatedBy = "hardik",
                CreatedDate = DateTime.Now,
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            


            Concierge concierge = new Concierge
            {
                ConciergeName = model.Fname,
                Street = model.Street,
                City = model.City,
                State = model.State,
                ZipCode = model.ZipCode,
                RegionId = _context.Regions.Where(x => x.Name== model.State).Select(x => x.RegionId).FirstOrDefault(),
                CreatedDate = DateTime.Now,
            };

            _context.Concierges.Add(concierge);
            _context.SaveChanges();
            //request
            Request request = new Request
            {
                UserId = user.UserId,
                RequestTypeId = 4,
                FirstName = model.Fname,
                LastName = model.Lname,
                PhoneNumber = model.Phone,
                Email = model.Emailaddress,
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
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                State = model.State,
                City = model.City,
                Street = model.Street,
                ZipCode = model.ZipCode,
                Address = model.Street + ", " + model.City + ", " + model.State + "- " + model.ZipCode,
                Notes = model.RequestNotes,
            };

            _context.RequestClients.Add(requestClient);
            _context.SaveChanges();

            RequestConcierge requestConcierge = new RequestConcierge
            {
                RequestId = request.RequestId,
                ConciergeId = concierge.ConciergeId,
            };

            _context.RequestConcierges.Add(requestConcierge);
            _context.SaveChanges();
        }



        public int LoginMethodRepo(string username, string password)
        {
            var temp = _context.AspNetUsers.FirstOrDefault(u => u.Email == username && u.PasswordHash == password);

            if (temp != null)
            {
                var userId = _context.Users.FirstOrDefault(u => u.AspNetUserId == temp.Id).UserId;
                return userId;
            }
            else
            {
                return -1;
            }

        }
        public string GetUserNameRepo(int id)
        {
            return _context.Users.Where(x => x.UserId == id).Select(x => x.FirstName + " " + x.LastName).FirstOrDefault();
        }

        public List<PatientHistoryViewModel> DisplayDashboardRepo(int id)
        {
            //string userName = GetUserNameRepo(id);
            var temp = _context.Requests.Include(x => x.RequestWiseFiles).Where(x => x.UserId == id)
                .Select(x => new PatientHistoryViewModel
                {
                    RequestId = x.RequestId,
                    CreatedDate = x.CreatedDate,
                    Status = x.Status,
                    fileCount = x.RequestWiseFiles.Count
                }).ToList();

            //PatientDashboardViewModel model = new PatientDashboardViewModel()
            //{
            //    UserName = userName,
            //    HistoryViewModel = temp.ToList()
            //};
            return temp;
        }

        public ViewDocumentViewModel fetchviewDocuments(int requestId, int id)
        {
            var documents = _context.RequestWiseFiles.Where(x => x.RequestId == requestId)
                                       .Select(x => new PatientDocumentsViewModel
                                       {
                                           CreatedDate = x.CreatedDate,
                                           FileName = x.FileName
                                       }).ToList();
            ViewDocumentViewModel model = new ViewDocumentViewModel()
            {
                RequestId = requestId,
                UserName = GetUserNameRepo(id),
                DocumentsViewModel = documents

            };

            return model;
        }


        public ViewDocumentViewModel Uploaddocuments(ViewDocumentViewModel model, int requestId)
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

        public PatientProfileViewModel GetPatientProfile(int id)
        {
            var User = _context.Users.FirstOrDefault(x => x.UserId == id);
            string userName = GetUserNameRepo(id);
            PatientProfileViewModel model = new PatientProfileViewModel()
            {
                UserName = userName,
                FirstName = User.FirstName,
                LastName = User.LastName,
                Email = User.Email,
                PhoneNo = User.Mobile,
                Street = User.Street,
                City = User.City,
                State = User.State,
                ZipCode = User.ZipCode,
                DateOfBirth = User.CreatedDate
            };

            return model;
        }

        public bool CheckExistingUser(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            return user != null;
        }

        public void GetInformationMeData(SubmitInformationMeViewModel model)
        {
            AspNetUser netUser = new AspNetUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
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
                Mobile = model.PhoneNumber,
                Street = model.Street,
                City = model.City,
                State = model.State,
                ZipCode = model.ZipCode,
                CreatedBy = "hardik",
                StrMonth = (model.DateofBirth.Month).ToString(),
                IntDate = (model.DateofBirth.Day),
                IntYear = (model.DateofBirth.Year),

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
                PhoneNumber = model.PhoneNumber,
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
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                State = model.State,
                City = model.City,
                Street = model.Street,
                ZipCode = model.ZipCode,
                Address = model.Street + ", " + model.City + ", " + model.State + "- " + model.ZipCode
            };

            _context.RequestClients.Add(requestClient);
            _context.SaveChanges();

            if (model.formFile != null)
            {
                string fileName = request.RequestId.ToString() + " - " + model.formFile.FileName;
                string filePath = Path.Combine("Files", "PatientDocs", fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.formFile.CopyTo(stream);
                }

                RequestWiseFile files = new()
                {
                    RequestId = request.RequestId,
                    FileName = fileName,
                    CreatedDate = DateTime.Now,
                };
                _context.RequestWiseFiles.Add(files);
                _context.SaveChanges();

            }
        }

        public void GetInformationElseData(SubmitInformationElseVIewModel model)
        {
            AspNetUser netUser = new AspNetUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
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
                Mobile = model.PhoneNumber,
                Street = model.Street,
                City = model.City,
                State = model.State,
                ZipCode = model.ZipCode,
                CreatedBy = "hardik",
                StrMonth = (model.DateofBirth.Month).ToString(),
                IntDate = (model.DateofBirth.Day),
                IntYear = (model.DateofBirth.Year),
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
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Status = 1,
                CreatedDate = DateTime.Now,

            };


            _context.Requests.Add(request);
            _context.SaveChanges();



            if (model.formFile != null)
            {
                string fileName = request.RequestId.ToString() + " - " + model.formFile.FileName;
                string filePath = Path.Combine("Files", "PatientDocs", fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.formFile.CopyTo(stream);
                }

                RequestWiseFile files = new()
                {
                    RequestId = request.RequestId,
                    FileName = fileName,
                    CreatedDate = DateTime.Now,
                };
                _context.RequestWiseFiles.Add(files);
                _context.SaveChanges();

            }
        }

        public List<Request> DisplayAdminDashboardRepo()
        {

            var model = _context.Requests.Include(x => x.RequestClients).ToList();
            return model;
        }

        public ViewCaseViewModel DisplayViewCaseRepo(int requestId)
        {
            var Requests = _context.Requests.FirstOrDefault(x => x.RequestId == requestId);
            ViewCaseViewModel model = new ViewCaseViewModel()
            {
                firstName = Requests.FirstName,
                lastName = Requests.LastName,
                email = Requests.Email,
                phone = Requests.PhoneNumber

            };

            return model;
        }

        public void GetBusinessrequest(BusinessRequestViewModel model)
        {
            AspNetUser netUser = new AspNetUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                CreatedDate = DateTime.Now,
            };

            _context.AspNetUsers.Add(netUser);
            _context.SaveChanges();


            //User
            User user = new User
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Mobile = model.PhoneNumber,
                Street = model.Street,
                City = model.City,
                State = model.State,
                ZipCode = model.ZipCode,
                CreatedBy = "hardik",
                CreatedDate = DateTime.Now,
            };

            _context.Users.Add(user);
            _context.SaveChanges();


            //request
            Request request = new Request
            {
                UserId = user.UserId,
                RequestTypeId = 1,
                FirstName = model.Fname,
                LastName = model.Lname,
                PhoneNumber = model.Phone,
                Email = model.Emailaddress,
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
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                State = model.State,
                City = model.City,
                Street = model.Street,
                ZipCode = model.ZipCode,
                Address = model.Street + ", " + model.City + ", " + model.State + "- " + model.ZipCode,
                Notes = model.RequestNotes,
            };

            _context.RequestClients.Add(requestClient);
            _context.SaveChanges();
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

    }
}
