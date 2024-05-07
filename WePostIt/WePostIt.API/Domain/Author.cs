namespace WePostIt.API.Domain
{
    public class Author : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public Author(
        int? id,
        string name = "",
        string surname = "",
        string email = "",
        DateTime? creationTime = null,
        DateTime? updateTime = null)
            : base(id, creationTime, updateTime) 
        { 
            Name = name; 
            Surname = surname;
            Email = email;
        }

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
