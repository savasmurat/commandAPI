using System;
using Xunit;
using CommandAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Moq;
using AutoMapper;
using CommandAPI.Models;
using CommandAPI.Data;


namespace CommandAPI.Tests
{
    public class CommandsControllerTests
    {
        [Fact]
        public void GetCommandItems_Returns200OK_WhenDBIsEmpty()
        {
            //Arrange
            var mockRepo = new Mock<ICommandAPIRepo>();
            mockRepo.Setup(repo => repo.GetAllCommands()).Returns(GetCommands(0)));
            
            var controller = new CommandsController(mockRepo.Object, "");
        }
        private List<Command> GetCommands(int num){
            var commands = new List<Command>();
            if(num > 0){
                commands.Add(new Command{
                    Id = 0,
                    HowTo = "How to generate a migration",
                    CommandLine = "dotnet ef migrations add <Name of Migration>",
                    Platform = ".Net Core EF"
                });
            }
            return commands;
        }
    }
}