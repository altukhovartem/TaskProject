using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskProject.Models
{
	public class MockTaskTypeRepository: ITaskTypeRepository
	{
		private List<TaskType> _types = new List<TaskType>
		{ 
			new TaskType{Id=1, Name = "Task"},
			new TaskType{Id=2, Name = "Bug"},
			new TaskType{Id=3, Name = "ChangeRequest"}
		};


		public IEnumerable<TaskType> GetAll()
		{
			return _types;
		}

		public IEnumerable<string> GetAllTitles()
		{
			return _types.Select(x => x.Name);
		}

		public TaskType GetById(int Id)
		{
			return _types.Where(t => t.Id == Id).FirstOrDefault();
		}
	}
}
