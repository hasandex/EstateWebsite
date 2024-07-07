namespace EstateWebsite.Repo.IRepo
{
    public interface ICommentRepo
    {
        int Add(Comment comment);
        Comment GetById(int commentId);
        int RemoveComment(int commentId);
    }
}
