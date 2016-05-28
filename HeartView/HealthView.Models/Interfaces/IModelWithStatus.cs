namespace HealthView.Models.Interfaces
{
	public interface IModelWithStatus : IModel
    {
        int Status { get; set; }
    }
}