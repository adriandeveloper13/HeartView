using System;

namespace HealthView.Models.Interfaces
{
	public interface IModelWithSinglePK : IModel
    {
        Guid Id { get; set; }
    }
}