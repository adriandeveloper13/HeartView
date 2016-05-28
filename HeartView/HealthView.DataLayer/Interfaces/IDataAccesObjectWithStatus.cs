using System;

namespace CBT.DataLayer.Interfaces
{
	public interface IDataAccesObjectWithStatus : IDataAccesObject
    {
	    int Status { get; set; }
	}
}