namespace Business
{
    public interface IBusinessClassNewUser
    {
        string NewUser(string email, string firstname,string lastname, string password);
        string LoginUser(string email, string password);
    }
}