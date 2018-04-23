using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using FormCollectionExtend.MVC;
using System.Diagnostics;
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
        /// 將FormCollection轉為單一物件
        /// </summary>
        [TestMethod]
        public void ToSingleObjectTest()
        {
            // Arrange
            FormCollection Stub = TestDate();

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
        /// 將FormCollection轉為單一物件 ( 例外對映 )
        /// </summary>
        [TestMethod]
        public void ToSingleObjectTestWithDictionary()
        {
            // Arrange
            FormCollection Stub = TestDateWithDifferentNaming();
            Dictionary<string, string> Key = GetKey();

            // Act
            TestModel Test = Stub.ToSingleObject<TestModel>(Key);

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
            FormCollection Stub = TestDateWithListType();
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
            FormCollection Stub = TestDateWithListTypeAndDifferentNaming();
            Dictionary<string, string> Key = GetKey();
            string PrimaryKeyName = "Name111";

            // Act
            List<TestModel> Test = Stub.ToListObject<TestModel>(Key, PrimaryKeyName);

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
        /// Create FormCollection and added TestData
        /// </summary>
        /// <returns>TestDate(Type:FormCollection)</returns>
        FormCollection TestDate()
        {
            // 模擬後端接值時的FormCollection集合
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
        /// Create FormCollection and added TestDateWithDifferentNaming
        /// </summary>
        /// <returns>TestDate(Type:FormCollection)</returns>
        FormCollection TestDateWithDifferentNaming()
        {
            // 模擬後端接值時的FormCollection集合 (前端欄位Name與後端物件屬性不同時)
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
        /// Create FormCollection and added TestDateWithListType
        /// </summary>
        /// <returns>TestDate(Type:FormCollection)</returns>
        FormCollection TestDateWithListType()
        {
            // 模擬後端接值時的FormCollection集合
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
        /// Create FormCollection and added TestDateWithListTypeAndDifferentNaming
        /// </summary>
        /// <returns>TestDate(Type:FormCollection)</returns>
        FormCollection TestDateWithListTypeAndDifferentNaming()
        {
            // 模擬後端接值時的FormCollection集合 (前端欄位Name與後端物件屬性不同時)
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
        /// 設定對映
        /// </summary>
        /// <returns>對映字典</returns>
        Dictionary<string, string> GetKey()
        {
            // 建立 前端欄位Name與後端物件屬性 對映字典
            // Key.Add( "後端物件屬性", "前端欄位Name" );
            Dictionary<string, string> Key = new Dictionary<string, string>();
            Key.Add("Name", "Name111");
            Key.Add("age", "age222");
            Key.Add("PhoneNumber", "PhoneNumber333");
            Key.Add("Married", "Married444");
            Key.Add("CreatedDateTime", "CreatedDateTime555");
            Key.Add("ModifyDateTime", "ModifyDateTime666");
            return Key;
        }

        #endregion
    }
}
