using FluentValidation;

namespace WebApi.Application.MovieOperations.Command
{
    public class UpdateMovieValidator : AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieValidator()
        {
            RuleFor(c => c.Model.Title).NotEmpty().NotNull().MinimumLength(2);
            RuleFor(c => c.Model.Price).NotEmpty().NotNull().GreaterThan(0).LessThan(9999);
            RuleFor(r => r.Model.ReleaseDate).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(x => x.Model.GenreId).GreaterThan(0);
        }
       
    }
}