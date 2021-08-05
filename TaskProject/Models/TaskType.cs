using System.ComponentModel.DataAnnotations;

namespace TaskProject.Models
{
	public class TaskType
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
