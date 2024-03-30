using JetBrains.Annotations;
using LegacyApp;

namespace TestProject1;

[TestSubject(typeof(UserService))]
public class UserServiceTest
{
    [Fact]
    public void AddUser_WhenFirstNameIsEmpty_ShouldReturnFalse()
    {
        var userService = new UserService();
        var result = userService.AddUser("", "Doe", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        Assert.False(result);
    }

    [Fact]
    public void AddUser_WhenLastNameIsEmpty_ShouldReturnFalse()
    {
        var userService = new UserService();
        var result = userService.AddUser("John", "", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_WhenFirstNameIsNull_ShouldReturnFalse()
    {
        var userService = new UserService();
        var result = userService.AddUser(null, "Doe", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        Assert.False(result);
    }

    [Fact] 
    public void AddUser_WhenLastNameIsNull_ShouldReturnFalse()
    {
        var userService = new UserService();
        var result = userService.AddUser("John", null, "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        Assert.False(result);
    }

    [Fact]
    public void AddUser_WhenEmailDoesNotContainAtSignAndDot_ShouldReturnFalse()
    {
        var userService = new UserService();
        var result = userService.AddUser("John", "Doe", "johndoegmailcom", DateTime.Parse("1982-03-21"), 1);
        Assert.False(result);
    }


    [Fact]
    public void AddUser_IfBirthMonthOrBirthdayIsLaterThanDateNowDecrementAge_ShouldReturnTrue()
    {
        var userService = new UserService();
        var result = userService.AddUser("John", "Doe", "johndoe@gmail.com", DateTime.Parse("2003-03-31"), 1);
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_IfAgeIsLessThan21_ShouldReturnFalse()
    {
        var userService = new UserService();
        var result = userService.AddUser("John", "Doe", "johndoe@gmail.com", DateTime.Parse("2010-03-21"), 1);
        Assert.False(result);
    }
    [Fact]
    public void AddUser_IfAgeIsBiggerThan21_ShouldReturnTrue()
    {
        var userService = new UserService();
        var result = userService.AddUser("John", "Doe", "johndoe@gmail.com", DateTime.Parse("2000-03-21"), 1);
        Assert.True(result);
    }
    
    [Fact]
    public void AddUser_IfClientTypeIsImportantClient_ShouldReturnTrue()
    {
        var userService = new UserService();
        var result = userService.AddUser("Jogn","Smith","smith@gmail.pl",DateTime.Parse("1990-03-21"),3);
        Assert.True(result);
    }
    
    [Fact]
    public void AddUser_IfClientTypeIsVeryImportantClient_ShouldReturnTrue()
    {
        var userService = new UserService();
        var result = userService.AddUser("Jogn","Malewski","malewski@gmail.pl",DateTime.Parse("1990-03-21"),2);
        Assert.True(result);
    }

    [Fact]
    public void AddUser_IfClientHasNotEnoughCreditLimit_ShouldReturnFalse()
    {
        var userService = new UserService();
        var result = userService.AddUser("Jogn","Kowalski","kowalski@wp.pl",DateTime.Parse("1990-03-21"),1);
        Assert.False(result);
    }
}