using System;
using System.Threading.Tasks;
using ComposTux.Helpers;
using ComposTux.Models.User;
using SQLite;
using Xamarin.Forms;

namespace ComposTux.DbLocal
{
    public class DbContext
    {
        #region Constructor
        private readonly SQLiteConnection connection;
        public DbContext()
        {
            try
            {
                var dbPath = DependencyService.Get<IPathString>().PathString();
                connection = new SQLiteConnection(dbPath, true);
                connection.CreateTable<UserModel>();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        #endregion

        #region User
        public void InsertUser(UserModel user)
        {
            try
            {
                connection.Insert(user);
            }
            catch(SQLiteException ex)
            {
                throw;
            }
        }
        public void DeleteUser()
        {
            try
            {
                connection.DeleteAll<UserModel>();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public UserModel GetUser()
        {
            try
            {
                var response = connection.Table<UserModel>().FirstOrDefault();
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
