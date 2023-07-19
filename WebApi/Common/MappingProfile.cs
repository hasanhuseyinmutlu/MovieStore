using AutoMapper;
using WebApi.Application.ActorMoviesOperations.Queries;
using WebApi.Application.ActorOperations.Command;
using WebApi.Application.ActorOperations.Queries;
using WebApi.Application.DirectorMoviesOperations.Command;
using WebApi.Application.DirectorMoviesOperations.Queries;
using WebApi.Application.DirectorOperations.Queries;
using WebApi.Application.MovieOperations.Queries;
using WebApi.Entities;
using static WebApi.Application.ActorMoviesOperations.Command.CreateActorMovieCommand;
using static WebApi.Application.CustomerOperations.CreateCustomerCommand;
using static WebApi.Application.CustomerOperations.Queries.GetCustomerQuey;
using static WebApi.Application.DirectorOperations.Command.CreateDirectorCommand;
using static WebApi.Application.FavoriteGenreOperations.Command.CreateFavoriteGenresCommand;
using static WebApi.Application.FavoriteGenreOperations.Queries.GetFavoriteGenresQuery;
using static WebApi.Application.MovieOperations.Command.CreateMovieCommand;
using static WebApi.Application.PurchasedMovieOperations.Command.CreatePurchaseMovieCommand;
using static WebApi.Application.PurchasedMovieOperations.Queries.GetPurchasedMovieQuery;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //     CreateMap<Movie, MoviesViewModel>();
            //movie mapper
            CreateMap<CreateMovieModel, Movie>();
            CreateMap<Movie, GetMoviesQuery.MoviesViewModel>();

            //ActorMovie mapper
            CreateMap<CreateActorMovieModel, ActorMovies>();

            //Actor mapper
            CreateMap<CreateActorModel, Actor>();

            CreateMap<Actor, GetActorsQueryViewModel>();

            CreateMap<Actor, CreateActorMovieModel>();

            CreateMap<Actor, GetActorMovieViewModel>()
            .ForMember(dest => dest.NameSurName, opt => opt.MapFrom(m => m.Name + " " + m.Surname))
            .ForMember(dest => dest.Movies, opt => opt.MapFrom(m => m.ActorMovies.Select(s => s.Movie.Title)));

            //DirectorMovie Mapper
            CreateMap<CreateDirectorMovieModel, DirectorMovie>();

            //Director mapper
            CreateMap<CreateDirectorModel, Director>();

            CreateMap<Director, GetDirectorsQueryViewModel>();

            CreateMap<Director, CreateDirectorMovieModel>();

            CreateMap<Director, GetDirectorMovieViewModel>()
            .ForMember(dest => dest.NameAndSurname, opt => opt.MapFrom(m => m.Name + " " + m.Surname))
            .ForMember(dest => dest.Movies, opt => opt.MapFrom(m => m.DirectorMovies.Select(s => s.Movie.Title)));

            //customer mapper
            CreateMap<Customer, CustomerQueryViewModel>();
            CreateMap<CustomerModel, Customer>();

            //purchased movies mapper
            CreateMap<PurchasedMovieModel, PurchasedMovies>();
            CreateMap<Customer, PurchasedMovieViewModel>()
                .ForMember(dest => dest.NameLastName, opt => opt.MapFrom(m => m.Name + " " + m.LastName))
                .ForMember(dest => dest.Movies, opt => opt.MapFrom(m => m.PurchasedMovies.Select(s => s.Movie.Title)))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(m => m.PurchasedMovies.Select(s => s.Movie.Price)))
                .ForMember(dest => dest.PurchasedDate, opt => opt.MapFrom(m => m.PurchasedMovies.Select(s => s.PurchasedTime)));


            //favorites genre mapper
            CreateMap<Customer, FavoriteGenreQueryViewModel>()
               .ForMember(dest => dest.NameSurname, opt => opt.MapFrom(m => m.Name + " " + m.LastName))
               .ForMember(dest => dest.Genre, opt => opt.MapFrom(m => m.FavoriteGenres.Select(s => (GenreEnum)s.FavoriteGenreId)));

            CreateMap<FavoriteGenreModel, FavoriteGenre>();

        }
    }
}
