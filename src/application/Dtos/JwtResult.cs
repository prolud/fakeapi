namespace application.Dtos
{
    public class JwtResult
    {
        public required string Token { get; set; }
        public required DateTime Expires { get; set; }
        public string Type { get; } = "Bearer";
    }
}