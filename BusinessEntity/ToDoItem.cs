using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoWebAPI.BusinessEntity
{
    // Todo.cs
    public class ToDoItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
    }
}
