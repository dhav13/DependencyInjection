namespace HighCoupling;

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
        biz.SignUp(_username, _password);
    }
}

public class Bussiness
{
    public void SignUp(string? username, string? password)
    {
        //MySqlDataAccess db = new MySqlDataAccess();
        //db.SingUp(username, password);

        OracleDataAccess o = new OracleDataAccess();   //here I am changing the code in main codebase
        o.SignUp(username, password);
    }
}

public class MySqlDataAccess
{
    public void SignUp(string? username, string? password)
    {
        Console.WriteLine("MySql - " + username + " " + password);
    }
}

public class OracleDataAccess
{
    public void SignUp(string? username, string? password)
    {
        Console.WriteLine("Oracel - " + username + " " + password);
    }
}


//HighDependency - In this program we are seeing high coupling where classes are dependent on other classes.
//Solution 1 - we replace concrete class with an interface that demonstrates the methods, properties and
                //method signatures of concrete class. So one concrete class can be work with another class's Interface.
                // Now everytime we want to actually do something in the concerte class, dependency injection will come into play
                // and we'll create an instance of that concrete class and then makes a call to the actual method inside that concrete class