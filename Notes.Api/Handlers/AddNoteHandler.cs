using AutoMapper;
using Notes.Api.Messages;
using Notes.Api.Model;
using Notes.Api.Repository.Entities;
using Notes.Api.Services;

namespace Notes.Api.Handlers
{
    public class AddNoteHandler : BaseMessageHandler<AddNoteRequest, AddNoteResponse>
    {
        private readonly ILogger<AddNoteHandler> _logger;
        private readonly IMapper _mapper;
        private readonly INoteService _noteService;
        public AddNoteHandler(ILogger<AddNoteHandler> logger, IMapper mapper, INoteService noteService) : base(logger)
        {
            _logger = logger;
            _mapper = mapper;
            _noteService = noteService;
        }

        public override async Task<NotesInProcessResponse> ValidateMessage(AddNoteRequest message)
        {
            return await Task.FromResult(new NotesInProcessResponse { Errors = new List<ErrorModel>() });
        }

        public override async Task<AddNoteResponse> HandleMessage(AddNoteRequest message)
        {
            _logger.LogInformation("AddNoteHandler HandleMessage Begin");
            var note = _mapper.Map<Note>(message.Note);
            var data = _noteService.AddNote(note);
            return await Task.FromResult(new AddNoteResponse(data.Id));
        }
    }
}

