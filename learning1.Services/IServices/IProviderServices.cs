﻿using learning1.DBEntities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.Services.IServices
{
    public interface IProviderServices
    {
        ProviderDashboardViewModel DisplayProviderDashboard();
        ProviderDashboardViewModel RenderActiveStateData(int status1, int status2, int page, int pageSize, string patientName, string regionName, RequestType requestType);
        ProviderDashboardViewModel RenderConcludeStateData(int status, int page, int pageSize, string patientName, string regionName, RequestType requestType);
        ProviderDashboardViewModel RenderNewStateData(int status, int page, int pageSize, string patientName, string regionName, RequestType requestType);
        ProviderDashboardViewModel RenderPendingStateData(int status, int page, int pageSize, string patientName, string regionName, RequestType requestType);
    }
}