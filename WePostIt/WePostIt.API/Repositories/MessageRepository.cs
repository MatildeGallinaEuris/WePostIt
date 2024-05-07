using Microsoft.EntityFrameworkCore;
using WePostIt.API.Abstract;
using WePostIt.API.Data;
using WePostIt.API.Domain;
using WePostIt.API.DTOs;

namespace WePostIt.API.Repositories
{
    public class MessageRepository(WePostIdDbContext context) : IMessageRespositoy
    {
        private readonly WePostIdDbContext context = context;

        public async Task<Message?> Create(CreateMessageDTO message)
        {
            Message newMessage = new()
            {
                Text = message.Text,
                AuthorId = message.AuthorId
            };

            context.Messages.Add(newMessage);
            context.SaveChanges();

            return await GetById(newMessage.Id ?? 0);
        }

        public async Task<bool> Delete(int id)
        {
            Message? message = await GetById(id);
            
            bool founded = message is not null;
            if (founded)
            {
                context.Messages.Remove(message!);
                context.SaveChanges();
            }
            return founded;
        }

        public async Task<bool> SoftDelete(int id)
        {
            Message? toUpdate = await GetById(id);
            if (toUpdate is not null)
            {
                toUpdate.IsDeleted = true;
                toUpdate.UpdateTime = DateTime.Now;

                context.Messages.Update(toUpdate);
                context.SaveChanges();
            }

            return toUpdate is not null;
        }

        public async Task<IEnumerable<Message>> GetAll()
        {
            return await context.Messages
                .Where(message => !message.IsDeleted)
                .ToListAsync();
        }

        public async Task<Message?> GetById(int id)
        {
            return await context.Messages.FirstOrDefaultAsync(
                message => message.Id == id && !message.IsDeleted);
        }

        public async Task<Message?> Update(int id, UpdateMessageDTO message)
        {
            Message? toUpdate = await GetById(id);
            if (toUpdate is not null)
            {
                toUpdate.Text = message.Text;
                toUpdate.UpdateTime = DateTime.Now;

                context.Messages.Update(toUpdate);
                context.SaveChanges();
            }

            return await GetById(id);
        }
    }
}
