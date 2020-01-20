using MassTransit;

namespace Valkyrie.EventBus.Provider
{
    public interface IBusProvider
    {
        IBusControl GetInstance(string instanceName = null);
    }
}
