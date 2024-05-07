using WePostIt.API.Domain;
using WePostIt.API.DTOs;

namespace WePostIt.API.Abstract
{
    public interface IMessageRespositoy
    {
        // getAll
        IEnumerable<Message> GetAll();
        // get by id
        Message? GetById(int id);
        // create
        Message? Create(CreateMessageDTO message);
        // update
        Message? Update(int id, UpdateMessageDTO message);
        // delete
        bool Delete(int id);
    }
}
