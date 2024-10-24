namespace MyApp.Application.DTOs.User{
    public class CreateUserDto{
        public int Id { get; set; }
        public required string First_name { get; set; }
        public string? Middle_name { get; set; }
        public required string Last_name { get; set; }
        public string? Second_last_name { get; set; }
        public required string Email { get; set; }
        public string? Phone_number { get; set; }
        public bool Active { get; set; }
    }
}
