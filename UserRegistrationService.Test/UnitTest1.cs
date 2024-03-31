namespace UserRegistrationService.Test;


[TestClass]
public class UserRegistrationTests
{
    //deklarerar en variabel
    private UserRegistration userRegistration;

    // denna moetod k�rs innan alla andra tester
    [TestInitialize]
    public void TestInitialize()
    {
        // r�nsar all data som funnits innan och skapar en ny instans av userRegistration
        userRegistration = new UserRegistration();
        userRegistration.ClearUsers(); 
    }

    [TestMethod]
    // test metod f�r att l�gga till en giltig anv�ndare
    public void RegisterUser_ValidUsername_ReturnsTrue()
    {
        // h�rdkodad kod f�r att l�ga till en ny anv�ndare, kallar ocks� p� metoden RegisterUser f�r att l�gga till anv�nadern, och testet ska vara true
        var user = new User("AndreLeskinen", "Password@89", "andre.leskinen@email.com");
        bool result = userRegistration.RegisterUser(user);
        Assert.IsTrue(result);
    }
    
    [TestMethod]
    // test metod f�r att l�gga till en Ogiltig anv�ndare
    public void RegisterUser_InvalidUsername_ReturnsFalse()
    {
        // h�rdkodad kod f�r att l�ga till en Ogiltig anv�ndare, kallar ocks� p� metoden RegisterUser f�r att l�gga till anv�nadern, och testet ska vara false
        var userRegistration = new UserRegistration();
        var user = new User("NotAValidUserName@!&", "pass", "firstname.lastname@email.com");
        bool result = userRegistration.RegisterUser(user);
        Assert.IsFalse(result);
    }
    

    [TestMethod]
    // test metod f�r att l�gga till en avn�ndare med ett giltigt l�senord
    public void RegisterUser_ValidPassword_ReturnsTrue()
    {
        var userRegistration = new UserRegistration();
        var user = new User("validusername", "StrongP@ssword", "test@example.com");
        bool result = userRegistration.RegisterUser(user);
        Assert.IsTrue(result);
    }

    [TestMethod]
    // test metod f�r att l�gga till en avn�ndare med ett Ogiltigt l�senord
    public void RegisterUser_InvalidPassword_ReturnsFalse()
    {
        var userRegistration = new UserRegistration();
        var user = new User("validusername", "weak", "test@example.com");
        bool result = userRegistration.RegisterUser(user);
        Assert.IsFalse(result);
    }

    [TestMethod]
    // test metod f�r att l�gga till en avn�ndare med ett giltig email
    public void RegisterUser_ValidEmail_ReturnsTrue()
    {
        var userRegistration = new UserRegistration();
        var user = new User("validusername", "StrongP@ssword", "test@example.com");
        bool result = userRegistration.RegisterUser(user);
        Assert.IsTrue(result);
    }

    [TestMethod]
    // test metod f�r att l�gga till en avn�ndare med ett Ogiltig email
    public void RegisterUser_InvalidEmail_ReturnsFalse()
    {
        var userRegistration = new UserRegistration();
        var user = new User("validusername", "StrongPssword134!@&", "OgiltigEmail");
        bool result = userRegistration.RegisterUser(user);
        Assert.IsFalse(result);
    }

    [TestMethod]
    // testmetod f�r att l�gga till a ny anv�ndare
    public void RegisterUser_NewUsername_ReturnsTrue()
    {
        var userRegistration = new UserRegistration();
        var user1 = new User("username", "StrongPssword135!@&", "test1@example.com");
        var user2 = new User("Username", "StrongPssword135!@&", "test2@example.com");
        userRegistration.RegisterUser(user1);
        bool result = userRegistration.RegisterUser(user2);
        Assert.IsTrue(result);
    }

    [TestMethod]
    // testmetod f�r att l�gga till en anv�ndare som redan finns
    public void RegisterUser_ExistingUsername_ReturnsFalse()
    {
        var userRegistration = new UserRegistration();
        var user = new User("existinguser", "StrongPssword135!@&", "test@example.com");
        userRegistration.RegisterUser(user);
        bool result = userRegistration.RegisterUser(user);
        Assert.IsFalse(result);
    }
    
}
