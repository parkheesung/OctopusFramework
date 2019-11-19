using Octopus.Basis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Octopus.Database
{
    public class MSSQLQueryItem : IStringWrite
    {
        public Entities.Method Method { get; set; } = Entities.Method.Select;
        public string TableName { get; set; } = string.Empty;

        public string TargetColumn { get; set; } = string.Empty;
        public StringBuilder WhereString { get; set; } = new StringBuilder(200);
        public string OrderByString { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public string Columns { get; set; } = string.Empty;

        public int TopCount { get; set; } = 0;

        public int PageIndex { get; set; } = 1;

        public virtual MSSQLQueryItem WhereAppend(string whereStr)
        {
            if (!String.IsNullOrWhiteSpace(whereStr))
            {
                if (!String.IsNullOrWhiteSpace(this.WhereString.ToString()))
                {
                    this.WhereString.Append(" and ");
                }
                this.WhereString.Append(whereStr);
            }
            return this;
        }

        public virtual string Write()
        {
            StringBuilder builder = new StringBuilder(200);

            switch (this.Method)
            {
                case Entities.Method.Count:
                    builder.Append("Select ");
                    if (!String.IsNullOrWhiteSpace(this.TargetColumn))
                    {
                        builder.Append($" Count({this.TargetColumn}) as [Count] From ");
                    }
                    else
                    {
                        builder.Append(" Count(1) as [Count] From ");
                    }
                    builder.Append($"{this.TableName} with (nolock) ");
                    if (!String.IsNullOrWhiteSpace(this.WhereString.ToString()))
                    {
                        builder.Append($" where {this.WhereString.ToString()}");
                    }
                    break;
                case Entities.Method.Delete:
                    builder.Append("Delete From ");
                    builder.Append($"{this.TableName}");
                    if (!String.IsNullOrWhiteSpace(this.WhereString.ToString()))
                    {
                        builder.Append($" where {this.WhereString.ToString()}");
                    }
                    break;
                case Entities.Method.Insert:
                    builder.Append("Insert into ");
                    builder.Append($"{this.TableName}");
                    builder.Append($" ({this.Columns})");
                    builder.Append($" values ({this.Content})");
                    break;
                case Entities.Method.List:
                    string orderString = (String.IsNullOrWhiteSpace(this.OrderByString)) ? this.TargetColumn : this.OrderByString;
                    builder.Append($"Select Top {this.TopCount} A.* From (Select Top ({this.TopCount} * {this.PageIndex}) ROW_NUMBER() OVER (Order by {orderString}) as rowNumber, ");
                    if (!String.IsNullOrWhiteSpace(this.Columns))
                    {
                        builder.Append($" {this.Columns} From ");
                    }
                    else
                    {
                        builder.Append(" * From ");
                    }
                    builder.Append($" [{this.TableName}] with (nolock) ");
                    if (!String.IsNullOrWhiteSpace(this.WhereString.ToString()))
                    {
                        builder.Append($" where {this.WhereString.ToString()}");
                    }
                    if (!String.IsNullOrWhiteSpace(this.OrderByString))
                    {
                        builder.Append($" order by {this.OrderByString}");
                    }
                    builder.Append($") as A where rowNumber > (({this.PageIndex} - 1) * {this.TopCount})");
                    break;
                case Entities.Method.Select:
                    builder.Append("Select ");
                    if (this.TopCount > 0)
                    {
                        builder.Append($" Top {this.TopCount} ");
                    }
                    if (!String.IsNullOrWhiteSpace(this.Columns))
                    {
                        builder.Append($" {this.Columns} From ");
                    }
                    else
                    {
                        builder.Append(" * From ");
                    }
                    builder.Append($"{this.TableName} with (nolock) ");
                    if (!String.IsNullOrWhiteSpace(this.WhereString.ToString()))
                    {
                        builder.Append($" where {this.WhereString.ToString()}");
                    }
                    if (!String.IsNullOrWhiteSpace(this.OrderByString))
                    {
                        builder.Append($" order by {this.OrderByString}");
                    }
                    break;
                case Entities.Method.Update:
                    builder.Append("Update ");
                    builder.Append($"{this.TableName}");
                    builder.Append(" Set ");
                    builder.Append(this.Content);
                    if (!String.IsNullOrWhiteSpace(this.WhereString.ToString()))
                    {
                        builder.Append($" where {this.WhereString.ToString()}");
                    }
                    break;
                case Entities.Method.GroupBy:
                    builder.Append("Select ");
                    builder.Append($" {this.Columns} From ");
                    builder.Append($"{this.TableName} with (nolock) ");
                    if (!String.IsNullOrWhiteSpace(this.WhereString.ToString()))
                    {
                        builder.Append($" where {this.WhereString.ToString()}");
                    }
                    builder.Append($" group by {this.Columns} ");
                    if (!String.IsNullOrWhiteSpace(this.OrderByString))
                    {
                        builder.Append($" order by {this.OrderByString}");
                    }
                    break;
            }

            return QueryHelper.toQueryTrim(builder.ToString());
        }



    }
}
