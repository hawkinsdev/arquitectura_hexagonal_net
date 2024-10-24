namespace MyApp.Application.DTOs.User{

    public class UserResponseDto{
        public int Id { get; set; }
        public required string First_name { get; set; }
        public required string Last_name { get; set; }
        public required string Email { get; set; }
        public bool Active { get; set; }
    }
}