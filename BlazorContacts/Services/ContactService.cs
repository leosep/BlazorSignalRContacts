using BlazorContacts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BlazorContacts.Services
{
    public class ContactService : IContactService
    {
        private readonly IDbContextFactory<DatabaseContext> _dbContextFactory;
        
        public ContactService(IDbContextFactory<DatabaseContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<bool> AddUpdate(Contact contact)
        {
            using var _ctx = _dbContextFactory.CreateDbContext();
            try
            {
                if(contact.Id==Guid.Empty)
                    await _ctx.Contacts.AddAsync(contact);
                else
                    _ctx.Contacts.Update(contact);
                
                await _ctx.SaveChangesAsync();
                return true;

            } catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            using var _ctx = _dbContextFactory.CreateDbContext();
            try
            {
                var contact = await FindById(id);
                if (contact == null)
                    return false;

                _ctx.Contacts.Remove(contact);  
                await _ctx.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Contact> FindById(Guid id)
        {
            using var _ctx = _dbContextFactory.CreateDbContext();
            return await _ctx.Contacts.FindAsync(id);
        }

        public async Task<List<Contact>> GetAll()
        {
            using var _ctx = _dbContextFactory.CreateDbContext();
            return await _ctx.Contacts.ToListAsync();
        }
    }
}
