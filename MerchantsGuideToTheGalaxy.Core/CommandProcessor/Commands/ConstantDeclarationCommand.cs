using System.Collections.Generic;
using MerchantsGuideToTheGalaxy.Core.CommandProcessor.Symbols;

namespace MerchantsGuideToTheGalaxy.Core.CommandProcessor.Commands
{
    public class ConstantDeclarationCommand: Command
    {
        public ConstantDeclarationCommand(IReadOnlyList<Symbol> symbols) : base(symbols)
        {
        }
    }
}
