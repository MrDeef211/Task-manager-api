using Api.App.Commands.CompleteTask;
using Api.App.Commands.CreateTask;
using Api.App.Commands.DeleteTask;
using Api.App.Commands.StartTask;
using Api.App.Commands.UpdateTask;

using Api.App.Interfaces;
using Api.App.Services;
using Api.Model.Entity;
using Api.Model.Exceptions;
using Api.Model.Events;
using Api.Model.Enums;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace UnitTests
{
	/// <summary>
	/// Тесты для команд
	/// </summary>
	public class CommandsTests
	{
		/// <summary>
		/// Конструктор для создания сервиса
		/// </summary>
		/// <param name="taskRepoMock"></param>
		/// <returns></returns>
		private ITaskService ServiceCreate(Mock<ITaskRepository> taskRepoMock)
		{
			var eventRepoMock = new Mock<ITaskEventRepository>();

			var service = new TaskCommandService(
			    eventRepoMock.Object,
				taskRepoMock.Object
			);
			return service;
		}

		/// <summary>
		/// Конструктор для создания сервиса
		/// </summary>
		/// <param name="taskRepoMock"></param>
		/// <returns></returns>
		private ITaskService ServiceCreate(Mock<ITaskRepository> taskRepoMock, Mock<ITaskEventRepository> eventRepoMock)
		{
			var service = new TaskCommandService(
	            eventRepoMock.Object,
	            taskRepoMock.Object
);
			return service;
		}

		[Fact]
		public async Task CreateTaskSuccess()
		{
			var taskRepoMock = new Mock<ITaskRepository>();
			var eventRepoMock = new Mock<ITaskEventRepository>();

			var service = ServiceCreate(taskRepoMock, eventRepoMock);

			var CreateTaskHandler = new CreateTaskHandler(service);

			var title = "title";
			var description = "desc";
			var deadline = DateTime.UtcNow.AddDays(7);

			var taskData = new CreateTask { 
				Title = title, 
				Description = description,
				Deadline = deadline
			};

			var taskId = await CreateTaskHandler.Handle(taskData, new CancellationToken());

			taskRepoMock.Verify(
				r => r.ApplyAsync(It.Is<TaskCreatedEvent>(t =>
					t.Title == title &&
					t.Description == description &&
					t.Deadline == deadline
				)),
				Times.Once
			);

			eventRepoMock.Verify(
				e => e.AddAsync(It.Is<TaskCreatedEvent>(ev =>
					ev.Title == title &&
					ev.Description == description &&
					ev.Deadline == deadline
				)),
				Times.Once
			);

			taskId.Should().NotBeEmpty();
		}

		[Fact]
		public async Task StartTaskSuccess()
		{
			var taskRepoMock = new Mock<ITaskRepository>();
			var eventRepoMock = new Mock<ITaskEventRepository>();

			var service = ServiceCreate(taskRepoMock, eventRepoMock);

			var StartTaskHandler = new StartTaskHandler(service);

			var task = new TaskEntity
			{
				Id = Guid.NewGuid(),
				Status = TaskStatusEnum.New
			};

			var taskData = new StartTask(task.Id);

			taskRepoMock
	            .Setup(r => r.GetByIdAsync(task.Id))
	            .ReturnsAsync(task);

			await StartTaskHandler.Handle(taskData, new CancellationToken());

			taskRepoMock.Verify(
				r => r.ApplyAsync(It.Is<TaskStartedEvent>(t =>
					t.TaskId == task.Id
				)),
				Times.Once
			);

			eventRepoMock.Verify(
				e => e.AddAsync(It.Is<TaskStartedEvent>(ev =>
					ev.TaskId == task.Id
				)),
				Times.Once
			);
		}

		[Fact]
		public async Task StartTaskInProgressThrowsException()
		{
			var taskRepoMock = new Mock<ITaskRepository>();

			var service = ServiceCreate(taskRepoMock);

			var StartTaskHandler = new StartTaskHandler(service);

			var task = new TaskEntity
			{
				Id = Guid.NewGuid(),
				Status = TaskStatusEnum.InProgress
			};

			var taskData = new StartTask(task.Id);

			taskRepoMock
				.Setup(r => r.GetByIdAsync(task.Id))
				.ReturnsAsync(task);

			Assert.ThrowsAsync<DomainException>(async () => await StartTaskHandler.Handle(taskData, new CancellationToken()));
		}

		[Fact]
		public async Task StartTaskCompletedThrowsException()
		{
			var taskRepoMock = new Mock<ITaskRepository>();

			var service = ServiceCreate(taskRepoMock);

			var StartTaskHandler = new StartTaskHandler(service);

			var task = new TaskEntity
			{
				Id = Guid.NewGuid(),
				Status = TaskStatusEnum.Completed
			};

			var taskData = new StartTask(task.Id);

			taskRepoMock
				.Setup(r => r.GetByIdAsync(task.Id))
				.ReturnsAsync(task);

			Assert.ThrowsAsync<DomainException>(async () => await StartTaskHandler.Handle(taskData, new CancellationToken()));
		}

		[Fact]
		public async Task CompleteTaskSuccess()
		{
			var taskRepoMock = new Mock<ITaskRepository>();
			var eventRepoMock = new Mock<ITaskEventRepository>();

			var service = ServiceCreate(taskRepoMock, eventRepoMock);

			var CompleteTaskHandler = new CompleteTaskHandler(service);

			var task = new TaskEntity
			{
				Id = Guid.NewGuid(),
				Status = TaskStatusEnum.InProgress
			};

			var taskData = new CompleteTask(task.Id);

			taskRepoMock
				.Setup(r => r.GetByIdAsync(task.Id))
				.ReturnsAsync(task);

			await CompleteTaskHandler.Handle(taskData, new CancellationToken());

			taskRepoMock.Verify(
				r => r.ApplyAsync(It.Is<TaskCompletedEvent>(t =>
					t.TaskId == task.Id
				)),
				Times.Once
			);

			eventRepoMock.Verify(
				e => e.AddAsync(It.Is<TaskCompletedEvent>(ev =>
					ev.TaskId == task.Id
				)),
				Times.Once
			);
		}

		[Fact]
		public async Task CompleteTaskNotStartedThrowsException()
		{
			var taskRepoMock = new Mock<ITaskRepository>();

			var service = ServiceCreate(taskRepoMock);

			var CompleteTaskHandler = new CompleteTaskHandler(service);

			var task = new TaskEntity
			{
				Id = Guid.NewGuid(),
				Status = TaskStatusEnum.New 
			};

			var taskData = new CompleteTask(task.Id);

			taskRepoMock
				.Setup(r => r.GetByIdAsync(task.Id))
				.ReturnsAsync(task);

			Assert.ThrowsAsync<DomainException>(async () => await CompleteTaskHandler.Handle(taskData, new CancellationToken()));
		}

		[Fact]
		public async Task CompleteTaskCompletedThrowsException()
		{
			var taskRepoMock = new Mock<ITaskRepository>();

			var service = ServiceCreate(taskRepoMock);

			var CompleteTaskHandler = new CompleteTaskHandler(service);

			var task = new TaskEntity
			{
				Id = Guid.NewGuid(),
				Status = TaskStatusEnum.Completed
			};

			var taskData = new CompleteTask(task.Id);

			taskRepoMock
				.Setup(r => r.GetByIdAsync(task.Id))
				.ReturnsAsync(task);

			Assert.ThrowsAsync<DomainException>(async () => await CompleteTaskHandler.Handle(taskData, new CancellationToken()));
		}

		[Fact]
		public async Task UpdateTaskSuccess()
		{
			var taskRepoMock = new Mock<ITaskRepository>();
			var eventRepoMock = new Mock<ITaskEventRepository>();

			var service = ServiceCreate(taskRepoMock, eventRepoMock);

			var CompleteTaskHandler = new CompleteTaskHandler(service);

			var task = new TaskEntity
			{
				Id = Guid.NewGuid(),
				Status = TaskStatusEnum.InProgress
			};

			var taskData = new CompleteTask(task.Id);

			taskRepoMock
				.Setup(r => r.GetByIdAsync(task.Id))
				.ReturnsAsync(task);

			await CompleteTaskHandler.Handle(taskData, new CancellationToken());

			taskRepoMock.Verify(
				r => r.ApplyAsync(It.Is<TaskCompletedEvent>(t =>
					t.TaskId == task.Id
				)),
				Times.Once
			);

			eventRepoMock.Verify(
				e => e.AddAsync(It.Is<TaskCompletedEvent>(ev =>
					ev.TaskId == task.Id
				)),
				Times.Once
			);
		}




	}
}
