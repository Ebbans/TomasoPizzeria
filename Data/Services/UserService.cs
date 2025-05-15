using Inlämning1Tomaso.Data.DTOs;
using Inlämning1Tomaso.Data.Interface.Repositories;
using Inlämning1Tomaso.Data.Interface.Services;

public class UserService : IUserService
{
    private readonly IUserRepo _userRepo;

    public UserService(IUserRepo userRepo)
    {
        _userRepo = userRepo;
    }

    //public List<UserDto> GetAllUsers()
    //{
    //    return _userRepo.GetAllUsers()
    //        .Select(u => new UserDto
    //        {
    //            UserID = u.UserID,
    //            UserName = u.UserName,
    //            Email = u.Email
    //        }).ToList();
    //}

   
}
