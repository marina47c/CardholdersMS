using AutoMapper;
using CardholderManagementSystem.Controllers;
using CardholderManagementSystem.Data;
using CardholderManagementSystem.DTOs;
using CardholderManagementSystem.Mappings;
using CardholderManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Tests
{
    [TestClass]
    public class CardholdersControllerTests
    {
        private static AppDbContext BuildDbContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;

            return new AppDbContext(options);
        }

        private static IMapper BuildMapper()
        {
            var cfg = new MapperConfiguration(cfg => cfg.AddProfile<CardholdersMappingProfile>());
            return cfg.CreateMapper();
        }

        [TestMethod]
        public async Task GetCardholders_ReturnsPagedResult_WithExpectedCounts()
        {
            // Arrange
            var dbName = Guid.NewGuid().ToString();
            await using var db = BuildDbContext(dbName);

            // seed 55 cardholders
            for (int i = 1; i <= 55; i++)
            {
                db.Cardholders.Add(new Cardholder
                {
                    Id = (uint)i,
                    FirstName = "F" + i,
                    LastName = "L" + i,
                    Address = "Some Street",
                    PhoneNumber = "+3859111111" + i,
                    TransactionCount = 0,
                });
            }
            await db.SaveChangesAsync();

            var mapper = BuildMapper();
            var logger = new LoggerFactory().CreateLogger<CardholdersController>();

            var controller = new CardholdersController(db, mapper, logger);

            int page = 2;
            int pageSize = 20;

            // Act
            var action = await controller.GetCardholders(page, pageSize, CancellationToken.None);

            // Assert
            var ok = action.Result as OkObjectResult;
            Assert.IsNotNull(ok, "Expected OkObjectResult");

            var payload = ok.Value as PagedResponse<CardholderDto>;
            Assert.IsNotNull(payload, "Expected PagedResponse<CardholderDto>");

            Assert.AreEqual(page, payload.Page);
            Assert.AreEqual(pageSize, payload.PageSize);
            Assert.AreEqual(55, payload.TotalCount);
            Assert.AreEqual((int)Math.Ceiling(55 / (double)pageSize), payload.TotalPages);
            Assert.AreEqual(pageSize, payload.Items.Count);

            Assert.AreEqual<uint>(21, payload.Items.First().Id);
        }
    }
}
