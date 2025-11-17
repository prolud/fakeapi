using domain.Models;

namespace tests._builders
{
    public class DbUserBuilder
    {
        private readonly Random _random = new();
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private readonly List<string> prefixUsernames = ["dev", "sys", "user", "app", "tech", "data", "net", "code", "cloud", "core"];
        private readonly List<string> sufixUsernames = ["01", "123", "br", "pro", "dev", "sys", "app", "2025", "lab", "team"];
        private readonly DbUser entity;

        public DbUserBuilder()
        {
            entity = new DbUser
            {
                Id = _random.Next(31, 79),
                Password = new string([.. Enumerable.Repeat(chars, _random.Next(8, 16)).Select(s => s[_random.Next(s.Length)])]),
                Username = $"{prefixUsernames[_random.Next(prefixUsernames.Count - 1)]} {sufixUsernames[_random.Next(sufixUsernames.Count - 1)]}"
            };
        }

        public DbUser Build() => entity;
    }
}