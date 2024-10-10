
namespace BasicDI;
public class UserInterface
{
    public string? _username;
    public string? _password;

    private IBussiness _bussiness;

    public UserInterface(IBussiness bussiness)
    {
        _bussiness = bussiness;
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

    public Business(IDataAccess dataAccess)
    {
        _access = dataAccess;
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

//Basic DI - Constructor Injection
//In Coupling-Reduced-2 we have managed to reduced coupling a bit, but we were still using "new" statement in our classes/contructor.
// How can we elimenate this new statement? --> We can say the constructor of this class accepts a parameter of type Interface and that paramter
// is used as a value for private local Interface - as belows
//private IDataAccess _access;

//public Business(IDataAccess dataAccess)
//{
//    _access = dataAccess;
//}

//By doing this we not using new stmt inside the concrete classess anymore, but then if we are not using this new stmt, how do we instaniate
//these two classes? -->  We do this outside the classess in the main program.{check program.cs file}
//So, we have moved all the new stmt to the main program and we just pass the instances to the concrete classes, so they don't need to instantiate
//the dependency classess inside their constructore.
//----------This technique is called "CONSTRUCTOR INJECTION" ---------------//