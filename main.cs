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
        buyDay = index;
      }
    }
    return new Tuple<int, int>(buyDay, sellDay);
	}

	// Driver Code
	public static void Main(String[] args)
	{
		// stock prices on consecutive days
		double []prices = { 7.0, 1.0, 5.0, 3.0, 0.5 };
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
