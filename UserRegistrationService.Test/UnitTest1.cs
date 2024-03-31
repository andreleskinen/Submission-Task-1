namespace UserRegistrationService.Test;


[TestClass]
public class UserRegistrationTests
{
    private UserRegistration userRegistration;

    [TestInitialize]
    public void TestInitialize()
    {
        // ränsar data som funnits innan
        userRegistration = new UserRegistration();
        userRegistration.ClearUsers(); 
    }

    [TestMethod]
    public void RegisterUser_ValidUsername_ReturnsTrue()
    {
        var user = new User("AndreLeskinen", "Password@89", "andre.leskinen@email.com");
        bool result = userRegistration.RegisterUser(user);
        Assert.IsTrue(result);
    }
    
    [TestMethod]
    public void RegisterUser_InvalidUsername_ReturnsFalse()
    {
        var userRegistration = new UserRegistration();
        var user = new User("inv@lid", "pass", "firstname.lastname@email.com");
        bool result = userRegistration.RegisterUser(user);
        Assert.IsFalse(result);
    }
    
    [TestMethod]
    public void RegisterUser_ValidPassword_ReturnsTrue()
    {
        var userRegistration = new UserRegistration();
        var user = new User("validusername", "StrongP@ssword", "test@example.com");
        bool result = userRegistration.RegisterUser(user);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void RegisterUser_InvalidPassword_ReturnsFalse()
    {
        var userRegistration = new UserRegistration();
        var user = new User("validusername", "weak", "test@example.com");
        bool result = userRegistration.RegisterUser(user);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void RegisterUser_ValidEmail_ReturnsTrue()
    {
        var userRegistration = new UserRegistration();
        var user = new User("validusername", "StrongP@ssword", "test@example.com");
        bool result = userRegistration.RegisterUser(user);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void RegisterUser_InvalidEmail_ReturnsFalse()
    {
        var userRegistration = new UserRegistration();
        var user = new User("validusername", "StrongP@ssword", "invalidemail");
        bool result = userRegistration.RegisterUser(user);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void RegisterUser_NewUsername_ReturnsTrue()
    {
        var userRegistration = new UserRegistration();
        var user1 = new User("validusername", "StrongP@ssword", "test1@example.com");
        var user2 = new User("Validusername", "StrongP@ssword", "test2@example.com");
        userRegistration.RegisterUser(user1);
        bool result = userRegistration.RegisterUser(user2);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void RegisterUser_ExistingUsername_ReturnsFalse()
    {
        var userRegistration = new UserRegistration();
        var user = new User("existinguser", "StrongP@ssword", "test@example.com");
        userRegistration.RegisterUser(user);
        bool result = userRegistration.RegisterUser(user);
        Assert.IsFalse(result);
    }
    
}
