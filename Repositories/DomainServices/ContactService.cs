using System.Collections.Generic;
using Repositories.Models.Domain;
using Repositories.Repositories;

namespace Repositories.DomainServices
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public List<Contact> GetAllContacts()
        {
            return _contactRepository.GetAllContacts();
        }

        public Contact GetContact(int id)
        {
            var contact = _contactRepository.GetContact(id);
            return contact;
        }

        public void CreateContact(Contact contact)
        {
           _contactRepository.CreateContact(contact);
        }

        public void DeleteContact(int id)
        {
           _contactRepository.DeleteContact(id);
        }

        public void UpdateContact(Contact contact)
        {
           _contactRepository.UpdateContact(contact);
        }

        public void DisableContact(Contact contact)
        {
            contact.IsActive = false;
            UpdateContact(contact);
        }

        public void EnableContact(Contact contact)
        {
            contact.IsActive = true;
            UpdateContact(contact);
        }
    }
}