using System.Threading.Tasks;

namespace GameTranslator.Core.Services
{
    public interface IOverlayService
    {
        Task ShowAsync(string text);
    }
}

