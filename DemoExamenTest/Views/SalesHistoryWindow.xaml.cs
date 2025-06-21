using System.Windows;
using DemoExamenTest.Data;
using DemoExamenTest.ViewModels;

namespace DemoExamenTest.Views;

public partial class SalesHistoryWindow : Window
{
    private readonly PartnerViewModel _viewModel;
    public SalesHistoryWindow()
    {
        InitializeComponent();
        _viewModel = new PartnerViewModel(new PartnerDbContext());
        saleHistoryDataGrid.ItemsSource = _viewModel.GetSaleHistory();
    }
}