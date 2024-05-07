namespace WePostIt.API.Domain
{
    public class Author(
            int? id,
            string name = "",
            string surname = "",
            string email = "",
            DateTime? creationTime = null,
            DateTime? updateTime = null) 
        : EntityBase(id, creationTime, updateTime)
    {
        public string Name { get; set; } = name;
        public string Surname { get; set; } = surname;
        public string Email { get; set; } = email;

        public Author()
            : this(
                  null, 
                  string.Empty, 
                  string.Empty, 
                  string.Empty, 
                  null, 
                  null)
        { }
    }
}
