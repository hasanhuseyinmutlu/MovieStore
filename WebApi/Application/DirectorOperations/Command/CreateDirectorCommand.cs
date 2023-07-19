using AutoMapper;
using WebApi.DbOperation;
using WebApi.Entities;

namespace WebApi.Application.DirectorOperations.Command
{
    public class CreateDirectorCommand
    {
        public CreateDirectorModel model;
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateDirectorCommand(IMapper mapper, IMovieStoreDbContext dbContext = null)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var director = _dbContext.Directors.SingleOrDefault(x => x.Name == model.Name && x.Surname == model.Surname);
            if (director is not null)
                throw new InvalidOperationException("director already exist");
            director = _mapper.Map<Director>(model);

            _dbContext.Directors.Add(director);
            _dbContext.SaveChanges();
        }

        public class CreateDirectorModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
        }
    }
}