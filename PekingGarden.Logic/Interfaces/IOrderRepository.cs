using PekingGarden.Domain;
 
namespace PekingGarden.Logic.Interfaces;

public interface IOrderRepository
{
    List<Order> GetOpenOrders();    
}