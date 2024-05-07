using WePostIt.API.Domain;
using WePostIt.API.DTOs;

namespace WePostIt.API.Abstract
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAll();
        Task<Author?> GetById(int id);
        Task<Author?> Create(CreateAuthorDTO message);
        Task<Author?> Update(int id, UpdateAuthorDTO message);
        Task<bool> Delete(int id);
    }
}
