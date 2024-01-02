using AutoMapper;
using Notes.Api.Messages;
using Notes.Api.Model;
using Notes.Api.Repository.Entities;
using Notes.Api.Services;

namespace Notes.Api.Handlers
{
    public class UpdateNoteHandler : BaseMessageHandler<UpdateNoteRequest, UpdateNoteResponse>
    {
        private readonly ILogger<UpdateNoteHandler> _logger;
        private readonly IMapper _mapper;
        private readonly INoteService _noteService;

        private Note _noteEnt;
        public UpdateNoteHandler(ILogger<UpdateNoteHandler> logger, IMapper mapper, INoteService noteService) : base(logger)
        {
            _logger = logger;
            _mapper = mapper;
            _noteService = noteService;
        }

        public override async Task<NotesInProcessResponse> ValidateMessage(UpdateNoteRequest message)
        {
            return await Task.FromResult(new NotesInProcessResponse { Errors = new List<ErrorModel>() });
        }

        public override async Task<UpdateNoteResponse> HandleMessage(UpdateNoteRequest message)
        {
            _logger.LogInformation("UpdateNoteHandler HandleMessage Begin");
            var note = _mapper.Map<Note>(message.Note);
            var data = _noteService.UpdateNote(note);
            return await Task.FromResult(new UpdateNoteResponse(data.Id));
        }
    }
}
