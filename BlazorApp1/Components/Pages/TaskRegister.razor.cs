using BlazorApp1.Components.Entity;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApp1.Components.Pages
{
    public partial class TaskRegister : IDisposable
    {
        private Entity.TaskItem taskItem = new TaskItem("", DateTime.Now);
        private bool isError = true;
        private EditContext editContext = null!;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            editContext = new(taskItem);
            editContext.OnFieldChanged += HandleFieldChanged;
        }
        private void HandleFieldChanged(object? sender, FieldChangedEventArgs e)
        {
            isError = !editContext.Validate() ;
            StateHasChanged();
        }

        public void Dispose()
        {
            editContext.OnFieldChanged -= HandleFieldChanged;
        }

        protected async Task OnSumbitAsync()
        {
            await TaskService.SaveTaskAsync(taskItem);
            Navi.NavigateTo("./");
        }

        protected async Task OnClickCancelAsync()
        {
            await Task.Run(() =>
            {
                Navi.NavigateTo("./");
            });
        }

    }


}
