using DataSource.Model;

namespace Repository.RepositoryInterfaces
{
    public interface IOrdersPicturesRepository
    {
        void MakeNewPictureOrder(OrderPictureModel orderPicture);
    }
}
