using E.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace E.ApplicationCore.Interfaces
{
    public interface IServiceTransaction:IService<Transaction>
    {

        double SommeMontant(DAB dab);

        int nbrTransaction(Compte compte);

        IEnumerable<Transaction> GetTransactions(Compte c, DateTime startDate);
    }
}
