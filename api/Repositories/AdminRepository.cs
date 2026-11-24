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
            Admin admin = new Admin("admin", "zealand123"); // laver en ny Admin og kalder på constructoren i Admin klassen som giver username
                                                            // til "Admin" og password til "zealand123". 
            admin.Id = NextId; // admin får sit Id sat til NextId som starter på 1.
            NextId++; // lægger 1 til nextId så næste admin får Id 2 osv.
            admins.Add(admin); // admin ligges i listen admins, og når CheckLogin metoden kaldes, så findes denne admin, hvis username og password passer.
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
