using MyDTO.MyContabilidad;
using Newtonsoft.Json;

namespace MyDTO.MyContabilidad.Test
{
    public class AddTipoAsientoDTO_Should
    {
        [Fact]
        public void Valid_Creation()
        {
            var tipoAsiento = new AddTipoAsientoDTO()
            {
                Abreviatura = "test",
                Descripcion = "my description",
                UserName = "userTest"
            };

            Assert.Equal("test", tipoAsiento.Abreviatura);
            Assert.Equal("my description", tipoAsiento.Descripcion);
            Assert.Equal("userTest", tipoAsiento.UserName);
        }

        [Fact]
        public void Valid_Deserialization()
        {
            var tipoAsientoJson = "{\"Abreviatura\":\"test\",\"Descripcion\":\"my description\",\"UserName\":\"userTest\"}";

            var expectedObject = JsonConvert.DeserializeObject<AddTipoAsientoDTO>(tipoAsientoJson);

            Assert.Equal("test", expectedObject.Abreviatura);
            Assert.Equal("my description", expectedObject.Descripcion);
            Assert.Equal("userTest", expectedObject.UserName);
        }

        [Fact]
        public void Valid_Serialization()
        {
            var tipoAsiento = new AddTipoAsientoDTO()
            {
                Descripcion = "my description",
                Abreviatura = "test",
                UserName = "userTest"
            };

            var tipoAsientoJson = JsonConvert.SerializeObject(tipoAsiento);
            var expectedJson = "{\"Descripcion\":\"my description\",\"Abreviatura\":\"test\",\"UserName\":\"userTest\"}";

            Assert.Equal(expectedJson, tipoAsientoJson);
        }
    }
}
