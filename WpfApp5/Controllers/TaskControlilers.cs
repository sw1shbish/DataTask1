using System.IO;
using System.Net;
using System.Xml.Linq;
using Newtonsoft.Json;
using WpfApp5.Models;

namespace WpfApp5.Controllers;

public class TaskControlilers
{
    private IList<DayTask> _tasks = new List<DayTask>();
    
    public TaskControlilers()
    {
        OpenFile();
    }

    private void OpenFile()
    {
        if (!File.Exists("tasks.json"))
            Save();
        
            var jsonOpen = File.ReadAllText("tasks.json");
            _tasks = JsonConvert.DeserializeObject<IList<DayTask>>(jsonOpen) ?? new List<DayTask>();
    }

    public void AddNewTask(DayTask task)
    {
        _tasks.Add(task);
        Save();
    }

    public IEnumerable<DayTask> Get(DateOnly dateOnly)
    {
        return from task in _tasks where task.Date == dateOnly select task;
    }

    public void DeleteTask(string id)
    {
        var task = _tasks.FirstOrDefault(x => x.Id.ToString() == id);

        if (task is null) 
            return;

        _tasks.Remove(task);
        Save();
    }

    private void Save()
    {
        string json = JsonConvert.SerializeObject(_tasks);
        File.WriteAllText("tasks.json",json);
    }
    
}