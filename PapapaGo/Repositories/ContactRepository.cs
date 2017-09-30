using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PapapaGo.Sample;

namespace PapapaGo.Repositories
{
    public class ContactRepository: BaseRepository, IContactRepository
    {
        protected ContactRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<List<Contact>> GetContactsAsync()
        {
            return (await GetListAsync<Contact>("WHERE 1")).ToList();
        }

        public async Task<Contact> GetContactAsync(string email)
        {
            return (await GetListAsync<Contact>("WHERE email = @email", new {email})).FirstOrDefault();
        }

        public async Task<int> CreateContactAsync(Contact contact)
        {
            return (await InsertAsync(contact)).GetValueOrDefault();
        }
    }
}