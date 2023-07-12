
using Notes.Api.Model;

namespace Notes.Api.Messages
{
    public record GetNoteByIdRequest(int Id) : BaseInProcessMessage;

    public record GetNoteByIdResponse(IEnumerable<NoteModel> Data) : NotesInProcessResponse;

}
