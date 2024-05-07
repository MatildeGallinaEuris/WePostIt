using WePostIt.API.Domain;
using WePostIt.API.DTOs;

namespace WePostIt.API.Abstract
{
    public interface IMessageRespositoy
    {
        Task<IEnumerable<Message>> GetAll();
        Task<Message?> GetById(int id);
        Task<Message?> Create(CreateMessageDTO message);
        Task<Message?> Update(int id, UpdateMessageDTO message);
        Task<bool> Delete(int id);
        Task<bool> SoftDelete(int id);
    }
}
