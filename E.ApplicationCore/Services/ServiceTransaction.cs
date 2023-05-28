using E.ApplicationCore.Domain;
using E.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.ApplicationCore.Services
{
    public class ServiceTransaction : Service<Transaction>,IServiceTransaction
    {
        public ServiceTransaction(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Transaction> GetTransactions(Compte c, DateTime startDate)
        {
            return GetMany(p => p.Compte.Type == 0 && p.Date.Equals(startDate));
        }

        public int nbrTransaction(Compte compte)
        {
            return compte.Transactions
                .Where(p => (DateTime.Now - p.Date).TotalDays < 7)
                .Count();
        }

        // IList<Transaction> transactions = new List

        public double SommeMontant(DAB dab)
        {
            //return GetMany(p => p.DAB.Equals(dab)).OfType<TransactionTransfert>()
            //   .Sum(p => p.Montant);

            //  return dab.Transactions.OfType<TransactionTransfert>().Sum(p => p.Montant);

            var query = from a in //GetAll().OfType<TransactionTransfert>()
                           // where a.DAB.Equals(dab)
                            dab.Transactions
                        select a.Montant;
            return query.Sum();
        }
    }
}
