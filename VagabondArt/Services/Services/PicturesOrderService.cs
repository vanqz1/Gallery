using Services.Interfaces;
using Services.Models;
using Repository.RepositoryInterfaces;
using Repository.RepositoryModels;

namespace Services.Services
{
    public class PicturesOrderService : IPicturesOrderService
    {
        private readonly IOrdersPicturesRepository m_OrdersPicturesRepository;

        public PicturesOrderService(IOrdersPicturesRepository ordersPicturesRepository)
        {
            m_OrdersPicturesRepository = ordersPicturesRepository;
        }

        public void MakeNewPicturesOrder(PicturesOrder pictureOrder)
        {
            m_OrdersPicturesRepository.MakeNewPictureOrder(new OrdersPicturesRepositoryModel
            {
                Address = pictureOrder.Address,
                Comment = pictureOrder.Comment,
                Emmail = pictureOrder.Emmail,
                Phone = pictureOrder.Phone,
                PictureId = pictureOrder.PictureId,
                FullName = pictureOrder.FullName
            });
        }
    }
}
