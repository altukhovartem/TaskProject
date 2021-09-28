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

		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	base.OnModelCreating(modelBuilder);

		//	modelBuilder.Entity<TaskType>().HasData(new TaskType { Id = 1, Name = "Task" });
		//	modelBuilder.Entity<TaskType>().HasData(new TaskType { Id = 2, Name = "Bug" });
		//	modelBuilder.Entity<TaskType>().HasData(new TaskType { Id = 3, Name = "Change Request" });

		//	modelBuilder.Entity<Task>().HasData(new Task
		//	{
		//		Id = 1,
		//		Title = TaskTypes.Where(x=>x.Id == 1).SingleOrDefault().Name,
		//		CreatedTime = DateTime.Now
		//	});

		//	modelBuilder.Entity<Task>().HasData(new Task
		//	{
		//		Id = 2,
		//		Title = TaskTypes.Where(x => x.Id == 2).SingleOrDefault().Name,

		//		CreatedTime = DateTime.Now
		//	});

		//	modelBuilder.Entity<Task>().HasData(new Task
		//	{
		//		Id = 3,
		//		Title = TaskTypes.Where(x => x.Id == 3).SingleOrDefault().Name,
		//		CreatedTime = DateTime.Now
		//	});
		//}
	}
}
