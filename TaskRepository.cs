using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace CybersecurityChatbotGUI
{
    public class TaskRepository
    {
        public void AddTask(CyberTask task)
        {
            string sql = "INSERT INTO cyber_task (title, description, reminder_date, is_completed) VALUES (@title, @desc, @reminder, @completed)";
            using (MySqlConnection conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@title", task.Title);
                cmd.Parameters.AddWithValue("@desc", task.Description);
                cmd.Parameters.AddWithValue("@reminder", task.ReminderDate.HasValue ? (object)task.ReminderDate.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@completed", task.IsCompleted);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<CyberTask> GetAllTasks()
        {
            List<CyberTask> tasks = new List<CyberTask>();
            string sql = "SELECT task_id, title, description, reminder_date, is_completed FROM cyber_task ORDER BY is_completed, task_id DESC";
            using (MySqlConnection conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tasks.Add(new CyberTask
                        {
                            TaskId = Convert.ToInt32(reader["task_id"]),
                            Title = reader["title"].ToString() ?? "",
                            Description = reader["description"].ToString() ?? "",
                            ReminderDate = reader["reminder_date"] == DBNull.Value ? null : Convert.ToDateTime(reader["reminder_date"]),
                            IsCompleted = Convert.ToBoolean(reader["is_completed"])
                        });
                    }
                }
            }
            return tasks;
        }

        public void MarkTaskCompleted(int taskId)
        {
            string sql = "UPDATE cyber_task SET is_completed = TRUE WHERE task_id = @id";
            using (MySqlConnection conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", taskId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTask(int taskId)
        {
            string sql = "DELETE FROM cyber_task WHERE task_id = @id";
            using (MySqlConnection conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", taskId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
