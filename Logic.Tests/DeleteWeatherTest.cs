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
using DataAccess.InMemoryDatabase;

namespace Logic.Tests
{
    [TestClass]
    public class DeleteWeatherTest
    {
        private readonly IMediator _mediator;

       
        public DeleteWeatherTest()
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
            DeleteWeatherCommand message = null;
            
            //Act && Assert
            await Assert.ThrowsExceptionAsync<NullReferenceException>(
                () => _mediator.Send(message));
        }

        [TestMethod]
        public async Task HappyFlow()
        {
            var weather = new ApiWeather(20, 20, 20, 20, 20);
            var message = new AddWeatherRequest(weather);

            await _mediator.Send(message);
            var weathers = await _mediator.Send(new GetWeatherRequest());
            var last = weathers.Last();

            //Arrange
            var message2 = new DeleteWeatherCommand();
            message2.Id = last.Id;

            //Act
            await _mediator.Send(message2);

            //Assert
            var books = await _mediator.Send(new GetWeatherRequest());
            
            Assert.IsTrue(books.Count == 1);
        }
    }
}
