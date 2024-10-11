using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using TaskManager.APP;

namespace TaskManager.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void UserTask_Constructor_SetsPropertiesCorrectly()
        {
            var title = "Complete Project Proposal";
            var dueDate = new DateTime(2023, 12, 31);
            var state = "In Progress";

            var task = new UserTask(title, dueDate, state);

            Assert.Equal(title, task.Title);
            Assert.Equal(dueDate, task.Due);
            Assert.Equal(state, task.State);
        }

        [Fact]
        public void Logic_AddTask_AddsTaskCorrectly()
        {
            var taskList = new List<UserTask>();
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Console.SetIn(new StringReader("Prepare Presentation\n05/15/2024\nNot Started\n"));

            Logic.AddTask(taskList);

            Assert.Single(taskList);
            Assert.Equal("Prepare Presentation", taskList[0].Title);
            Assert.Equal(new DateTime(2024, 5, 15), taskList[0].Due);
            Assert.Equal("Not Started", taskList[0].State);
            Assert.Contains("New task Added: Prepare Presentation", consoleOutput.ToString());
        }

        [Fact]
        public void Logic_RemoveTasks_RemovesExistingTask()
        {
            var taskList = new List<UserTask>
            {
                new UserTask("Write Report", new DateTime(2023, 11, 30), "In Progress"),
                new UserTask("Client Meeting", new DateTime(2023, 12, 5), "Not Started")
            };
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Console.SetIn(new StringReader("Write Report\n"));

            Logic.RemoveTasks(taskList);

            Assert.Single(taskList);
            Assert.DoesNotContain(taskList, t => t.Title == "Write Report");
            Assert.Contains("Task Deleted", consoleOutput.ToString());
        }

        [Fact]
        public void Logic_ShowTasks_DisplaysAllTasks()
        {
            var taskList = new List<UserTask>
            {
                new UserTask("Team Meeting", new DateTime(2023, 11, 25), "Not Started"),
                new UserTask("Code Review", new DateTime(2023, 11, 28), "In Progress")
            };
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            Logic.ShowTasks(taskList);

            var output = consoleOutput.ToString();
            Assert.Contains("Team Meeting", output);
            Assert.Contains("11/25/2023", output);
            Assert.Contains("Not Started", output);
            Assert.Contains("Code Review", output);
            Assert.Contains("11/28/2023", output);
            Assert.Contains("In Progress", output);
        }

        [Fact]
        public void Menu_Input_ReturnsValidNumber()
        {
            var consoleInput = new StringReader("3\n");
            Console.SetIn(consoleInput);

            var result = Menu.Input();

            Assert.Equal(3, result);
        }

        [Fact]
        public void Menu_Input_ReturnsZeroForInvalidInput()
        {
            var consoleInput = new StringReader("invalid\n");
            Console.SetIn(consoleInput);

            var result = Menu.Input();

            Assert.Equal(0, result);
        }

        [Fact]
        public async Task Data_SerializeAndDeserialize_WorksCorrectly()
        {
            var taskList = new List<UserTask>
            {
                new UserTask("Quarterly Report", new DateTime(2023, 12, 31), "Not Started"),
                new UserTask("Team Building Event", new DateTime(2024, 1, 15), "In Progress")
            };

            await Data.SerializeAsync(taskList);
            var deserializedTasks = Data.DeserializeTasks();

            Assert.Equal(2, deserializedTasks.Count);
            Assert.Equal("Quarterly Report", deserializedTasks[0].Title);
            Assert.Equal(new DateTime(2023, 12, 31), deserializedTasks[0].Due);
            Assert.Equal("Not Started", deserializedTasks[0].State);
            Assert.Equal("Team Building Event", deserializedTasks[1].Title);
            Assert.Equal(new DateTime(2024, 1, 15), deserializedTasks[1].Due);
            Assert.Equal("In Progress", deserializedTasks[1].State);
        }
    }
}