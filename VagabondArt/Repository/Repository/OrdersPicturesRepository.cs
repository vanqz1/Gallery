using DataSource.Model;
using Repository.RepositoryInterfaces;
using DataSource.DataSourceInterfaces;
using Repository.RepositoryModels;

namespace Repository.Repository
{
    public class OrdersPicturesRepository : IOrdersPicturesRepository
    {
        private IOrdersPricturesDataSource m_OrdersPicturesDataSource;

        public OrdersPicturesRepository(IOrdersPricturesDataSource ordersPricturesDataSource)
        {
            m_OrdersPicturesDataSource = ordersPricturesDataSource;
        }

        public void MakeNewPictureOrder(OrdersPicturesRepositoryModel orderPicture)
        {
            m_OrdersPicturesDataSource.MakeNewPictureOrder(new OrderPictureModel {
                Address = orderPicture.Address,
                Comment = orderPicture.Comment,
                Emmail = orderPicture.Emmail,
                Phone = orderPicture.Phone,
                PictureId = orderPicture.PictureId,
                FullName = orderPicture.FullName
            });
        }
    }
}
