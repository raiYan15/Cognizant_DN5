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
            string email =
                "cust123@abc.com";

            string message =
                "Welcome Customer";

            _mailSender.SendMail(
                email,
                message);

            return true;
        }
    }
}