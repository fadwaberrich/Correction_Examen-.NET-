using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.ApplicationCore.Domain
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public double Montant { get; set; }
        public string CompteFk { get; set; }
        public string DabFK { get; set; }
        public virtual Compte Compte { get; set; }
        public virtual DAB DAB { get; set; }
    }
}
