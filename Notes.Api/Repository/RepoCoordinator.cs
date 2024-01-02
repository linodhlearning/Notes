using Notes.Api.Repository.Entities;

namespace Notes.Api.Repository
{

    public class RepoCoordinator : IDisposable
    {
        private readonly NotesDBContext _context;

        public RepoCoordinator(NotesDBContext context)
        {
            _context = context;
        }

        public GenericRepository<Note> NotesRepo => new(_context);

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
