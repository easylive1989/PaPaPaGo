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
    }
}