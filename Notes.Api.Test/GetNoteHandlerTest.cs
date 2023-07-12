using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Notes.Api.Handlers;
using Notes.Api.Messages;

namespace Notes.Api.Test
{
    public class GetNoteHandlerTest
    {
        private readonly Mock<ILogger<GetNoteHandler>> _logger;

        public GetNoteHandlerTest()
        {
            _logger = new Mock<ILogger<GetNoteHandler>>();
        }

        [Fact]
        public async Task GivenNoteHandler_GeneralNoteById_Request_Returns_OneNote()
        {
            var handler = new GetNoteHandler(_logger.Object);
            var request = new GetNoteByIdRequest(Id: 101);
            var validationResult = await handler.ValidateMessage(request);
            var result = await handler.HandleMessage(request);

            validationResult.Should().NotBeNull();
            validationResult.Errors.Should().BeEmpty();
            result.Should().NotBeNull();
            result.Data.Should().NotBeNull();
            result.Data.Count().Should().Be(1);
            result.Data.First().Id.Should().Be(101);
        }
    }
}