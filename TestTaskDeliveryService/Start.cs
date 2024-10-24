using TestTaskDeliveryService.ChoiceService;
using TestTaskDeliveryService.CreateResult;
using TestTaskDeliveryService.Repositories;
using TestTaskDeliveryService.Services;

namespace TestTaskDeliveryService;

public class Start
{
    private  OrderRepository _orderRepository = new();
    private  OrderService _orderService = new();
    private  Choice _choice = new();
    private  Result _result = new();
    public void Build()
    {
        var orders = _orderRepository.GetAllOrders();
        var region = _choice.ChooseRegion();
        var date = _choice.ChooseDate();
        var sortOrders = _orderService.FilterOrders(orders, region, date);
        _result.Create(sortOrders);
    }
}