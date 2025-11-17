using domain.Interfaces.Services;

namespace infra.Services
{
    public class JwtService : IJwtService
    {
        public string GenerateJwt()
        {
            Random random = new();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var jwt1 = "ey" + new string([.. Enumerable.Repeat(chars, random.Next(33, 39)).Select(s => s[random.Next(s.Length)])]);
            var jwt2 = "ey" + new string([.. Enumerable.Repeat(chars, random.Next(88, 94)).Select(s => s[random.Next(s.Length)])]);
            var jwt3 = new string([.. Enumerable.Repeat(chars, random.Next(35, 41)).Select(s => s[random.Next(s.Length)])]);
            var jwt4 = new string([.. Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)])]);

            return $"{jwt1}.{jwt2}.{jwt3}-{jwt4}".ToLower();
        }
    }
}