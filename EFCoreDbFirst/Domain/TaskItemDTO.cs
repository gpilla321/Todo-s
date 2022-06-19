using System;
namespace EFCoreDbFirst.Domain
{
	public class TaskItemDTO
	{
		public TaskItemDTO() { }

		public TaskItemDTO(string title, string description)
		{
			Title = title;
			Description = description;
		}

		public string Title { get; set; }
		public string Description { get; set; }
    }
}

