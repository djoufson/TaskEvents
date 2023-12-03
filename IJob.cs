namespace TaskEvents;

public interface IJob
{
    Task Start();
    Task Stop();
}
