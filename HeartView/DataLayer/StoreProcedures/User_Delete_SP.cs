using System;
using DataLayer.Helpers;

namespace DataLayer.StoreProcedures
{
    public class User_Delete_SP : StoredProcedureBase
    {
        public User_Delete_SP(Guid userId)
            : base(StoredProcedures.User_Delete)
        {
            Parameters.Add("@UserId", userId);
        }
    }
}