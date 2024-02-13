namespace learning1.ViewModel
{
    public class ViewDocumentViewModel
    {
        public string UserName { get; set; }

        public List<PatientDocumentsViewModel> DocumentsViewModel { get; set; }
    }

    public class PatientDocumentsViewModel
    {
        public string FileName { get; set; }
        public string UserName { get; set; } //uploader name
        public DateTime CreatedDate { get; set; }
    }
}
