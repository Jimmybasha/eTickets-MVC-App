using eTickets.Data.Services.ActorServices;
using eTickets.Data.Services.CinemaServices;
using eTickets.Data.Services.MovieServices;
using eTickets.Data.Services.ProducerServices;

namespace eTickets.Core.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void RegisterProjectServices(this IServiceCollection services)
        {
            // Here i can add the DependyInjection Services instead of Crashing all of it 
            //Into the Program.cs
            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<IProducerService,ProducerService>();
            services.AddScoped<ICinemaService,CinemaService>();
            services.AddScoped<IMovieService,MovieService>();


        }
    }
}
