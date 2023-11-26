namespace UserAPI.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public bool IsBlocked { get; set; } = true;
    }
}
