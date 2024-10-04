

namespace CoupingReduced;

public class UserInterface
{
    public string? _username;
    public string? _password;

    private IBussiness _bussiness;

    public UserInterface()
    {
        _bussiness = new Business();
    }

    public void GetData()
    {
        Console.Write("UserName: ");
        _username = Console.ReadLine();

        Console.Write("Password: ");
        _password = Console.ReadLine();
    }

    public void SignUp()
    {
        GetData();

        //Bussiness biz = new Bussiness();
        _bussiness.SingUp(_username, _password);
    }
}

public interface IBussiness
{
    void SingUp(string? username, string? password);
}

public class Business : IBussiness
{
    private IDataAccess _access;

    public Business()
    {
       //_access = new OracleDataAccess();
        _access = new MySqlDataAccess();
    }

    public void SingUp(string? username, string? password)
    {
        _access.SignUp(username, password);
    }
}

public interface IDataAccess
{
    void SignUp(string? username, string? password);
}

public class MySqlDataAccess : IDataAccess
{
    public void SignUp(string? username, string? password)
    {
        Console.WriteLine("MySql - " + username + " " + password);
    }
}

public class OracleDataAccess : IDataAccess
{
    public void SignUp(string? username, string? password)
    {
        Console.WriteLine("Oracel - " + username + " " + password);
    }
}

// This is Reduced couping but not completly dependency free as we see in Bussiness we create object of one particular 
// DataAccess class and if we need to change we have to update the Constructor of Business