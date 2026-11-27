using api.Models;

namespace api.Interfaces
{
    public interface IAdminRepository
    {
        Admin? CheckLogin(string username, string password);
    }
}