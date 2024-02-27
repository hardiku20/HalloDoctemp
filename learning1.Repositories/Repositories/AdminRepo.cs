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
    }
}
