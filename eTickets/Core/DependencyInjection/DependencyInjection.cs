using eTickets.Data.Services.ActorServices;

namespace eTickets.Core.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void RegisterProjectServices(this IServiceCollection services)
        {
            // Here i can add the DependyInjection Files instead of Crashing all of it 
            //Into the Program.cs

            services.AddScoped<IActorService, ActorService>();
        }
    }
}
