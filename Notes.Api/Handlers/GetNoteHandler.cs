using AutoMapper;
using Notes.Api.Messages;
using Notes.Api.Model;
using Notes.Api.Services;

namespace Notes.Api.Handlers
{
    public class GetNoteHandler : BaseMessageHandler<GetNoteByIdRequest, GetNoteByIdResponse>
    {
        private readonly ILogger<GetNoteHandler> _logger;
        private readonly IMapper _mapper;
        private readonly INoteService _noteService;
        public GetNoteHandler(ILogger<GetNoteHandler> logger, IMapper mapper, INoteService noteService) : base(logger)
        {
            _logger = logger;
            _mapper = mapper;
            _noteService = noteService;
        }

        public override async Task<NotesInProcessResponse> ValidateMessage(GetNoteByIdRequest message)
        { 
            return await Task.FromResult(new NotesInProcessResponse { Errors = new List<ErrorModel>() });
        }

        public override async Task<GetNoteByIdResponse> HandleMessage(GetNoteByIdRequest message)
        {
            _logger.LogInformation("GetNoteHandler HandleMessage Begin");
            var note = _noteService.GetNoteById(message.Id);
            var data = _mapper.Map<NoteModel>(note);
            return await Task.FromResult(new GetNoteByIdResponse(data));
        }
    }
}
