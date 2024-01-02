using AutoMapper;
using Notes.Api.Messages;
using Notes.Api.Model;
using Notes.Api.Services;

namespace Notes.Api.Handlers
{
    public class GetNoteListHandler : BaseMessageHandler<GetNoteListRequest, GetNoteListResponse>
    {
        private readonly ILogger<GetNoteListHandler> _logger;
        private readonly IMapper _mapper;
        private readonly INoteService _noteService;
        public GetNoteListHandler(ILogger<GetNoteListHandler> logger, IMapper mapper, INoteService noteService) : base(logger)
        {
            _logger = logger;
            _mapper = mapper;
            _noteService = noteService;
        }

        public override async Task<NotesInProcessResponse> ValidateMessage(GetNoteListRequest message)
        {
            return await Task.FromResult(new NotesInProcessResponse { Errors = new List<ErrorModel>() });
        }

        public override async Task<GetNoteListResponse> HandleMessage(GetNoteListRequest message)
        {
            _logger.LogInformation("GetNoteListHandler HandleMessage Begin");
            var notes = _noteService.GetNotes();
            var data = _mapper.Map<IEnumerable<NoteModel>>(notes);
            return await Task.FromResult(new GetNoteListResponse(data));
        }
    }
}