using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreDbFirst.Domain
{
    public partial class TaskItem
    {
        public TaskItem() { }

        public TaskItem(string title, string description = "", bool active = true)
        {
            Title = title;
            Description = description;
            Active = active;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Title { get; private set; }
        
        [Required]
        public string Description { get; private set; }

        [Required]
        public bool Active { get; private set; }

        public void Activate() => Active = true;
        public void Inactivate() => Active = false;
        public void SetTitle(string newTitle) => Title = newTitle;
        public void SetDescription(string newDescription) => Description = newDescription;
    }
}

