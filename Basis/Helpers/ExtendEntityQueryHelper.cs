using Octopus.Basis;
using Octopus.Database;

namespace Octopus.Database.MSSQL
{
    public static class ExtendEntityQueryHelper
    {
        public static MSSQLQueryItem toGroupBy<T>(this T item, string columns) where T : ITableBinder
        {
            return QueryHelper.MSSQL.toGroupBy<T>(item, columns);
        }

        public static MSSQLQueryItem toGroupBy<T>(this T item, string columns, string whereStr) where T : ITableBinder
        {
            return QueryHelper.MSSQL.toGroupBy<T>(item, columns, whereStr);
        }

        public static MSSQLQueryItem toGroupBy<T>(this T item, string columns, string whereStr, string order) where T : ITableBinder
        {
            return QueryHelper.MSSQL.toGroupBy<T>(item, columns, whereStr, order);
        }

        public static MSSQLQueryItem toSelect<T>(this T item) where T : ITableBinder
        {
            return QueryHelper.MSSQL.toSelect<T>(item);
        }

        public static MSSQLQueryItem toSelect<T>(this T item, string whereStr) where T : ITableBinder
        {
            return QueryHelper.MSSQL.toSelect<T>(item, whereStr);
        }

        public static MSSQLQueryItem toSelect<T>(this T item, string whereStr, string order) where T : ITableBinder
        {
            return QueryHelper.MSSQL.toSelect<T>(item, whereStr, order);
        }

        public static MSSQLQueryItem toList<T>(this T item, int CurPage, int TopCount = 10) where T : ITableBinder
        {
            return QueryHelper.MSSQL.toList<T>(item, CurPage, TopCount);
        }

        public static MSSQLQueryItem toList<T>(this T item, int CurPage, string whereStr, int TopCount = 10) where T : ITableBinder
        {
            return QueryHelper.MSSQL.toList<T>(item, CurPage, whereStr, TopCount);
        }

        public static MSSQLQueryItem toList<T>(this T item, int CurPage, string whereStr, string order, int TopCount = 10) where T : ITableBinder
        {
            return QueryHelper.MSSQL.toList<T>(item, CurPage, whereStr, order, TopCount);
        }

        public static MSSQLQueryItem toCount<T>(this T item) where T : ITableBinder
        {
            return QueryHelper.MSSQL.toCount<T>(item);
        }

        public static MSSQLQueryItem toCount<T>(this T item, string whereStr) where T : ITableBinder
        {
            return QueryHelper.MSSQL.toCount<T>(item, whereStr);
        }

        public static MSSQLQueryItem toUpdate<T>(this T item, string update) where T : ITableBinder
        {
            return QueryHelper.MSSQL.toUpdate<T>(item, update);
        }

        public static MSSQLQueryItem toUpdate<T>(this T item, string update, string whereStr) where T : ITableBinder
        {
            return QueryHelper.MSSQL.toUpdate<T>(item, update, whereStr);
        }

        public static MSSQLQueryItem toInsert<T>(this T item, string columns, string values) where T : ITableBinder
        {
            return QueryHelper.MSSQL.toInsert<T>(item, columns, values);
        }

        public static MSSQLQueryItem toDelete<T>(this T item, string whereStr) where T : ITableBinder
        {
            return QueryHelper.MSSQL.toDelete<T>(item, whereStr);
        }

        public static string toTryCatch(this MSSQLQueryItem query, string successQuery, string failQuery)
        {
            return QueryHelper.MSSQL.toTryCatch(query, successQuery, failQuery);
        }
    }
}
