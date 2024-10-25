namespace MyApp.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string First_name { get; set; }
        public string? Middle_name { get; set; }
        public required string Last_name { get; set; }
        public string? Second_last_name { get; set; }
        public required string Email { get; set; }
        public string? Phone_number { get; set; }
        public required string Identification_number { get; set; }
        public required string Password { get; set; }
        public int Id_Profile { get; set; }
        public bool Active { get; set; }
        public int State { get; set; }
        public DateTime Date_created { get; set; }
        public DateTime Date_updated { get; set; }
    }
}
