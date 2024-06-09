using DataAccess.SqlLite;
using Domain;
using Logic.Commands;
using Logic.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DataAccess.InMemoryDatabase

namespace Logic.Tests
{
    [TestClass]
    public class AddWeatherTest
    {
        private readonly IMediator _mediator;

       
        public AddWeatherTest()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .SetupApplication()
                .SetupDataAccessInMemory()
                .BuildServiceProvider();
            _mediator = serviceProvider.GetRequiredService<IMediator>();
        }

        [TestMethod]
        public async Task CannotAddNullAsync()
        {
            //Arrange
            ApiWeather weather = null;
            AddWeatherRequest message = null;
            
            try
            {
                message = new AddWeatherRequest(weather);
            } catch (NullReferenceException ex)
            {
                Assert.IsTrue(true);
                return;
            }
            //Act && Assert
            await Assert.ThrowsExceptionAsync<NullReferenceException>(
                () => _mediator.Send(message));
        }

        [TestMethod]
        public async Task HappyFlow()
        {
            //Arrange
            var weather = new ApiWeather(20,20,20,20,20);
            var message = new AddWeatherRequest(weather);

            //Act
            await _mediator.Send(message);

            //Assert
            var books = await _mediator.Send(new GetWeatherRequest());
            
            Assert.IsTrue(books.Count == 1);
        }
    }
}
