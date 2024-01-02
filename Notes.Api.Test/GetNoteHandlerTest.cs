using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Notes.Api.AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly Mock<INoteService> _noteService;
        public GetNoteHandlerTest()
        {
            _logger = new Mock<ILogger<GetNoteHandler>>();

            _noteService = new Mock<INoteService>();


            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new NoteMappingProfile());
            });
            _mapper = config.CreateMapper();

        }

        [Fact]
        public async Task GivenNoteHandler_GeneralNoteById_Request_Returns_OneNote()
        {
            _noteService.Setup(x => x.GetNoteById(It.IsAny<int>())).Returns(new Note
            {
                Description = "test1",
                Id = 101,
                Title = "Test123",
                CreatedBy = "LinT",
                ModifiedBy = null
            });

            var handler = new GetNoteHandler(_logger.Object, _mapper, _noteService.Object);
            var request = new GetNoteByIdRequest(Id: 101);
            var validationResult = await handler.ValidateMessage(request);
            var result = await handler.HandleMessage(request);

            validationResult.Should().NotBeNull();
            validationResult.Errors.Should().BeEmpty();
            result.Should().NotBeNull();
            result.Data.Should().NotBeNull();
            result.Data.Id.Should().Be(101);
            result.Data.Title.Should().Be("Test123");
        }
    }
}