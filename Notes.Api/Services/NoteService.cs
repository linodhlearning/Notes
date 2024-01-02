using Notes.Api.Repository;
using Notes.Api.Repository.Entities;

namespace Notes.Api.Services
{

    public class NoteService : INoteService
    {
        private readonly RepoCoordinator _uow;

        public NoteService(RepoCoordinator uow)
        {
            _uow = uow;
        }

        public IEnumerable<Note> GetNotes()
        {
            return _uow.NotesRepo.GetAll();
        }

        public Note GetNoteById(int id)
        {
            return _uow.NotesRepo.GetById(id);
        }

        public IEntity AddNote(Note data)
        {
            data.Id = 0;
            _uow.NotesRepo.Create(data);
            _uow.Save();
            return data;
        }

        public IEntity UpdateNote(Note data)
        {
            _uow.NotesRepo.Update(data);
            _uow.Save();
            return data;
        }

        public void DeleteNote(int id)
        {
            _uow.NotesRepo.Delete(id);
            _uow.Save();
        }
    }
}
