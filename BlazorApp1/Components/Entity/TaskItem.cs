using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BlazorApp1.Components.Entity
{

    public class TaskItem : IComparable<TaskItem>
    {
        [Required(AllowEmptyStrings = false)]
        public string 題名 { get; set; } = "";
        public DateTime 期限 { get; set; } = DateTime.Now;
        public TaskStatus 状態 { get; set; } = TaskStatus.未着手;
        public string 内容 { get; set; } = "";


        public TaskItem(string 題名, DateTime 期限, TaskStatus 状態 = TaskStatus.未着手)
        {
            this.題名 = 題名;
            this.期限 = 期限;
            this.状態 = 状態;
        }

        public string 内容の先頭1行 => 内容.Split('\n')[0];
        public string 期日 => 期限.ToString("yyyy/MM/dd");

        public int CompareTo(TaskItem? other)
        {
            if (other == null) return 1;

            int 期限差 = this.期限.CompareTo(other.期限);
            if(期限差 != 0) return 期限差;
            return this.状態.CompareTo(other.状態);
        }
    }

}