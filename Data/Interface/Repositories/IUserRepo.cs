using Inlämning1Tomaso.Data.Models;

namespace Inlämning1Tomaso.Data.Interface.Repositories
{
    public interface IUserRepo
    {
        void AddUSer(User user);

        void DeleteUser (int userID);

        void UpdateUser (User user);

        //public List <User> GetAllUsers();
    }
}
