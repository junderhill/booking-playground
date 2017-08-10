namespace BookingTDD.Command
{
    public interface ISendEmail
    {
        void SendEmail(string to, string messageBody);
    }
}