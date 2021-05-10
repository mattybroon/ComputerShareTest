using System;

class BuyStock {

  public static Tuple<int, int> FindMaxProfit(double[] prices)
  {
    double difference = System.Double.MinValue;
    int days = prices.Length;
    double maxSoFar = prices[days-1];
    int buyDay = -1;
    int sellDay = -1;

    for(int index = days - 2; index >= 0; index--)
    {
      if (prices[index] > maxSoFar)
      {
        maxSoFar = prices[index];
        if (index > buyDay)
        {
          sellDay = index;
        }
      }
      else
      {
        difference = Math.Max(difference, maxSoFar - prices[index]);
        if (buyDay == -1 || prices[index] < prices[buyDay])
        {
          buyDay = index;
        }
        Console.WriteLine(buyDay);
      }
    }
    return new Tuple<int, int>(buyDay, sellDay);
  }
  
  public static void Main(String[] args)
  {
    double []prices = { 19.15, 18.30, 18.88, 17.93, 15.95, 19.03, 19.00 };
    var stockDays = FindMaxProfit(prices);
    if (stockDays.Item1 == 0 && stockDays.Item2 == 0)
    {
      Console.WriteLine("No suitable transactions found");
    }
    else
    {
      Console.WriteLine($"{stockDays.Item1+1}({prices[stockDays.Item1]:0.00}),{stockDays.Item2+1}({prices[stockDays.Item2]:0.00})");
    }
  }
}
