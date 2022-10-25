namespace Domain.User;

public interface IEmailService{
    Task<IVerification> verify(IVerification data);

    Task<IChangeEmail> changeEmail(IChangeEmail data);
}