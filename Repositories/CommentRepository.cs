using rest_husky.Data;
using rest_husky.Models;
using Microsoft.EntityFrameworkCore;

namespace rest_husky.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly ProfileContext _context;

    public CommentRepository(ProfileContext context)
    {
        _context = context;
    }

    public Profile GetProfile (int profileId)
    {
        var profile = _context.Profiles.Single(b => b.Id == profileId);

        return profile;
    }

    public Buzz GetBuzz (int buzzId)
    {
        var buzz = _context.Buzzes.Single(b => b.Id == buzzId);

        return buzz;
    }

    public Comment CreateComment(Profile parentProfile,Buzz parentBuzz, Comment newComment)
    {
        _context.Attach(parentBuzz);
        parentBuzz.Commented.Add(newComment);
        _context.Attach(parentProfile);
        parentProfile.Comments.Add(newComment);
        _context.SaveChanges();

        return newComment;
    }

    public void DeleteComment(int commentId)
    {
        var commentToDelete = _context.Comments.Find(commentId);
        if (commentToDelete is not null)
        {
            _context.Comments.Remove(commentToDelete);
            _context.SaveChanges();
        }
    }

    public Comment? EditComment(Comment newComment)
    {
        var originComment = _context.Comments.Find(newComment.Id);
        if (originComment is not null)
        {
            originComment.Text = newComment.Text;
            _context.SaveChanges();
        }
        return originComment;
    }

    public Comment GetComment(int commentId)
    {
        return _context.Comments
            .AsNoTracking()
            .Single(c => c.Id == commentId);
    }

    public IEnumerable<Comment> GetCommentsOnPost(int postId)
    {
        throw new NotImplementedException();
    }
}