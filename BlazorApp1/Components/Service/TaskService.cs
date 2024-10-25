using BlazorApp1.Components.Entity;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BlazorApp1.Components.Service
{
    public class TaskService
    {
        private List<TaskItem> elements = default!;

        public TaskService()
        {

        }

        private static async Task<List<TaskItem>> NewElements()
        {
            await Task.Yield();
            List < TaskItem > list = new List<TaskItem>();
            list.Add(new TaskItem("課題A", DateTime.Today, Entity.TaskStatus.完了));
            list.Add(new TaskItem("課題B", DateTime.Today, Entity.TaskStatus.未着手));
            list.Add(new TaskItem("課題C", DateTime.MaxValue, Entity.TaskStatus.未着手));
            return list;
        }

        public async Task<List<TaskItem>> LoadAllAsync()
        {
            this.elements ??= await NewElements();
            List<TaskItem> list = new List<TaskItem>(this.elements);
            list.Sort();
            return list;
        }

    }

}
