using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Interfaces
{
    public interface ILogging
    {
        void LogToDb(string Process, string name);
        void SavetoDB();

    }
}
