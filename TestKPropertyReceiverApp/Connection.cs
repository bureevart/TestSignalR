using Microsoft.AspNetCore.SignalR.Client;

namespace TestKPropertyReceiverApp;

public class Connection
{
    private HubConnection _connection = null!;
    private const string HostAddress = "http://192.168.20.202:5008/events";
    public Connection()
    {
        _connection = new HubConnectionBuilder()
            .WithUrl(HostAddress)
            .WithAutomaticReconnect()
            .Build();
    }
    
    public async Task ConnectToChatAsync()
    {
        _connection.On<KPropertyUpdateValueModel>("SendKPropertyValueAsync", (valueModel) =>
        {
            Console.WriteLine($"\nNew value from {HostAddress}\nId: {valueModel.Id}\nValue: {valueModel.Value}\n");
        });
        
        _connection.On<KEvent>("SendEventAsync", (valueModel) =>
        {
            Console.WriteLine($"\n" +
                              $"kEvent was updated - {HostAddress}\n" +
                              $"Id: {valueModel.Id}\n" +
                              $"StateNum: {valueModel.StateNum}\n" +
                              $"StatusNum: {valueModel.StatusNum}\n" +
                              $"Priority: {valueModel.Priority}\n" +
                              $"Message: {valueModel.Message}\n" +
                              $"Source: {valueModel.Source}\n" +
                              $"GenerationTimestamp: {valueModel.GenerationTimestamp}\n" +
                              $"SourceTimestamp: {valueModel.SourceTimestamp}\n" +
                              $"ReactionTimestamp: {valueModel.ReactionTimestamp}\n" +
                              $"Acked: {valueModel.Acked}\n" +
                              $"AckDescription: {valueModel.AckDescription}\n" +
                              $"User: {valueModel.User}\n");
        });

        try
        {
            await _connection.StartAsync();
        }
        catch (Exception ex)
        {
        }
    }
}