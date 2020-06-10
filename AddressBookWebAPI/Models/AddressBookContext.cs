using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookWebAPI.Models
{
    public class AddressBookContext: DbContext
    {
        public AddressBookContext(DbContextOptions<AddressBookContext> options):base(options)
        {
                    
        }
        
        public DbSet<AddressBook> addressBooks { get; set; }
    }
}
