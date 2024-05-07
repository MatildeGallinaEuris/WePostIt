namespace WePostIt.API.Domain
{
    public abstract class EntityBase
    {
        public int? Id { get; set; }
        public DateTime? CreationTime { get; set; }
        public DateTime? UpdateTime { get; set; }

        public EntityBase(
            int? id = default,
            DateTime? creationTime = null,
            DateTime? updateTime = null)
        {
            Id = id;
            CreationTime = creationTime;
            UpdateTime = updateTime;
        }
    }
}
