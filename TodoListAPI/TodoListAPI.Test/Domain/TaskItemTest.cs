using System;
using System.Linq;
using TodoListAPI.Core.Domain;
using TodoListAPI.Resources;
using Xunit;

namespace TodoListAPI.Test.Domain
{
    public class TaskItemTest
    {
        [Fact]
        public void ShouldCreateTask_Success()
        {
            TaskItem taskItem = new TaskItem("This is a title");

            Assert.NotNull(taskItem);
            Assert.True(taskItem.InsertIsValid());
        }

        [Fact]
        public void ShouldCreateTaskWithEmptyTitle_Error()
        {
            TaskItem taskItem = new TaskItem("");

            Assert.False(taskItem.InsertIsValid());
            Assert.True(taskItem.GetErrors().Find(e => e == ErrorMessage_TaskItem._001_Title) is not null);
            Assert.True(taskItem.GetErrors().Find(e => e == ErrorMessage_TaskItem._002_Title) is not null);
        }

        [Fact]
        public void ShouldCreateTaskWithTitleBiggerThan20Char_Error()
        {
            TaskItem taskItem = new TaskItem("This is a big title to return an error about characters max length");

            Assert.False(taskItem.InsertIsValid());
            Assert.True(taskItem.GetErrors().Find(e => e == ErrorMessage_TaskItem._002_Title) is not null);
        }

        [Fact]
        public void ShoulCreateTaskWithStartTime_Success()
        {
            TaskItem taskItem = new TaskItem("This is a title", new DateTime(2022, 05, 22));

            Assert.True(taskItem.InsertIsValid());
        }

        [Fact]
        public void ShouldCreateTaskWithStartTime_Error()
        {
            TaskItem taskItem = new TaskItem("This is a title", new DateTime(2052, 05, 22));

            Assert.False(taskItem.InsertIsValid());
            Assert.True(taskItem.GetErrors().Find(e => e == ErrorMessage_TaskItem._004_StartTime) is not null);
        }

        [Fact]
        public void ShouldCreateTaskWithEndTime_Success()
        {
            TaskItem taskItem = new TaskItem("This is a title", new DateTime(2022, 05, 22), new DateTime(2022, 05, 23));

            Assert.True(taskItem.InsertIsValid());
        }

        [Fact]
        public void ShouldCreateTaskWithEndTime_Error()
        {
            TaskItem taskItem = new TaskItem("This is a title", new DateTime(2022, 05, 22), new DateTime(2022, 04, 23));

            Assert.False(taskItem.InsertIsValid());
            Assert.True(taskItem.GetErrors().Find(e => e == ErrorMessage_TaskItem._005_EndTime) is not null);
        }
    }
}
