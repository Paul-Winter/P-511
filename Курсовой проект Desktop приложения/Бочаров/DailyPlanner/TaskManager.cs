using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace DailyPlanner
{
    public class PlannerTask
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }

    public class TaskManager
    {
        private readonly string _filePath = "tasks.json";
        public List<PlannerTask> Tasks { get; private set; }

        public TaskManager()
        {
            LoadTasks();
        }

        public void LoadTasks()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                Tasks = JsonSerializer.Deserialize<List<PlannerTask>>(json) ?? new List<PlannerTask>();
            }
            else
            {
                Tasks = new List<PlannerTask>();
            }
        }

        public void SaveTasks()
        {
            var json = JsonSerializer.Serialize(Tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        public void AddTask(PlannerTask task) { Tasks.Add(task); SaveTasks(); }
        public void UpdateTask() { SaveTasks(); }
        public void DeleteTask(string id)
        {
            var task = Tasks.FirstOrDefault(t => t.Id == id);
            if (task != null) { Tasks.Remove(task); SaveTasks(); }
        }

        public List<PlannerTask> GetTasksByDate(DateTime date)
        {
            return Tasks.Where(t => t.Date.Date == date.Date).OrderBy(t => t.Date).ToList();
        }
    }
}