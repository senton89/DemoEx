using System.Windows;
using DemoExamenTest.Data;
using DemoExamenTest.Models;
using DemoExamenTest.ViewModels;
using DemoExamenTest.Views;

namespace DemoExamenTest;

public partial class MainWindow : Window
{
    private readonly PartnerViewModel _viewModel;
    
    private void LoadPartners() => partnersItemsControl.ItemsSource = _viewModel.GetPartners();

    public MainWindow()
    {
        InitializeComponent();
        _viewModel = new PartnerViewModel(new PartnerDbContext());
        LoadPartners();
    }
    

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        var selectedPartner = (sender as FrameworkElement).DataContext as PartnerModelView;
        if(selectedPartner == null) return;
        new PartnerEditWindow(selectedPartner.Id).ShowDialog();
        LoadPartners();
    }

    private void HistoryButton_OnClick(object sender, RoutedEventArgs e)
    {
        new SalesHistoryWindow().ShowDialog();
    }

    private void AddButton_OnClick(object sender, RoutedEventArgs e)
    {
        new PartnerEditWindow(null).Show();
        LoadPartners();
    }
}