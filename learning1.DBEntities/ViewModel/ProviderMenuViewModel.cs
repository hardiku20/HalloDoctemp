using learning1.DBEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.DBEntities.ViewModel
{
    public class ProviderMenuViewModel
    {
        public int PhysicianId { get; set; }
        public List<Region> RegionList { get; set; }

        public string SelectedRegion { get; set; }
        public List<ProviderMenuDetailsViewModel> Details { get; set; }

    }
}
public class ProviderMenuDetailsViewModel
{
    public int PhysicianId { get; set; }
    public string? firstName {  get; set; }
    public string? lastName { get; set; }
    public string? Name { get; set; }

    public bool? Notification { get; set; }
    public RoleName Role { get; set; }
    public string? OnCallStatus { get; set; }

    public PhysicianStatus? Status { get; set; }
    public string? Message {  get; set; }
    
}

public enum RoleName
{
    Admin = 1,
    Physician = 2,
    Patient = 3

}

public enum PhysicianStatus
{
    Active = 1,
    Inactive = 2,
    Pending = 3,
}
