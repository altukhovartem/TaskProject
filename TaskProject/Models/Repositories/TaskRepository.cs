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
			task.CreatedTime = DateTime.Now;
			context.Tasks.Add(task);
			context.SaveChanges();
		}

		public void Update(Task task)
		{
			context.Tasks.Update(task);
			context.SaveChanges();
		}

		public IEnumerable<Task> GetAll()
		{
			return context.Tasks;
		}

		public Task GetById(int Id)
		{
			return	context.Tasks.FirstOrDefault(t => t.Id == Id);
		}

		public void Delete(Task task)
		{
			context.Tasks.Remove(task);
			context.SaveChanges();
		}
	}
}
