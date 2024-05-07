using Microsoft.EntityFrameworkCore;
using WePostIt.API.Abstract;
using WePostIt.API.Data;
using WePostIt.API.Domain;
using WePostIt.API.DTOs;

namespace WePostIt.API.Repositories
{
    public class AuthorRepository(WePostIdDbContext context) : IAuthorRepository
    {
        private readonly WePostIdDbContext context = context;

        public async Task<Author?> Create(CreateAuthorDTO author)
        {
            Author newAuthor = new()
            {
                Name = author.Name,
                Surname = author.Surname,
                Email = author.Email,
            };
            
            context.Authors.Add(newAuthor);
            await context.SaveChangesAsync();
            
            return await GetById(newAuthor.Id ?? 0);
        }

        public async Task<bool> Delete(int id)
        {
            Author? author = await GetById(id);
            
            bool founded = author is not null;
            if (founded)
            {
                context.Authors.Remove(author!);
                await context.SaveChangesAsync();
            }

            return founded;
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await context.Authors.ToListAsync();
        }

        public async Task<Author?> GetById(int id)
        {
            return await context.Authors.FindAsync(id);
        }

        public async Task<Author?> Update(int id, UpdateAuthorDTO updateDTO)
        {
            Author? toUpdate = await GetById(id);
            if (toUpdate is not null)
            {
                toUpdate.Name = updateDTO.Name;
                toUpdate.Surname = updateDTO.Surname;
                toUpdate.UpdateTime = DateTime.Now;

                context.Authors.Update(toUpdate);
                context.SaveChanges();
            }

            return await GetById(id);
        }
    }
}
