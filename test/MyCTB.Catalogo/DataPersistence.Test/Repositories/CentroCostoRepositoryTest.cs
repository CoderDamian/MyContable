using MyCTB.Catalogo.DataPersistence;

namespace DataPersistence.Test
{
    public class CentroCostoRepositoryTest
    {
        [Fact]
        public async Task Be_Valid_To_Read_Data()
        {
            using var myDbContext = new MyDbContext();

            var uow = new UnitOfWork(myDbContext);

            var centroCosto = await uow.CentroCostoRepository
                .GetAllAsync();

            Assert.NotNull(centroCosto);
        }
    }
}
