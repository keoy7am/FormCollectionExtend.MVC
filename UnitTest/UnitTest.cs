using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using FormCollectionExtend.MVC;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        /// <summary>
        /// List Count
        /// </summary>
        int ListCount = 2;

        #region TestMethod

        /// <summary>
        /// Convert FormCollection To Single Object.
        /// </summary>
        [TestMethod]
        public void ToSingleObjectTest()
        {
            // Arrange
            FormCollection Stub = CreateTestData();

            // Act
            TestModel Test = Stub.ToSingleObject<TestModel>();

            // Assert
            Assert.AreEqual(Test.Name.ToString(), TestData.Name.ToString());
            Assert.AreEqual(Test.age, TestData.age);
            Assert.AreEqual(Test.PhoneNumber, TestData.PhoneNumber);
            Assert.AreEqual(Test.Married, TestData.Married);
            Assert.AreEqual(Test.CreatedDateTime, TestData.CreatedDateTime);
        }
        /// <summary>
        /// ToSingleObjectTestWithDictionary
        /// </summary>
        [TestMethod]
        public void ToSingleObjectTestWithDictionary()
        {
            // Arrange
            FormCollection Stub = CreateTestDataWithDifferentNaming();
            Dictionary<string, string> MappingDictionary = CreateMappingDictionary();

            // Act
            TestModel Test = Stub.ToSingleObject<TestModel>(MappingDictionary);

            // Assert
            Assert.AreEqual(Test.Name.ToString(), TestData.Name.ToString());
            Assert.AreEqual(Test.age, TestData.age);
            Assert.AreEqual(Test.PhoneNumber, TestData.PhoneNumber);
            Assert.AreEqual(Test.Married, TestData.Married);
            Assert.AreEqual(Test.CreatedDateTime, TestData.CreatedDateTime);
        }

        /// <summary>
        /// 將FormCollection轉為List形別物件
        /// </summary>
        [TestMethod]
        public void ToListObjectTest()
        {
            // Arrange
            FormCollection Stub = CreateTestDataSet();
            string PrimaryKeyName = "Name";
            // Act
            List<TestModel> Test = Stub.ToListObject<TestModel>(PrimaryKeyName);

            //Assert
            Assert.AreEqual(Test.Count, ListCount);

            foreach (var i in Test)
            {
                Assert.AreEqual(i.Name.ToString(), TestData.Name.ToString());
                Assert.AreEqual(i.age, TestData.age);
                Assert.AreEqual(i.PhoneNumber, TestData.PhoneNumber);
                Assert.AreEqual(i.Married, TestData.Married);
                Assert.AreEqual(i.CreatedDateTime, TestData.CreatedDateTime);
            }
        }

        /// <summary>
        /// 將FormCollection轉為List形別物件 ( 例外對映 )
        /// </summary>
        [TestMethod]
        public void ToListObjectWithDictionary()
        {
            // Arrange
            FormCollection Stub = CreateTestDataSetWithDifferentNaming();
            Dictionary<string, string> MappingDictionary = CreateMappingDictionary();
            string PrimaryKeyName = "Name111";

            // Act
            List<TestModel> Test = Stub.ToListObject<TestModel>(MappingDictionary, PrimaryKeyName);

            // Assert
            foreach (var i in Test)
            {
                Assert.AreEqual(i.Name.ToString(), TestData.Name.ToString());
                Assert.AreEqual(i.age, TestData.age);
                Assert.AreEqual(i.PhoneNumber, TestData.PhoneNumber);
                Assert.AreEqual(i.Married, TestData.Married);
                Assert.AreEqual(i.CreatedDateTime, TestData.CreatedDateTime);
            }
        }

        #endregion

        #region DataSource

        /// <summary>
        /// Create FormCollection and add TestData.
        /// </summary>
        /// <returns>TestData</returns>
        FormCollection CreateTestData()
        {
            FormCollection Stub = new FormCollection();
            Stub.Add("Name", $"{TestData.Name}");
            Stub.Add("age", $"{TestData.age}");
            Stub.Add("PhoneNumber", $"{TestData.PhoneNumber}");
            Stub.Add("Married", $"{TestData.Married}");
            Stub.Add("CreatedDateTime", $"{TestData.CreatedDateTime}");
            Stub.Add("ModifyDateTime", $"{TestData.ModifyDateTime}");
            return Stub;
        }

        /// <summary>
        /// Create FormCollection and add TestDataWithDifferentNaming.
        /// </summary>
        /// <returns>TestData</returns>
        FormCollection CreateTestDataWithDifferentNaming()
        {
            FormCollection Stub = new FormCollection();
            Stub.Add("Name111", $"{TestData.Name}");
            Stub.Add("age222", $"{TestData.age}");
            Stub.Add("PhoneNumber333", $"{TestData.PhoneNumber}");
            Stub.Add("Married444", $"{TestData.Married}");
            Stub.Add("CreatedDateTime555", $"{TestData.CreatedDateTime}");
            Stub.Add("ModifyDateTime666", $"{TestData.ModifyDateTime}");
            return Stub;
        }

        /// <summary>
        /// Create FormCollection and add Test Data Set.
        /// </summary>
        /// <returns>TestData</returns>
        FormCollection CreateTestDataSet()
        {
            FormCollection Stub = new FormCollection();

            for (int i = 1; i <= ListCount; i++)
            {
                Stub.Add("Name", $"{TestData.Name}");
                Stub.Add("age", $"{TestData.age}");
                Stub.Add("PhoneNumber", $"{TestData.PhoneNumber}");
                Stub.Add("Married", $"{TestData.Married}");
                Stub.Add("CreatedDateTime", $"{TestData.CreatedDateTime}");
                Stub.Add("ModifyDateTime", $"{TestData.ModifyDateTime}");
            }
            return Stub;
        }

        /// <summary>
        /// Create FormCollection and add Test Data Set With Different Naming.
        /// </summary>
        /// <returns>TestData</returns>
        FormCollection CreateTestDataSetWithDifferentNaming()
        {
            FormCollection Stub = new FormCollection();
            for (int i = 1; i <= ListCount; i++)
            {
                Stub.Add("Name111", $"{TestData.Name}");
                Stub.Add("age222", $"{TestData.age}");
                Stub.Add("PhoneNumber333", $"{TestData.PhoneNumber}");
                Stub.Add("Married444", $"{TestData.Married}");
                Stub.Add("CreatedDateTime555", $"{TestData.CreatedDateTime}");
                Stub.Add("ModifyDateTime666", $"{TestData.ModifyDateTime}");
            }
            return Stub;
        }
        /// <summary>
        /// Create Mapping Dictionary.
        /// </summary>
        /// <returns>Mapping Dictionary</returns>
        Dictionary<string, string> CreateMappingDictionary()
        {
            // Setting up mapping dictionary.
            // Ex. Key.Add( "Model field", "Form name" );
            Dictionary<string, string> Dictionary = new Dictionary<string, string>();
            Dictionary.Add("Name", "Name111");
            Dictionary.Add("age", "age222");
            Dictionary.Add("PhoneNumber", "PhoneNumber333");
            Dictionary.Add("Married", "Married444");
            Dictionary.Add("CreatedDateTime", "CreatedDateTime555");
            Dictionary.Add("ModifyDateTime", "ModifyDateTime666");
            return Dictionary;
        }

        #endregion
    }
}
