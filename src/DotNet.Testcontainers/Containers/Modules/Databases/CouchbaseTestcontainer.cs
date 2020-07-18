namespace DotNet.Testcontainers.Containers.Modules.Databases
{
  using System.Linq;
  using System.Threading.Tasks;
  using Abstractions;
  using Configurations;

  public class CouchbaseTestcontainer : TestcontainerDatabase
  {
    internal CouchbaseTestcontainer(ITestcontainersConfiguration configuration) : base(configuration)
    {
    }

    public override string ConnectionString => "couchbase://"+this.IpAddress;

    public async Task<long> CreateBucket(string bucket)
    {
      var flushBucketCommand =
        "bash /opt/couchbase/bin/couchbase-cli " +
        "bucket-create -c 127.0.0.1:8091 " +
        "--username " + this.Username + " --password " + this.Password + " " +
        "--bucket=" + bucket + " --bucket-type couchbase --bucket-ramsize 512 --enable-flush 1 --bucket-replica 0";

      return await this.ExecAsync(flushBucketCommand.Split(" ").ToList());
    }

    public async Task<long> FlushBucket(string bucket)
    {
      var flushBucketCommand =
        "bash /opt/couchbase/bin/couchbase-cli " +
        "bucket-flush -c 127.0.0.1:8091 " +
        "--username " + this.Username + " --password " + this.Password + " " +
        "--bucket=" + bucket + " --force";

      return await this.ExecAsync(flushBucketCommand.Split(" ").ToList());
    }

  }
}
