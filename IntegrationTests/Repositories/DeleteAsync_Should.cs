using ApplicationCore.Entities.CompareAggregate;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Builders;
using Xunit;
using Xunit.Abstractions;

namespace IntegrationTests.Repositories
{
    public class DeleteAsync_Should
    {
        private readonly AlfonsoContext _alfonsoContext;
        private readonly EfRepository<Compare> _compareRepository;
        private readonly EfRepository<CompareItem> _compareItemRepository;

        private CompareBuilder CompareBuilder { get; } = new CompareBuilder();
        private readonly ITestOutputHelper _output;

        public DeleteAsync_Should(ITestOutputHelper output)
        {
            _output = output;
            var dbOptions = new DbContextOptionsBuilder<AlfonsoContext>()
                .UseInMemoryDatabase(databaseName: "Alfonso")
                .Options;

            _alfonsoContext = new AlfonsoContext(dbOptions);
            _compareRepository = new EfRepository<Compare>(_alfonsoContext);
            _compareItemRepository = new EfRepository<CompareItem>(_alfonsoContext);
        }

        [Fact]
        public async Task DeleteItemFromCompare()
        {
            var existingCompare = CompareBuilder.WithOneCompareItem();
            _alfonsoContext.Add(existingCompare);
            _alfonsoContext.SaveChanges();

            await _compareItemRepository.DeleteAsync(existingCompare.Items.FirstOrDefault());
            _alfonsoContext.SaveChanges();

            var compareFromDb = _compareRepository.GetById(CompareBuilder.CompareId);

            Assert.Equal(0, compareFromDb.Items.Count);
        }


    }
}
