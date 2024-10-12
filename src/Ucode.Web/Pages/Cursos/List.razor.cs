using Microsoft.AspNetCore.Components;
using MudBlazor;
using Ucode.Core.Handlers;
using Ucode.Core.Models;
using Ucode.Core.Requests.Curso;

namespace Ucode.Web.Pages.Cursos
{
    public partial class ListCursosPage : ComponentBase
    {
        #region Properties
        public bool IsBusy { get; set; } = false;
        public List<Curso> Cursos { get; set; } = [];
        public string SearchTerm { get; set; } = string.Empty;

        #endregion

        #region Services
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        [Inject]
        public ICursoHandler Handler { get; set; } = null!;

        [Inject]
        public IDialogService DialogService { get; set; } = null!;  // Modal tem que registrar no MainLayout.razor

        #endregion

        #region Overrides       

        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;
            try
            {
                var request = new GetAllCursoRequest();
                var result = await Handler.GetAllAsync(request);
                if (result.IsSucess)
                    Cursos = result.Data ?? []; // new list<Category>() que é um lista
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion

        #region Methods 

        public async void OnDeleteButtonClickedAsync(long id, string nome)
        {
            var result = await DialogService.ShowMessageBox(
                "ATENÇÃO",
                $"Ao prosseguir o curso {nome} será excluída. Esta é uma ação irreversível! Deseja continuar?",
                yesText: "EXCLUIR",
                cancelText: "Cancelar");

            if (result is true)
                await OnDeleteAsync(id, nome);

            StateHasChanged();
        }

        public async Task OnDeleteAsync(long id, string nome)
        {
            try
            {
                var request = new DeleteCursoRequest { Id = id };
                await Handler.DeleteAsync(request);
                Cursos.RemoveAll(x => x.Id == id);
                Snackbar.Add($"Curso {nome} foi excluído", Severity.Success);
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }

        }

        public Func<Curso, bool> Filter => cursos =>
        {
            if (string.IsNullOrWhiteSpace(SearchTerm))
                return true;

            if (cursos.Id.ToString().Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                return true;

            if (cursos.Nome.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        };    

        #endregion
    }
} 
	



