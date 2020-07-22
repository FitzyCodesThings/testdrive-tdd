using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestDriveTDD.Core.Entities;

namespace TestDriveTDD.Core.Interfaces
{
    public interface IDealerService
    {
        public Task<Dealer> AddDealerAsync(Dealer dealer);
        public Task<Dealer> GetDealerByIdAsync(Guid id);
        public Task<List<Dealer>> GetDealersAsync();
        public Task<Dealer> UpdateDealerAsync(Dealer dealer);
        public Task<Dealer> DeleteDealerAsync(Dealer dealer);

    }
}
