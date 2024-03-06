using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.DBEntities.ViewModel
{
    public class ViewUploadViewModel
    {
        public string? UserName { get; set; }
        public int? RequestId { get; set; }

        public IFormFile? formFile { get; set; }

        public List<AdminDocumentViewModel>? DocumentsViewModel { get; set; }
    }

    public class AdminDocumentViewModel
    {
        public string? UserName { get; set; }
        public string? FileName { get; set;}

        public DateTime? CreatedDate { get; set; }
    }
}
