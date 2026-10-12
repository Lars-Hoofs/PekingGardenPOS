using Moq;
using PekingGarden.Domain;
using PekingGarden.Logic;
using PekingGarden.Logic.Interfaces;
using PekingGarden.Logic.Services;

namespace PekingGarden.Tests.Services;

[TestClass]
public class TableServiceTests
{
    private readonly Mock<ITableRepository> tableRepository = new Mock<ITableRepository>();
    private readonly Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
    private readonly TableService service;

    public TableServiceTests()
    {
        service = new TableService(tableRepository.Object, orderRepository.Object);
        tableRepository.Setup(repository => repository.GetTable(4)).Returns(TestData.Table4);
        tableRepository.Setup(repository => repository.GetTable(7)).Returns(TestData.Table5);
    }

    [TestMethod]
    public void GetOverview_OneOpenTable_OnlyThatTableHasAnOrder()
    {
        Order open = new Order(40, TestData.Table4, TestData.Evening, null);
        tableRepository.Setup(repository => repository.GetTables())
            .Returns(new List<DiningTable> { TestData.Table4, TestData.Table5 });
        orderRepository.Setup(repository => repository.GetOpenOrders()).Returns(new List<Order> { open });

        List<TableStatus> overview = service.GetOverview();

        Assert.HasCount(2, overview);
        Assert.IsTrue(overview[0].IsOpen);
        Assert.IsFalse(overview[1].IsOpen);
    }
}