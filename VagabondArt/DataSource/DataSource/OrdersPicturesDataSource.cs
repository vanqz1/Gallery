using DataSource.DataSourceInterfaces;
using DataSource.Model;

namespace DataSource.DataSource
{
    public class OrdersPicturesDataSource : IOrdersPricturesDataSource
    { 
        public void MakeNewPictureOrder(OrderPictureModel pictureOrder)
        {
            using (var contex = new VagabondEntities())
            {
                contex.OrdersPictures.Add(new OrdersPicture {
                        Email = pictureOrder.Emmail,
                        Phone = pictureOrder.Phone,
                        Address = pictureOrder.Address,
                        Comment = pictureOrder.Comment,
                        ProductId = pictureOrder.PictureId,
                        FullName = pictureOrder.FullName
                });

                contex.SaveChanges();
            }
       }
    }
}
