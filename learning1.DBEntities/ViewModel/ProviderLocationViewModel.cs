using learning1.DBEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.DBEntities.ViewModel
{
    public class ProviderLocationViewModel
    {

        public IEnumerable<PhysicianLocation>? Physicianlocation { get; set; }

    }
}
