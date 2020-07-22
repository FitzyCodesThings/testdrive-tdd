using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestDriveTDD.Core.Entities;

namespace TestDriveTDD.Core.Interfaces
{
    public partial interface IAppDbContext
    {
        public Task<Dealer> CreateDealerAsync(Dealer dealer);
        public Task<Dealer> SelectDealerByIdAsync(Guid id);
        public Task<List<Dealer>> SelectDealersAsync();
        public Task<Dealer> UpdateDealerAsync(Dealer dealer);
        public Task<Dealer> DeleteDealerAsync(Dealer dealer);

    }
}
