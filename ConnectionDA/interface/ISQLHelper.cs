using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDA.Interface
{
   public interface ISQLHelper
    {
       public int ExcuteQuery(String query, Dictionary<string, string> parameters);
        public object RetriveSingleData(string query, Dictionary<string, string> parameters);
        public List<Dictionary<string, object>> RetriveMultipleData(string query, Dictionary<string, string> parameters);

        public DataSet GetData(string query, Dictionary<string, string> parameters);

    }
}
