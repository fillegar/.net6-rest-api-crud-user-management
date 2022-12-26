namespace User.Core.Model
{
    public class UserInfo
    {
        public int Id { get; set; }

        public string? FullName { get; set; }

        public int Age { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenEndDate { get; set; }

        public string? Role { get; set; }
    }
}
