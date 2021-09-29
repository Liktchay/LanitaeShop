using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace LanitaeShop.DataAccess.Functions
{
    public class ReflectionPopulator<T> where T: class
    {
        public virtual List<T> CreateList(SqlDataReader reader)
        {
            var results = new List<T>();

            Func<SqlDataReader, T> readRow = GetReader(reader);

            while (reader.Read())
            {
                results.Add(readRow(reader));
            }

            return results;
        }

        private Func<SqlDataReader, T> GetReader(SqlDataReader reader)
        {
            var readerParam = Expression.Parameter(typeof(SqlDataReader), "reader");
            var readerGetValue = typeof(SqlDataReader).GetMethod("GetValue");
            var dbNullValue = typeof(DBNull).GetField("Value");
            var dbNullExp = Expression.Field(expression: null, type: typeof(DBNull), fieldName: "Value");
            //var dbNullExp = Expression.Field(Expression.Parameter(typeof(DBNull), "System.DBNull"), dbNullValue);

            List<MemberBinding> memberBindings = new List<MemberBinding>();

            foreach (var prop in typeof(T).GetProperties())
            {
                //determine the defaul value of a property
                object defaultValue = null;

                if (prop.PropertyType.IsValueType)
                    defaultValue = Activator.CreateInstance(prop.PropertyType);
                else if (prop.PropertyType.Name.ToLower().Equals("string"))
                    defaultValue = string.Empty;

                // build the Call expression to retrieve the data value from the reader
                var indexExpression = Expression.Constant(reader.GetOrdinal(prop.Name));
                var getValueExp = Expression.Call(readerParam, readerGetValue, new Expression[] { indexExpression });

                // create the conditional expression to make sure the reader value != DBNull.Value
                var testExp = Expression.NotEqual(dbNullExp, getValueExp);
                var ifTrue = Expression.Convert(getValueExp, prop.PropertyType);
                var ifFalse = Expression.Convert(Expression.Constant(defaultValue), prop.PropertyType);

                // create the actual Bind expression to bind the value from the reader to the property value
                MemberInfo mi = typeof(T).GetMember(prop.Name)[0];
                MemberBinding mb = Expression.Bind(mi, Expression.Condition(testExp, ifTrue, ifFalse));
                memberBindings.Add(mb);
            }

            var newItem = Expression.New(typeof(T));
            var memberInit = Expression.MemberInit(newItem, memberBindings);
            var lambda = Expression.Lambda<Func<SqlDataReader, T>>(memberInit, new ParameterExpression[] { readerParam });
            var resDelegate = lambda.Compile();
            return (Func<SqlDataReader, T>)resDelegate;

        }
    }
}
