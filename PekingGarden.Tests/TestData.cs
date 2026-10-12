using PekingGarden.Domain;

namespace PekingGarden.Tests;

public class TestData
{
   public static readonly DiningTable Table4 = new DiningTable(4, "4", false);
   public static readonly DiningTable Table5 = new DiningTable(5, "5", false);

   public static readonly DateTime Evening = new DateTime(2026, 10, 10, 19, 30, 0);
}