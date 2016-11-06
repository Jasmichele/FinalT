using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalTask
{
    [MetadataType(typeof(TaskMetaData))]
    public partial class Duty
    {

    }

    public class TaskMetaData
    {
        [DisplayName("Task")]
        public int DutyId { get; set; }
        [DisplayName("Task")]
        [Required(ErrorMessage = "Task required")]
        public string DutyName { get; set; }
        [DisplayName("Description")]
        [Required(ErrorMessage = "Description required")]
        public string Description { get; set; }
        [DisplayName("Due Date")]
        [Required(ErrorMessage = "Due Date required")]
        public System.DateTime DutyDueDate { get; set; }
        [DisplayName("Completion")]
        public Nullable<System.DateTime> DutyCompletion { get; set; }
    }

    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {

    }

    public class UserMetaData
    {
        [DisplayName("Employee")]
        [Required(ErrorMessage = "Employee required")]
        public string UserName { get; set; }
        [DisplayName("Task")]
        public Nullable<int> DutyId { get; set; }
    }
}