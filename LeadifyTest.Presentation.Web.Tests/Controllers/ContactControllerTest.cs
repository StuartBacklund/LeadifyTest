using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeadifyTest.Presentation.Web;
using LeadifyTest.Presentation.Web.Controllers;
using Moq;
using LeadifyTest.Services;
using LeadifyTest.Entities;

namespace LeadifyTest.Presentation.Web.Tests.Controllers
{
    [TestClass]
    public class ContactControllerTest
    {
        private Mock<IContactService> _contactServiceMock;
        private ContactController objController;
        private List<Contact> listContact;

        [TestInitialize]
        public void Initialize()
        {
            _contactServiceMock = new Mock<IContactService>();

            listContact = new List<Contact>() {
                                    new Contact() {
                                        ContactId = Guid.NewGuid(),
                                        Firstname = "Test1"
                                    },
                                    new Contact() {
                                        ContactId =  Guid.NewGuid(),
                                        Firstname = "Test2"
                                    },
                                    new Contact() {
                                        ContactId =  Guid.NewGuid(),
                                        Firstname = "Test3"
                                    }
                                };

            _contactServiceMock.Setup(f => f.GetAllContacts()).Returns(listContact);
            objController = new ContactController(_contactServiceMock.Object);
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            ContactController controller = objController;
            // Act
            var result = controller.Index() as ActionResult;
            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Details()
        {
            // Arrange
            ContactController controller = objController;
            var contact = listContact.First();
            // Act
            var result = controller.Details(contact.ContactId) as ActionResult;
            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Edit()
        {
            // Arrange
            ContactController controller = objController;
            var contact = listContact.First();
            // Act
            ActionResult result = controller.Edit(contact.ContactId) as ActionResult;
            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }
    }
}