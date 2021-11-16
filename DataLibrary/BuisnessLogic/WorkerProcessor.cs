using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.BuisnessLogic
{
    public class WorkerProcessor
    {
        public static int CreateWorker(DateTime dateTime, string status,
                                         string comment, string conString)

        {

            Worker data = new Worker
            {
               WorkerDateTime = dateTime,
               StatusCode = status,
               Comment = comment
            };

            string sql = @"insert into dbo.Worker (WorkerDateTime,StatusCode,Comment)
                             values(@WorkerDateTime,@StatusCode,@Comment)";


            //string sql = @"insert into dbo.Worker (WorkerDateTime,StatusCode,Comment) values(" + dateTime + "," + status + "," + comment + ")";

            return SQlDataAccess.SaveDataWorker(sql,data ,conString);
        }
    }
}
