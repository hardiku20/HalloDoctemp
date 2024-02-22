using learning1.DBEntities.Models;
using learning1.DBEntities.ViewModel;
using learning1.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.Repositories.Repositories
{

    public class PatientRepo : IPatientRepo
    {
        public readonly DbHallodocContext _context;

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
                FirstName = model.Fname,
                LastName = model.LastName,
                PhoneNumber = model.Phone,
                Email = model.Emailaddress,
            };

            _context.RequestClients.Add(requestClient);
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




    }
}
