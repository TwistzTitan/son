namespace Domain.User;
public interface IUserFactory<T> where T:User {
    Task<T> updateEmail(ChangeEmail changeEmail);
}

public class UserFactory : IUserFactory<User>
{   
    private readonly IUserRepository<User> _userRepo;
    public UserFactory(IUserRepository<User> userRepo){
        _userRepo = userRepo;
    }
    public async Task<User> updateEmail(ChangeEmail changeEmail)
    {
       User? user = await _userRepo.getUser(changeEmail.UserId);
       user!.email = changeEmail.Email;
       user.GenerateUserCode();
       return user;
    }
}