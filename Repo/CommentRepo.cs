
namespace EstateWebsite.Repo
{
    public class CommentRepo : ICommentRepo
    {
        private readonly AppDbContext _context;

        public CommentRepo(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Comment comment)
        {
            _context.Comments.Add(comment);
            return _context.SaveChanges();
        }

        public Comment GetById(int commentId)
        {
            var comment = _context.Comments.SingleOrDefault(c => c.Id == commentId);
            if (comment == null)
            {
                return null;
            }
            return comment;
        }

        public int RemoveComment(int commentId)
        {
            var comment = GetById(commentId);
            if (comment == null)
            {
                return 0;
            }
            _context.Comments.Remove(comment);
            return _context.SaveChanges();
        }
    }
}
