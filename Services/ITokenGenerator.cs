namespace KibritAPI.Services
{
    public interface ITokenGenerator
    {
        public string CreateJwtToken(string userName, string id);
        public string CreateRefreshToken();
    }
}