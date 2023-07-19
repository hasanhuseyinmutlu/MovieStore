using AutoMapper;
using WebApi.DbOperation;
using WebApi.TokenOperations;

namespace WebApi.Application.TokenOperations
{
    public class CreateTokenCommand
    {
        public CreateTokenModel model;
        private readonly IMovieStoreDbContext _context;
        private readonly IConfiguration _configuration;

        public CreateTokenCommand(IConfiguration configuration, IMovieStoreDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

            public Token Handle()
        {
            var user = _context.Customers.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            if (user is not null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccesToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _context.SaveChanges();

                return token;
            }
            else
            {
                throw new InvalidOperationException("Kullanıcı adı veya şifre hatalı!");
            }  
        }
        public class CreateTokenModel{
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}