using learning1.Models;
using learning1.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System.Diagnostics;
using System.IO.Compression;
using System.Runtime.InteropServices;

namespace learning1.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        private readonly DbHallodocContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public HomeController(DbHallodocContext context, IHttpContextAccessor httpContextAccessor)
        {
            /* _logger = logger;*/
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }




        public IActionResult patientlogin()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult patientlogin(LoginViewModel model)
        {
            //AspNetUser netUser = new AspNetUser
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    UserName = model.Email,
            //    Email = model.Email,
            //    PasswordHash = model.Password,
            //    CreatedDate = DateTime.Now,
            //};
            //_context.AspNetUsers.Add(netUser);
            //_context.SaveChanges();


            if (ModelState.IsValid)
            {

                var user = _context.AspNetUsers.FirstOrDefault(u => u.Email == model.Email && u.PasswordHash == model.Password);

                if (user != null)
                {
                    //return View("patient_dashboard", user.Id);
                    int id = _context.Users.Where(u => u.AspNetUserId == user.Id).FirstOrDefault().UserId;
                    //return patient_dashboard((short)id);
                    //TempData["id"] = (int)id;
                    _httpContextAccessor.HttpContext.Session.SetInt32("Id", id);
                    return RedirectToAction("patientdashboard", "Home");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //public IActionResult patientlogin()
        //{
        //    return View();
        //}

        public IActionResult patientforgotpass()
        {
            return View();
        }

        public IActionResult patientsite()
        {
            return View();
        }

        public IActionResult patientrequest()
        {
            return View();
        }

        //post 
        [HttpPost]
        public IActionResult patientrequest(PatientRequestViewModel model)
        {

            if (ModelState.IsValid)
            {

                if(model.Password != null && model.Password==model.ConfirmPassword)
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


                TempData["viewPassword"] = "false";
                return RedirectToAction("patientlogin");
            }
            else
            {
                TempData["viewPassword"] = "true";
                return View();
            }
        }



        public IActionResult familyrequest()
        {
            return View();
        }


        //familypage form data___
        [HttpPost]
        public IActionResult familyrequest(Family_FriendRequestViewModel model)
        {
            if (ModelState.IsValid)
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

                return RedirectToAction("patientlogin");
            }
            else
            {
                return View();
            }
        }

        public IActionResult conciergerequest()
        {
            return View();
        }
        //Concierge post method
        [HttpPost]
        public IActionResult conciergerequest(ConciergeRequestViewModel model)
        {

            if (ModelState.IsValid)
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

                Region region = new Region
                {
                    Name = model.State,
                };
                _context.Regions.Add(region);
                _context.SaveChanges();


                Concierge concierge = new Concierge
                {

                    ConciergeName = model.Fname,
                    Street = model.Street,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode,
                    RegionId = region.RegionId,
                    CreatedDate = DateTime.Now,

                };

                _context.Concierges.Add(concierge);
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

                RequestConcierge requestConcierge = new RequestConcierge
                {
                    RequestId = request.RequestId,
                    ConciergeId = concierge.ConciergeId,
                };

                _context.RequestConcierges.Add(requestConcierge);
                _context.SaveChanges();

                //RequestClient requestClient = new RequestClient
                //{
                //    RequestId = request.RequestId,
                //    FirstName = model.Fname,
                //    LastName = model.LastName,
                //    PhoneNumber = model.Phone,
                //    Email = model.Emailaddress,
                //};

                //_context.RequestClients.Add(requestClient);
                //_context.SaveChanges();



                return RedirectToAction("patientlogin");
            }

            else { return View(model); }
        }


        public IActionResult businessrequest()
        {
            return View();
        }


        //Business post method
        [HttpPost]
        public IActionResult businessrequest(BusinessRequestViewModel model)
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





            return RedirectToAction("patientlogin");
        }

        public IActionResult patientdashboard(short userId)
        {
            //int id = (int)TempData["id"];
            int id = (int)_httpContextAccessor.HttpContext.Session.GetInt32("Id");
            string userName = _context.Users.Where(x => x.UserId == id).Select(x => x.FirstName + " " + x.LastName).FirstOrDefault();
            var temp = _context.Requests.Include(x => x.RequestWiseFiles).Where(x => x.UserId == id)
                .Select(x => new PatientHistoryViewModel
                {
                    RequestId = x.RequestId,
                    CreatedDate = x.CreatedDate,
                    Status = x.Status,
                    fileCount = x.RequestWiseFiles.Count
                });

            PatientDashboardViewModel model = new PatientDashboardViewModel()
            {
                UserName = userName,
                HistoryViewModel = temp.ToList()
            };

            //_httpContextAccessor.HttpContext.Session.SetInt32("id", id);
            return View(model);

        }





        public IActionResult patientsubmitrequest()
        {
            return View();
        }

        public IActionResult createpatient()
        {
            return View();
        }

        


        public IActionResult viewdocuments( int requestId)
        {
            if (requestId == 0)
            {
                requestId = (int)_httpContextAccessor.HttpContext.Session.GetInt32("requestId");
            }
            int id = (int)_httpContextAccessor.HttpContext.Session.GetInt32("Id");
            string userName = _context.Users.Where(x => x.UserId == id).Select(x => x.FirstName + " " + x.LastName).FirstOrDefault();


            //List<int> requestTempId = _context.Requests.Where(x => x.UserId == id).Select(x => x.RequestId).Distinct().ToList();


            var documents = _context.RequestWiseFiles.Where(x => x.RequestId == requestId)
                                           .Select(x => new PatientDocumentsViewModel
                                           {
                                               CreatedDate = x.CreatedDate,
                                               FileName = x.FileName
                                           }).ToList();
            ViewDocumentViewModel model = new ViewDocumentViewModel()
            {
                RequestId = requestId,
                UserName = userName,
                DocumentsViewModel = documents

            };
            return View(model);
        }

        [HttpPost]
        public IActionResult viewDocuments(ViewDocumentViewModel model, int requestId)
        {
            if(model.formFile != null)
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
                _httpContextAccessor.HttpContext.Session.SetInt32("requestId", requestId);
                return RedirectToAction("viewdocuments", requestId);

            }
            return View(model);
        }

        public IActionResult patientprofile()
        {
            int id = (int)_httpContextAccessor.HttpContext.Session.GetInt32("Id");
            var User = _context.Users.FirstOrDefault(x=>x.UserId == id);
            PatientProfileViewModel model = new PatientProfileViewModel()
            {
                FirstName= User.FirstName

            };


            return View(model);
        }

        public IActionResult reviewagreement()
        {
            return View(); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //public IActionResult DownLoadAll()
        //{
        //    var zipName = $"TestFiles-{DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss")}.zip";
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        //required: using System.IO.Compression;
        //        using (var zip = new ZipArchive(ms, ZipArchiveMode.Create, true))
        //        {
        //            //QUery the Products table and get all image content
        //            _dbcontext.Products.ToList().ForEach(file =>
        //            {
        //                var entry = zip.CreateEntry(file.ProImageName);
        //                using (var fileStream = new MemoryStream(file.ProImageContent))
        //                using (var entryStream = entry.Open())
        //                {
        //                    fileStream.CopyTo(entryStream);
        //                }
        //            });
        //        }
        //        return File(ms.ToArray(), "application/zip", zipName);
        //    }
        //}


        public IActionResult download_file(string filename)
        {
            var net = new System.Net.WebClient();
            var data = net.DownloadData("Files/PatientDocs/" + filename);
            var content = new System.IO.MemoryStream(data);
            var contentType = "APPLICATION/octet-stream";
            return File(content, contentType, filename);
        }


        public IActionResult PatientCheck(string email)
        {
            var existingUser = _context.AspNetUsers.FirstOrDefault(u => u.Email == email);
            bool isValidEmail;
            if (existingUser == null)
            {
                isValidEmail = false;
                TempData["viewPassword"] = "true";
            }
            else
            {
                isValidEmail = true;
            }
            return Json(new { isValid = isValidEmail });
        }
    }
}
