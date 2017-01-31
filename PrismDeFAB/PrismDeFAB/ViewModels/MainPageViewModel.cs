using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace PrismDeFAB.ViewModels
{
    public class TListItem
    {
        public string Title { get; set; }
        public string Detail { get; set; }
    }

    public class MainPageViewModel : BindableBase
    {
        private IPageDialogService _pageDialogService;

        public ICommand FabCommand { get; }
        public List<TListItem> ListItems { get; }

        public MainPageViewModel(IPageDialogService pageDialogService)
        {
            _pageDialogService = pageDialogService;
            FabCommand = new DelegateCommand(Fab);

            ListItems = new List<TListItem>();
            for (int i = 0; i < 100; i++)
            {
                ListItems.Add(new TListItem() { Title = $"title-{i}", Detail = $"detail-{i}" });
            }
        }

        async private void Fab()
        {
            await _pageDialogService.DisplayAlertAsync("FAB", "FABったね、オヤジにもFABられたことないのに", "OK");
        }

    }
}
