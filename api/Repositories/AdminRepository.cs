using api.Models;

namespace api.Repositories
{
    public class AdminRepository
    {
        private List<Admin> admins = new List<Admin>();
        private int NextId = 1;


        // Constructor 
        public AdminRepository()
        {
            Admin admin = new Admin();
            admin.Id = NextId;
            NextId++;
            admin.UserName = "admin1";
            admin.Password = "zealand123";
            admins.Add(admin);
        }

        // CheckLogin method
        public Admin? CheckLogin(string username, string password)
        {
            foreach (Admin a in admins)
            {
                if (a.UserName == username && a.Password == password)
                {
                    return a;
                }
            }
            return null;
        }
    }
}
