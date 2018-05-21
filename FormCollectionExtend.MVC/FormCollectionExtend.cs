using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FormCollectionExtend.MVC
{
    public static class FormCollectionExtend
    {
        /* FormCollection To Object Extend Library */
        
        #region 轉換單一物件
        /// <summary>
        /// Convert FormCollection To Single Object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static T ToSingleObject<T>(this FormCollection collection) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();

            T result = new T();
            CheckProperty(properties);

            foreach (var property in properties)
            {
                if (!property.CanWrite) { continue; }
                Type conversionType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                object Value = null;
                Value = (collection.GetValues(property.Name)[0] == null) ? null : Convert.ChangeType(collection.GetValues(property.Name)[0], conversionType);
                property.SetValue(result, Value, null);
            }
            return result;
        }

        /// <summary>
        /// Convert FormCollection To Single Object With Dictionary.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns>object</returns>
        public static T ToSingleObject<T>(this FormCollection collection, Dictionary<string, string> Key) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();

            T result = new T();
            CheckProperty(properties);

            foreach (var property in properties)
            {
                Type conversionType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                object Value = null;
                if (!property.CanWrite) { continue; }
                try
                {
                    if (Key.ContainsKey(property.Name))
                    {
                        Value = (collection.GetValues(Key[property.Name])[0] == null) ? null : Convert.ChangeType(collection.GetValues(Key[property.Name])[0], conversionType);
                        property.SetValue(result, Value, null);
                    }
                    else
                    {
                        Value = (collection.GetValues(property.Name)[0] == null) ? null : Convert.ChangeType(collection.GetValues(property.Name)[0], conversionType);
                        property.SetValue(result, Value, null);
                    }
                }
                catch
                {
                    continue;
                }
            }

            return result;
        }

        #endregion

        #region 轉換為List型別物件

        /// <summary>
        /// Convert FormCollection To List<Object>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static List<T> ToListObject<T>(this FormCollection collection, string PrimaryKeyName) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            List<T> result = new List<T>();
            int counter = collection.GetValues(PrimaryKeyName.Trim()).Count();
            CheckProperty(properties);

            for (int i = 0; i < counter; i++)
            {
                T item = new T();
                foreach (var property in properties)
                {
                    if (!property.CanWrite) { continue; }
                    Type conversionType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                    object Value = null;
                    Value = Convert.ChangeType(collection.GetValues(property.Name)[i], conversionType);
                    property.SetValue(item, Value, null);
                }
                result.Add(item);
            }

            return result;
        }

        /// <summary>
        /// Convert FormCollection To List<Object> With Dictionary.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static List<T> ToListObject<T>(this FormCollection collection, Dictionary<string, string> Key, string PrimaryKeyName) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            List<T> result = new List<T>();
            int counter = collection.GetValues(PrimaryKeyName.Trim()).Count();
            CheckProperty(properties);
            for (int i = 0; i < counter; i++)
            {
                T item = new T();
                foreach (var property in properties)
                {
                    Type conversionType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                    object Value = null;
                    if (!property.CanWrite) { continue; }
                    try
                    {
                        if (Key.ContainsKey(property.Name))
                        {
                            Value = (collection.GetValues(Key[property.Name])[i] == null) ? null : Convert.ChangeType(collection.GetValues(Key[property.Name])[i], conversionType);
                            property.SetValue(item, Value, null);
                        }
                        else
                        {
                            Value = (collection.GetValues(property.Name)[i] == null) ? null : Convert.ChangeType(collection.GetValues(property.Name)[i], conversionType);
                            property.SetValue(item, Value, null);
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
                result.Add(item);
            }
            return result;
        }
        #endregion

        /// <summary>
        /// Check Accessors
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        private static void CheckProperty(IList<PropertyInfo> properties)
        {
            if (properties.Count == 0) { throw new Exception("The Class Didn't Declare The Property!"); }
        }
    }
}
