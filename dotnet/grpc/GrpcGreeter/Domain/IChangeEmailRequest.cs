namespace Domain.User;
public interface IChangeEmail {

    string Email {get;}
    int UserId {get;}
    
}

public class ChangeEmail : IChangeEmail
{   
    private string _email; 

    private int _userId;
    public string Email { get => _email;}
    public int UserId { get => _userId;}


   public ChangeEmail(string email, int userid){
        _email = email;
        _userId = userid;
    }

}