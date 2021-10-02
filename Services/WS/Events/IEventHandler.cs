namespace WS.Events
{
    public interface IEventHandler<in T, out TR> 
    {
        TR Handle(T theEvent);
    }
}