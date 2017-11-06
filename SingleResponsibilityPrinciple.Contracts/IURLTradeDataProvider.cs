using System.Collections.Generic;

namespace SingleResponsibilityPrinciple.Contracts
{
    public interface IURLTradeDataProvider
    {
        IEnumerable<string> GetURLTradeData();
    }
}