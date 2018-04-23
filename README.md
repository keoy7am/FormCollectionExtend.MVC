# FormCollectionExtend.MVC
MVC FormCollection To Object Extend Library.

* * *
## About Method ##
#### ToSingleObject(this FormCollection collection)
Convert FormCollection To Single Object.
#### ToSingleObject(this FormCollection collection, Dictionary<string, string> MappingDictionary)
Convert FormCollection To Single Object with Mapping Dictionary.
#### ToListObject(this FormCollection collection)
Convert FormCollection To List&lt;Object&gt;.
#### ToListObjectWithMappingDictionary(this FormCollection collection, Dictionary<string, string> MappingDictionary)
Convert FormCollection To List&lt;Object&gt; with Mapping Dictionary.


* * *
## About Mapping Dictionary ##
Example：
<pre><code>
Dictionary<string, string> GetKey()
        {
            // 建立 前端欄位Name與後端物件屬性 映射字典
            // Key.Add( "後端物件屬性", "前端表單欄位Name" );
            // Key.Add( "Object Property", "Form Name" );
            Dictionary<string, string> Key = new Dictionary<string, string>();
            Key.Add("Name", "Name111");
            Key.Add("age", "age222");
            Key.Add("PhoneNumber", "PhoneNumber333");
            Key.Add("Married", "Married444");
            Key.Add("CreatedDateTime", "CreatedDateTime555");
            Key.Add("ModifyDateTime", "ModifyDateTime666");
            return Key;
        }
</code></pre>
