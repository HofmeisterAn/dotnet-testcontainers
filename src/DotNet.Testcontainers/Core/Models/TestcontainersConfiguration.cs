namespace DotNet.Testcontainers.Core.Models
{
  using System.Collections.Generic;

  internal struct TestcontainersConfiguration
  {
    public ContainerConfiguration Container;

    public HostConfiguration Host;

    public struct ContainerConfiguration
    {
      public string Image;

      public string Name;

      public IReadOnlyDictionary<string, string> ExposedPorts;

      public IReadOnlyCollection<string> Command;
    }

    public struct HostConfiguration
    {
      public IReadOnlyDictionary<string, string> PortBindings;

      public IReadOnlyDictionary<string, string> Mounts;
    }
  }
}
