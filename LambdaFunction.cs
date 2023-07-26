using Amazon.Lambda.AspNetCoreServer;
namespace SinafApi
{
    public class LambdaFunction: APIGatewayProxyFunction
    {
        protected override void Init(IWebHostBuilder builder)
        {
            builder
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Program>()
                .UseLambdaServer();
        }
    }
}
