using NSubstitute;
using NUnit.Framework;
using Snowman.Tourist.Spots.Domain.Users.CommandHandlers;
using Snowman.Tourist.Spots.Domain.Users.Commands;
using Snowman.Tourist.Spots.Domain.Users.Models;
using Snowman.Tourist.Spots.Domain.Users.Repositories;
using Snowman.Tourist.Spots.Shared.Domain.Commands;
using Snowman.Tourist.Spots.Shared.Domain.Interfaces;
using Snowman.Tourist.Spots.Shared.Domain.Notifications;
using Snowman.Tourist.Spots.Shared.Test.Builder.Users.Commands;
using Snowman.Tourist.Spots.Shared.Test.Builder.Users.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Snowman.Tourist.Spots.Shared.Test.UnitTest.Users.CommandHandlers
{
    public class AddUserCommandHandlerTest
    {
        private IUserRepository repositoryMock;
        private IMediatorHandler mediatorHandlerMock;
        private AddUserCommandHandler handler;

        [SetUp]
        public void Setup()
        {
            repositoryMock = Substitute.For<IUserRepository>();
            mediatorHandlerMock = Substitute.For<IMediatorHandler>();
            var unitOfWorkMock = Substitute.For<IUnitOfWork>();
            unitOfWorkMock.CommitAsync().Returns(true);
            handler = new AddUserCommandHandler(repositoryMock, unitOfWorkMock, new NotificationContext(), mediatorHandlerMock);
        }


        [Test]
        public async Task AddUserCommandHandler_UserAlreadyExists_AndNotHasCHanges_ShouldReturn_UserId()
        {
            var user = new UserBuild().Builder();
            var command = new AddUserCommandBuilder()
                .WithExternalId(user.ExternalId)
                .WithName(user.Name)
                .WithPhoneNumber(user.PhoneNumber)
                .WithEmail(user.Email)
                .Builder();

            repositoryMock.GetByExternalIdAsync(Arg.Any<string>()).Returns(user);
            var result = await handler.Handle(command, new CancellationToken());

            Assert.True(result.Success);
            Assert.AreEqual(user.Id, (Guid)result.Data);
        }

        [Test]
        public async Task AddUserCommandHandler_UserAlreadyExists_AndHasCHanges_ShouldReturn_UserId()
        {
            var guid = Guid.NewGuid();
            var user = new UserBuild().Builder();
            var command = new AddUserCommandBuilder().Builder();

            repositoryMock.GetByExternalIdAsync(Arg.Any<string>()).Returns(user);
            mediatorHandlerMock.SendAsync(Arg.Any<UpdateUserCommand>()).Returns(new CommandResult(true, guid));
            var result = await handler.Handle(command, new CancellationToken());

            Assert.True(result.Success);
            Assert.AreEqual(guid, (Guid)result.Data);
        }

        [Test]
        public async Task AddUserCommandHandler_CreateNewUser()
        {
            User user = null;
            var command = new AddUserCommandBuilder().Builder();

            repositoryMock.GetByExternalIdAsync(Arg.Any<string>()).Returns(user);
            var result = await handler.Handle(command, new CancellationToken());

            Assert.True(result.Success);
            Assert.IsNotNull(result.Data);
        }


    }
}
