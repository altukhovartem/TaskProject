using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskProject.Models.EF;

namespace TaskProject.Models
{
	public class TaskTypeRepository : ITaskTypeRepository
	{
		private readonly AppDBContext context;

		public TaskTypeRepository(AppDBContext context)
		{
			this.context = context;
		}
		public IEnumerable<TaskType> GetAll()
		{
			return context.TaskTypes;
		}

		public IEnumerable<string> GetAllTitles()
		{
			return context.TaskTypes.Select(tt => tt.Title);
		}
	}
}
