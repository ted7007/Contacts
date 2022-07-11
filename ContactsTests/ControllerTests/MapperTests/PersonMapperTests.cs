using Contacts.Controller.Mapper;
using Contacts.DTO;
using Contacts.Service.util;
using SemanticComparison;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsTests.ControllerTests.MapperTests
{
    [TestClass]
    public class PersonMapperTests
    {
        [TestMethod]
        public void Mapt_DtoToCreationArgumentCompareTwoEqualObjectsTest()
        {
            //Arrange
            PersonMapper mapper = new PersonMapper();
            PersonDTO dto = new PersonDTO()
            {
                id = 1,
                firstName = "Mike",
                lastName = "Johns",
                middleName = "Johnson",
                address = "Russia",
                birthday = new DateTime(2003, 06, 18),
                discord = "abc#3456",
                email = "cd@mail.ru",
                phoneNumber = "333777",
                placeOfStudy = "FEFU",
                sex = "male",
                vkLink = "abc",
                workplace = "home"
            };
            CreationPersonArgument argument = new CreationPersonArgument()
            {
                firstName = "Mike",
                lastName = "Johns",
                middleName = "Johnson",
                address = "Russia",
                birthday = new DateTime(2003, 06, 18),
                discord = "abc#3456",
                email = "cd@mail.ru",
                phoneNumber = "333777",
                placeOfStudy = "FEFU",
                sex = Contacts.Model.Sex.Male,
                VKLink = "abc",
                workplace = "home"
            };


            //Act
            var result = mapper.Map<PersonDTO, CreationPersonArgument>(dto);
            var lresult = new Likeness<CreationPersonArgument>(result);

            //Assert
            Assert.AreEqual(lresult, argument);
        }

        [TestMethod]
        public void DTOToCreationArgument_CompareTwoDifferentObjectsTest()
        {
            //Arrange
            PersonMapper mapper = new PersonMapper();
            PersonDTO dto = new PersonDTO()
            {
                id = 1,
                firstName = "Mike",
                lastName = "Johns",
                middleName = "Johnson",
                address = "Russia",
                birthday = new DateTime(2003, 06, 18),
                discord = "abc#3456",
                email = "cd@mail.ru",
                phoneNumber = "333777",
                placeOfStudy = "FEFU",
                sex = "male",
                vkLink = "abc",
                workplace = "home"
            };
            CreationPersonArgument argument = new CreationPersonArgument()
            {
                firstName = "Mike",
                lastName = "Johns",
                middleName = "Johnson",
                address = "Russia",
                birthday = new DateTime(2002, 06, 18),
                discord = "abc#3456",
                email = "cd@mail.ru",
                phoneNumber = "333777",
                placeOfStudy = "FEFU",
                sex = Contacts.Model.Sex.Male,
                VKLink = "abc",
                workplace = "home"
            };


            //Act
            var result = mapper.Map<PersonDTO, CreationPersonArgument>(dto);
            var lresult = new Likeness<CreationPersonArgument>(result);

            //Assert
            Assert.AreNotEqual(lresult, argument);
        }
    }
}
