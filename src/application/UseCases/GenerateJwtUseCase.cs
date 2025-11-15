using application.Dtos;

namespace application.UseCases
{
    public class GenerateJwtUseCase
    {
        public static string ExecuteAsync()
        {

            Random random = new();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var jwt1 = "ey" + new string([.. Enumerable.Repeat(chars, 36).Select(s => s[random.Next(s.Length)])]);
            var jwt2 = "ey" + new string([.. Enumerable.Repeat(chars, 91).Select(s => s[random.Next(s.Length)])]);
            var jwt3 = new string([.. Enumerable.Repeat(chars, 38).Select(s => s[random.Next(s.Length)])]);
            var jwt4 = new string([.. Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)])]);

            return $"{jwt1}.{jwt2}.{jwt3}-{jwt4}".ToLower();
        }
    }
}