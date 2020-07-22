using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestDriveTDD.Core.Entities;
using TestDriveTDD.Core.Interfaces;

namespace TestDriveTDD.Application.Services
{
    public class DealerService : IDealerService
    {
        private readonly IAppDbContext appDbContext;

        public DealerService(IAppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Dealer> AddDealerAsync(Dealer dealer)
        {
            throw new NotImplementedException();
        }

        public async Task<Dealer> DeleteDealerAsync(Dealer dealer)
        {
            throw new NotImplementedException();
        }

        public async Task<Dealer> GetDealerByIdAsync(Guid id)
        {
            var dealer = await this.appDbContext.SelectDealerByIdAsync(id);

            if (dealer == null)
                throw new Exception("Dealer not found.");

            return dealer;
        }

        public async Task<List<Dealer>> GetDealersAsync()
        {
            return await this.appDbContext.SelectDealersAsync();
        }

        public async Task<Dealer> UpdateDealerAsync(Dealer dealer)
        {
            throw new NotImplementedException();
        }
    }
}
