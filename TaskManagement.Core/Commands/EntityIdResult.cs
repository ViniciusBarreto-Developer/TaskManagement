namespace TaskManagement.Core.Commands
{
    public class EntityIdResult
    {
        public EntityIdResult(object id)
        {
            Id = id;
        }

        public EntityIdResult()
        {

        }

        public object Id { get; set; }
    }
}
