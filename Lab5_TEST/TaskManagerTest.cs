using Lab5.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_TEST
{
    internal class TaskManagerTest
    {
        private TaskManager _taskManager;
        [SetUp]
        public void Setup()
        {
            _taskManager = new TaskManager();
        }
        [Test]
        public void AddTask_ShouldIncreaseTaskCount()
        {
            // Arrange
            var task = new Lab5.Tasks.Task("Test task");
            // Act
            _taskManager.AddTask(task);
            // Assert
            Assert.AreEqual(1, _taskManager.GetTasks().Count);
        }
        [Test]
        public void RemoveTask_ExistingTask_ShouldDecreaseTaskCount()
        {
            // Arrange
            var task = new Lab5.Tasks.Task("chwilowy task");
            _taskManager.AddTask(task);
            // Act
            _taskManager.RemoveTask(0);
            // Assert
            Assert.AreEqual(1, _taskManager.GetTasks().Count);
            foreach ( var t in _taskManager.GetTasks() )
            {
                if (t.Title != "chwilowy task")
                {
                    Assert.AreEqual(1, 2);
                }
            }
        }

        [Test]
        public void MarkTaskAsCompleted_ExistingTask_ShouldMarkTaskAsCompleted()
        {
            // Arrange
            var task = new Lab5.Tasks.Task("nie wykonany task");
            _taskManager.AddTask(task);
            // Act
            _taskManager.MarkTaskAsCompleted(1);
            // Assert
            Assert.AreEqual(true, _taskManager.GetTaskById(1).IsCompleted);
        }

    }
}
