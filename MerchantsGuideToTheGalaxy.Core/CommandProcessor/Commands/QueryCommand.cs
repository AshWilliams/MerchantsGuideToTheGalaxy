using System.Collections.Generic;
using MerchantsGuideToTheGalaxy.Core.CommandProcessor.Symbols;

namespace MerchantsGuideToTheGalaxy.Core.CommandProcessor.Commands
{
    public class QueryCommand : Command
    {
        public QueryCommand(IReadOnlyList<Symbol> symbols) : base(symbols)
        {
        }
    }
}
