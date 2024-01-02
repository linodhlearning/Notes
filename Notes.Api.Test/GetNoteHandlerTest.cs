using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Notes.Api.Handlers;
using Notes.Api.Messages;
using Notes.Api.Model;
using Notes.Api.Repository.Entities;
using Notes.Api.Services;

namespace Notes.Api.Test
{
    public class GetNoteHandlerTest
    {
        private readonly Mock<ILogger<GetNoteHandler>> _logger;  
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<INoteService> _noteService;
        public GetNoteHandlerTest()
        {
            _logger = new Mock<ILogger<GetNoteHandler>>();
            _mockMapper = new Mock<IMapper>();
            _noteService = new Mock<INoteService>();

        }

        [Fact]
        public async Task GivenNoteHandler_GeneralNoteById_Request_Returns_OneNote()
        { 
            //_mockMapper.Setup(x => x.Map<Note, NoteModel>(It.IsAny<Note>())).Returns(expected);

            //var handler = new GetNoteHandler(_logger.Object, _mockMapper.Object,_noteService.Object);
            //var request = new GetNoteByIdRequest(Id: 101);
            //var validationResult = await handler.ValidateMessage(request);
            //var result = await handler.HandleMessage(request);

            //validationResult.Should().NotBeNull();
            //validationResult.Errors.Should().BeEmpty();
            //result.Should().NotBeNull();
            //result.Data.Should().NotBeNull();
            //result.Data.Count().Should().Be(1);
            //result.Data.First().Id.Should().Be(101);
        }
    }
}