using System.Net; 
using Notes.Api.Messages;
using Notes.Api.Model;
using Notes.Api.Services;

namespace Notes.Api.Handlers
{
    public class DeleteNoteHandler : BaseMessageHandler<DeleteNoteRequest, DeleteNoteResponse>
    {
        private readonly ILogger<DeleteNoteHandler> _logger;
        private readonly INoteService _noteService;
        public DeleteNoteHandler(ILogger<DeleteNoteHandler> logger, INoteService noteService) : base(logger)
        {
            _logger = logger;
            _noteService = noteService;
        }

        public override async Task<NotesInProcessResponse> ValidateMessage(DeleteNoteRequest message)
        {
            var errors = new List<ErrorModel>();
            if (message.Id <= 0)
            {
                errors.Add(new ErrorModel
                {
                    Code = (int)HttpStatusCode.BadRequest,
                    Detail = "Note Id provided is invalid",
                    Source = string.Empty,
                    Title = "Invalid Note id"
                });
            }
            return await Task.FromResult(new NotesInProcessResponse { Errors = errors });
        }

        public override async Task<DeleteNoteResponse> HandleMessage(DeleteNoteRequest message)
        {
            _logger.LogInformation("DeleteNotehandler HandleMessage Begin");
            _noteService.DeleteNote(message.Id);
            return await Task.FromResult(new DeleteNoteResponse());
        }
    }
}
