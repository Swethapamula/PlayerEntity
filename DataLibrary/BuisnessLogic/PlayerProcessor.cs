using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;

namespace DataLibrary.BuisnessLogic
{
    public class PlayerProcessor
    {
        public static int CreatePlayer(int playerID, string firstName,
                                            string lastName, string emailAddress,string conString)
        {
            Player data = new Player
            {
                PlayerId = playerID,
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress
            };

            string sql = @"insert into dbo.Player (PlayerId,
                             FirstName,LastName,EmailAddress) values(@PlayerId,@FirstName,@LastName,@EmailAddress)";
            return SQlDataAccess.SaveData(sql, data, conString);
        }

      

        public static List<Player> LoadPayers(string conString)
        {
            string sql = @"Select * from dbo.Player;";
            return SQlDataAccess.LoadData<Player>(sql, conString);
        }
    }
}
