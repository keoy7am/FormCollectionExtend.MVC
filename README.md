# [FormCollectionExtend.MVC](https://github.com/keoy7am/FormCollectionExtend.MVC) #

MVC FormCollection To Object Extend Library.  
Easy Convert FormCollection To Object.  
Click [here](https://github.com/keoy7am/FormCollectionExtend.MVC/blob/master/UnitTest/UnitTest.cs) to check our UnitTest example.  

### [NuGet](https://www.nuget.org/packages/FormCollectionExtend.MVC/1.0.1) ###
- Package Manager
  - Install-Package FormCollectionExtend.MVC -Version 1.0.1
- .NET CLI
  - dotnet add package FormCollectionExtend.MVC --version 1.0.1

## Features  ##
- Convert FormCollection To Single Object
- Convert FormCollection To Single Object with Mapping Dictionary
- Convert FormCollection To List&lt;Object&gt;
- Convert FormCollection To List&lt;Object&gt; with Mapping Dictionary

## Examples ##

### ToSingleObject(this FormCollection collection) ###

Convert FormCollection To Single Object.

```csharp
            // Arrange
            FormCollection Stub = CreateTestData();

            // Act
            TestModel Test = Stub.ToSingleObject<TestModel>();
```
### ToSingleObject(this FormCollection collection, Dictionary<string, string> MappingDictionary) ###

Convert FormCollection To Single Object with Mapping Dictionary.

```csharp
            // Arrange
            FormCollection Stub = CreateTestDataWithDifferentNaming();
            Dictionary<string, string> MappingDictionary = CreateMappingDictionary();

            // Act
            TestModel Test = Stub.ToSingleObject<TestModel>(MappingDictionary);
```

### ToListObject(this FormCollection collection) ###

Convert FormCollection To List&lt;Object&gt;.

```csharp
            // Arrange
            FormCollection Stub = CreateTestDataSet();
            string PrimaryKeyName = "Name";
            // Act
            List<TestModel> Test = Stub.ToListObject<TestModel>(PrimaryKeyName);
```

### ToListObjectWithMappingDictionary(this FormCollection collection, Dictionary<string, string> MappingDictionary) ###

Convert FormCollection To List&lt;Object&gt; with Mapping Dictionary.

```csharp
            // Arrange
            FormCollection Stub = CreateTestDataSetWithDifferentNaming();
            Dictionary<string, string> MappingDictionary = CreateMappingDictionary();
            string PrimaryKeyName = "Name111";

            // Act
            List<TestModel> Test = Stub.ToListObject<TestModel>(MappingDictionary, PrimaryKeyName);
```

### About Mapping Dictionary ###

Example：
```csharp
Dictionary<string, string> CreateMappingDictionary()
        {
            // Key.Add( "後端物件屬性", "前端表單欄位Name" );
            // Key.Add( "Model Object Property", "Form Field Name" );
            Dictionary<string, string> Key = new Dictionary<string, string>();
            Key.Add("Name", "Name111");
            Key.Add("age", "age222");
            Key.Add("PhoneNumber", "PhoneNumber333");
            Key.Add("Married", "Married444");
            Key.Add("CreatedDateTime", "CreatedDateTime555");
            Key.Add("ModifyDateTime", "ModifyDateTime666");
            return Key;
        }
```
