namespace CustomerCommLib
{
    public class CustomerComm
    {
        private readonly IMailSender _mailSender;

        public CustomerComm(IMailSender mailSender)
        {
            _mailSender = mailSender;
        }

        public bool SendMailToCustomer()
        {
            return _mailSender.SendMail("cust123@abc.com", "Some Message");
        }

        public bool SendMailToCustomer(string toAddress, string message)
        {
            return _mailSender.SendMail(toAddress, message);
        }
    }
}
