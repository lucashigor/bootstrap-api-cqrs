namespace AdasIt.{{cookiecutter.project_name}}.Core.ServiceBus
{
    public class MessageQueue
    {
        public class DefaultMessageQueue<T>
        {
            public T OldData { get; set; }
            public T Data { get; set; }
            public CrudAction CrudAction { get; set; }
        }
    }
}
