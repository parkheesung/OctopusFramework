using System;
using System.Collections.Generic;
using System.Text;

namespace Octopus.Basis
{
    public interface ITableBinder : IEntity
    {
        string TableName { get; set; }
        string TargetColumn { get; set; }
        StringBuilder OrderBy { get; set; }

        StringBuilder WhereString { get; set; }
    }
}
