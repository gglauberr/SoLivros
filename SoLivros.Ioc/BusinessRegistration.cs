using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SoLivros.Ioc
{
    using SoLivros.BusinessLogic;
    using SoLivros.Abstraction.BusinessLogic;

    public static class BusinessRegistration
    {
        public static IServiceCollection BusinessRegister(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddTransient<ILivroService, LivroService>();
            service.AddTransient<IUserService, UserService>();
            service.AddTransient<IFavoritoService, FavoritoService>();

            return service;
        }
    }
}
