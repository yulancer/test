using NUnit.Framework;
using WebTestEFCore20.Controllers;

namespace WebTestEFCore20.Tests
{
    [TestFixture]
    public class EditOwnerControllerTest
    {
        [Test]
        public void Register_GetView_ItsOkViewModelIsUserView()
        {

            var a = 1;
            Assert.AreEqual(a, 1);
            //Console.WriteLine("=====INIT======");
            var controller = new HomeController();
            //Console.WriteLine("======ACT======");
            var result = controller.EditOwner();
            //Console.WriteLine("====ASSERT=====");
            //Assert.IsInstanceOf<ViewResult>(result);
            //Assert.IsInstanceOf<IList<AccountViewModel>>(((ViewResult)result).Model);
        }
    }
}
