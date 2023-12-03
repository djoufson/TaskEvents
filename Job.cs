using System.Diagnostics;
using CommunityToolkit.Mvvm.Messaging;

namespace TaskEvents;

public class Job : IJob
{
    private readonly CancellationTokenSource _cts = new();
    private readonly Queue<Message> _messages = new();

    public Job()
    {
        WeakReferenceMessenger.Default.Register<Message>(this, HandleMessageReceived);
    }

    private void HandleMessageReceived(object sender, Message payload)
    {
        _messages.Enqueue(payload);
    }

    public Task Start()
    {
        return Run(_cts.Token);
    }

    private Task Run(CancellationToken token)
    {
        return Task.Run(() =>
        {
            while (!token.IsCancellationRequested)
            {
                if(_messages.Count != 0)
                {
                    var message = _messages.Dequeue();
                    Debug.WriteLine($"Thread {Environment.CurrentManagedThreadId}: {message.Value}");
                }
                else
                {
                    Debug.WriteLine($"Thread {Environment.CurrentManagedThreadId}: Nothing in the queue");
                }
                Thread.Sleep(1500);
            }
        }, token);
    }

    public Task Stop()
    {
        _cts.Cancel();
        return Task.CompletedTask;
    }
}
