using rest_husky.Models;

namespace rest_husky.Repositories;

public interface IBuzzRepository
{
    IEnumerable<Buzz> GetAllBuzz();

    Buzz CreateBuzz(Profile ParentProfile, Buzz newBuzz);

    Buzz? UpdateBuzz(Buzz buzz);

    Buzz? GetBuzzById(int BuzzId);

    void DeleteBuzz(int buzzId);

    Profile GetProfileById(int profileId);
}