using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log.Data;
using Log.Interfaces;
using Log.Models;

namespace Log.Services
{
    public class LoggingService: ILogging
    {
        //List<LoggingDS> loggingDs = new();
        LoggingDS loging = new();
        private readonly LogDbContext logDbContext = null;
        public LoggingService(LogDbContext _logDbContext)
        {
            logDbContext= _logDbContext;
        }
        public void LogToDb(string Process,string name)
        {
            loging = new();
            loging.Processtype= Process;
            loging.ProcessName= name;
            loging.Time = DateTime.Now;
            logDbContext.Logs.Add(loging);
        }
        public void SavetoDB()
        {
            
            logDbContext.SaveChanges();
        }
    }
}
