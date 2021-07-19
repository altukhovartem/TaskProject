using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskProject.Models.EF
{
	public class AppDBContext: DbContext 
	{
		public AppDBContext(DbContextOptions<AppDBContext> option)
			:base(option)
		{

		}

		public DbSet<Task> Tasks { get; set; }
		public DbSet<TaskType> TaskTypes { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<TaskType>().HasData(new TaskType { Id = 1, Title = "Task" });
			modelBuilder.Entity<TaskType>().HasData(new TaskType { Id = 2, Title = "Bug" });
			modelBuilder.Entity<TaskType>().HasData(new TaskType { Id = 3, Title = "Change Request" });

			modelBuilder.Entity<Task>().HasData(new Task
			{
				Id = 1,
				Title = "First Task",
				TypeId = 1,
				CreatedTime = DateTime.Now
			});

			modelBuilder.Entity<Task>().HasData(new Task
			{
				Id = 2,
				Title = "Second Task",
				TypeId = 2,
				CreatedTime = DateTime.Now
			});

			modelBuilder.Entity<Task>().HasData(new Task
			{
				Id = 3,
				Title = "Third Task",
				TypeId = 3,
				CreatedTime = DateTime.Now
			});
		}
	}
}
