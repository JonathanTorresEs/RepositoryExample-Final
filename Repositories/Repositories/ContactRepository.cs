using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Repositories.Models;
using Repositories.Models.Domain;
using Repositories.Models.Entities;

namespace Repositories.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DatabaseContext dbcontext;

        public ContactRepository()
        {
            dbcontext = new DatabaseContext();
        }

        public List<Contact> GetAllContacts()
        {
            var contacts = dbcontext.Contacts.ToList();
            return contacts.Select(c => AutoMapper.Mapper.Map<Contact>(c)).ToList();
        }

        public Contact GetContact(int id)
        {
            var c = dbcontext.Contacts.Find(id);
            var r = AutoMapper.Mapper.Map<Contact>(c);
            return r;
        }

        public void CreateContact(Contact contact)
        {
            var entity = AutoMapper.Mapper.Map<ContactEntity>(contact);
            dbcontext.Contacts.Add(entity);
            dbcontext.SaveChanges();
        }

        public void DeleteContact(int id)
        {
            var entity = new ContactEntity()
            {
                Id = id
            };

            dbcontext.Entry(entity).State = EntityState.Deleted;
            dbcontext.SaveChanges();
        }

        public void UpdateContact(Contact contact)
        {
            var entity = AutoMapper.Mapper.Map<ContactEntity>(contact);
            dbcontext.Set<ContactEntity>().AddOrUpdate(entity);
            dbcontext.SaveChanges();
        }
    }
}