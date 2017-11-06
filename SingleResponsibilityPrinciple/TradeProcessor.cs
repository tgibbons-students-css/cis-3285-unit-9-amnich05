
using SingleResponsibilityPrinciple.AdoNet;
using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class TradeProcessor
    {
        public TradeProcessor(IURLTradeDataProvider uRLTradeDataProvider, ITradeDataProvider tradeDataProvider, ITradeParser tradeParser, AdoNetTradeStorage tradeStorage)
        {
            this.uRLTradeDataProvider = uRLTradeDataProvider;
            this.tradeDataProvider = tradeDataProvider;
            this.tradeParser = tradeParser;
            this.tradeStorage = tradeStorage;
        }

        public TradeProcessor(URLTradeDataProvider uRLTradeDataProvider, SimpleTradeParser tradeParser, AdoNetTradeStorage tradeStorage)
        {
            this.uRLTradeDataProvider = uRLTradeDataProvider;
            this.tradeParser = tradeParser;
            this.tradeStorage = tradeStorage;
        }

        public void ProcessTrades()
        {
            var lines = uRLTradeDataProvider.GetURLTradeData();
            var trades = tradeParser.Parse(lines);
            tradeStorage.Persist(trades);
        }

        private readonly IURLTradeDataProvider uRLTradeDataProvider;
        private readonly ITradeDataProvider tradeDataProvider;
        private readonly ITradeParser tradeParser;
        private readonly ITradeStorage tradeStorage;
    }
}
