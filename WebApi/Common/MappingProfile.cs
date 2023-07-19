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
using static WebApi.Application.DirectorOperations.Command.CreateDirectorCommand;
using static WebApi.Application.MovieOperations.Command.CreateMovieCommand;

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



        }
    }
}
