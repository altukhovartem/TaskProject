using System.Collections.Generic;

namespace TaskProject.Models
{
	public interface ITaskRepository
	{
		IEnumerable<Task> GetAll();
	}
}
