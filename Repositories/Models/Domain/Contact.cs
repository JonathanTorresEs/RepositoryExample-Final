using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repositories.Models.Domain
{
    public class Contact
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }

        public string FullName => Name +" "+ LastName;
    }
}