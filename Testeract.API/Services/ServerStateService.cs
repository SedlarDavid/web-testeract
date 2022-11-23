using Grpc.Core;

namespace Testeract.API.Services;

public class ServerStateService : ServerState.ServerStateBase
{
    private readonly ILogger<ServerStateService> _logger;

    public ServerStateService(ILogger<ServerStateService> logger)
    {
        _logger = logger;
    }

    public override Task<ServerStateResponse> GetState(ServerStateRequest request,
        ServerCallContext context)
    {
        _logger.LogInformation("Saying hello to {Name}", request.ClientName);
        return Task.FromResult(new ServerStateResponse
        {
            Status = $"{System.Diagnostics.Process.GetProcesses().Length} processes running",
            Message = "Hello " + request.ClientName
        });
    }
}