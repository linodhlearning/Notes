using Notes.Api.Repository.Entities;

namespace Notes.Api.Services
{
    public interface INoteService
    {
        IEnumerable<Note> GetNotes();

        Note GetNoteById(int id);

        IEntity AddNote(Note data);

        IEntity UpdateNote(Note data);

        void DeleteNote(int id);
    }
}
