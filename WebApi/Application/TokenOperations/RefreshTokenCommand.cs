using WebApi.DbOperation;
using WebApi.Entities;
using WebApi.TokenOperations;

namespace WebApi.Application.TokenOperations
{
    public class RefreshTokenCommand
    {
        public string RefreshToken;
        private readonly IMovieStoreDbContext _context;
        private readonly IConfiguration _configuration;

        public RefreshTokenCommand(IConfiguration configuration, IMovieStoreDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public Token Handle()
        {
            var user = _context.Customers.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);
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
                throw new InvalidOperationException("Geçerli bir refresh token bulunamadı.");
            }
        }
    }
}