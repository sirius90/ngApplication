using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ngApplication.DTOModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ngApplication.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UploadController : Controller
    {
        public UploadController()
        {

        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<Result> Post()
        {
            StringBuilder fileResult = new StringBuilder();
            Result count = new Result();

            try
            {
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[Request.Form.Files.Count - 1];

                    if (file.Length > 0)
                    {
                        using (var reader = new StreamReader(file.OpenReadStream()))
                        {
                            while (reader.Peek() >= 0)
                                fileResult.AppendLine(await reader.ReadLineAsync());
                        }                    

                    }
                }

                var json = JObject.Parse(fileResult.ToString());

                var items = (JArray)json["menu"]["items"];

                foreach (var item in items)
                {
                    if (item.HasValues && item["label"] != null)
                    {
                        count.Count += Convert.ToInt32(item["id"]);
                    }
                }

                return count;
            }
            catch (Exception ex)
            {                
                return count;
            }
        }


        public int GetFileStub(string jsonString)
        {
            int sum = 0;

            var json = JObject.Parse(jsonString.ToString());

            var items = (JArray)json["menu"]["items"];

            foreach (var item in items)
            {
                if (item.HasValues && item["label"] != null) {
                    sum += Convert.ToInt32(item["id"]);
                }
            }

            return sum;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
       
    }
}
