using System;

namespace Laboratorio2.Controllers
{
    internal class SqlConnection
    {
        private object connString;

        public SqlConnection(object connString)
        {
            this.connString = connString;
        }

        internal void Open()
        {
            throw new NotImplementedException();
        }
    }
}