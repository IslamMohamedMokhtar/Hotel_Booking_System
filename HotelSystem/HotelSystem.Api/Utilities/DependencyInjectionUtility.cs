namespace HotelSystem.Api.Utilities;

internal static class DependencyInjectionUtility
{
    internal static IServiceCollection AddRepositoryInjections(this IServiceCollection services)
    {
        services.AddScoped<IHotelRepository,HotelRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        return services;
    }
}