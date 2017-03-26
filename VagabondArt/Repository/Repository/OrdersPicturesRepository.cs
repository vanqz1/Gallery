using DataSource.Model;
using Repository.RepositoryInterfaces;
using DataSource.DataSourceInterfaces;

namespace Repository.Repository
{
    public class OrdersPicturesRepository : IOrdersPicturesRepository
    {
        private IOrdersPricturesDataSource m_OrdersPicturesDataSource;

        public OrdersPicturesRepository(IOrdersPricturesDataSource ordersPricturesDataSource)
        {
            m_OrdersPicturesDataSource = ordersPricturesDataSource;
        }

        public void MakeNewPictureOrder(OrderPictureModel orderPicture)
        {
            m_OrdersPicturesDataSource.MakeNewPictureOrder(orderPicture);
        }
    }
}
