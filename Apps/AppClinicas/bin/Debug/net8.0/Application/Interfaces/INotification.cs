public interface INotification
{
    TypeNotification Type { get; }
    TypeNotification get_Type();
    Void SendNotification(IMessage menssege);
}
