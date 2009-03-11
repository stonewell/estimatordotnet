using System;
using System.Collections.Generic;
using System.Text;
using Estimation.Core;
using Stock.Estimator;
using Stock.Estimator.Rules;

namespace TestStockEstimator
{
    class Program
    {

        static void Main(string[] args)
        {
            EstimationEngine engine = new EstimationEngine();
            EstimationRuleList rulesList = new EstimationRuleList();
            Estimator estimator = null;

            System.IO.TextReader tr = System.Console.In;

            if (args.Length >= 1)
                tr = new System.IO.StreamReader(args[0]);

            string line = tr.ReadLine();

            if (line == null)
            {
                System.Console.Error.WriteLine("Invalid Input Data");
                return;
            }

            while (line != null && !line.StartsWith("StockId:")) line = tr.ReadLine();

            if (line == null)
            {
                System.Console.Error.WriteLine("Invalid Input Data");
                return;
            }

            string stockId = line.Substring("StockId:".Length);

            CreateStockRules(rulesList);

            estimator = engine.CreateEstimator(new StockCategory(stockId),
                new StockRuleSet(rulesList));

            estimator.Initialize();

            estimator.OnRuleRateUpdate += new UpdateRuleRateHandler(estimator_OnRuleRateUpdate);
            estimator.OnAddEstimationResult += new AddResultHandler(estimator_OnAddEstimationResult);

            while (line != null)
            {
                if (line.StartsWith("lDayCount:"))
                {
                    System.Console.WriteLine(line);
                }
                else if (line.StartsWith("lday "))
                {
                    string[] parts = line.Split(' ');

                    StockEvent se = new StockEvent();
                    se.StockCategory = new StockCategory(stockId);

                    //Date
                    string[] tmp = parts[1].Split(':');
                    DateTime dt = DateTime.Now;

                    int lv = 0;

                    if (int.TryParse(tmp[1], out lv))
                    {
                        se.EventDateTime = new DateTime(lv / 10000,
                            lv % 10000 / 100,
                            lv % 100);
                    }

                    double v = 0.0;

                    //Open
                    tmp = parts[2].Split(':');
                    if (double.TryParse(tmp[1], out v))
                        se.Begin = v;

                    //Highest
                    tmp = parts[3].Split(':');
                    if (double.TryParse(tmp[1], out v))
                        se.Highest = v;
                    //Lowest
                    tmp = parts[4].Split(':');
                    if (double.TryParse(tmp[1], out v))
                        se.Lowest = v;
                    //Final
                    tmp = parts[5].Split(':');
                    if (double.TryParse(tmp[1], out v))
                        se.Final = v;

                    estimator.PushEvent(se);
                }
                else
                {
                    System.Console.WriteLine(line);
                }

                line = tr.ReadLine();
            }

            if (args.Length > 0)
            {
                System.Console.ReadKey();
            }
            else
            {
                System.Threading.Thread.Sleep(10 * 1000);
            }
        }

        private static void estimator_OnAddEstimationResult(EstimationResultEventArgs args)
        {
            StockEstimationResult result = args.Result as StockEstimationResult;

            if (result == null)
                return;

            System.Console.WriteLine("Up={0},Down={1},Date={2}",
                result.GoingUpRate, result.GoingDownRate, result.StockEvent.EventDateTime);
        }

        private static void CreateStockRules(EstimationRuleList rulesList)
        {
            rulesList.Add(new ThreeWhiteSoldiers());
        }

        private static void estimator_OnRuleRateUpdate(UpdateRuleRateEventArgs args)
        {
            StockRuleRate rate = args.NewRate as StockRuleRate;

            System.Console.Error.WriteLine("Fail={0}, Success={1}", rate.FailCount, rate.SuccessCount);
        }
    }
}
