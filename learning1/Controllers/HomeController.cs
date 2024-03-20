using learning1.DBEntities.Models;
using learning1.DBEntities.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SQLitePCL;
using System.Diagnostics;
using System.IO.Compression;
using learning1.Services.Services;
using System.Runtime.InteropServices;
using System.Net.Mail;
using System.Net;
using learning1.Services.IServices;
using AspNetCoreHero.ToastNotification.Abstractions;
using learning1.Utils;
using learning1.Authentication;
//using learning1.Authentication;

namespace learning1.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly ILogger<HomeController> _logger;
        private readonly DbHallodocContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMemoryCache _memoryCache;
        private readonly IPatientServices _patientServices;
        private readonly INotyfService _notyf;
        private readonly IJWTService _JWTService;

        //public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor, DbHallodocContext context, IMemoryCache memoryCache)
        public HomeController(ILogger<HomeController> logger, IJWTService JWTService , IPatientServices patientServices, IHttpContextAccessor httpContextAccessor, DbHallodocContext context, IMemoryCache memoryCache, INotyfService notyf)
        {
            _patientServices = patientServices;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _memoryCache = memoryCache;
            _notyf = notyf;
            _JWTService = JWTService;
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
                //var temp = loginmethod()




                //im Authentication visit me
                //var user = new AuthManager().Login(model);
                //if(user== null)
                //{
                //    return View();
                //}

                //else
                //{
                //    SessionUtils.SetLoggedInUser(HttpContext.Session, user);
                //    return RedirectToAction("",user.Role.RoleName);
                //}
                UserInfoViewModel validUser = _patientServices.CheckValidUserWithRole(model.Email, model.Password);
                var JWTToken = _JWTService.GenerateJWTToken(validUser);
                Response.Cookies.Append("jwt", JWTToken);
                SessionUtils.SetLoggedInUser(HttpContext.Session, validUser);




                int userId = _patientServices.LoginMethod(model.Email, model.Password);
                if (userId != -1)
                {
                    //return View("patient_dashboard", user.Id);
                    //int id = _context.Users.Where(u => u. == userId).FirstOrDefault().UserId;
                    //return patient_dashboard((short)id);
                    //TempData["id"] = (int)id;
                    _httpContextAccessor.HttpContext.Session.SetInt32("Id", userId);
                    //_notyf.Success("Login Successfully");
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



        public IActionResult patientsite()
        {
            return View();
        }

        public IActionResult patientrequest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Patientrequest(PatientRequestViewModel model)
        {

            if (ModelState.IsValid)
            {
                _patientServices.GetPatientRequestData(model);
                return RedirectToAction("patientlogin");
            }
            return View();
        }


        [HttpPost]
        public IActionResult Familyrequest(Family_FriendRequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                _patientServices.GetFamilyRequestData(model);
                return RedirectToAction("patientlogin");
            }
            return View();
        }




        //post 
        //[HttpPost]
        //public IActionResult patientrequest(PatientRequestViewModel model)
        //{

        //    if (ModelState.IsValid)
        //    {

        //                if (model.Password != null && model.Password == model.ConfirmPassword)
        //                {
        //                    AspNetUser netUser = new AspNetUser
        //                    {
        //                        Id = Guid.NewGuid().ToString(),
        //                        UserName = model.Email,
        //                        Email = model.Email,
        //                        PhoneNumber = model.PhoneNumber,
        //                        CreatedDate = DateTime.Now,
        //                        PasswordHash = model.Password
        //                    };
        //        _context.AspNetUsers.Add(netUser);
        //                    _context.SaveChanges();


        //                    //User
        //                    User user = new User
        //                    {
        //                        Email = model.Email,
        //                        AspNetUserId = netUser.Id,
        //                        FirstName = model.FirstName,
        //                        LastName = model.LastName,
        //                        Mobile = model.PhoneNumber,
        //                        Street = model.Street,
        //                        City = model.City,
        //                        State = model.State,
        //                        ZipCode = model.ZipCode,
        //                        CreatedBy = "hardik",
        //                        StrMonth = (model.DateofBirth.Month).ToString(),
        //                        IntDate = (model.DateofBirth.Day),
        //                        IntYear = (model.DateofBirth.Year),

        //                        CreatedDate = DateTime.Now,
        //                    };

        //        _context.Users.Add(user);
        //                    _context.SaveChanges();

        //                }


        //    var userId = _context.Users.Where(u => u.Email == model.Email).Select(u => u.UserId).FirstOrDefault();
        //    //request
        //    Request request = new Request
        //    {
        //        UserId = userId,
        //        RequestTypeId = 2,
        //        FirstName = model.FirstName,
        //        LastName = model.LastName,
        //        PhoneNumber = model.PhoneNumber,
        //        Email = model.Email,
        //        Status = 1,
        //        CreatedDate = DateTime.Now,

        //    };


        //    _context.Requests.Add(request);
        //                _context.SaveChanges();


        //                if (model.formFile != null)
        //                {
        //                    string fileName = request.RequestId.ToString() + " - " + model.formFile.FileName;
        //    string filePath = Path.Combine("Files", "PatientDocs", fileName);
        //    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

        //                    using (var stream = new FileStream(filePath, FileMode.Create))
        //                    {
        //                        model.formFile.CopyTo(stream);
        //                    }

        //RequestWiseFile files = new()
        //{
        //    RequestId = request.RequestId,
        //    FileName = fileName,
        //    CreatedDate = DateTime.Now,
        //};
        //_context.RequestWiseFiles.Add(files);
        //_context.SaveChanges();

        //                }


        //        TempData["viewPassword"] = "false";
        //        return RedirectToAction("patientlogin");
        //    }
        //    else
        //    {
        //        TempData["viewPassword"] = "true";
        //        return View();
        //    }
        //}



        public IActionResult familyrequest()
        {
            return View();
        }


        //familypage form data___
        //[HttpPost]
        //public IActionResult familyrequest(Family_FriendRequestViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        AspNetUser netUser = new AspNetUser
        //        {
        //            Id = Guid.NewGuid().ToString(),
        //            UserName = model.Email,
        //            Email = model.Email,
        //            PhoneNumber = model.PhoneNumber,
        //            CreatedDate = DateTime.Now,
        //        };

        //        _context.AspNetUsers.Add(netUser);
        //        _context.SaveChanges();
        //        //User
        //        User user = new User
        //        {
        //            Email = model.Email,
        //            FirstName = model.FirstName,
        //            LastName = model.LastName,
        //            Mobile = model.PhoneNumber,
        //            Street = model.Street,
        //            City = model.City,
        //            State = model.State,
        //            ZipCode = model.ZipCode,
        //            CreatedBy = "hardik",
        //            CreatedDate = DateTime.Now,
        //        };

        //        _context.Users.Add(user);
        //        _context.SaveChanges();
        //        //request
        //        Request request = new Request
        //        {
        //            UserId = user.UserId,
        //            RequestTypeId = 3,
        //            FirstName = model.FirstName,
        //            LastName = model.LastName,
        //            PhoneNumber = model.PhoneNumber,
        //            Email = model.Email,
        //            Status = 1,
        //            CreatedDate = DateTime.Now,

        //        };

        //        _context.Requests.Add(request);
        //        _context.SaveChanges();

        //        RequestClient requestClient = new RequestClient
        //        {
        //            RequestId = request.RequestId,
        //            FirstName = model.Fname,
        //            LastName = model.LastName,
        //            PhoneNumber = model.Phone,
        //            Email = model.Emailaddress,
        //        };

        //        _context.RequestClients.Add(requestClient);
        //        _context.SaveChanges();

        //        return RedirectToAction("patientlogin");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}



        [HttpPost]
        public IActionResult Conciergerequest(ConciergeRequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                _patientServices.GetConciergeRequestData(model);
                return RedirectToAction("conciergerequest");
            }
            else
            {
                return View(null);
            }
        }

        public IActionResult conciergerequest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Businessrequest(BusinessRequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                _patientServices.GetBusinesssRequestData(model);
                return RedirectToAction(null);
            }
            else
            {
                return View();
            }
        }

        public IActionResult businessrequest()
        {
            return View();
        }



        //Concierge post method
        //[HttpPost]
        //public IActionResult conciergerequest(ConciergeRequestViewModel model)
        //{

        //    if (ModelState.IsValid)
        //    {



        //        AspNetUser netUser = new AspNetUser
        //        {
        //            Id = Guid.NewGuid().ToString(),
        //            UserName = model.Email,
        //            Email = model.Email,
        //            PhoneNumber = model.PhoneNumber,
        //            CreatedDate = DateTime.Now,
        //        };

        //        _context.AspNetUsers.Add(netUser);
        //        _context.SaveChanges();
        //        //User
        //        User user = new User
        //        {
        //            Email = model.Email,
        //            FirstName = model.FirstName,
        //            LastName = model.LastName,
        //            Mobile = model.PhoneNumber,
        //            Street = model.Street,
        //            City = model.City,
        //            State = model.State,
        //            ZipCode = model.ZipCode,
        //            CreatedBy = "hardik",
        //            CreatedDate = DateTime.Now,
        //        };

        //        _context.Users.Add(user);
        //        _context.SaveChanges();

        //        Region region = new Region
        //        {
        //            Name = model.State,
        //        };
        //        _context.Regions.Add(region);
        //        _context.SaveChanges();


        //        Concierge concierge = new Concierge
        //        {

        //            ConciergeName = model.Fname,
        //            Street = model.Street,
        //            City = model.City,
        //            State = model.State,
        //            ZipCode = model.ZipCode,
        //            RegionId = region.RegionId,
        //            CreatedDate = DateTime.Now,

        //        };

        //        _context.Concierges.Add(concierge);
        //        _context.SaveChanges();
        //        //request
        //        Request request = new Request
        //        {
        //            UserId = user.UserId,
        //            RequestTypeId = 3,
        //            FirstName = model.FirstName,
        //            LastName = model.LastName,
        //            PhoneNumber = model.PhoneNumber,
        //            Email = model.Email,
        //            Status = 1,
        //            CreatedDate = DateTime.Now,

        //        };

        //        _context.Requests.Add(request);
        //        _context.SaveChanges();

        //        RequestConcierge requestConcierge = new RequestConcierge
        //        {
        //            RequestId = request.RequestId,
        //            ConciergeId = concierge.ConciergeId,
        //        };

        //        _context.RequestConcierges.Add(requestConcierge);
        //        _context.SaveChanges();

        //        //RequestClient requestClient = new RequestClient
        //        //{
        //        //    RequestId = request.RequestId,
        //        //    FirstName = model.Fname,
        //        //    LastName = model.LastName,
        //        //    PhoneNumber = model.Phone,
        //        //    Email = model.Emailaddress,
        //        //};

        //        //_context.RequestClients.Add(requestClient);
        //        //_context.SaveChanges();



        //        return RedirectToAction("patientlogin");
        //    }

        //    else { return View(model); }
        //}







        //public IActionResult patientdashboard()
        //{
        //    //int id = (int)TempData["id"];
        //    int id = (int)_httpContextAccessor.HttpContext.Session.GetInt32("Id");
        //    string userName = _context.Users.Where(x => x.UserId == id).Select(x => x.FirstName + " " + x.LastName).FirstOrDefault();
        //    var temp = _context.Requests.Include(x => x.RequestWiseFiles).Where(x => x.UserId == id)
        //        .Select(x => new PatientHistoryViewModel
        //        {
        //            RequestId = x.RequestId,
        //            CreatedDate = x.CreatedDate,
        //            Status = x.Status,
        //            fileCount = x.RequestWiseFiles.Count
        //        });

        //    PatientDashboardViewModel model = new PatientDashboardViewModel()
        //    {
        //        UserName = userName,
        //        HistoryViewModel = temp.ToList()
        //    };

        //    //_httpContextAccessor.HttpContext.Session.SetInt32("id", id);
        //    return View(model);

        //}

        [CustomAuthorize("Patient")]
        public IActionResult patientdashboard()
        {
            int id = (int)_httpContextAccessor.HttpContext.Session.GetInt32("Id");
            var model = _patientServices.displayDashboard(id);
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





        //public IActionResult viewdocuments(int requestId)
        //    {
        //        if (requestId == 0)
        //        {
        //            requestId = (int) _httpContextAccessor.HttpContext.Session.GetInt32("requestId");
        //}
        //int id = (int)_httpContextAccessor.HttpContext.Session.GetInt32("Id");
        //string userName = _context.Users.Where(x => x.UserId == id).Select(x => x.FirstName + " " + x.LastName).FirstOrDefault();


        //    //List<int> requestTempId = _context.Requests.Where(x => x.UserId == id).Select(x => x.RequestId).Distinct().ToList();


        //var documents = _context.RequestWiseFiles.Where(x => x.RequestId == requestId)
        //                               .Select(x => new PatientDocumentsViewModel
        //                               {
        //                                   CreatedDate = x.CreatedDate,
        //                                   FileName = x.FileName
        //                               }).ToList();
        //ViewDocumentViewModel model = new ViewDocumentViewModel()
        //{
        //    RequestId = requestId,
        //    UserName = userName,
        //    DocumentsViewModel = documents

        //};
        //    return View(model);
        //}

        [CustomAuthorize("Patient")]
        public IActionResult viewdocuments(int requestId)
        {
            if (requestId == 0)
            {
                requestId = (int)_httpContextAccessor.HttpContext.Session.GetInt32("requestId");
            }
            int id = (int)_httpContextAccessor.HttpContext.Session.GetInt32("Id");
            var model = _patientServices.GetviewDocuments(requestId, id);
            return View(model);
        }

        //[HttpPost]
        //public IActionResult viewDocuments(ViewDocumentViewModel model, int requestId)
        //{
        //    if (model.formFile != null)
        //    {
        //        string fileName = requestId.ToString() + " - " + model.formFile.FileName;
        //        string filePath = Path.Combine("Files", "PatientDocs", fileName);
        //        Directory.CreateDirectory(Path.GetDirectoryName(filePath));

        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            model.formFile.CopyTo(stream);
        //        }

        //        RequestWiseFile files = new RequestWiseFile()
        //        {
        //            RequestId = requestId,
        //            FileName = fileName,
        //            CreatedDate = DateTime.Now,
        //        };
        //        _context.RequestWiseFiles.Add(files);
        //        _context.SaveChanges();
        //        _httpContextAccessor.HttpContext.Session.SetInt32("requestId", requestId);
        //        return RedirectToAction("viewdocuments", requestId);
        //    }
        //    return View(model);
        //}


        [HttpPost]
        public IActionResult viewDocuments(learning1.DBEntities.ViewModel.ViewDocumentViewModel model, int requestId)
        {
            if (model.formFile != null)
            {
                _patientServices.InsertviewDocuments(model, requestId);
                _httpContextAccessor.HttpContext.Session.SetInt32("requestId", requestId);
                return RedirectToAction("viewdocuments", requestId);
            }

            return View(model);
        }
        //public IActionResult patientprofile()
        //{
        //    int id = (int)_httpContextAccessor.HttpContext.Session.GetInt32("Id");
        //    var User = _context.Users.FirstOrDefault(x => x.UserId == id);
        //    string userName = _context.Users.Where(x => x.UserId == id).Select(x => x.FirstName + " " + x.LastName).FirstOrDefault();
        //    PatientProfileViewModel model = new PatientProfileViewModel()
        //    {
        //        UserName = userName,
        //        FirstName = User.FirstName,
        //        LastName = User.LastName,
        //        Email = User.Email,
        //        PhoneNo = User.Mobile,
        //        Street = User.Street,
        //        City = User.City,
        //        State = User.State,
        //        ZipCode = User.ZipCode,
        //        DateOfBirth = User.CreatedDate
        //    };


        //    return View(model);
        //}
        public IActionResult patientprofile()
        {
            int id = (int)_httpContextAccessor.HttpContext.Session.GetInt32("Id");
            var model = _patientServices.DisplayPatientProfile(id);
            return View(model);
        }




        public IActionResult reviewagreement()
        {
            return View();
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


        //public IActionResult PatientCheck(string email)
        //{
        //    var existingUser = _context.AspNetUsers.FirstOrDefault(u => u.Email == email);
        //    bool isValidEmail;
        //    if (existingUser == null)
        //    {
        //        isValidEmail = false;
        //        TempData["viewPassword"] = "true";
        //    }
        //    else
        //    {
        //        isValidEmail = true;
        //    }
        //    return Json(new { isValid = isValidEmail });
        //}

        public IActionResult PatientCheck(string email)
        {
            bool existingUser = _patientServices.IsExistingUser(email);
            bool isValidEmail;
            if (existingUser)
            {
                //isValidEmail = false;
                TempData["viewPassword"] = "true";
            }
            //else
            //{
            //    isValidEmail = true;
            //}
            return Json(new { isValid = existingUser });
        }


        public IActionResult submitinformationme()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult submitinformationme(SubmitInformationMeViewModel model)
        //{

        //    if (ModelState.IsValid)
        //    {

        //    AspNetUser netUser = new AspNetUser
        //    {
        //        Id = Guid.NewGuid().ToString(),
        //        UserName = model.Email,
        //        Email = model.Email,
        //        PhoneNumber = model.PhoneNumber,
        //        CreatedDate = DateTime.Now,

        //    };
        //    _context.AspNetUsers.Add(netUser);
        //            _context.SaveChanges();


        //            //User
        //            User user = new User
        //            {
        //                Email = model.Email,
        //                AspNetUserId = netUser.Id,
        //                FirstName = model.FirstName,
        //                LastName = model.LastName,
        //                Mobile = model.PhoneNumber,
        //                Street = model.Street,
        //                City = model.City,
        //                State = model.State,
        //                ZipCode = model.ZipCode,
        //                CreatedBy = "hardik",
        //                StrMonth = (model.DateofBirth.Month).ToString(),
        //                IntDate = (model.DateofBirth.Day),
        //                IntYear = (model.DateofBirth.Year),

        //                CreatedDate = DateTime.Now,
        //            };

        //    _context.Users.Add(user);
        //            _context.SaveChanges();

        //            Request request = new Request
        //            {
        //                UserId = user.UserId,
        //                RequestTypeId = 2,
        //                FirstName = model.FirstName,
        //                LastName = model.LastName,
        //                PhoneNumber = model.PhoneNumber,
        //                Email = model.Email,
        //                Status = 1,
        //                CreatedDate = DateTime.Now,

        //            };


        //    _context.Requests.Add(request);
        //            _context.SaveChanges();


        //            if (model.formFile != null)
        //            {
        //                string fileName = request.RequestId.ToString() + " - " + model.formFile.FileName;
        //    string filePath = Path.Combine("Files", "PatientDocs", fileName);
        //    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

        //                using (var stream = new FileStream(filePath, FileMode.Create))
        //                {
        //                    model.formFile.CopyTo(stream);
        //                }

        //RequestWiseFile files = new()
        //{
        //    RequestId = request.RequestId,
        //    FileName = fileName,
        //    CreatedDate = DateTime.Now,
        //};
        //_context.RequestWiseFiles.Add(files);
        //                _context.SaveChanges();

        //        }


        //    }
        //    else
        //    {
        //        return View();
        //    }
        //    return View();

        //}


        [HttpPost]
        public IActionResult submitinformationme(SubmitInformationMeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _patientServices.GetInformationMe(model);
            }
            else
            {
                return View();
            }
            return View();

        }


        public IActionResult submitinformationelse()
        {
            return View();
        }



        [HttpPost]
        public IActionResult submitinformationelse(learning1.DBEntities.ViewModel.SubmitInformationElseVIewModel model)
        {
            if (ModelState.IsValid)
            {
                _patientServices.GetInformationElse(model);
                return View();
            }
            return View();
        }

        //[HttpPost]
        //public IActionResult submitinformationelse(SubmitInformationElseVIewModel model)
        //{

        //    if (ModelState.IsValid)
        //    {

        //        AspNetUser netUser = new AspNetUser
        //        {
        //            Id = Guid.NewGuid().ToString(),
        //            UserName = model.Email,
        //            Email = model.Email,
        //            PhoneNumber = model.PhoneNumber,
        //            CreatedDate = DateTime.Now,

        //        };
        //        _context.AspNetUsers.Add(netUser);
        //        _context.SaveChanges();


        //        //User
        //        User user = new User
        //        {
        //            Email = model.Email,
        //            AspNetUserId = netUser.Id,
        //            FirstName = model.FirstName,
        //            LastName = model.LastName,
        //            Mobile = model.PhoneNumber,
        //            Street = model.Street,
        //            City = model.City,
        //            State = model.State,
        //            ZipCode = model.ZipCode,
        //            CreatedBy = "hardik",
        //            StrMonth = (model.DateofBirth.Month).ToString(),
        //            IntDate = (model.DateofBirth.Day),
        //            IntYear = (model.DateofBirth.Year),

        //            CreatedDate = DateTime.Now,
        //        };

        //        _context.Users.Add(user);
        //        _context.SaveChanges();

        //        Request request = new Request
        //        {
        //            UserId = user.UserId,
        //            RequestTypeId = 2,
        //            FirstName = model.FirstName,
        //            LastName = model.LastName,
        //            PhoneNumber = model.PhoneNumber,
        //            Email = model.Email,
        //            Status = 1,
        //            CreatedDate = DateTime.Now,

        //        };


        //        _context.Requests.Add(request);
        //        _context.SaveChanges();

        //        if (model.formFile != null)
        //        {
        //            string fileName = request.RequestId.ToString() + " - " + model.formFile.FileName;
        //            string filePath = Path.Combine("Files", "PatientDocs", fileName);
        //            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

        //            using (var stream = new FileStream(filePath, FileMode.Create))
        //            {
        //                model.formFile.CopyTo(stream);
        //            }

        //            RequestWiseFile files = new()
        //            {
        //                RequestId = request.RequestId,
        //                FileName = fileName,
        //                CreatedDate = DateTime.Now,
        //            };
        //            _context.RequestWiseFiles.Add(files);
        //            _context.SaveChanges();

        //        }
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //    return View();

        //}

        //[HttpPost]
        //public IActionResult patientprofile(PatientProfileViewModel model)
        //{
        //    int id = (int)_httpContextAccessor.HttpContext.Session.GetInt32("Id");
        //    User user = _context.Users.FirstOrDefault(x => x.UserId == id);

        //    user.FirstName = model.FirstName;
        //    user.LastName = model.LastName;
        //    user.Email = model.Email.ToString();
        //    user.Mobile = model.PhoneNo;
        //    user.Street = model.Street;
        //    user.City = model.City;
        //    user.State = model.State;
        //    user.ZipCode = model.ZipCode;

        //    _context.Users.Update(user);
        //    _context.SaveChanges();

        //    //int requestId = _context.Requests.FirstOrDefault(x => x.UserId == id).RequestId;
        //    //RequestClient requestClient = _context.RequestClients.FirstOrDefault(x => x.RequestId == requestId);

        //    //requestClient.FirstName = model.FirstName;
        //    //requestClient.LastName = model.LastName;
        //    //requestClient.Email = model.Email.ToString();
        //    //requestClient.PhoneNumber = model.PhoneNo;



        //    return RedirectToAction("patientprofile");
        //}



        public static void SendEmail(string email, string body, string subject)
        {

            var client = new SmtpClient("smtp.office365.com", 587);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("tatav.dotnet.hardikupadhyay@outlook.com", "Hardik@2003");
            client.EnableSsl = true;

            var message = new MailMessage();
            message.From = new MailAddress("tatav.dotnet.hardikupadhyay@outlook.com");
            message.To.Add(email);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;
            client.Send(message);
        }

        public IActionResult patientforgotpass()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult patientforgotpass(ForgotPasswordViewModel model)
        {
            var userEmail = _context.AspNetUsers.FirstOrDefault(x => x.Email == model.Email).Email;
            if (userEmail != null)
            {

                var emailKey = Guid.NewGuid().ToString();
                _httpContextAccessor.HttpContext.Session.SetString("EmailKey", emailKey);
                _memoryCache.Set(userEmail, emailKey, TimeSpan.FromMinutes(30));
                var resetLink = "https://localhost:7116/Home/Reset_pwd?uid=" + userEmail + "&token=" + emailKey;
                var subject = "Request to Reset Password";
                var body = "Hi " + "USER " + "Click on link below to reset your password " + resetLink;
                SendEmail(userEmail, body, subject);
                var tmp = _memoryCache.Get(userEmail);
                return RedirectToAction("patientlogin");
            }
            else
            {
                return View();
            }
            return View();
        }
        [HttpGet]
        public IActionResult Reset_pwd([FromQuery] string uid, [FromQuery] string token)
        {
            var tokenStored = _memoryCache.Get(uid);
            if (tokenStored.ToString() == token)
            {
                ResetPasswordViewModel model = new ResetPasswordViewModel();
                model.Email = uid;
                TempData["isTokenSame"] = "true";
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Reset_pwd(ResetPasswordViewModel model, [FromQuery] string uid)
        {
            if (ModelState.IsValid)
            {
                model.Email = uid;
                if (model.Password == model.ConfirmPassword)
                {
                    AspNetUser netUser = _context.AspNetUsers.FirstOrDefault(x => x.Email == uid);
                    netUser.PasswordHash = model.Password;
                    _context.AspNetUsers.Update(netUser);
                    _context.SaveChanges();


                    return RedirectToAction("Login");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
