using Moq;
using NUnit.Framework;
using CustomerCommLib;

namespace HandsOn.Tests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> _mailSenderMock;
        private CustomerComm _customerComm;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _mailSenderMock = new Mock<IMailSender>();
            _mailSenderMock.Setup(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            _customerComm = new CustomerComm(_mailSenderMock.Object);
        }

        [TestCase]
        public void SendMailToCustomer_ShouldReturnTrue()
        {
            bool result = _customerComm.SendMailToCustomer();

            Assert.That(result, Is.True);
            _mailSenderMock.Verify(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
