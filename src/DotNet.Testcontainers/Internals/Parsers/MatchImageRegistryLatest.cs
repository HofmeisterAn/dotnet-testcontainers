namespace DotNet.Testcontainers.Internals.Parsers
{
  using DotNet.Testcontainers.Images;

  internal sealed class MatchImageRegistryLatest : MatchImage
  {
    public MatchImageRegistryLatest() : base(@"^([\w][\w\.\-:/]+)/([\w][\w\.\-]+)$") // Matches baz/foo/bar
    {
    }

    protected override IDockerImage Match(params string[] matches)
    {
      return new DockerImage(matches[0], matches[1], string.Empty);
    }
  }
}
