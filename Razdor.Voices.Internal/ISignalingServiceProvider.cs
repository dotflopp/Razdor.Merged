namespace Razdor.Voices.Internal;

public interface ISignalingServiceProvider
{
    Task<ISignalingInternalService?> FindSignalingServiceAsync(ulong serviceIp);
    Task<ISignalingInternalService> GetOptimalSignalingServiceAsync(ulong guildId, ulong channelId);
}

