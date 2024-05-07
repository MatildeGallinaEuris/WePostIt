using WePostIt.API.Domain;
using WePostIt.API.DTOs;

namespace WePostIt.API.Abstract
{
    public interface IMessageRespositoy
    {
        IEnumerable<Message> GetAll();
        Message? GetById(int id);
        Message? Create(CreateMessageDTO message);
        Message? Update(int id, UpdateMessageDTO message);
        bool Delete(int id);
        bool SoftDelete(int id);
    }
}
