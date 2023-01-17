namespace Clickatell.OneApi.Sdk.Models.Requests
{
    public interface IRecipent
    {
        string To { get; }
    }

    public class PhoneRecipent : IRecipent
    {
        public PhoneRecipent(long phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        string IRecipent.To => PhoneNumber.ToString();

        public long PhoneNumber { get; }
    }
}
