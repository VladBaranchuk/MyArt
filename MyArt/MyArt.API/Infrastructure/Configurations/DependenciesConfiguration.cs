using FluentValidation;
using MyArt.API.Validations;
using MyArt.API.ViewModels;
using MyArt.BusinessLogic.Mappings;
using MyArt.DataAccess;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Providers;
using MyArt.DataAccess.Contracts.Repositories;
using MyArt.DataAccess.Mappings;
using MyArt.DataAccess.Providers;
using MyArt.DataAccess.Repositories;
using MyArt.Domain.Entities;

namespace MyArt.API.Infrastructure.Configurations
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
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
            services.AddScoped<IRepository<Role>, RoleRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRepository<Comment>, CommentRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();

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
            services.AddScoped<IProvider<Role>, RoleProvider>();
            services.AddScoped<IRoleProvider, RoleProvider>();
            services.AddScoped<IProvider<User>, UserProvider>();
            services.AddScoped<IUserProvider, UserProvider>();
            services.AddScoped<IProvider<Comment>, CommentProvider>();
            services.AddScoped<ICommentProvider, CommentProvider>();

            services.AddScoped<IDataProvider, DataProvider>();

            return services;
        }
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(x =>
            {
                x.AddProfile<UserProfile>();
                x.AddProfile<FluentFailureProfile>();
                x.AddProfile<FilmProfile>();
                x.AddProfile<CommentProfile>();
                x.AddProfile<ArtProfile>();
                x.AddProfile<BoardProfile>();
            });

            return services;
        }
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<RegisterViewModel>, RegisterValidator>();
            services.AddScoped<IValidator<AuthenticationViewModel>, AuthenticationValidator>();
            services.AddScoped<IValidator<ArtFilterViewModel>, ArtFilterValidator>();
            services.AddScoped<IValidator<UpdatePublicUserInfoViewModel>, UpdateUserValidator>();
            services.AddScoped<IValidator<CreateArtViewModel>, AddArtValidator>();
            services.AddScoped<IValidator<CreateBoardViewModel>, AddBoardValidator>();
            services.AddScoped<IValidator<MailViewModel>, MailVlidator>();

            return services;
        }
    }
}
