using Moq;
using NUnit.Framework;
using CustomerCommLib;

namespace CustomerCommTests
{
    [TestFixture]
    public class CustomerCommTest
    {
        private Mock<IMailSender> mockMailSender;
        private CustomerComm customerComm;

        [OneTimeSetUp]
        public void Init()
        {
            mockMailSender =
                new Mock<IMailSender>();

            mockMailSender
                .Setup(x =>
                    x.SendMail(
                        It.IsAny<string>(),
                        It.IsAny<string>()))
                .Returns(true);

            customerComm =
                new CustomerComm(
                    mockMailSender.Object);
        }

        [TestCase]
        public void SendMailToCustomer_Test()
        {
            bool result =
                customerComm.SendMailToCustomer();

            Assert.That(
                result,
                Is.True);
        }
    }
}