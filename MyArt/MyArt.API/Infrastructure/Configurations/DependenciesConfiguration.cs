using FluentValidation;
using MyArt.API.Validations;
using MyArt.API.ViewModels;
using MyArt.BusinessLogic.Mappings;
using MyArt.DataAccess;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Providers;
using MyArt.DataAccess.Contracts.Repositories;
using MyArt.DataAccess.Providers;
using MyArt.DataAccess.Repositories;
using MyArt.Domain.Entities;

namespace MyArt.API.Infrastructure.Configurations
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            services.AddScoped<IDataProvider, DataProvider>();

            // IRepository
            services.AddScoped<IRepository<ArtForm>, ArtFormRepository>();
            services.AddScoped<IArtFormRepository, ArtFormRepository>();
            services.AddScoped<IRepository<Art>, ArtRepository>();
            services.AddScoped<IArtRepository, ArtRepository>();
            services.AddScoped<IRepository<Board>, BoardRepository>();
            services.AddScoped<IBoardRepository, BoardRepository>();
            services.AddScoped<IRepository<Exhibition>, ExhibitionRepository>();
            services.AddScoped<IExhibitionRepository, ExhibitionRepository>();
            services.AddScoped<IRepository<Film>, FilmRepository>();
            services.AddScoped<IFilmRepository, FilmRepository>();
            services.AddScoped<IRepository<Genre>, GenreRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // IProvider
            services.AddScoped<IProvider<ArtForm>, ArtFormProvider>();
            services.AddScoped<IArtFormProvider, ArtFormProvider>();
            services.AddScoped<IProvider<Art>, ArtProvider>();
            services.AddScoped<IArtProvider, ArtProvider>();
            services.AddScoped<IProvider<Board>, BoardProvider>();
            services.AddScoped<IBoardProvider, BoardProvider>();
            services.AddScoped<IProvider<Exhibition>, ExhibitionProvider>();
            services.AddScoped<IExhibitionProvider, ExhibitionProvider>();
            services.AddScoped<IProvider<Film>, FilmProvider>();
            services.AddScoped<IFilmProvider, FilmProvider>();
            services.AddScoped<IProvider<Genre>, GenreProvider>();
            services.AddScoped<IGenreProvider, GenreProvider>();
            services.AddScoped<IProvider<User>, UserProvider>();
            services.AddScoped<IUserProvider, UserProvider>();

            return services;
        }
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(x =>
            {
                x.AddProfile<UserProfile>();
            });

            return services;
        }
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<RegisterViewModel>, RegisterValidator>();
            services.AddScoped<IValidator<AuthenticationViewModel>, AuthenticationValidator>();

            return services;
        }
    }
}
