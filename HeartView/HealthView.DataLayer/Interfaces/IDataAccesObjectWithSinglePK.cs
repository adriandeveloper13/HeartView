using System;

namespace HealthView.DataLayer.Interfaces
{
	public interface IDataAccesObjectWithSinglePk : IDataAccesObject
    {
	    Guid Id { get; set; }
	}
}