using Microsoft.AspNetCore.Mvc;
using Notes.Api.Messages;
using Notes.Api.Model;
using Notes.Api.Utils;

namespace Notes.Api.Controllers
{
    [Route("mynotes")]
    [ApiController]
    public class NotesController : BaseController<NotesController>
    {
        public NotesController(ILogger<NotesController> logger) : base(logger)
        {
        }

        [HttpGet]
        [Route("notes")]
        public async Task<IActionResult> GetNotesList()
        {
            try
            {
                return await SendToMessageHandler(new GetNoteListRequest());
            }
            catch (Exception ex)
            {
                string error = "Error occurred while retrieving notes";
                _logger.LogError(ex, error);
                return ex.HandleException(error);
            }
        }

        [HttpGet]
        [Route("notes/{noteId:int}")]
        public async Task<IActionResult> GetNote(int noteId)
        {
            try
            {
                return await SendToMessageHandler(new GetNoteByIdRequest(noteId));
            }
            catch (Exception ex)
            {
                string error = $"Error occurred while retrieving note for note id:{noteId}";
                _logger.LogError(ex, error);
                return ex.HandleException(error);
            }
        }

        [HttpPost]
        [Route("notes")]
        public async Task<IActionResult> AddNote(NoteModel note)
        {
            try
            {
                return await SendToMessageHandler(new AddNoteRequest(note));
            }
            catch (Exception ex)
            {
                string error = "Error occurred while adding new notes";
                _logger.LogError(ex, error);
                return ex.HandleException(error);
            }
        }

        [HttpPut]
        [Route("notes")]
        public async Task<IActionResult> UpdateNote(NoteModel note)
        {
            try
            {
                return await SendToMessageHandler(new UpdateNoteRequest(note));
            }
            catch (Exception ex)
            {
                string error = $"Error occurred while updating note  with id {note.Id}";
                _logger.LogError(ex, error);
                return ex.HandleException(error);
            }
        }

        [HttpDelete]
        [Route("notes/{noteId:int}")]
        public async Task<IActionResult> DeleteNote(int noteId)
        {
            try
            {
                return await SendToMessageHandler(new DeleteNoteRequest(noteId));
            }
            catch (Exception ex)
            {
                string error = $"Error occurred while deleting the note with id {noteId}";
                _logger.LogError(ex, error);
                return ex.HandleException(error);
            }
        }
    }
}
