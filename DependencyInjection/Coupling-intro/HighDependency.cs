namespace DependencyInjection;

public class UserInterface
{
    public string? _username;
    public string? _password;



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

        Bussiness biz = new Bussiness();
        biz.SingUp(_username, _password);
    }
}

public class Bussiness
{
    public void SingUp(string? username, string? password)
    {
        //MySqlDataAccess db = new MySqlDataAccess();
        //db.SingUp(username, password);

        OracleDataAccess o = new OracleDataAccess();   //here I am changing the code in main codebase
        o.SingUp(username, password);
    }
}

public class MySqlDataAccess
{
    public void SingUp(string? username, string? password)
    {
        Console.WriteLine("MySql - " + username + " " + password);
    }
}

public class OracleDataAccess
{
    public void SingUp(string? username, string? password)
    {
        Console.WriteLine("Oracel - " + username + " " + password);
    }
}


//HighDependency
//Solution 1 - we replace concrete class with an interface that demonstrates the methods, properties and
                //method signatures of concrete class