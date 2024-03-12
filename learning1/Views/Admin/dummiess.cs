


//using Microsoft.EntityFrameworkCore;

//public ViewNotesViewModel GetViewNotes(int requestId)
//{
//    var requestStatus = _context.RequestStatusLogs.FirstOrDefault(r => r.RequestId == requestId);
//    var requestNotes = _context.RequestNotes.Where(r => r.RequestId == requestId).Select(r => new { r.RequestId, r.AdminNotes, r.PhysicianNotes }).ToList();


//    if (requestStatus?.PhysicianId != null)
//    {
//        var physicianName = _context.Physicians.Find(requestStatus.PhysicianId);

//        var model = new ViewNotesViewModel
//        {
//            RequestId = requestId,
//            TransferedNotes = requestStatus.Notes,
//            PhysicianName = physicianName.FirstName + ' ' + physicianName.LastName,
//            CreatedDate = requestStatus.CreatedDate.ToString(),
//            PhysicianNotes = requestNotes.FirstOrDefault()?.PhysicianNotes,
//            AdminNotes = requestNotes.FirstOrDefault()?.AdminNotes,
//        };

//        return model;
//    }
//    else
//    {
//        var model = new ViewNotesViewModel
//        {
//            RequestId = requestId,
//            //TransferedNotes = requestStatus.Notes,
//            //CreatedDate = requestStatus.CreatedDate.ToString(),
//            PhysicianNotes = requestNotes.FirstOrDefault()?.PhysicianNotes,
//            AdminNotes = requestNotes.FirstOrDefault()?.AdminNotes,
//        };

//        return model;
//    }
//    /*Admin Transfered to Dr.Agola on 27 / 09 / 2023 at 9:38:04 AM: test assign*/

//}

//public void SetViewNotes(int requestId, ViewNotesViewModel model)
//{
//    //var temp = from rn in _context.RequestNotes
//    //           join rs in _context.RequestStatusLogs on rn.RequestId equals rs.RequestId into rgroup
//    //           from r in rgroup
//    //           select new ;
//    //var AdminId = _context.RequestStatusLogs.Where(x => x.RequestId == requestId).Select(x=>x.AdminId)?.FirstOrDefault();
//    var ExistingRequestId = _context.RequestNotes.Where(x => x.RequestId == requestId).Select(x => x.RequestId).FirstOrDefault();
//    if (ExistingRequestId != 0)
//    {
//        RequestNote requestNote = _context.RequestNotes.Where(X => X.RequestId == requestId)?.FirstOrDefault();

//        requestNote.AdminNotes = model.NewAdminNotes;
//        requestNote.CreatedBy = "Harimati";
//        requestNote.CreatedDate = DateTime.Now;

//        _context.Update(requestNote);
//        _context.SaveChanges();
//    }
//    else
//    {
//        RequestNote requestNote = new RequestNote()
//        {
//            RequestId = requestId,
//            AdminNotes = model.NewAdminNotes,
//            CreatedBy = 2.ToString(), //Because we dont have AdminId right now
//            CreatedDate = DateTime.Now
//        };

//        _context.Add(requestNote);
//        _context.SaveChanges();
//    }
//}

