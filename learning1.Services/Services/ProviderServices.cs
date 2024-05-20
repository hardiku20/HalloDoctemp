using learning1.DBEntities.Models;
using learning1.DBEntities.ViewModel;
using learning1.Repositories.IRepositories;
using learning1.Repositories.Repositories;
using learning1.Services.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.Services.Services
{
    public class ProviderServices : IProviderServices
    {
        private readonly IProviderRepo _providerRepo;

        public ProviderServices(IProviderRepo providerRepo)
        {
            _providerRepo = providerRepo;
        }

        public ProviderDashboardViewModel DisplayProviderDashboard(int PhysicianId)
        {
            var Casetags = _providerRepo.DisplayCasetags();
            var Regions = _providerRepo.DisplayRegions();
            var Count = _providerRepo.SetCount(PhysicianId);
            var temp = _providerRepo.DisplayProviderDashboardRepo(PhysicianId).
                Select(x => new ProviderTableViewModel
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

            ProviderDashboardViewModel model = new ProviderDashboardViewModel()
            {
                TableViewModel = temp,
                CancellationReason = Casetags,
                Region = Regions,
                RequestCount = Count,
            };
            return model;
        }

        public ProviderDashboardViewModel RenderActiveStateData(int status1, int status2, int physicianId, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
        {
            var model = _providerRepo.RenderToActiveState(status1, status2, physicianId, page, pageSize, patientName, regionName, requestType);
            return model;
        }

        public ProviderDashboardViewModel RenderConcludeStateData(int status, int physicianId, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
        {
            var model = _providerRepo.RenderConcludeState(status, physicianId, page, pageSize, patientName, regionName, requestType);
            return model;
        }

        public ProviderDashboardViewModel RenderNewStateData(int status, int physicianId, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
        {
            var model = _providerRepo.RenderNewState(status, physicianId, page, pageSize, patientName, regionName, requestType);
            return model;
        }

        public ProviderDashboardViewModel RenderPendingStateData(int status, int physicianId, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
        {
            var model = _providerRepo.RenderPendingState(status, physicianId, page, pageSize, patientName, regionName, requestType);
            return model;
        }







        public ViewCaseViewModel DisplayViewCase(int requestId)
        {
            var model = _providerRepo.DisplayViewCaseRepo(requestId);
            return model;
        }

        public void acceptCase(int requestId)
        {
            _providerRepo.acceptcase(requestId);
        }

        public ViewUploadViewModel GetviewUploads(int requestId)
        {
            var model = _providerRepo.FetchViewUploads(requestId);
            return model;
        }

        public void InsertviewUploads(ViewUploadViewModel model, int requestId)
        {
            _providerRepo.Uploaddocuments(model, requestId);
        }

        public void GetTransferCaseData(ProviderDashboardViewModel model, int requestId)
        {
            _providerRepo.TransferCaseRepo(model, requestId);
        }
        public SendOrderViewModel GetOrderdetails()
        {
            var Profession = _providerRepo.DisplayProfession();
            SendOrderViewModel model = new SendOrderViewModel()
            {
                Profession = Profession,
            };
            return model;
        }

        public List<string> GetBusinessByProfession(string professionName)
        {
            var BusinessName = _providerRepo.GetBusinessByProfessionName(professionName);
            return BusinessName;
        }

        public SendOrderViewModel GetDetailsByBusiness(string businessName)
        {
            var Orderdetails = _providerRepo.GetOrder(businessName);
            return Orderdetails;
        }

        public void InsertOrderDetails(SendOrderViewModel model)
        {
            _providerRepo.OrderDetailRepo(model);
        }

        public ProviderProfileViewModel GetProviderProfileData(int physicianId)
        {
            var model = _providerRepo.GetProviderProfileRepo(physicianId);
            return model;
        }

        public ViewNotesViewModel GetNotesById(int requestId)
        {
            return _providerRepo.GetNoteDataById(requestId);
        }

        public void SetNotesById(ViewNotesViewModel model)
        {
            RequestNote requestNote = _providerRepo.GetRquestNoteById(model.RequestId);
            if (requestNote != null)
            {
                requestNote.AdminNotes = model.AdminNotes;
                requestNote.PhysicianNotes = model.AdditionalNotes;
                requestNote.ModifiedBy = "Physician";
                requestNote.ModifiedDate = DateTime.Now;

                _providerRepo.UpdateNotes(requestNote);
            }
            else
            {
                RequestNote requestnote = new RequestNote()
                {
                    RequestId = model.RequestId,
                    PhysicianNotes = model.AdditionalNotes,
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now

                };

                _providerRepo.AddRequestNote(requestnote);

            }


        }

        public int LoginMethod(string email, string password)
        {
            int providerId = _providerRepo.LoginMethodRepo(email, password);
            return providerId;
        }

        public Dictionary<int, string> GetPhysicianRegionList(int physicianId)
        {
            return _providerRepo.GetPhysicianRegionList(physicianId);
        }

        public List<ShiftDetail> GetProviderScheduleData(int physicianId, int regionId)
        {
            return _providerRepo.GetShiftDetailData(physicianId, regionId);
        }

        public bool SetCreateNewShiftData(ProviderSchedulingViewModel model)
        {
            try
            {
                //DateTime combinedDate = new DateTime(year, month, date); // Combine year, month, and date
                var date = model.ShiftDate;
                DateTime shiftDate = date.ToDateTime(TimeOnly.MinValue); // Convert to DateOnly


                var regionId = model.regionId;


                Shift shift = new()
                {
                    PhysicianId = model.PhysicianId,
                    StartDate = (DateOnly)model.ShiftDate, //same ???????
                    IsRepeat = model.IsRepeat,
                    //WeekDays -- character -- no. of week days???? 
                    RepeatUpto = model.RepeatEnd,
                    //CreatedBy = vmodel.AdminId.ToString(),
                    CreatedBy = "f1ae5ca9-bc3c-4b9b-bd2a-22ff31271182",

                    CreatedDate = DateTime.Now
                };

                _providerRepo.AddShift(shift);


                if (model.IsRepeat)
                {

                    List<DateOnly> days = new();
                    days.Add(model.ShiftDate);

                    var dayListString = model.SelectedDays;
                    var daylist = dayListString.Split(',').Select(int.Parse).ToList();

                    for (var i = 0; i < model.RepeatEnd; i++)
                    {
                        for (int j = 0; j < daylist.Count; j++)
                        {

                            int temp;
                            switch (daylist[j])
                            {
                                case 1:
                                    temp = (int)DayOfWeek.Sunday - (int)DateTime.Parse(days.Last().ToString()).DayOfWeek;
                                    break;
                                case 2:
                                    temp = (int)DayOfWeek.Monday - (int)DateTime.Parse(days.Last().ToString()).DayOfWeek;
                                    break;
                                case 3:
                                    temp = (int)DayOfWeek.Tuesday - (int)DateTime.Parse(days.Last().ToString()).DayOfWeek;
                                    break;
                                case 4:
                                    temp = (int)DayOfWeek.Wednesday - (int)DateTime.Parse(days.Last().ToString()).DayOfWeek;
                                    break;
                                case 5:
                                    temp = (int)DayOfWeek.Thursday - (int)DateTime.Parse(days.Last().ToString()).DayOfWeek;
                                    break;
                                case 6:
                                    temp = (int)DayOfWeek.Friday - (int)DateTime.Parse(days.Last().ToString()).DayOfWeek;
                                    break;
                                default:
                                    temp = (int)DayOfWeek.Saturday - (int)DateTime.Parse(days.Last().ToString()).DayOfWeek;
                                    break;
                            }
                            if (temp <= 0)
                            {
                                temp += 7;
                            }
                            days.Add(days.Last().AddDays(temp));
                        }

                    }

                    foreach (var day in days)
                    {
                        DateTime dayy = day.ToDateTime(TimeOnly.FromTimeSpan(DateTime.Now.TimeOfDay));

                        ShiftDetail shiftDetail1 = new()
                        {
                            ShiftId = shift.ShiftId,
                            ShiftDate = dayy,
                            StartTime = model.StartTime,
                            EndTime = model.EndTime,
                            IsDeleted = false,
                            RegionId = regionId,
                            Status = 1
                            //Status

                        };

                        //ShiftDetail.Add(shiftDetail1);
                        _providerRepo.AddShiftDetail(shiftDetail1);

                    }

                    _providerRepo.SaveRecentChanges();
                }
                else
                {
                    ShiftDetail shiftDetail = new()
                    {
                        ShiftId = shift.ShiftId,
                        ShiftDate = shiftDate,
                        StartTime = model.StartTime,
                        EndTime = model.EndTime,
                        IsDeleted = false,
                        RegionId = regionId,
                        Status = 1
                        //Status

                    };

                    _providerRepo.AddShiftDetail(shiftDetail);
                    _providerRepo.SaveRecentChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public UserInfoViewModel CheckValidUserWithRole(string email, string password)
        {
            var model = _providerRepo.GetRoleByAspNetId(email, password);
            return model;
        }

        public Physician GetPhysicianByEmail(string email, string password)
        {
            return _providerRepo.GetProviderByMailRepo(email, password);
        }

        public void clickHousecall(int requestId)
        {
            _providerRepo.HousecallRepo(requestId);
        }

        public void SendAgreement(int requestId)
        {
            _providerRepo.AgreementMails(requestId);
        }

        public void clickConsult(int requestId)
        {
            _providerRepo.ConsultRepo(requestId);
        }

        public CloseCaseViewModel GetConcludeCare(int requestId)
        {
            return _providerRepo.ConcludeCareRepo(requestId);
        }

        public bool UploadConcludeDocument(IFormFile fileforConcludeCare, int reqId)
        {

            try
            {
                var fileName = reqId + "-" + Path.GetFileName(fileforConcludeCare.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files", "PatientDocs", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    fileforConcludeCare.CopyTo(stream);
                }
                RequestWiseFile requestwisefile = new()
                {
                    FileName = fileName,
                    RequestId = reqId,
                    CreatedDate = DateTime.Now,
                };

                _providerRepo.AddRequestWiseFile(requestwisefile);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ConcludeCare(int RequestId, CloseCaseViewModel modal)
        {
            try
            {
                Request req = _providerRepo.GetRequestById(RequestId);
                req.Status = 8;
                _providerRepo.UpdateRequest(req);
                DateTime date = DateTime.Now;
                RequestStatusLog requestStatusLog = new RequestStatusLog()
                {
                    RequestId = req.RequestId,
                    Status = req.Status,
                    PhysicianId = req.PhysicianId,
                    CreatedDate = date,
                    Notes = "The case has been conclude by physician on " + date.ToString("f") + " with additional notes:" + modal.ProviderNotes
                };

                _providerRepo.AddRequestStatusLog(requestStatusLog);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public EncounterFormViewModel GetEncounterform(int requestId)
        {
            return _providerRepo.GetEncounterformRepo(requestId);
        }

        public void EncounterforData(EncounterFormViewModel model)
        {
            _providerRepo.EncounterFormRepo(model);
        }

        public void ConcludeCareService(int requestId)
        {
            _providerRepo.ConcludeCareStatusRepo(requestId);
        }

        public IEnumerable<TimeSheetDetailVM> CreateInvoiceSheet(DateOnly firstDate, DateOnly lastDate)
        {
            int PhysicianId = 21;
            Timesheet? timesheet = _providerRepo.GetTimesheetByDate(firstDate, lastDate,PhysicianId);
            if (timesheet == null)
            {
                Timesheet timesheet1 = new()
                {
                    PhysicianId = PhysicianId,
                    Startdate = firstDate,
                    Enddate = lastDate,
                    IsFinalized = new BitArray(1, false),
                    Status = false
                };
                Timesheet? createdSheet = _providerRepo.CreateTimeSheet(timesheet1);

                List<TimesheetDetail> timesheetDetailsInsert = new();
                DateOnly date = firstDate;
                while (date <= lastDate)
                {
                    timesheetDetailsInsert.Add(new TimesheetDetail()
                    {
                        TimesheetId = createdSheet.TimesheetId,
                        Shiftdate = date,
                        ShiftHours = (int?)_providerRepo.GetTotalShiftHours(date, PhysicianId),
                        Housecall = null,
                        PhoneConsult = null,
                        IsWeekend = new BitArray(1, false)
                    });

                    date = date.AddDays(1);
                }

                _providerRepo.CreateRangeTimesheetDetail(timesheetDetailsInsert);

                return _providerRepo.GetTimeSheetData(createdSheet.TimesheetId, PhysicianId);

            }

            return _providerRepo.GetTimeSheetData(timesheet.TimesheetId, PhysicianId);
        }

        public bool DeleteTimesheetReimbursement(int timeSheetId, DateOnly shiftDate)
        {
            TimesheetReimbursement? data = _providerRepo.GetTimesheetReimbursementByDateAndTimeSheetId(shiftDate, timeSheetId);
            if (data == null) return false;
            DeleteInvoiceReceipt(data.Bill);
            return _providerRepo.DeleteTimesheetReimbursement(data);
        }

        private void DeleteInvoiceReceipt(string fileName)
        {
            string exitingFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Invoice", fileName);
            if (File.Exists(exitingFile))
            {
                System.IO.File.Delete(exitingFile);

            }

        }

        public void SaveInvoiceReceipt(IFormFile file, string fileName)
        {
            //var filepath = Path.Combine(_hostingEnvironment.ContentRootPath, @"wwwroot\Invoice", fileName);
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Invoice", fileName);
            using var filestream = new FileStream(filepath, FileMode.Create);
            file.CopyTo(filestream);
        }

        public bool FinalizeInvoice(DateOnly firstDate, DateOnly lastDate)
        {
            int PhysicianId = 21;
            Timesheet? timesheet = _providerRepo.GetTimesheetByDate(firstDate, lastDate, PhysicianId);
            if (timesheet != null)
            {
                timesheet.IsFinalized = new BitArray(1, true);
                return _providerRepo.UpdateTimesheet(timesheet);
            }
            return false;
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

        public InvocingViewModel GetInvoiceData(DateOnly firstDate, DateOnly lastDate, string aspNetId)
        {
            int PhysicianId = 21;
            Timesheet? timesheet = _providerRepo.GetTimesheetByDate(firstDate, lastDate,PhysicianId);

            learning1.DBEntities.ViewModel.InvocingViewModel invoice = new();
            if (timesheet != null)
            {
                invoice.TimesheetDetails = _providerRepo.GetTimeSheetDetailStaticData(timesheet.TimesheetId);
                invoice.TimesheetReimbursements = _providerRepo.GetTimesheetReimbursementByTimeSheetId(timesheet.TimesheetId);
                invoice.IsSheetFinalized = IsInvoiceSheetFinalize(firstDate, lastDate, aspNetId);

            }
            return invoice;
        }

        public InvoiceReciept GetInvoiceReceipt(DateOnly firstDate, DateOnly lastDate)
        {
            int PhysicianId = 21;
            Timesheet? timesheet = _providerRepo.GetTimesheetByDate(firstDate, lastDate, PhysicianId);
            IEnumerable<TimesheetReimbursement> data = _providerRepo.GetTimesheetReimbursementByTimeSheetId(timesheet.TimesheetId);
            learning1.DBEntities.ViewModel.InvoiceReciept invoiceReceipt = new()
            {
                FirstDate = (DateOnly)timesheet.Startdate,
                LastDate = (DateOnly)timesheet.Enddate,
                TimeSheetId = timesheet.TimesheetId,
                ReimbursementData = data
            };
            return invoiceReceipt;
        }

        public bool UpdateInvoiceSheetData(List<SheetData> sheetData)
        {
            List<TimesheetDetail> timesheetDetailsUpdate = new();
            foreach (SheetData sheet in sheetData)
            {
                TimesheetDetail timesheetDetail = _providerRepo.GetTimesheetDetailById(sheet.TimesheetDetailId);
                timesheetDetail.ShiftHours = (int)sheet.TotalHours;
                timesheetDetail.Housecall = sheet.Housecall;
                timesheetDetail.IsWeekend = new BitArray(1, sheet.IsWeekend);
                timesheetDetail.PhoneConsult = sheet.PhoneConsult;
                timesheetDetailsUpdate.Add(timesheetDetail);
            }
            return _providerRepo.UpdateRangeTimesheetDetail(timesheetDetailsUpdate);
        }


        public bool IsInvoiceSheetFinalize(DateOnly firstDate, DateOnly lastDate, string aspNetId)
        {
            int PhysicianId = 21;
            Timesheet? timesheet = _providerRepo.GetTimesheetByDate(firstDate, lastDate, PhysicianId);
            if (timesheet == null) return false;
            if (timesheet.IsFinalized == null) return false;
            return timesheet.IsFinalized[0];
        }



        public bool UploadReceipt(TimesheetReimbursementVM receipt)
        {
            TimesheetReimbursement? data = _providerRepo.GetTimesheetReimbursementByDateAndTimeSheetId(receipt.ShiftDate, receipt.TimesheetId);
            if (data == null && receipt.ReceiptDoc != null)
            {
                TimesheetReimbursement receipt1 = new()
                {
                    TimesheetId = receipt.TimesheetId,
                    Item = receipt.Item,
                    Amount = receipt.Amount,
                    ShiftDate = receipt.ShiftDate
                };

                TimesheetReimbursement? createdReceipt = _providerRepo.CreateTimesheetReimbursement(receipt1);

                string fileName = createdReceipt.TimesheetReimbursementId + "_" + receipt.ReceiptDoc.FileName;
                SaveInvoiceReceipt(receipt.ReceiptDoc, fileName);

                createdReceipt.Bill = fileName;
                _providerRepo.UpdateTimesheetReimbursement(createdReceipt);
                return true;
            }
            return false;
        }
    }
}
