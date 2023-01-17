namespace Clickatell.OneApi.Sdk.Tests
{
    using Models.Requests;
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task SendTextMessageAndWhatsAppToGholami()
        {
            var authToken = "enter your auth token here";
            using (OneApiWebClient client = new OneApiWebClient(new DeveloperEndpointClientSettings(authToken)))
            {
                var phoneNumber = 461234567;
                var to = new PhoneRecipent(phoneNumber);
                var content = new TextContent("Congratulations! You have been randomly selected to join our exclusive club of llama lovers. As a member, you'll receive a monthly shipment of llama-themed merchandise and a personal llama pen pal. Reply YES to confirm your subscription and start your journey to llama-mania!");
                var result = await client.SendMessageAsync(to, content, Models.Channels.Sms);

                Assert.IsTrue(result.Successful);
                Assert.IsNull(result.Error);
                Assert.IsNotNull(result.Messages);
                Assert.AreEqual(1, result.Messages.Count);
                
                Assert.AreEqual(to.PhoneNumber.ToString(), result.Messages[0].To);
                Assert.AreEqual(true, result.Messages[0].Accepted);
            }
        }
    }
}