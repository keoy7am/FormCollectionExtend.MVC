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
        // TODO Check Performace
        // TODO Exception Handle

        
        #region 轉換單一物件
        /// <summary>
        /// 將FormCollection轉為單一物件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static T ToSingleObject<T>(this FormCollection collection) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();

            T result = new T();

            if (CheckAccessors(properties))
                foreach (var property in properties)
                {
                    Type conversionType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                    object Value = null;
                    Value = (collection.GetValues(property.Name)[0] == null) ? null : Convert.ChangeType(collection.GetValues(property.Name)[0], conversionType);
                    property.SetValue(result, Value, null);
                    //property.SetValue(result, Convert.ChangeType(collection.GetValues(property.Name)[0], property.PropertyType), null);
                }
            return result;
        }

        /// <summary>
        /// 將FormCollection轉為單一物件 ( 例外對映 )
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns>object</returns>
        public static T ToSingleObject<T>(this FormCollection collection, Dictionary<string, string> Key) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();

            T result = new T();

            if (CheckAccessors(properties))
                foreach (var property in properties)
                {
                    Type conversionType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                    object Value = null;

                    if (Key.ContainsKey(property.Name))
                    {
                        Value = (collection.GetValues(Key[property.Name])[0] == null) ? null : Convert.ChangeType(collection.GetValues(Key[property.Name])[0], conversionType);
                        property.SetValue(result, Value, null);
                    }
                    else
                    {
                        try
                        {
                            Value = (collection.GetValues(property.Name)[0] == null) ? null : Convert.ChangeType(collection.GetValues(property.Name)[0], conversionType);
                            property.SetValue(result, Value, null);
                        }
                        catch
                        {

                        }
                    }
                }

            return result;
        }

        #endregion

        #region 轉換為List型別物件

        /// <summary>
        /// 將FormCollection轉為List形別物件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static List<T> ToListObject<T>(this FormCollection collection, string check) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            List<T> result = new List<T>();
            int counter = collection.GetValues(check.Trim()).Count();

            if (CheckAccessors(properties))
                for (int i = 0; i < counter; i++)
                {
                    T item = new T();
                    foreach (var property in properties)
                    {
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
        /// 將FormCollection轉為List形別物件 ( 例外對映 )
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static List<T> ToListObject<T>(this FormCollection collection, Dictionary<string, string> Key, string check) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            List<T> result = new List<T>();
            int counter = collection.GetValues(check.Trim()).Count();

            if (CheckAccessors(properties))
                for (int i = 0; i < counter; i++)
                {
                    T item = new T();
                    foreach (var property in properties)
                    {
                        Type conversionType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                        object Value = null;
                        if (Key.ContainsKey(property.Name))
                        {
                            Value = (collection.GetValues(Key[property.Name])[i] == null) ? null : Convert.ChangeType(collection.GetValues(Key[property.Name])[i], conversionType);
                            property.SetValue(item, Value, null);

                        }
                        else
                        {
                            try
                            {
                                Value = (collection.GetValues(property.Name)[i] == null) ? null : Convert.ChangeType(collection.GetValues(property.Name)[i], conversionType);
                                property.SetValue(item, Value, null);
                            }
                            catch
                            {

                            }
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
        private static bool CheckAccessors(IList<PropertyInfo> properties)
        {
            if (properties.Count > 0) { return true; }
            else
            {
                throw new Exception($"The Class didn't Declare the Accessors!");
            }
        }
    }
}
