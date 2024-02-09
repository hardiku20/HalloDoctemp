using learning1.Models;
using learning1.ViewModel;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using System.Diagnostics;

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

        public IActionResult Index()
        {
            return View();
        }

        public HomeController(DbHallodocContext context)
        {
            /* _logger = logger;*/
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.AspNetUsers.FirstOrDefault(u => u.Email == model.Email && u.PasswordHash == model.Password);

                if (user != null)
                {
                    return RedirectToAction("patientsite");
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

        public IActionResult patientlogin()
        {
            return View();
        }

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
            AspNetUser netUser = new AspNetUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                CreatedDate = DateTime.Now,
            };

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

            //request
            Request request = new Request
            {
                RequestTypeId = 2,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Status = 1,
                CreatedDate = DateTime.Now,

            };


            _context.AspNetUsers.Add(netUser);
            _context.SaveChanges();

            _context.Users.Add(user);
            _context.SaveChanges();

            _context.Requests.Add(request);
            _context.SaveChanges();

            return View(null);
        }


        public IActionResult familyrequest()
        {
            return View();
        }


        //familypage form data___
        [HttpPost]
        public IActionResult familyrequest(Family_FriendRequestViewModel model)
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

            return RedirectToAction("Index");
        }

        public IActionResult conciergerequest()
        {
            return View();
        }
        //Concierge post method
        [HttpPost]
        public IActionResult conciergerequest(ConciergeRequestViewModel model)
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
            //Concierge concierge = new Concierge
            //{
            //    ConciergeId = user.UserId,
            //    RequestTypeId = 3,
            //    FirstName = model.FirstName,
            //    LastName = model.LastName,
            //    PhoneNumber = model.PhoneNumber,
            //    Email = model.Email,
            //    Status = 1,
            //    CreatedDate = DateTime.Now,

            //};

            //_context.Requests.Add(request);
            //_context.SaveChanges();

            RequestClient requestClient = new RequestClient
            {
                //RequestId = request.RequestId,
                FirstName = model.Fname,
                LastName = model.LastName,
                PhoneNumber = model.Phone,
                Email = model.Emailaddress,
            };

            _context.RequestClients.Add(requestClient);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult businessrequest()
        {
            return View();
        }
        //Business post method





        public IActionResult patientsubmitrequest()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}