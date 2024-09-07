using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncEntity
{
    public class DataInitializer
    {
        private readonly DataContext _db;
        public DataInitializer(DataContext db) 
        {
            _db = db;
        }
        public async Task Run()
        {
            await _db.Database.EnsureDeletedAsync();
            await _db.Database.EnsureCreatedAsync();
            var total = 1000000;
            for (int i = 0; i < total; i++)
            {
                _db.Suppliers.Add(new Supplier 
                {
                    Name = $"P{(i+total)}"
                });
                
                _db.Customers.Add(new Customer 
                {
                    Name = $"C{(i+total)}"
             
                });
            }
            await _db.SaveChangesAsync();
        }
    }
}
