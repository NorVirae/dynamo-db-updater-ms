using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoDbSnsUpdaterService.Models
{
    public class HotelCreatedEvent
    {
        [DynamoDBHashKey("userId")]
        public string userId { get; set; }

        [DynamoDBRangeKey("id")]
        public string id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }
        public int Rating { get; set; }
        public string CityName { get; set; }
        public string FileName { get; set; }
        public DateTime CreationDateTIme { get; set; }
    }
}
