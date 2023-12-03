using CommunityToolkit.Mvvm.Messaging.Messages;

namespace TaskEvents;

public class Message : ValueChangedMessage<string>
{
    public Message(string value) : base(value)
    {
    }
}
