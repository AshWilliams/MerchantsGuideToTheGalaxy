using System.Collections.Generic;
using MerchantsGuideToTheGalaxy.Core.CommandProcessor.Symbols;

namespace MerchantsGuideToTheGalaxy.Core.CommandProcessor.Commands
{
    public abstract class Command
    {
        public IReadOnlyList<Symbol> Symbols { get; set; }

        protected Command(IReadOnlyList<Symbol> symbols)
        {
            Symbols= symbols;
        }

        public override string ToString()
        {
            return string.Join(" ", Symbols);
        }
    }
}
