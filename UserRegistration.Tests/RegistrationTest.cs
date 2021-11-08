
using UserRegistration.Web.Data;
using UserRegistration.Web.Models;
using Xunit;

namespace UserRegistration.Tests
{
    public class RegistrationTest
    {
       [Fact]
        public void CanRegister()
        {
            var testClass = new RegistrationRepository();
            UserModel testData = new UserModel { UserID = 1, FirstName = "Pawan", LastName = "Choudhary" };
            var result = testClass.Register(testData);
            Assert.True(result);
        }
    }
}
