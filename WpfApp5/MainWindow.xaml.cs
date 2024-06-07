using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp5.Controllers;
using WpfApp5.Windows;

namespace WpfApp5;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
    {
        WindowNewTask windows = new WindowNewTask();
        windows.Show();
    }

  

    private void Calendar_OnSelectedDataChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (e.AddedItems.Count == 0)
            return;
        TaskControlilers taskControlilers = new TaskControlilers();
        foreach (DateTime dateTime in e.AddedItems)
        {
            LbData.ItemsSource = taskControlilers.Get(DateOnly.FromDateTime(dateTime));
        }
        
    }

    private void BtnDel_OnClick(object sender, RoutedEventArgs e)
    {
        if (MessageBox.Show("Вы действительно хотите удалить запись?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.No)
        {
            return;
        }

        Button button = (Button)e.Source;
        TaskControlilers controlilers = new TaskControlilers();
        controlilers.DeleteTask(button.Content.ToString());

    }
}