using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskProject.Models.EF;

namespace TaskProject.Models
{
	public class TaskRepository : ITaskRepository
	{
		private readonly AppDBContext context;

		public TaskRepository(AppDBContext context)
		{
			this.context = context;
		}
		public void Create(Task task)
		{
			//task.Id = context.Tasks.Max(t => t.Id)+1;
			context.Tasks.Add(task);
			context.SaveChanges();
		}

		public IEnumerable<Task> GetAll()
		{
			return context.Tasks.Include(t => t.Type);
		}

		public Task GetById(int Id)
		{
			return	context.Tasks.Include(t => t.Type).FirstOrDefault(t => t.Id == Id);
		}
	}
}
