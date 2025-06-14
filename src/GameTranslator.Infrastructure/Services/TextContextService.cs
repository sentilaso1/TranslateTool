using System.Collections.Generic;
using GameTranslator.Core.Services;

namespace GameTranslator.Infrastructure.Services
{
    public class TextContextService : IContextService
    {
        private readonly Queue<string> _lines = new();
        private readonly int _maxLines;

        public TextContextService(int maxLines = 5)
        {
            _maxLines = maxLines;
        }

        public void Add(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return;
            _lines.Enqueue(text);
            if (_lines.Count > _maxLines)
            {
                _lines.Dequeue();
            }
        }

        public IReadOnlyList<string> GetContext() => _lines.ToArray();
    }
}
