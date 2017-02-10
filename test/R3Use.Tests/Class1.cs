﻿using NSubstitute;
using R3Use.Core;
using R3Use.Core.Repository.Contracts;
using Xunit;

namespace NPoco.Tests
{
    public class Class1
    {

        [Fact]
        public async void Should_Create_Mock()
        {
            // Arrange 
            var r = Substitute.For<IProspectRepository>();

            r.GetAsync(2).Returns(new Prospect { Id = 2, Name = "Test"});

            // Act
            var y =  await r.GetAsync(2);

            // Assert
            Assert.Equal(2, y.Id);
        }
    }
}
