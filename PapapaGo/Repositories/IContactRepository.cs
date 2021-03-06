﻿using System.Collections.Generic;
using System.Threading.Tasks;
using PapapaGo.Sample;

namespace PapapaGo.Repositories
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetContactsAsync();
        Task<Contact> GetContactAsync(string email);
        Task<int> CreateContactAsync(Contact contact);
    }
}
