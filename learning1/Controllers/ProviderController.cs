using AspNetCoreHero.ToastNotification.Abstractions;
using learning1.Repositories.Repositories;
using learning1.Services.IServices;
using learning1.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace learning1.Controllers
{
    public class ProviderController : Controller
    {

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IProviderServices _providerServices;
        private readonly INotyfService _notyf;


        public ProviderController(IHttpContextAccessor contextAccessor, IProviderServices providerServices,INotyfService notyf)
        {
            _contextAccessor = contextAccessor;
            _providerServices = providerServices;
            _notyf = notyf;
        }



        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ProviderDashboard(int PhysicianId = 16)
        {
            var model = _providerServices.DisplayProviderDashboard(PhysicianId);
            return View(model);
        }

        public IActionResult RenderNewPartialView(int Status,int physicianId = 16, int Page = 1, int PageSize = 4, string patientName = null, string regionName = null, learning1.DBEntities.ViewModel.RequestType requestType = (learning1.DBEntities.ViewModel.RequestType)5)
        {

            var model = _providerServices.RenderNewStateData(Status, physicianId, Page, PageSize, patientName, regionName, requestType);
            return PartialView("_providerNewState", model);
        }



        public IActionResult RenderPendingPartialView(int Status, int physicianId = 16, int Page = 1, int PageSize = 4, string patientName = null, string regionName = null, learning1.DBEntities.ViewModel.RequestType requestType = (learning1.DBEntities.ViewModel.RequestType)5)
        {
            var model = _providerServices.RenderPendingStateData(Status, physicianId, Page, PageSize, patientName, regionName, requestType);
            return PartialView("_providerPendingState", model);
        }

        public IActionResult RenderActivePartialView(int status1,  int status2, int physicianId = 16, int Page = 1, int PageSize = 4, string patientName = null, string regionName = null, learning1.DBEntities.ViewModel.RequestType requestType = (learning1.DBEntities.ViewModel.RequestType)5)
        {
            var model = _providerServices.RenderActiveStateData(status1, status2, physicianId, Page, PageSize, patientName, regionName, requestType);
            return PartialView("_providerActiveState", model);
        }
        public IActionResult RenderConcludePartialView(int Status, int physicianId = 16, int Page = 1, int PageSize = 4, string patientName = null, string regionName = null, learning1.DBEntities.ViewModel.RequestType requestType = (learning1.DBEntities.ViewModel.RequestType)5)
        {
            var model = _providerServices.RenderConcludeStateData(Status, physicianId, Page, PageSize, patientName, regionName, requestType);
            return PartialView("_providerConcludeState", model);
        }



        public IActionResult ViewCase(int RequestId)
        {
            var model = _providerServices.DisplayViewCase(RequestId);
            return View(model);
        }



    }
}
