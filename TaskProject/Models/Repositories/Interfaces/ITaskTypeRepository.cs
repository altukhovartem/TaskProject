using System.Collections.Generic;

namespace TaskProject.Models
{
	public interface ITaskTypeRepository
	{
		IEnumerable<TaskType> GetAll();
	}
}
