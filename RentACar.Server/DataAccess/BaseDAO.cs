using System;

namespace RentACar.Server.DataAccess
{
    public class BaseDAO
    {
        protected void TryDatabaseQuery (Action query) 
        {
            try 
            {
                query ();
            } 
            catch 
            {
                throw;
            }
        }

        protected T TryDatabaseQuery<T> (Func<T> query) 
        {
            try 
            {
                return query();
            }
            catch 
            {
                throw;
            }
        }   
    }
}
