namespace api.Models
{
    public class Admin
    {
        // properties
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        // Constructor
        public Admin(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }




        // ToString method
        public override string ToString()
        {
            return $"Admin Id: {Id}, User Name: {UserName}, Password: {Password}";
        }

    }
}
