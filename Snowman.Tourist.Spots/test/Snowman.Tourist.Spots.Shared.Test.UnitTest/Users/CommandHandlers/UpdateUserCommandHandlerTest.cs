using NSubstitute;
using NUnit.Framework;
using Snowman.Tourist.Spots.Domain.Users.CommandHandlers;
using Snowman.Tourist.Spots.Domain.Users.Models;
using Snowman.Tourist.Spots.Domain.Users.Repositories;
using Snowman.Tourist.Spots.Shared.Domain.Interfaces;
using Snowman.Tourist.Spots.Shared.Domain.Notifications;
using Snowman.Tourist.Spots.Shared.Test.Builder.Users.Commands;
using Snowman.Tourist.Spots.Shared.Test.Builder.Users.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Snowman.Tourist.Spots.Shared.Test.UnitTest.Users.CommandHandlers
{
    public class UpdateUserCommandHandlerTest
    {
        private IUserRepository repositoryMock;
        private UpdateUserCommandHandler handler;

        [SetUp]
        public void Setup()
        {
            repositoryMock = Substitute.For<IUserRepository>();
            var unitOfWorkMock = Substitute.For<IUnitOfWork>();
            unitOfWorkMock.CommitAsync().Returns(true);

            handler = new UpdateUserCommandHandler(repositoryMock, unitOfWorkMock, new NotificationContext(), Substitute.For<IMediatorHandler>());
        }

        [Test]
        public async Task UpdateUserCommandHandler_UserIsNotExist_ShouldReturn_UserIsNotFind()
        {
            User user = null;
            var command = new UpdateUserCommandBuilder().Builder();
            
            repositoryMock.GetByExternalIdAsync(Arg.Any<string>()).Returns(user);

            var result = await handler.Handle(command, new CancellationToken());

            Assert.IsTrue(result.HasAProblem);
        }

        [Test]
        public async Task UpdateUserCommandHandler_UpdateUser()
        {
            User user = new UserBuild().Builder();
            var command = new UpdateUserCommandBuilder().Builder();

            repositoryMock.GetByExternalIdAsync(Arg.Any<string>()).Returns(user);

            var result = await handler.Handle(command, new CancellationToken());

            Assert.IsTrue(result.Success);
            Assert.AreEqual(user.Id, (Guid)result.Data);
        }
    }
}
