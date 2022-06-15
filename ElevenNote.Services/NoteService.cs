using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevenNote.Data;
using ElevenNote.Models;

namespace ElevenNote.Services
{
    public class NoteService
    {
        private readonly Guid _userId;
        private readonly ApplicationDbContext _context;

        public NoteService(Guid userId)
        {
            _userId = userId;
        }   

        public bool CreateNote(NoteCreate model)
        {
            var entity =
                new Note()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Content = model.Content,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Notes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
            
        }

        public IEnumerable<NoteListItem> GetNotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = _context.Notes.Where(x => x.OwnerId == _userId)
                .Select(x => new NoteListItem
                {
                    NoteId = x.NoteId,
                    Title = x.Title,
                    CreatedDateUtc = x.CreatedUtc
                });

                return query.ToArray();
            }
        }
    }
}
