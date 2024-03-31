using JetBrains.Annotations;
using LegacyApp;

namespace TestProject1;

[TestSubject(typeof(UserService))]
public class UserServiceTest
{
    [Fact]
    public void AddUser_When_First_Name_Is_Empty_Should_Return_False()
    {
        var userService = new UserService();
        var result = userService.AddUser("", "Doe", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        Assert.False(result);
    }

    [Fact]
    public void AddUser_When_Last_Name_Is_Empty_Should_Return_False()
    {
        var userService = new UserService();
        var result = userService.AddUser("John", "", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_When_First_Name_Is_Null_Should_Return_False()
    {
        var userService = new UserService();
        var result = userService.AddUser(null, "Doe", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        Assert.False(result);
    }

    [Fact] 
    public void AddUser_When_Last_Name_Is_Null_Should_Return_False()
    {
        var userService = new UserService();
        var result = userService.AddUser("John", null, "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        Assert.False(result);
    }

    [Fact]
    public void AddUser_When_Email_Does_Not_Contain_At_Sign_And_Dot_Should_Return_False()
    {
        var userService = new UserService();
        var result = userService.AddUser("John", "Doe", "johndoegmailcom", DateTime.Parse("1982-03-21"), 1);
        Assert.False(result);
    }


    [Fact]
    public void AddUser_If_Birth_Month_Or_Birthday_Is_Later_Than_Date_Now_Decrement_Age_Should_Return_True()
    {
        var userService = new UserService();
        var result = userService.AddUser("John", "Doe", "johndoe@gmail.com", DateTime.Parse("2003-04-01"), 1);
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_If_Age_Is_Less_Than_21_Should_Return_False()
    {
        var userService = new UserService();
        var result = userService.AddUser("John", "Doe", "johndoe@gmail.com", DateTime.Parse("2010-03-21"), 1);
        Assert.False(result);
    }
    [Fact]
    public void AddUser_If_Age_Is_Bigger_Than_21_Should_Return_True()
    {
        var userService = new UserService();
        var result = userService.AddUser("John", "Doe", "johndoe@gmail.com", DateTime.Parse("2000-03-21"), 1);
        Assert.True(result);
    }
    
    [Fact]
    public void AddUser_If_Client_Type_Is_Important_Client_Should_Return_True()
    {
        var userService = new UserService();
        var result = userService.AddUser("Jogn","Smith","smith@gmail.pl",DateTime.Parse("1990-03-21"),3);
        Assert.True(result);
    }
    
    [Fact]
    public void AddUser_If_Client_Type_Is_Very_Important_Client_Should_Return_True()
    {
        var userService = new UserService();
        var result = userService.AddUser("Jogn","Malewski","malewski@gmail.pl",DateTime.Parse("1990-03-21"),2);
        Assert.True(result);
    }

    [Fact]
    public void AddUser_If_Client_Has_Not_Enough_Credit_Limit_Should_Return_False()
    {
        var userService = new UserService();
        var result = userService.AddUser("Jogn","Kowalski","kowalski@wp.pl",DateTime.Parse("1990-03-21"),1);
        Assert.False(result);
    }

    [Fact]
    public void AddUser_When_Client_Id_Is_Not_In_Database_Should_Throw_ArgumentException()
    {
        var userService = new UserService();
        Assert.Throws<ArgumentException>(() => userService.AddUser("Jogn","Kowalski","kowalski@wp.pl",DateTime.Parse("1990-03-21"),10));
    }

    [Fact]
    public void AddUser_When_Client_Has_NoCredit_Limit_Should_Throw_ArgumentException()
    {
        var userService = new UserService();
        Assert.Throws<ArgumentException>(() => userService.AddUser("Jogn", "NMFASMIOLK_P", "kowalski@wp.pl", DateTime.Parse("1990-03-21"), 10));
    }
}