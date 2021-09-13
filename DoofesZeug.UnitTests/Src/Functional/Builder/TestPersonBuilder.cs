﻿using DoofesZeug.Entities.Specieses;
using DoofesZeug.Entities.Specieses.Human;
using DoofesZeug.Entities.Specieses.Human.Professions;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Builder
{
    [TestClass]
    public class TestPersonBuilder
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Person person = PersonBuilder.New().
                WithDateOfBirth((01, 01, 1998)).
                WithFirstName("John").
                WithLastName("Doe").
                WithGender(Gender.Male).
                WithHandedness(Handedness.Both).
                WithProfession(new FireFighter());

            Assert.IsNotNull(person);
        }
    }
}