using BlazorApp2.Components.Entity;

namespace BlazorApp2.Components.Pages
{
    /// <summary>
    /// 社員一覧
    /// </summary>
    public partial class EmployeeList
    {
        private List<Employee> list = new();

        protected override async Task OnInitializedAsync()
        {
            list = await TaskService.LoadAllAsync();
            return;
        }

        protected async Task OnClickAddAsync()
        {
            await Task.Run(() =>
            {
                Navi.NavigateTo("./employee-register");
            });
        }

    }
}
