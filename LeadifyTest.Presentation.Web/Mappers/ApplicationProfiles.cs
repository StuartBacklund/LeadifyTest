using AutoMapper;
using LeadifyTest.Entities;
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