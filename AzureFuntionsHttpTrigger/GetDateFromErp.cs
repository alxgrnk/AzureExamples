using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Company.Function;

public class GetDateFromErp
{
    private readonly ILogger<GetDateFromErp> _logger;

    public GetDateFromErp(ILogger<GetDateFromErp> logger)
    {
        _logger = logger;
    }

    [Function("GetDateFromErp")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {

        string netprice1 = req.Query["netprice1"];
        string netprice2 = req.Query["netprice2"];

        var priceWithTax =  ((int.Parse(netprice1) + int.Parse( netprice2) ) ) * 1.19;
        string u1 = Environment.GetEnvironmentVariable("MY_VAR");

        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult($"Summe {priceWithTax} - Env Var {u1}");
    }
}