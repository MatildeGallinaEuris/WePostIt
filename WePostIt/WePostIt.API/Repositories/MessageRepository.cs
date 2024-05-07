using WePostIt.API.Abstract;
using WePostIt.API.Data;
using WePostIt.API.Domain;
using WePostIt.API.DTOs;

namespace WePostIt.API.Repositories
{
    public class MessageRepository : IMessageRespositoy
    {
        private readonly WePostIdDbContext context;

        public MessageRepository(WePostIdDbContext context)
        {
            this.context = context;
        }

        public Message? Create(CreateMessageDTO message)
        {
            Message newMessage = new Message
            {
                Text = message.Text,
                AuthorId = message.AuthorId,
                IdDeleted = false
            };

            context.Messages.Add(newMessage);
            context.SaveChanges();

            return GetById(newMessage.Id ?? 0);
        }

        public bool Delete(int id)
        {
            Message? message = GetById(id);
            
            bool founded = message is not null;
            if (founded)
            {
                context.Messages.Remove(message!);
                context.SaveChanges();
            }
            return founded;
        }

        public bool SoftDelete(int id)
        {
            Message? toUpdate = GetById(id);
            if (toUpdate is not null)
            {
                toUpdate.IdDeleted = true;
                context.Messages.Update(toUpdate);
                context.SaveChanges();
            }

            return toUpdate is not null;
        }

        public IEnumerable<Message> GetAll()
        {
            return context.Messages.Where(message => !message.IdDeleted);
        }

        public Message? GetById(int id)
        {
            return context.Messages.FirstOrDefault(
                message => 
                message.Id == id && !message.IdDeleted);
        }

        public Message? Update(int id, UpdateMessageDTO message)
        {
            Message? toUpdate = GetById(id);
            if (toUpdate is not null)
            {
                toUpdate.Text = message.Text;
                context.Messages.Update(toUpdate);
                context.SaveChanges();
            }

            return GetById(id);
        }
    }
}
