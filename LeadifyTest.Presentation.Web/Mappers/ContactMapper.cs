using System.Collections.Generic;
using AutoMapper;
using LeadifyTest.Entities;
using LeadifyTest.Presentation.Web.Models;

namespace LeadifyTest.Presentation.Web.Mappers
{
    public static partial class ApplicationMappings
    {
        private static void ConfigureMapper(string profile)
        {
            Mapper.Initialize(c => c.AddProfile<ApplicationProfiles>());
            Mapper.AssertConfigurationIsValid();
        }

        public static ContactViewModel MapToViewModel(this Contact item)
        {
            ConfigureMapper("ContactProfiles");
            ContactViewModel viewModel = new ContactViewModel();
            viewModel = Mapper.Map<Contact, ContactViewModel>(item);
            return viewModel;
        }

        public static Contact MapToModel(this ContactViewModel item)
        {
            ConfigureMapper("ContactProfiles");
            Contact model = new Contact();
            model = Mapper.Map<ContactViewModel, Contact>(item);
            return model;
        }

        public static List<ContactViewModel> MapToViewModelList(this List<Contact> list)
        {
            ConfigureMapper("ContactProfiles");
            var modelList = new List<ContactViewModel>();
            foreach (var model in list)
            {
                ContactViewModel Contact = Mapper.Map<Contact, ContactViewModel>(model);
                modelList.Add(Contact);
            }
            return modelList;
        }

        public static List<Contact> MapToModelList(this List<ContactViewModel> list)
        {
            ConfigureMapper("ContactProfiles");
            var modelList = new List<Contact>();
            foreach (var model in list)
            {
                Contact Contact = Mapper.Map<ContactViewModel, Contact>(model);
                modelList.Add(Contact);
            }
            return modelList;
        }
    }
}