using System;
using DataLayer.Helpers;

namespace DataLayer.StoreProcedures
{
	public class User_Get_Identity_Data_SP : StoredProcedureBase
	{
		public User_Get_Identity_Data_SP(string aspNetUserId)
			: base(StoredProcedures.User_Get_IdentityData)
		{
			Parameters.Add("@AspNetUserId", aspNetUserId);
		}
	}
}