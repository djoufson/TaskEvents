using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace TaskEvents;

public class ViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    private string _textMessage = string.Empty;
    public string TextMessage
    {
        get => _textMessage;
        set => SetValue(ref _textMessage, value);
    }
    public ICommand SendEventCommand { get; private set; }
    public ViewModel()
    {
        SendEventCommand = new Command(SendEvent);
    }

    private void SendEvent()
    {
        Debug.WriteLine("Clicked");
    }

    private void SetValue<T>(ref T property, T value, [CallerMemberName] string propertyName = "")
    {
        if (Equals(property,value))
            return;
        property = value;
        OnPropertyChanged(propertyName);
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
