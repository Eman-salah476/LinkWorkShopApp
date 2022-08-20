using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkShopApp.Models;
using WorkShopApp.Repository.Interfaces;
using WorkShopApp.Services.Interfaces;

namespace WorkShopApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<UserProduct> _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IGenericRepository<UserProduct> orderRepository,
                              IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<bool> AddOrder(UserProduct userProduct)
        {
            await _orderRepository.Add(userProduct);
            var isSaved = await _unitOfWork.Save();
            return isSaved;
        }
    }
}
