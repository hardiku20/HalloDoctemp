using learning1.DBEntities.Models;
using learning1.DBEntities.ViewModel;
using learning1.Repositories.IRepositories;
using learning1.Repositories.Repositories;
using learning1.Services.IServices;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace learning1.Services.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly IAdminRepo _adminRepo;
        public AdminServices(IAdminRepo adminRepo)
        {
            _adminRepo = adminRepo;
        }

        public AdminDashboardViewModel DisplayAdminDashboard()
        {
            var Casetags = _adminRepo.DisplayCasetags();
            var Regions = _adminRepo.DisplayRegions();
            var Count = _adminRepo.SetCount();
            var temp = _adminRepo.DisplayAdminDashboardRepo().
                Select(x => new AdminTableViewModel
                {
                    RequestId = x.RequestId,
                    RequestedDate = x.CreatedDate.ToString(),
                    Phone = x.PhoneNumber,
                    Name = x.RequestClients.Select(x => x.FirstName + " " + x.LastName).FirstOrDefault(),
                    Address = x.RequestClients.Select(x => x.Address).FirstOrDefault(),
                    Requester = x.FirstName + " " + x.LastName,
                    PhoneNumber = x.PhoneNumber,
                    RequestType = (DBEntities.ViewModel.RequestType)x.RequestTypeId,
                }).ToList();

            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                //TableViewModel = temp,
                CancellationReason = Casetags,
                Region = Regions,
                RequestCount = Count,
            };
            return model;
        }

        public ViewCaseViewModel DisplayViewCase(int requestId)
        {
            var model = _adminRepo.DisplayViewCaseRepo(requestId);
            return model;
        }

        public void SendAgreement(int requestId)
        {
            _adminRepo.Mails(requestId);
        }

        public void GetAssignCaseData(AdminDashboardViewModel model, int requestId)
        {
            _adminRepo.AssignCaseRepo(model, requestId);
        }

        public List<string> GetAvailablePhysicianByRegion(string regionName)
        {
            var physicianName = _adminRepo.GetAvailablePhysicianByRegionName(regionName);
            return physicianName;
        }

        public void GetBlockCaseData(AdminDashboardViewModel model)
        {
            _adminRepo.BlockCaseRepo(model);
        }

        public List<string> GetBusinessByProfession(string professionName)
        {
            var BusinessName = _adminRepo.GetBusinessByProfessionName(professionName);
            return BusinessName;
        }

        public void GetCancelCaseData(AdminDashboardViewModel model)
        {
            _adminRepo.CancelCaseRepo(model);
        }

        public SendOrderViewModel GetDetailsByBusiness(string businessName)
        {
            var Orderdetails = _adminRepo.GetOrder(businessName);
            return Orderdetails;
        }

        public SendOrderViewModel GetOrderdetails()
        {
            var Profession = _adminRepo.DisplayProfession();
            SendOrderViewModel model = new SendOrderViewModel()
            {
                Profession = Profession,
            };
            return model;
        }

        //public void GetOrderdetails(SendOrderViewModel model)
        //{
        //    _adminRepo.OrderdetailsRepo(model);
        //}

        public List<string> GetPhysicianByRegion(string regionName)
        {
            var physicianName = _adminRepo.GetPhysicianByRegionName(regionName);
            return physicianName;
        }

        //public void GetSendAgreementData(AdminDashboardViewModel model, int requestId)
        //{
        //    _adminRepo.SendAgreementRepo(model, requestId);
        //}

        public void GetTransferCaseData(AdminDashboardViewModel model, int requestId)
        {
            _adminRepo.TransferCaseRepo(model, requestId);
        }



        public ViewUploadViewModel GetviewUploads(int requestId)
        {
            var model = _adminRepo.FetchViewUploads(requestId);
            return model;
        }

        public void InsertOrderDetails(SendOrderViewModel model)
        {
            _adminRepo.OrderDetailRepo(model);
        }

        public void InsertviewUploads(ViewUploadViewModel model, int requestId)
        {
            _adminRepo.Uploaddocuments(model, requestId);
        }

        public void IsClearCase(AdminDashboardViewModel model)
        {
            _adminRepo.ClearCaseRepo(model);
        }

        public AdminDashboardViewModel ListToExportAllData()
        {
            var model = _adminRepo.ListToExportAllData();
            return model;
        }




        public AdminDashboardViewModel RenderActiveStateData(int status1, int status2, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
        {
            var model = _adminRepo.RenderToActiveState(status1, status2, page, pageSize, patientName, regionName, requestType);
            return model;
        }

        public AdminDashboardViewModel RenderConcludeStateData(int status, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
        {
            var model = _adminRepo.RenderConcludeState(status, page, pageSize, patientName, regionName, requestType);
            return model;
        }

        public AdminDashboardViewModel RenderNewStateData(int status, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
        {
            var model = _adminRepo.RenderNewState(status, page, pageSize, patientName, regionName, requestType);
            return model;
        }

        public AdminDashboardViewModel RenderPendingStateData(int status, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
        {
            var model = _adminRepo.RenderPendingState(status, page, pageSize, patientName, regionName, requestType);
            return model;
        }

        public AdminDashboardViewModel RenderToCloseStateData(int status1, int status2, int status3, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
        {
            var model = _adminRepo.RenderToCloseState(status1, status2, status3, page, pageSize, patientName, regionName, requestType);
            return model;
        }

        public AdminDashboardViewModel RenderUnpaidStateData(int status, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
        {
            var model = _adminRepo.RenderUnpaidState(status, page, pageSize, patientName, regionName, requestType);
            return model;
        }



       
        public int LoginMethod(string email, string password)
        {
            int AdminId = _adminRepo.LoginMethodRepo(email, password);
            return AdminId;
        }

        public void SendlinktoPatient(AdminDashboardViewModel model)
        {
            _adminRepo.SendlinkMail(model);
        }

        public void CreatePatientRequest(CreateRequestViewModel model)
        {
            _adminRepo.CreateRequestRepo(model);
        }

        public CreateAdminAccountViewModel GetRegionforAdmin()
        {
            var regions = _adminRepo.GetRegionTable();
            CreateAdminAccountViewModel model = new CreateAdminAccountViewModel()
            {
                Region = regions,
            };
            return model;
        }

        public AdminProfileViewModel GetAdminProfileData(int AdminId)
        {
            var model = _adminRepo.GetAdminProfileRepo(AdminId);
            return model;


        }

        public List<Menu> GetMenus(int accountType)
        {
            var Menus = _adminRepo.GetMenuRepo(accountType);
            return Menus;
        }

        public void CreateRoleByAccount(CreateRoleViewModel model)
        {
            _adminRepo.CreateRoleRepo(model);
        }

        public AccountAccessViewModel GetAccountAccessTable()
        {
            var model = _adminRepo.GetAccountAccessRepo();
            return model;
        }

        public CreateRoleViewModel GetDetailsByRoleId(int roleId)
        {
            return _adminRepo.GetRoleDetailsRepo(roleId);
        }

        public void DeleteRoleById(int roleId)
        {
            _adminRepo.DeleteRoleRepo(roleId);
        }

        public List<ShiftDetail> GetScheduleData()
        {
            return _adminRepo.GetScheduleData();
        }

        public List<Region> getRegionTableData()
        {
            return _adminRepo.GetRegionTable();
        }

        public List<ProviderMenuDetailsViewModel> GetPhysicianDataByRegion(int regionId)
        {
            var tableData = _adminRepo.ProviderMenuTableDetails(regionId);


            return tableData;
        }

        public AddBusinessViewModal GetProfession()
        {
            var Profession = _adminRepo.DisplayProfessionlist();
            AddBusinessViewModal model = new AddBusinessViewModal()
            {
                ProfessionalTypes = Profession,
            };
            return model;
        }

        public void AddNewBusiness(AddBusinessViewModal modal)
        {
            _adminRepo.AddBusinessRepo(modal);
        }



        public AddBusinessViewModal GetBusinessByVendorId(int vendorId)
        {
            var model = _adminRepo.GetBusinessRepo(vendorId);
            return model;
        }

        public void UpdateBusiness(AddBusinessViewModal modal)
        {
            _adminRepo.UpdateBusinessRepo(modal);
        }

        public void DeleteBusinessByVendor(int vendorId)
        {
            _adminRepo.DeleteBusinessRepo(vendorId);
        }

        public VendorViewModel GetVendorsDetails(int professionId, string vendorName, int Page, int PageSize)
        {
            var model = _adminRepo.GetVendorRepo(professionId, vendorName,Page,PageSize);
            return model;
        }

        public RecordsViewModel GetPatientHistory(string firstname, string lastname, string email, string phonenumber)
        {
            var model = _adminRepo.PatientHistoryRepo(firstname, lastname, email, phonenumber);
            return model;
        }

        public RecordsViewModel GetPatientExplore(int userId)
        {
            var model = _adminRepo.PatientExploreRepo(userId);
            return model;
        }

        public RecordsViewModel GetSearchData(string patientName, string providerName, string email, string phoneNumber)
        {
            var model = _adminRepo.SearchDataRepo(patientName, providerName, email, phoneNumber);
            return model;
        }

        public UserAccessViewModel GetUserAccessdetail(int RoleId)
        {
            var model = _adminRepo.GetUserAccessRepo(RoleId);
            return model;

        }

        public RecordsViewModel GetBlockRecords(string name, string date, string email, string phoneNumber)
        {
            var model = _adminRepo.BlockDataRepo(name, date, email, phoneNumber);
            return model;
        }

        public CreateRoleViewModel GetDetailsByRoleId()
        {
            return _adminRepo.GetRoleDetailsRepo();
        }

        public CreateProviderAccountViewModel GetRegionforProvider()
        {
            var regions = _adminRepo.GetRegionTable();
            CreateProviderAccountViewModel model = new CreateProviderAccountViewModel()
            {
                Region = regions,
            };
            return model;
        }

        public ProviderMenuViewModel GetRegionsforProvider()
        {
            var regions = _adminRepo.GetRegionTable();
            ProviderMenuViewModel model = new ProviderMenuViewModel()
            {
                RegionList = regions,
            };
            return model;
        }

        public ProviderMenuViewModel GetProvidersdetails(int regionId)
        {
            var modal = _adminRepo.GetProviderRepo(regionId);
            return modal;

        }

        //public CreateProviderAccountViewModel GetRegionsforPhysician()
        //{
        //    var regions = _adminRepo.GetRegionTable();
        //    CreateProviderAccountViewModel model = new CreateProviderAccountViewModel()
        //    {
        //        Region = regions,
        //    };
        //    return model;

        //}

        public void CreateAdmin(CreateAdminAccountViewModel model)
        {
            _adminRepo.CreateAdminRepo(model);
        }

        public SchedulingViewModel GetRegionsforShift()
        {
            var regions = _adminRepo.GetRegionTable();
            SchedulingViewModel model = new SchedulingViewModel()
            {
                RegionList = regions,
            };
            return model;
        }

        public void CreateNewShift(SchedulingViewModel model)
        {
            _adminRepo.CreateNewStateData(model);
        }

        public void UpdateBusinessProfileBilling(AdminProfileViewModel model)
        {
            _adminRepo.UpdateBillingRepo(model);
        }

        public void UpdateAdminInformation(AdminProfileViewModel model)
        {
            _adminRepo.UpdateAdminInfoRepo(model);
        }

        public ProviderLocationViewModel GetProviderList()
        {
            return _adminRepo.GetPhysicianLocationList();
        }

        public void CreateProvider(CreateProviderAccountViewModel model)
        {
            _adminRepo.CreateProviderRepo(model);
        }

        public Admin GetAdminByEmail(string email, string password)
        {
            return _adminRepo.GetAdminByMailRepo(email, password);
        }

        public UserInfoViewModel CheckValidUserWithRole(string email, string password)
        {
            var model = _adminRepo.GetRoleByAspNetId(email, password);
            return model;
        }

        public ViewNotesViewModel GetNotesById(int requestId)
        {
            return _adminRepo.GetNoteDataById(requestId);
        }

        public void SetNotesById(ViewNotesViewModel model)
        {
            RequestNote requestNote = _adminRepo.GetRquestNoteById(model.RequestId);
            if (requestNote != null)
            {
                requestNote.AdminNotes = model.AdditionalNotes;
                requestNote.PhysicianNotes = model.PhysicianNotes ?? "No Notes Available";
                requestNote.ModifiedBy = "Admin";
                requestNote.ModifiedDate = DateTime.Now;

                _adminRepo.UpdateNotes(requestNote);
            }
            else
            {
                RequestNote requestnote = new RequestNote()
                {
                    RequestId = model.RequestId,
                    AdminNotes = model.AdditionalNotes,
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now

                };

                _adminRepo.AddRequestNote(requestnote);

            }
        }

        public ShiftViewDetailDTO GetShiftDetails(int shiftDetailId)
        {
            var model = _adminRepo.GetViewShift(shiftDetailId);
            return model;
        }

        public void ReturnViewShiftDetail(int shiftDetailId, int adminId)
        {
            _adminRepo.ReturnViewShift(shiftDetailId, adminId);
        }

        public void DeleteViewShiftDetail(int shiftDetailId, int adminId)
        {
            _adminRepo.DeleteViewShift(shiftDetailId, adminId);
        }

        public void EditViewShiftDetail(ShiftViewDetailDTO shiftDetail, int adminId)
        {
            _adminRepo.EditViewShift(shiftDetail, adminId);
        }

        public List<Physician> GetPhysiciansByRegion(int regionId)
        {

            return _adminRepo.GetPhysicianByRegion(regionId);
        }

        public void SaveNotifications(List<int> idlist)
        {
            _adminRepo.SaveNotificationRepo(idlist);
        }

        public CloseCaseViewModel GetCloseCase(int id)
        {
            var model = _adminRepo.GetCloseCaseRepo(id);
            return model;
        }

        public void SetCloseCase(CloseCaseViewModel modal)
        {
            _adminRepo.SetCloseCaseRepo(modal);
        }

        public bool UpdateRequest(int id)
        {
            Request req = _adminRepo.GetRequestById(id);
            req.ModifiedDate = DateTime.Now;
            req.Status = 9;
            _adminRepo.UpdateRequests(req);
            DateTime date = DateTime.Now;
            RequestStatusLog requestStatusLog = new RequestStatusLog()
            {
                RequestId = req.RequestId,
                Status = req.Status,
                PhysicianId = req.PhysicianId,
                CreatedDate = date,
                Notes = "The case has been closed on " + date.ToString("f")
            };

            _adminRepo.AddRequestStatusLog(requestStatusLog);
            return true;


        }

        public void SendAgreementMail(int requestId)
        {
            _adminRepo.Mails(requestId);
        }

        public CreateRoleViewModel GetEditDetailsByRoleId(int accountType, int roleId)
        {
            return _adminRepo.EditDetailsRepo(accountType, roleId);
        }

        public void EditRole(CreateRoleViewModel model)
        {
            _adminRepo.EditRoleRepo(model);
        }

        public void UnblockCase(int requestId)
        {
            _adminRepo.UnblockCaseRepo(requestId);
        }

        public EncounterFormViewModel GetEncounterform(int requestId)
        {
            return _adminRepo.GetEncounterformRepo(requestId);
        }

        public void EncounterforData(EncounterFormViewModel model)
        {
            _adminRepo.EncounterFormRepo(model);
        }

        public Payrate GetPayrateByPhysicianId(int physicianId)
        {
            var model = _adminRepo.GetPayratesData(physicianId);
            if (model == null)
            {
                Payrate payrate = new()
                {
                    PhysicianId = physicianId,
                    NightShiftWeekend = 0,
                    Shift = 0,
                    HousecallNightWeekend = 0,
                    Phoneconsult = 0,
                    PhoneconsultNightWeekend = 0,
                    BatchTesting = 0,
                    Housecall = 0,

                };

                _adminRepo.AddPayrates(payrate);

                return payrate;
            }
            return model;
        }

        public bool UpdatePayrate(object fieldId, Payrate model)
        {
            try
            {
                Payrate oldpayrates = _adminRepo.GetPayratesData(model.PhysicianId);

                if (oldpayrates != null)
                {
                    switch (fieldId)
                    {
                        case 1: oldpayrates.NightShiftWeekend = model.NightShiftWeekend; break;
                        case 2: oldpayrates.Shift = model.Shift; break;
                        case 3: oldpayrates.HousecallNightWeekend = model.HousecallNightWeekend; break;
                        case 4: oldpayrates.Phoneconsult = model.Phoneconsult; break;
                        case 5: oldpayrates.PhoneconsultNightWeekend = model.PhoneconsultNightWeekend; break;
                        case 6: oldpayrates.BatchTesting = model.BatchTesting; break;
                        case 7: oldpayrates.Housecall = model.Housecall; break;
                        default: return false;
                    };

                    _adminRepo.UpdatePayrates(oldpayrates);

                    return true;
                }
                return false;

            }
            catch
            {
                throw;

            }
        }

        public string GetContentType(string filePath)
        {

            string contentType = "application/octet-stream"; // Default content type
            string extension = Path.GetExtension(filePath).ToLowerInvariant();

            switch (extension)
            {
                case ".jpg":
                case ".jpeg":
                    contentType = "image/jpeg";
                    break;
                case ".png":
                    contentType = "image/png";
                    break;
                case ".gif":
                    contentType = "image/gif";
                    break;
                case ".pdf":
                    contentType = "application/pdf";
                    break;

            }

            return contentType;
        }

        public bool ApproveInvoice(int timeSheetId)
        {
            Timesheet? timesheet = _adminRepo.GetTimesheetById(timeSheetId);
            if (timesheet != null)
            {
                timesheet.Status = true;
                return _adminRepo.UpdateTimesheet(timesheet);
            }
            return false;
        }

        public bool UpdateInvoiceSheetData(List<SheetData> sheetData)
        {
            List<TimesheetDetail> timesheetDetailsUpdate = new();
            foreach (SheetData sheet in sheetData)
            {
                TimesheetDetail timesheetDetail = _adminRepo.GetTimesheetDetailById(sheet.TimesheetDetailId);
                timesheetDetail.ShiftHours = (int)sheet.TotalHours;
                timesheetDetail.Housecall = sheet.Housecall;
                timesheetDetail.IsWeekend = new BitArray(1, sheet.IsWeekend);
                timesheetDetail.PhoneConsult = sheet.PhoneConsult;
                timesheetDetailsUpdate.Add(timesheetDetail);
            }
            return _adminRepo.UpdateRangeTimesheetDetail(timesheetDetailsUpdate);
        }

        public InvoiceReciept GetInvoiceReceiptAdmin(int timeSheetId)
        {
            Timesheet? timesheet = _adminRepo.GetTimesheetById(timeSheetId);
            IEnumerable<TimesheetReimbursement> data = _adminRepo.GetTimesheetReimbursementByTimeSheetId(timesheet.TimesheetId);
            InvoiceReciept invoiceReceipt = new()
            {
                FirstDate = (DateOnly)timesheet.Startdate,
                LastDate = (DateOnly)timesheet.Enddate,
                TimeSheetId = timesheet.TimesheetId,
                ReimbursementData = data
            };
            return invoiceReceipt;
        }

        public InvocingViewModel GetInvoiceSheetDataAdmin(int timeSheetId)
        {
            Timesheet? timesheet = _adminRepo.GetTimesheetById(timeSheetId);

            InvocingViewModel invoice = new()
            {
                Timesheets = _adminRepo.GetTimeSheetData(timesheet.TimesheetId, timesheet.PhysicianId),
                Payrate = GetPayrateByPhysicianId(timesheet.PhysicianId)
            };

            decimal shiftHours = 0;
            int weekend = 0;
            int housecall = 0;
            int phoneconsult = 0;
            foreach (TimeSheetDetailVM data in invoice.Timesheets)
            {
                shiftHours += (decimal)data.ShiftHours;
                if ((bool)data.IsWeekend) weekend += 1;
                housecall += (int)data.Housecall;
                phoneconsult += (int)data.PhoneConsult;
            }

            invoice.TotalShiftHours = shiftHours * (decimal)invoice.Payrate.Shift;
            invoice.TotalWeekend = weekend * (decimal)invoice.Payrate.NightShiftWeekend;
            invoice.TotalHouseCall = housecall * (decimal)invoice.Payrate.Housecall;
            invoice.TotalPhoneConsult = phoneconsult * (decimal)invoice.Payrate.Phoneconsult;
            invoice.Total = invoice.TotalShiftHours + invoice.TotalWeekend + invoice.TotalHouseCall + invoice.TotalPhoneConsult;
            return invoice;
        }

        public List<SelectListItem>? GetPhysicians(string v1, string v2)
        {
            List<SelectListItem> physicianList = new();
            IEnumerable<Physician> physicians = _adminRepo.GetAllPhysician();

            physicianList.Add(new SelectListItem
            {
                Text = v1,
                Value = v2
            });
            foreach (Physician physician in physicians)
            {
                physicianList.Add(new SelectListItem
                {
                    Text = physician.FirstName + " " + physician.LastName,
                    Value = physician.PhysicianId.ToString()
                });
            }
            return physicianList;
        }

        public InvocingViewModel IsInvoiceFinalizedAndApproved(int providerId, DateOnly firstDate, DateOnly lastDate)
        {
            InvocingViewModel invoice = new();
            Timesheet? timesheet = _adminRepo.GetTimesheetByDate(firstDate, lastDate, providerId);
            if (timesheet == null)
            {
                Physician physician = _adminRepo.GetPhyByPhysicianId(providerId);
                invoice.IsSheetFinalized = false;
                invoice.PhysicianName = physician.FirstName + " " + physician.LastName;
            }
            else
            {
                if (timesheet.IsFinalized[0])
                {
                    if ((bool)timesheet.Status)
                    {
                        invoice.IsSheetFinalized = true;
                        invoice.IsSheetApproved = true;
                        invoice.TimesheetDetails = _adminRepo.GetTimeSheetDetailStaticData(timesheet.TimesheetId);
                        invoice.TimesheetReimbursements = _adminRepo.GetTimesheetReimbursementByTimeSheetId(timesheet.TimesheetId);
                    }
                    else
                    {
                        invoice.IsSheetFinalized = true;
                        invoice.IsSheetApproved = false;
                        invoice.Timesheet = timesheet;
                    }

                }
                else
                {
                    Physician physician = _adminRepo.GetPhyByPhysicianId(providerId);
                    invoice.IsSheetFinalized = false;
                    invoice.PhysicianName = physician.FirstName + " " + physician.LastName;

                }
            }
            return invoice;
        }

        public CreateProviderAccountViewModel GetPhysicianDetails(int physicianId)
        {
            var regions = _adminRepo.GetRegionTable();
            var physicianRegion = _adminRepo.GetSelectedPhysicianRegionByPhysicianId(physicianId);
            Physician physician = _adminRepo.GetPhyByPhysicianId(physicianId);
            CreateProviderAccountViewModel model = new CreateProviderAccountViewModel()
            {
                PhysicianId = physicianId,
                UserName = physician.FirstName + "_" + physician.LastName,
                FirstName = physician.FirstName,
                LastName = physician.LastName,
                Email = physician.Email,
                Phone = physician.Mobile,
                Address1 = physician.Address1,
                Address2 = physician.Address2,
                City = physician.City,
                State = "Gujarat",
                Zip = physician.Zip,
                MailingPhone = physician.AltPhone,
                AdminNotes = physician.AdminNotes,
                BussinessName = physician.BusinessName,
                BussinessWebsite = physician.BusinessWebsite,
                ConfirmEmail = physician.SyncEmailAddress,
                Role = "Physician",
                Region = regions,
                PhysicianRegions = physicianRegion,
            };
            return model;
        }
    }
}
