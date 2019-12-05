using Octopus.Basis;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Octopus.Tests
{
    public class Human : ITableBinder
    {
        [Entity("이름", "Name", SqlDbType.NVarChar, 30)]
        public string Name { get; set; }

        [Entity("성별", "Gender", SqlDbType.NVarChar, 10)]
        public string Gender { get; set; }

        [Entity("나이", "Age", SqlDbType.Int)]
        public int Age { get; set; }
        public string TableName { get; set; } = "human";
        public string TargetColumn { get; set; } = "idx";
        public StringBuilder OrderBy { get; set; } = new StringBuilder(200);
        public StringBuilder WhereString { get; set; } = new StringBuilder(200);

        public Human()
        {
        }

        public List<EntityObject> GetColumns()
        {
            return this.GetEntities();
        }
    }
}
