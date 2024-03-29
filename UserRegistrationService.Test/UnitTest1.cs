namespace UserRegistrationService.Test
{

    [TestClass]
    public class UserRegistrationTests
    {
        [TestMethod]
        public void RegisterUser_ValidUsername_ReturnsTrue()
        {
            var userRegistration = new UserRegistration();
            var user = new User("validusername", "Password135", "firstname.lastname@email.com");
            bool result = userRegistration.RegisterUser(user);
            Assert.IsTrue(result);
        }

        
    }
}
