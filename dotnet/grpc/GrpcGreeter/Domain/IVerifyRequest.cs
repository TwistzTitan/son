namespace Domain.User;
public interface IVerification {
    public string email {get; set;}
    public string userCode {get;set;}
    public int code {get; set;}
}