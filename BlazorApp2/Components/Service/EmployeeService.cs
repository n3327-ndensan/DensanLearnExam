using BlazorApp2.Components.Entity;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BlazorApp2.Components.Service
{
    public class EmployeeService
    {
        private List<Employee> elements = default!;

        public EmployeeService()
        {

        }

        private static async Task<List<Employee>> NewElements()
        {
            return await Task.Run(() =>
            {
                List<Employee> list = new List<Employee>();
                list.Add(new Employee("田中　太郎", new DateTime(2000, 4, 1), EmployeeType.正社員));
                list.Add(new Employee("鈴木　花子", new DateTime(2024, 4, 1), EmployeeType.正社員));
                list.Add(new Employee("佐藤　一郎", new DateTime(1984, 4, 1), EmployeeType.嘱託));
                list.Add(new Employee("山田　次郎", new DateTime(1985, 4, 1), EmployeeType.嘱託));
                list.Add(new Employee("高橋　美咲", new DateTime(2023, 10, 1), EmployeeType.協力会社));
                return list;
            });
        }

        public async Task<List<Employee>> LoadAllAsync()
        {
            this.elements ??= await NewElements();
            List<Employee> list = new List<Employee>(this.elements);
            list.Sort();
            return list;
        }

        public async Task SaveEmployeeAsync(Employee employee)
        {
            this.elements ??= await NewElements();
            this.elements.Add(employee);
            return;
        }

    }

}
