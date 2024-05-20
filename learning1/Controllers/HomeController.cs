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
                _notyf.Success("Request Successfully Created");
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
                _notyf.Success("Request Successfully Created");
                return RedirectToAction("patientlogin");
            }
            return View();
        }

        public IActionResult familyrequest()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Conciergerequest(ConciergeRequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                _patientServices.GetConciergeRequestData(model);
                _notyf.Success("Request Successfully Created");
                return RedirectToAction("patientlogin");
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
                _notyf.Success("Request Successfully Created");
                return RedirectToAction("patientlogin");
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
        [CustomAuthorize("Patient")]
        public IActionResult patientprofile()
        {
            int id = (int)_httpContextAccessor.HttpContext.Session.GetInt32("Id");
            var model = _patientServices.DisplayPatientProfile(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult patientprofile(PatientProfileViewModel model)
        {
            int id = (int)_httpContextAccessor.HttpContext.Session.GetInt32("Id");
            _patientServices.UpdatePatientProfile(model,id);
            return View(model);
        }

        public IActionResult reviewagreement(string requestId)
        {
            TempData["RequestId"] = requestId;
            return View();
        }





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
      


        [HttpPost]
        public IActionResult submitinformationme(SubmitInformationMeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _patientServices.GetInformationMe(model);
                _notyf.Success("Request Created Successfully");
            }
            else
            {
                return View();
            }
            return View("patientdashboard");

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
                _notyf.Success("Request Created Successfully");
                return View("patientdashboaard");
            }
            return View();
        }


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





        public IActionResult AcceptRequest()
        {
            var requestId=TempData["RequestId"].ToString();
            _patientServices.AcceptAgreement(int.Parse(requestId));
            return RedirectToAction("Patientsite");
        }







        public IActionResult Logout()
        {

            _httpContextAccessor.HttpContext.Session.Clear();
            Response.Cookies.Delete("jwt");
            //_notyf.Success("Logged Out");
            return RedirectToAction("patientlogin", "Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
