using BlazorApp1.Components.Entity;

namespace BlazorApp1.Components.Pages
{
    /// <summary>
    /// TaskList
    /// </summary>
    public partial class TaskList
    {
        private List<TaskItem> list = new();

        protected override async Task OnInitializedAsync()
        {
            list = await TaskService.LoadAllAsync();
            return;
        }

        protected async Task OnClickAddAsync()
        {
            await Task.Run(() =>
            {
                Navi.NavigateTo("./task-register");
            });
        }

    }
}
