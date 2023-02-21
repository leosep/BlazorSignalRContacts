using BlazorContacts.Models;

namespace BlazorContacts.Services
{
    public interface IContactService
    {
        Task<bool> AddUpdate(Contact contact);

        Task<bool> Delete(Guid id);

        Task<Contact> FindById(Guid id);

        Task<List<Contact>> GetAll();
    }
}
