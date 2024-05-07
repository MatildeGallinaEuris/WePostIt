namespace WePostIt.API.Domain
{
    public interface ISoftDeleteEntity
    {
        bool IsDeleted { get; set; }
    }
}
