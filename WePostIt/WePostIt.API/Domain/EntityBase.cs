namespace WePostIt.API.Domain
{
    public abstract class EntityBase(
        int? id = default,
        DateTime? creationTime = null,
        DateTime? updateTime = null)
    {
        public int? Id { get; set; } = id;
        public DateTime? CreationTime { get; set; } = creationTime;
        public DateTime? UpdateTime { get; set; } = updateTime;
    }
}
