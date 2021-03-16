namespace DotNet.Testcontainers.Clients
{
  using System;
  using System.Threading;
  using System.Threading.Tasks;
  using DotNet.Testcontainers.Containers.Configurations;

  internal sealed class DockerSystemOperations : DockerApiClient, IDockerSystemOperations
  {
    public DockerSystemOperations(IDockerClientAuthenticationConfiguration clientAuthConfig)
      : base(clientAuthConfig)
    {
    }

    public async Task<bool> GetIsWindowsEngineEnabled(CancellationToken ct = default)
    {
      return (await this.Docker.System.GetSystemInfoAsync(ct)
        .ConfigureAwait(false)).OperatingSystem.Contains("Windows", StringComparison.OrdinalIgnoreCase);
    }
  }
}
