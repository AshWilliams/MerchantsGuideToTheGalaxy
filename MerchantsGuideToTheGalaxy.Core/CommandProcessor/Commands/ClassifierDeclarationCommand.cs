using System.Collections.Generic;
using MerchantsGuideToTheGalaxy.Core.CommandProcessor.Symbols;

namespace MerchantsGuideToTheGalaxy.Core.CommandProcessor.Commands
{
    public class ClassifierDeclarationCommand: Command
    {
        public ClassifierDeclarationCommand(IReadOnlyList<Symbol> symbols) : base(symbols)
        {
        }
    }
}
