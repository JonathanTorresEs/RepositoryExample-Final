using System.Collections.Generic;
using Repositories.Models.Domain;

namespace Repositories.Repositories
{
    public interface IContactRepository
    {
        List<Contact> GetAllContacts();

        Contact GetContact(int id);

        void CreateContact(Contact contact);

        void DeleteContact(int id);

        void UpdateContact(Contact contact);
    }
}