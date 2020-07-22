using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using TestDriveTDD.Application.Services;
using TestDriveTDD.Core.Entities;
using TestDriveTDD.Core.Interfaces;
using TestDriveTDD.Core.Types;
using Xunit;

namespace TestDriveTDD.Tests
{
    public class DealerServiceTests
    {
        private readonly Mock<IAppDbContext> appDbContextMock;
        private readonly IDealerService dealerService;

        public DealerServiceTests()
        {
            this.appDbContextMock = new Mock<IAppDbContext>();

            this.dealerService = new DealerService(this.appDbContextMock.Object);
        }

        [Fact]
        public async Task GetDealerShouldReturnDealerWhenValidIdProvided()
        {
            // given (arrange)
            Guid validId = Guid.NewGuid();

            DateTime date = DateTime.UtcNow;

            Dealer databaseDealer = new Dealer()
            {
                ID = validId,
                Name = "Bob's Ford Dealer",
                MakeCarried = VehicleMake.Ford,
                DateCreated = date,
                DateUpdated = date
            };

            Dealer expectedDealer = new Dealer()
            {
                ID = validId,
                Name = "Bob's Ford Dealer",
                MakeCarried = VehicleMake.Ford,
                DateCreated = date,
                DateUpdated = date
            };

            this.appDbContextMock.Setup(db =>
                db.SelectDealerByIdAsync(validId))
                    .ReturnsAsync(databaseDealer);

            // when (act)
            Dealer actualDealer = await dealerService.GetDealerByIdAsync(validId);

            // then (assert)
            // 1. actualDealer == expectedDealer
            // 2. Storage was hit once exactly

            actualDealer.Should().BeEquivalentTo(expectedDealer);

            appDbContextMock.Verify(db => db.SelectDealerByIdAsync(validId), Times.Once, "Db context was hit more than once.");

            appDbContextMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetDealerShouldThrowExceptionWhenInvalidIdIsProvided()
        {
            // given
            Guid invalidId = Guid.NewGuid();
            Guid validId = Guid.NewGuid();
            DateTime date = DateTime.UtcNow;

            Dealer databaseDealer = new Dealer()
            {
                ID = validId,
                Name = "Bob's Ford Dealer",
                MakeCarried = VehicleMake.Ford,
                DateCreated = date,
                DateUpdated = date
            };

            this.appDbContextMock.Setup(db =>
                db.SelectDealerByIdAsync(validId))
                    .ReturnsAsync(databaseDealer);

            // when
            Task<Dealer> actualDealerTask = dealerService.GetDealerByIdAsync(invalidId);

            // then
            // 1. Service throws an exception when no Dealer is found
            // 2. No other db calls

            await Assert.ThrowsAnyAsync<Exception>(() => actualDealerTask);

            appDbContextMock.Verify(db => db.SelectDealerByIdAsync(invalidId), Times.Once, "Db context was hit more than once.");

            appDbContextMock.VerifyNoOtherCalls();
        }
    }
}
