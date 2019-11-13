using System.Net.Http;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class MyAsyncMethods
    {
        public static Task<long?> GetPageLength() // Working with tasks Directly
        {
            HttpClient client = new HttpClient();

            var httpTask = client.GetAsync("http://apress.com");

            return httpTask.ContinueWith((Task<HttpResponseMessage> antecedent) => 
            {
                return antecedent.Result.Content.Headers.ContentLength;
            });
        }

        public async static Task<long?> GetPageLengthAsync() // Applying the async and await Keywords
        {
            HttpClient client = new HttpClient();

            var httpMessage = await client.GetAsync("http://apress.com");

            return httpMessage.Content.Headers.ContentLength;
        }
    }
}
