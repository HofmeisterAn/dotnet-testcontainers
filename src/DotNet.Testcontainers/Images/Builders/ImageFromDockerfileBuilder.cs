namespace DotNet.Testcontainers.Images.Builders
{
  using System.Threading.Tasks;
  using DotNet.Testcontainers.Clients;
  using DotNet.Testcontainers.Images.Configurations;

  /// <inheritdoc cref="IImageFromDockerfileBuilder" />
  public sealed class ImageFromDockerfileBuilder : IImageFromDockerfileBuilder
  {
    private readonly IImageFromDockerfileConfiguration configuration;

    /// <summary>
    /// Initializes a new instance of the <see cref="ImageFromDockerfileBuilder" /> class.
    /// </summary>
    public ImageFromDockerfileBuilder() : this(new ImageFromDockerfileConfiguration())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ImageFromDockerfileBuilder" /> class.
    /// </summary>
    /// <param name="configuration">The Dockerfile configuration.</param>
    private ImageFromDockerfileBuilder(IImageFromDockerfileConfiguration configuration)
    {
      this.configuration = configuration;
    }

    /// <inheritdoc />
    public IImageFromDockerfileBuilder WithName(string name)
    {
      return this.WithName(new DockerImage(name));
    }

    /// <inheritdoc />
    public IImageFromDockerfileBuilder WithName(IDockerImage name)
    {
      return new ImageFromDockerfileBuilder(
        new ImageFromDockerfileConfiguration(name, this.configuration.Dockerfile, this.configuration.DockerfileDirectory, this.configuration.DeleteIfExists));
    }

    /// <inheritdoc />
    public IImageFromDockerfileBuilder WithDockerfile(string dockerfile)
    {
      return new ImageFromDockerfileBuilder(
        new ImageFromDockerfileConfiguration(this.configuration.Image, dockerfile, this.configuration.DockerfileDirectory, this.configuration.DeleteIfExists));
    }

    /// <inheritdoc />
    public IImageFromDockerfileBuilder WithDockerfileDirectory(string dockerfileDirectory)
    {
      return new ImageFromDockerfileBuilder(
        new ImageFromDockerfileConfiguration(this.configuration.Image, this.configuration.Dockerfile, dockerfileDirectory, this.configuration.DeleteIfExists));
    }

    /// <inheritdoc />
    public IImageFromDockerfileBuilder WithDeleteIfExists(bool deleteIfExists)
    {
      return new ImageFromDockerfileBuilder(
        new ImageFromDockerfileConfiguration(this.configuration.Image, this.configuration.Dockerfile, this.configuration.DockerfileDirectory, deleteIfExists));
    }

    /// <inheritdoc />
    public async Task<string> Build()
    {
      using (var client = new TestcontainersClient())
      {
        return await client.BuildAsync(this.configuration)
          .ConfigureAwait(false);
      }
    }
  }
}
