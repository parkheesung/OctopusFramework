using Octopus.Basis;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Octopus.Database
{
    public class QueryHelper
    {
        private static readonly Lazy<MSSQLQuery> mssql = new Lazy<MSSQLQuery>(() => new MSSQLQuery());
        public static MSSQLQuery MSSQL { get { return mssql.Value; } }


        public static string toQueryTrim(string query)
        {
            Regex reg = new Regex("[\\s\\t\\n\\r]{2,100}");
            return reg.Replace(query, " ").Trim();
        }
    }

    public class MSSQLQuery
    {
        public MSSQLQuery()
        {
        }

        public MSSQLQueryItem toGroupBy<T>(T item, string columns) where T : ITableBinder
        {
            var result = new MSSQLQueryItem();
            result.TableName = item.TableName;
            result.Columns = columns;
            result.WhereAppend(item.WhereString.ToString());
            result.Method = Entities.Method.GroupBy;
            return result;
        }

        public MSSQLQueryItem toGroupBy<T>(T item, string columns, string whereStr) where T : ITableBinder
        {
            var result = new MSSQLQueryItem();
            result.TableName = item.TableName;
            result.Columns = columns;
            result.WhereAppend(item.WhereString.ToString());
            result.WhereAppend(whereStr);
            result.Method = Entities.Method.GroupBy;
            return result;
        }

        public MSSQLQueryItem toGroupBy<T>(T item, string columns, string whereStr, string order) where T : ITableBinder
        {
            var result = new MSSQLQueryItem();
            result.TableName = item.TableName;
            result.Columns = columns;
            result.WhereAppend(item.WhereString.ToString());
            result.WhereAppend(whereStr);
            result.OrderByString = order;
            result.Method = Entities.Method.GroupBy;
            return result;
        }

        public MSSQLQueryItem toSelect<T>(T item) where T : ITableBinder
        {
            var result = new MSSQLQueryItem();
            result.TableName = item.TableName;
            result.TargetColumn = item.TargetColumn;
            result.OrderByString = item.OrderBy.ToString();
            result.WhereAppend(item.WhereString.ToString());
            result.Method = Entities.Method.Select;
            return result;
        }

        public MSSQLQueryItem toSelect<T>(T item, string whereStr) where T : ITableBinder
        {
            var result = new MSSQLQueryItem();
            result.TableName = item.TableName;
            result.TargetColumn = item.TargetColumn;
            result.OrderByString = item.OrderBy.ToString();
            result.WhereAppend(item.WhereString.ToString());
            result.WhereAppend(whereStr);
            result.Method = Entities.Method.Select;
            return result;
        }

        public MSSQLQueryItem toSelect<T>(T item, string whereStr, string order) where T : ITableBinder
        {
            var result = new MSSQLQueryItem();
            result.TableName = item.TableName;
            result.TargetColumn = item.TargetColumn;
            result.OrderByString = order;
            result.WhereAppend(item.WhereString.ToString());
            result.WhereAppend(whereStr);
            result.Method = Entities.Method.Select;
            return result;
        }

        public MSSQLQueryItem toList<T>(T item, int CurPage, int TopCount = 10) where T : ITableBinder
        {
            var result = new MSSQLQueryItem();
            result.TopCount = TopCount;
            result.PageIndex = CurPage;
            result.TableName = item.TableName;
            result.TargetColumn = item.TargetColumn;
            result.OrderByString = item.OrderBy.ToString();
            result.WhereAppend(item.WhereString.ToString());
            result.Method = Entities.Method.List;
            return result;
        }

        public MSSQLQueryItem toList<T>(T item, int CurPage, string whereStr, int TopCount = 10) where T : ITableBinder
        {
            var result = new MSSQLQueryItem();
            result.TableName = item.TableName;
            result.PageIndex = CurPage;
            result.TopCount = TopCount;
            result.TargetColumn = item.TargetColumn;
            result.OrderByString = item.OrderBy.ToString();
            result.WhereAppend(item.WhereString.ToString());
            result.WhereAppend(whereStr);
            result.Method = Entities.Method.List;
            return result;
        }

        public MSSQLQueryItem toList<T>(T item, int CurPage, string whereStr, string order, int TopCount = 10) where T : ITableBinder
        {
            var result = new MSSQLQueryItem();
            result.TableName = item.TableName;
            result.PageIndex = CurPage;
            result.TopCount = TopCount;
            result.TargetColumn = item.TargetColumn;
            result.OrderByString = (String.IsNullOrWhiteSpace(order)) ? item.OrderBy.ToString() : order;
            result.WhereAppend(item.WhereString.ToString());
            result.WhereAppend(whereStr);
            result.Method = Entities.Method.List;
            return result;
        }

        public MSSQLQueryItem toCount<T>(T item) where T : ITableBinder
        {
            var result = new MSSQLQueryItem();
            result.TableName = item.TableName;
            result.WhereAppend(item.WhereString.ToString());
            result.Method = Entities.Method.Count;
            return result;
        }

        public MSSQLQueryItem toCount<T>(T item, string whereStr) where T : ITableBinder
        {
            var result = new MSSQLQueryItem();
            result.TableName = item.TableName;
            result.WhereAppend(item.WhereString.ToString());
            result.WhereAppend(whereStr);
            result.Method = Entities.Method.Count;
            return result;
        }

        public MSSQLQueryItem toUpdate<T>(T item, string update) where T : ITableBinder
        {
            var result = new MSSQLQueryItem();
            result.TableName = item.TableName;
            result.WhereAppend(item.WhereString.ToString());
            result.Method = Entities.Method.Update;
            result.Content = update;
            return result;
        }

        public MSSQLQueryItem toUpdate<T>(T item, string update, string whereStr) where T : ITableBinder
        {
            var result = new MSSQLQueryItem();
            result.TableName = item.TableName;
            result.WhereAppend(item.WhereString.ToString());
            result.WhereAppend(whereStr);
            result.Method = Entities.Method.Update;
            result.Content = update;
            return result;
        }

        public MSSQLQueryItem toInsert<T>(T item, string columns, string values) where T : ITableBinder
        {
            var result = new MSSQLQueryItem();
            result.TableName = item.TableName;
            result.WhereAppend(item.WhereString.ToString());
            result.Method = Entities.Method.Insert;
            result.Content = values;
            result.Columns = columns;
            return result;
        }

        public MSSQLQueryItem toDelete<T>(T item, string whereStr) where T : ITableBinder
        {
            var result = new MSSQLQueryItem();
            result.TableName = item.TableName;
            result.WhereAppend(item.WhereString.ToString());
            result.WhereAppend(whereStr);
            result.Method = Entities.Method.Delete;
            return result;
        }

        public string toTryCatch(MSSQLQueryItem query, string successQuery, string failQuery)
        {
            StringBuilder builder = new StringBuilder(200);
            builder.AppendLine("BEGIN TRY");
            builder.AppendLine(query.Write());
            builder.AppendLine(String.Empty);
            builder.AppendLine(successQuery);
            builder.AppendLine("END TRY");
            builder.AppendLine("BEGIN CATCH");
            builder.AppendLine(failQuery);
            builder.AppendLine("END CATCH");
            return builder.ToString().Trim();
        }

    }
}
