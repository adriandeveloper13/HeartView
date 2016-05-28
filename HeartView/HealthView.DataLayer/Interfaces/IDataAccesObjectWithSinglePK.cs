using System;

namespace CBT.DataLayer.Interfaces
{
	public interface IDataAccesObjectWithSinglePk : IDataAccesObject
    {
	    Guid Id { get; set; }
	}
}