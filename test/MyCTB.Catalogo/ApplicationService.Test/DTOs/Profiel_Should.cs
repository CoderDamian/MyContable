using AutoMapper;
using MyDTO.MyContabilidad;

namespace MyDTO.MyContabilidad.Test
{
    public class Profiel_Should
    {
        [Fact]
        void Be_Valid_Cuenta_Profile()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CuentaProfile>());

            config.AssertConfigurationIsValid();
        }

        [Fact]
        void Be_Valid_CentroCosto_Profile()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CentroCostoProfile>());

            config.AssertConfigurationIsValid();
        }

        [Fact]
        void Be_Valid_TipoAsiento_Profile()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<TipoAsientoProfile>());

            config.AssertConfigurationIsValid();
        }
    }
}