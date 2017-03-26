using DataSource.Model;

namespace DataSource.DataSourceInterfaces
{
    public interface IOrdersPricturesDataSource
    {
        void MakeNewPictureOrder(OrderPictureModel pictureOrder);
    }
}
