using PetShop.EF.Context;
using PetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.EF.Repositories
{
    internal class TransactionRepo : IEntityRepo<Transaction>
    {
        public async Task Create(Transaction entity)
        {
            using var context = new PetShopContext();
            context.Transactions.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            using var context = new PetShopContext();
            var foundTransaction = context.Transactions.SingleOrDefault(transaction => transaction.ID == id);
            if (foundTransaction is null)
                return;

            context.Transactions.Remove(foundTransaction);
            await context.SaveChangesAsync();
        }

        public List<Transaction> GetAll()
        {
            using var context = new PetShopContext();
            return context.Transactions.ToList();
        }

        public Transaction? GetById(int id)
        {
            using var context = new PetShopContext();
            return context.Transactions.Where(transaction => transaction.ID == id).SingleOrDefault();
        }

        public async Task Update(int id, Transaction entity)
        {
            using var context = new PetShopContext();
            var foundTransaction = context.Transactions.SingleOrDefault(transaction => transaction.ID == id);
            if (foundTransaction is null)
                return;

            //TODO:For this Im not sure
            foundTransaction.Date=entity.Date;
            foundTransaction.CustomerID = entity.CustomerID;
            foundTransaction.EmployeeID = entity.EmployeeID;
            foundTransaction.PetID=entity.PetID;
            foundTransaction.PetPrice=entity.PetPrice;
            foundTransaction.PetFoodID=entity.PetFoodID;
            foundTransaction.PetFoodQty=entity.PetFoodQty;
            foundTransaction.PetFoodPrice=entity.PetFoodPrice;
            foundTransaction.TotalPrice=entity.TotalPrice;
            await context.SaveChangesAsync();
        }
    }
}
