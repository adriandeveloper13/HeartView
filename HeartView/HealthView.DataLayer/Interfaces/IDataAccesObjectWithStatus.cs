using System;

namespace HealthView.DataLayer.Interfaces
{
	public interface IDataAccesObjectWithStatus : IDataAccesObject
    {
	    int Status { get; set; }
	}
}