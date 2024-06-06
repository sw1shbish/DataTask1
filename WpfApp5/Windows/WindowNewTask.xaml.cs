using System.Windows;
using WpfApp5.Controllers;
using WpfApp5.Models;

namespace WpfApp5.Windows;

public partial class WindowNewTask : Window
{
    public WindowNewTask()
    {
        InitializeComponent();
    }

    private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
    {
        TaskControlilers taskController = new TaskControlilers();
        DayTask task = new DayTask()
        {
            Id = Guid.NewGuid(),
            Date = DateOnly.FromDateTime(Calendar.SelectedDate ?? DateTime.Today),
            Name = TbName.Text,
            Description = TbDescription.Text
        };
        taskController.AddNewTask(task);
        Close();
    }
}

