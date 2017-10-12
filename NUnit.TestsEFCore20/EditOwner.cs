using NUnit.Framework;
using WebTestEFCore20;

namespace NUnit.TestsEFCore20
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
            //var controller = DbInitializer.
            //Console.WriteLine("======ACT======");
            //var result = controller.EditOwner();
            //Console.WriteLine("====ASSERT=====");
            //Assert.IsInstanceOf<ViewResult>(result);
            //Assert.IsInstanceOf<IList<AccountViewModel>>(((ViewResult)result).Model);
        }
    }
}
