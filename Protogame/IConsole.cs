using System;

namespace Protogame
{
    public interface IConsole
    {
        bool Open { get; }
        
        void Toggle();
        void Update(IGameContext gameContext, IUpdateContext updateContext);
        void Render(IGameContext gameContext, IRenderContext renderContext);
    }
}
