using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadifyTest.Entities
{
    public class Contact : BaseEntity
    {
        public System.Guid ContactId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
    }
}