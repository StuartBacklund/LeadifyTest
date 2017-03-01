using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using LeadifyTest.Data;
using LeadifyTest.Presentation.Web.Models;

namespace LeadifyTest.Presentation.Web.Mappers
{
    public class ApplicationProfiles : Profile
    {
        public ApplicationProfiles()
        {
            CreateMap<Contact, ContactViewModel>();
            CreateMap<ContactViewModel, Contact>();
        }
    }
}