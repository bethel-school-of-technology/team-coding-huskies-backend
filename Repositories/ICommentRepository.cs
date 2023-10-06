using rest_husky.Models;

namespace rest_husky.Repositories;

public interface ICommentRepository
{
    IEnumerable<Comment> GetCommentsOnPost(int postId);

    Profile GetProfile (int profileId);

    Buzz GetBuzz (int buzzId);

    Comment CreateComment(Profile parentProfile,Buzz parentBuzz, Comment newComment);

    Comment GetComment(int commentId);

    Comment? EditComment(Comment newComment);

    void DeleteComment(int commentId);
}