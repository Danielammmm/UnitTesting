using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
public class SampleApiController : ApiController
{
    [HttpGet]
    [Route("api/sample/data")]
    public IEnumerable<string> GetSampleData()
    {
        return new List<string> { "Value1", "Value2", "Value3" };
    }

    [HttpGet]
    [Route("api/sample/data/{id}")]
    public string GetSampleDataById(int id)
    {
        return $"Value{id}";
    }
}
