using BusinessLogic.Interfaces;
using DataAccess.CustomModels;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories
{
    public class AssignmentRepository : IAssignmentInterface
    {
       private readonly AssigmentContext _context;
        public AssignmentRepository(AssigmentContext context)
        {
            _context = context;
        }

        public void CreateNewUser(DashboardViewModel model)
        {
            User user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                City = model.City,
                Age=18,
                Email =model.Email,
                PhoneNo = model.PhoneNumber,
                Gender = 'M',
                Country = model.Country,
                CityId = 1,
            };
            _context.Users.Add(user);
            _context.SaveChanges();


        }

        public void DeleteById(int userId)
        {   

            var user = _context.Users.Where(x => x.Id == userId).FirstOrDefault();
            
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void EditUserData(DashboardViewModel model)
        {
            User user = _context.Users.Where(x => x.Id == model.Id).FirstOrDefault();
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.PhoneNo = model.PhoneNumber;
            _context.Users.Update(user);
            _context.SaveChanges();
        }




        public DashboardViewModel RenderTable()
        {
            var temp = _context.Users.Select(x => new DashboardViewModel.Dashboardtable()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Age= "18",
                PhoneNumber = x.PhoneNo,
                Gender = x.Gender.ToString(),
                City = x.City,
                Country = x.Country,

            }).ToList();

            DashboardViewModel model = new DashboardViewModel()
            {
                dashboardtables = temp,
            };
            return model;



        }






    }
}
