using DataSource.Model;
using Repository.RepositoryModels;

namespace Repository.RepositoryInterfaces
{
    public interface IOrdersPicturesRepository
    {
        void MakeNewPictureOrder(OrdersPicturesRepositoryModel orderPicture);
    }
}
