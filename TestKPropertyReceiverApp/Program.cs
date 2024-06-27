// See https://aka.ms/new-console-template for more information

using TestKPropertyReceiverApp;

Console.WriteLine("Welcome to KPropValue Receiver app!");

var connection = new Connection();

await connection.ConnectToChatAsync();

Console.WriteLine("Press ENTER to stop & exit.");

Console.ReadLine();