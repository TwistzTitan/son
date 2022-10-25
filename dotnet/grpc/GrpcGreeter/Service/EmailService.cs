using Domain.User;

public class EmailService : IEmailService
{   
    private readonly IUserRepository<User> _userRepo;
    private readonly IUserFactory<User> _userFactory;
    public EmailService (IUserFactory<User> userFactory, IUserRepository<User> userRepository){
        _userFactory = userFactory;
        _userRepo = userRepository;
    }

    public Task<IChangeEmail> changeEmail(IChangeEmail change)
    {
        throw new NotImplementedException();
    }

    public Task<IVerification>verify(IVerification verification)
    {
        var user = _userRepo.getByEmail(verification.email);

        throw new NotImplementedException();
    }
}