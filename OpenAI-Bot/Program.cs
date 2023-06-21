// See https://aka.ms/new-console-template for more information

using System.Runtime.Serialization;
using OpenAI_API.Models;
using OpenAI_Bot;


Console.WriteLine("Welcome to my Bot");
Console.WriteLine("To Stop Chatting enter Stop");
bool status = true;
while (status)
{
    string prompt = Console.ReadLine();
    if(prompt.ToLower() == "stop")
    {
        Console.WriteLine("Thank You for Using this OPenAi-Service"); break;
    }
    Service service = new Service();
    Choice datax = service.SendRequest("Emmn");
    Console.WriteLine(datax.Message.content.ToString());
}

