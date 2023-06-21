using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI_Bot
{
    public class Service
    {
        public Choice SendRequest(string promptz)
        {
            HttpClient client = new HttpClient();
            OpenAiSecret model = new OpenAiSecret();
            HttpClientService service = new HttpClientService(client);

            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Authorization",  $"Bearer {model.Key}"}
            };
            List<Message> listMessage = new();
            Message newMessage = new()
            {
                content = promptz,
                role = "user"
            };
            listMessage.Add(newMessage);
            Request request = new()
            {
                model = "gpt-3.5-turbo",
                messages = listMessage
            };
            var response = service.SendAsync<ChatCompletion>(HttpMethod.Post, model.BaseUrl, headers, request);
            
            return response.Result.Choices.FirstOrDefault();
        }
    }
}
