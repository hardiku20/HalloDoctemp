﻿using DataAccess.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IAssignmentInterface
    {
        void CreateNewUser(DashboardViewModel model);
        void DeleteById(int userId);
        void EditUserData( DashboardViewModel model);
        DashboardViewModel RenderTable();
    }
}
