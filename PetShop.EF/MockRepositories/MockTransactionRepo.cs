using PetShop.EF.Repositories;
using PetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.EF.MockRepositories
{
    internal class MockTransactionRepo : IEntityRepo<Transaction>
    {
        private List<Transaction> _transactions = new List<Transaction>
        {
            new Transaction(){ID = 1, CustomerID = 1,EmployeeID=1,PetID=1,PetPrice=300,PetFoodID=1,PetFoodQty=3,PetFoodPrice=15,TotalPrice=330},
            new Transaction(){ID = 2, CustomerID = 2,EmployeeID=1,PetID=2,PetPrice=50,PetFoodID=3,PetFoodQty=5,PetFoodPrice=5,TotalPrice=70},
        };
        public Task Create(Transaction entity)
        {

            _transactions.Add(entity);
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {

            var foundTransaction = _transactions.SingleOrDefault(transaction => transaction.ID == id);
            if (foundTransaction is null)
                return Task.CompletedTask;

            _transactions.Remove(foundTransaction);
            return Task.CompletedTask;
        }

        public List<Transaction> GetAll()
        {
            return _transactions;
        }

        public Transaction? GetById(int id)
        {
            return _transactions.SingleOrDefault(transaction => transaction.ID == id);
        }

        public Task Update(int id, Transaction entity)
        {
            var foundTransaction = _transactions.SingleOrDefault(transaction => transaction.ID == id);
            if (foundTransaction is null)
                return Task.CompletedTask;

            foundTransaction.Date = entity.Date;
            foundTransaction.CustomerID = entity.CustomerID;
            foundTransaction.EmployeeID = entity.EmployeeID;
            foundTransaction.PetID = entity.PetID;
            foundTransaction.PetPrice = entity.PetPrice;
            foundTransaction.PetFoodID = entity.PetFoodID;
            foundTransaction.PetFoodQty = entity.PetFoodQty;
            foundTransaction.PetFoodPrice = entity.PetFoodPrice;
            foundTransaction.TotalPrice = entity.TotalPrice;
            return Task.CompletedTask;
        }
    }
}
