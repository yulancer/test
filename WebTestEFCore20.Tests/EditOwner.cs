using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using WebTestEFCore20.Controllers;
using WebTestEFCore20.Models;

namespace WebTestEFCore20.Tests
{
    [TestFixture]
    public class EditOwnerControllerTest
    {
        [Test]
        public void Register_GetView_ItsOkViewModelIsUserView()
        {
            AccountOwner owner7876Old;
            AccountOwner owner5678Old;
            using (TestDbContext context = new TestDbContext())
            {
                Account acc5678 = context.Accounts
                    .Include(a => a.Owner).FirstOrDefault(a => a.Number == 5678);
                Account acc7876 = context.Accounts
                    .Include(a => a.Owner).FirstOrDefault(a => a.Number == 7876);

                Assert.NotNull(acc7876, "Не найден счет с номером 7876");
                Assert.NotNull(acc5678, "Не найден счет с номером 5678");

                owner7876Old = acc7876.Owner;
                owner5678Old = acc5678.Owner;

                Assert.NotNull(owner7876Old, "Для счета с номером 7876 не указан владелец");
                Assert.NotNull(owner5678Old, "Для счета с номером 5678 не указан владелец");
            }

            var controller = new HomeController();
            var result = controller.EditOwner();

            using (TestDbContext context = new TestDbContext())
            {
                Account acc5678 = context.Accounts
                    .Include(a => a.Owner).FirstOrDefault(a => a.Number == 5678);
                Account acc7876 = context.Accounts
                    .Include(a => a.Owner).FirstOrDefault(a => a.Number == 7876);

                AccountOwner owner7876New = acc7876.Owner;
                AccountOwner owner5678New = acc5678.Owner;

                Assert.NotNull(owner7876New, "У счета с номером 7876 потерялся владелец");
                Assert.NotNull(owner5678New, "У счета с номером 5678 потерялся владелец");

                Assert.AreEqual(owner7876Old.Id, owner5678New.Id
                    , "У счета с номером 5678 владелец поменялся неправильно");
                Assert.AreEqual(owner5678Old.Id, owner7876New.Id
                    , "У счета с номером 7876 владелец поменялся неправильно");
            }
        }
    }
}
