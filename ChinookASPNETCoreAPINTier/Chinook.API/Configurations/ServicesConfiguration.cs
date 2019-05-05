// This line needs to be changed for the desired Data project: DataEFCore, DataEFCoreCmpldQry, DataDapper
using Chinook.DataEFCoreCmpldQry.Repositories;
//
using Chinook.Domain.ApiModels;
using Chinook.Domain.Repositories;
using Chinook.Domain.Supervisor;
using Chinook.Domain.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Chinook.API.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAlbumRepository, AlbumRepository>()
                .AddScoped<IArtistRepository, ArtistRepository>()
                .AddScoped<ICustomerRepository, CustomerRepository>()
                .AddScoped<IEmployeeRepository, EmployeeRepository>()
                .AddScoped<IGenreRepository, GenreRepository>()
                .AddScoped<IInvoiceRepository, InvoiceRepository>()
                .AddScoped<IInvoiceLineRepository, InvoiceLineRepository>()
                .AddScoped<IMediaTypeRepository, MediaTypeRepository>()
                .AddScoped<IPlaylistRepository, PlaylistRepository>()
                .AddScoped<ITrackRepository, TrackRepository>();

            return services;
        }

        public static IServiceCollection ConfigureSupervisor(this IServiceCollection services)
        {
            services.AddScoped<IChinookSupervisor, ChinookSupervisor>();

            return services;
        }

        public static IServiceCollection AddMiddleware(this IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            return services;
        }

        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services) =>        
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", new Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowCredentials()
                    .Build());
            }
        );

        public static IServiceCollection ConfigureValidators(this IServiceCollection services)
        {
            services.AddSingleton<IValidator<AlbumApiModel>, AlbumValidator>();
            services.AddSingleton<IValidator<ArtistApiModel>, ArtistValidator>();
            services.AddSingleton<IValidator<CustomerApiModel>, CustomerValidator>();
            services.AddSingleton<IValidator<EmployeeApiModel>, EmployeeValidator>();
            services.AddSingleton<IValidator<GenreApiModel>, GenreValidator>();
            services.AddSingleton<IValidator<InvoiceApiModel>, InvoiceValidator>();
            services.AddSingleton<IValidator<InvoiceLineApiModel>, InvoiceLineValidator>();
            services.AddSingleton<IValidator<MediaTypeApiModel>, MediaTypeValidator>();
            services.AddSingleton<IValidator<PlaylistApiModel>, PlaylistValidator>();
            services.AddSingleton<IValidator<PlaylistTrackApiModel>, PlaylistTrackValidator>();
            services.AddSingleton<IValidator<TrackApiModel>, TrackValidator>();

            return services;
        }
    }
}