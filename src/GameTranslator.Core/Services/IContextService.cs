using System.Collections.Generic;

namespace GameTranslator.Core.Services
{
    public interface IContextService
    {
        void Add(string text);
        IReadOnlyList<string> GetContext();
    }
}
