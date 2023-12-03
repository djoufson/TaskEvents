using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace TaskEvents;

public partial class ViewModel : ObservableObject
{
    [RelayCommand]
    private static void SendEvent()
    {
        WeakReferenceMessenger.Default.Send(new Message($"Message sent from thread: {Environment.CurrentManagedThreadId}"));
    }
}
