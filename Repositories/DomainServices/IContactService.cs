using System.Collections.Generic;
using Repositories.Models.Domain;

namespace Repositories.DomainServices
{
    public interface IContactService
    {
        List<Contact> GetAllContacts();

        Contact GetContact(int id);

        void CreateContact(Contact contact);

        void DeleteContact(int id);

        void UpdateContact(Contact contact);

        void DisableContact(Contact contact);
        void EnableContact(Contact contact);
    }
}