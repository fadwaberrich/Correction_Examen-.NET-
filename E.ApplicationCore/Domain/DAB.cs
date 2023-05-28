using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.ApplicationCore.Domain
{
    public class DAB
    {

        public string DABId { get; set; }
        public string Localisation { get; set; }
        public virtual IList<Transaction> Transactions { get; set; }
    }
}
