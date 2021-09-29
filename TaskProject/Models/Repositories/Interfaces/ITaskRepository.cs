using System.Collections.Generic;

namespace TaskProject.Models
{
	public interface ITaskRepository
	{
		IEnumerable<Task> GetAll();
		Task GetById(int Id);
		void Create(Task task);
		void Update(Task task);
	}
}
