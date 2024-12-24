using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BlazorApp2.Components.Entity
{

    public class Employee : IComparable<Employee>
    {
        [Required(AllowEmptyStrings = false)]
        public string 氏名 { get; set; } = "";
        public DateTime 入社日 { get; set; } = DateTime.Now.Date;
        public EmployeeType 雇用形態 { get; set; } = EmployeeType.正社員;
        public string 備考 { get; set; } = "";

        public Employee(string 氏名)
        {
            this.氏名 = 氏名;
        }
        public Employee(string 氏名, DateTime 入社日, EmployeeType 雇用形態 = EmployeeType.正社員)
        {
            this.氏名 = 氏名;
            this.入社日 = 入社日.Date;
            this.雇用形態 = 雇用形態;
        }

        public string 備考の先頭1行 => 備考.Split('\n')[0];

        public int CompareTo(Employee? other)
        {
            if (other == null) return 1;

            int 形態差 = this.雇用形態.CompareTo(other.雇用形態);
            if(形態差 != 0) return 形態差;
            return this.入社日.CompareTo(other.入社日);
        }
    }

}