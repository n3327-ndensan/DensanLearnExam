using BlazorApp2.Components.Entity;
using BlazorApp2.Components.Service;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApp2.Components.Pages
{
    public partial class EmployeeRegister : IDisposable
    {
        private Employee employee = new Employee("", DateTime.Now);
        private bool isError = true;
        private EditContext editContext = null!;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            editContext = new(employee);
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
            await EmployeeService.SaveEmployeeAsync(employee);
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
