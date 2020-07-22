using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestDriveTDD.Core.Entities;

namespace TestDriveTDD.Persistence
{
    public partial class AppDbContext
    {
        public DbSet<Dealer> Dealers { get; set; }

        public async Task<Dealer> CreateDealerAsync(Dealer dealer)
        {
            EntityEntry<Dealer> dealerEntry = await this.Dealers.AddAsync(dealer);
            await this.SaveChangesAsync();

            return dealerEntry.Entity;
        }

        public async Task<List<Dealer>> SelectDealersAsync()
        {
            // TODO Add optional predicate for finding specific dealers (.Where())
            return await this.Dealers.ToListAsync();
        }

        public async Task<Dealer> SelectDealerByIdAsync(Guid id)
        {
            return await this.Dealers.FindAsync(id);
        }

        public async Task<Dealer> UpdateDealerAsync(Dealer dealer)
        {
            EntityEntry<Dealer> dealerEntry = this.Dealers.Update(dealer);
            await this.SaveChangesAsync();

            return dealerEntry.Entity;
        }
        public async Task<Dealer> DeleteDealerAsync(Dealer dealer)
        {
            EntityEntry<Dealer> dealerEntry = this.Dealers.Remove(dealer);
            await this.SaveChangesAsync();

            return dealerEntry.Entity;
        }
    }
}
