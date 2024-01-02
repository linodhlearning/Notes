
using Notes.Api.Model;

namespace Notes.Api.Messages
{
    public record GetNoteByIdRequest(int Id) : BaseInProcessMessage;

    public record GetNoteByIdResponse(NoteModel Data) : NotesInProcessResponse;


    public record GetNoteListRequest() : BaseInProcessMessage;

    public record GetNoteListResponse(IEnumerable<NoteModel> Data) : NotesInProcessResponse;


    public record AddNoteRequest(NoteModel Note) : BaseInProcessMessage;

    public record AddNoteResponse(int Id) : NotesInProcessResponse;


    public record UpdateNoteRequest(NoteModel Note) : BaseInProcessMessage;

    public record UpdateNoteResponse(int Id) : NotesInProcessResponse;

    public record DeleteNoteRequest(int Id) : BaseInProcessMessage;

    public record DeleteNoteResponse() : NotesInProcessResponse;
}
