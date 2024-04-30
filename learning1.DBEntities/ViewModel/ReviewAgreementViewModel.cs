using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.DBEntities.ViewModel
{
    public class ReviewAgreementViewModel
    {
        public int ReqId { get; set; }
        public bool? isAgreed { get; set; }
        public string? userName { get; set; }
        [StringLength(100)]
        public string Notes { get; set; }
    }
}
