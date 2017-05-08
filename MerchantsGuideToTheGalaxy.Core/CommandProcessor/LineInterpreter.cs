using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MerchantsGuideToTheGalaxy.Core.CommandProcessor.Commands;
using MerchantsGuideToTheGalaxy.Core.CommandProcessor.Symbols;

namespace MerchantsGuideToTheGalaxy.Core.CommandProcessor
{
    public class LineInterpreter
    {
        private readonly Lex _lex;
        public Processor Processor { get; private set; }

        public LineInterpreter()
        {
            _lex = new Lex();
            Processor = new Processor();
        }

        public CommandResult ParseAndExecute(string commandText)
        {
            try
            {
                _lex.Init(commandText);

                var command = Parse();

                if (command is ConstantDeclarationCommand)
                    return Processor.Execute(command as ConstantDeclarationCommand);
                if (command is ClassifierDeclarationCommand)
                    return Processor.Execute(command as ClassifierDeclarationCommand);
                if (command is QueryCommand)
                    return Processor.Execute(command as QueryCommand);
            }
            catch (DuplicatedDeclarationException)
            {
                return new CommandResult {ResultText = @"You already said it", Sucess = false};
            }
            catch (Exception)
            {
                return new CommandResult { ResultText = @"I have no idea what you are talking about", Sucess = false };   
            }

            throw new NotSupportedException(@"Command Not Supported");
        }

        private Command Parse()
        {
            var symbols = GetSymbolsList();

            if (IsConstantDeclaration(symbols))
                return new ConstantDeclarationCommand(symbols);

            if (IsClassifierDeclaration(symbols))
                return new ClassifierDeclarationCommand(symbols);

            if (IsQueryCommand(symbols))
                return new QueryCommand(symbols);

            throw new ParsingException();
        }

        private static bool IsQueryCommand(IReadOnlyList<Symbol> symbols)
        {
            return symbols.First().Kind == SymbolKind.Statement
                   && symbols[1].Kind == SymbolKind.SubStatemant
                   && symbols.Any(s => s.Kind == SymbolKind.Constant)
                   && symbols.Any(s => s.Kind == SymbolKind.Operator)
                   && symbols.Last().Kind == SymbolKind.QueryQualifier;
        }

        private static bool IsClassifierDeclaration(IReadOnlyCollection<Symbol> symbols)
        {
            return symbols.First().Kind == SymbolKind.Constant
                   && symbols.Any(s => s.Kind == SymbolKind.Classifier)
                   && symbols.Any(s => s.Kind == SymbolKind.Operator)
                   && symbols.Any(s => s.Kind == SymbolKind.ValueDefinition)                   
                   && symbols.Last().Kind == SymbolKind.Unit;
        }

        private static bool IsConstantDeclaration(IReadOnlyCollection<Symbol> symbols)
        {
            return symbols.Count == 3
                   && symbols.First().Kind == SymbolKind.Constant
                   && symbols.Any(s => s.Kind == SymbolKind.Operator)
                   && symbols.Last().Kind == SymbolKind.RomanSymbol;
        }

        private IReadOnlyList<Symbol> GetSymbolsList()
        {
            var symbols = new List<Symbol>();

            var lastSymbol = _lex.GetNextSymbol();

            while (lastSymbol != null)
            {
                symbols.Add(lastSymbol);
                lastSymbol = _lex.GetNextSymbol();
            }

            return new ReadOnlyCollection<Symbol>(symbols);
        }

    }
}
