using WePostIt.API.Abstract;
using WePostIt.API.Domain;
using WePostIt.API.DTOs;

namespace WePostIt.API.Repositories
{
    public class MessageRepository : IMessageRespositoy
    {
        public Message? Create(CreateMessageDTO message)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetAll()
        {
            throw new NotImplementedException();
        }

        public Message? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Message? Update(int id, UpdateMessageDTO message)
        {
            throw new NotImplementedException();
        }
    }
}
