namespace DotNet.Testcontainers.Tests.Unit.Containers
{
  using System.IO;
  using Testcontainers.Containers.Configurations;
  using Xunit;

  public class DockerCertDirTest
  {
    [Fact]
    public void HasRequiredTlsCertificates()
    {
      var dockerCertDir = new DockerCertificatesDirectory(Path.Combine("Assets", "tls"));
      Assert.True(dockerCertDir.ClientAuthPossible);
    }

    [Fact]
    public void DoesNotHaveRequiredTlsCertificates()
    {
      var dockerCertDir = new DockerCertificatesDirectory(Path.Combine("Assets"));
      Assert.False(dockerCertDir.ClientAuthPossible);
    }
  }
}
