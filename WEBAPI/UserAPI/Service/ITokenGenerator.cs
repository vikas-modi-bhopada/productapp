namespace UserAPI.Service
{
    public interface ITokenGenerator
    {
        string GenerateToken(int id, string name);
    }
}
