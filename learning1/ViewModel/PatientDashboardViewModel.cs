﻿namespace learning1.ViewModel
{
    public class PatientDashboardViewModel
    {
        public string UserName { get; set; }
        public List<PatientHistoryViewModel> HistoryViewModel { get; set; }
    }
    public class PatientHistoryViewModel
    {
        public int RequestId { get; set; }
        public DateTime CreatedDate { get; set; }
        public short Status { get; set; }
        //public string Document {get; set;}

        public int fileCount { get; set; }
    }
}
