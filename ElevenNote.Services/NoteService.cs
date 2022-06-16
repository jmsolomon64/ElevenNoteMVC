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
        private readonly ApplicationDbContext _ctx;

        public NoteService(Guid userId, ApplicationDbContext context)
        {
            _userId = userId;
            _ctx = context;
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

            _ctx.Notes.Add(entity);
            return _ctx.SaveChanges() == 1;

            
        }

        public IEnumerable<NoteListItem> GetNotes()
        {
            var query = _ctx.Notes.Where(x => x.OwnerId == _userId)
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
