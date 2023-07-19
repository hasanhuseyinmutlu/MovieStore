using AutoMapper;
using WebApi.DbOperation;
using WebApi.Entities;

namespace WebApi.Application.ActorOperations.Command
{
    
    public class CreateActorCommand
    {
        public CreateActorModel model;
        private readonly IMovieStoreDbContext _dbContext;

        private readonly IMapper _mapper;

        public CreateActorCommand(IMapper mapper, IMovieStoreDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var actor = _dbContext.Actors.SingleOrDefault(x => x.Name == model.Name && x.Surname == model.Surname);
            if (actor is not null)
                throw new InvalidOperationException("actor already exist");
                
            actor = _mapper.Map<Actor>(model);

            _dbContext.Actors.Add(actor);
            _dbContext.SaveChanges();
        }
    }
    public class CreateActorModel
    {
        public string Name { get; set; }
        public string  Surname { get; set; }

    }
}