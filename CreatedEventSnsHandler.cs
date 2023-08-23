using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.SystemTextJson;
using Amazon.Lambda.SNSEvents;
using DynamoDbSnsUpdaterService.Models;
using Nest;
using System.Text.Json;

[assembly: LambdaSerializer(typeof(DefaultLambdaJsonSerializer))]

namespace DynamoDbSnsUpdaterService
{

    public class CreatedEventSnsHandler
    {
        public async Task Handler(SNSEvent snsEvent)
        {
            var dbClient = new AmazonDynamoDBClient(RegionEndpoint.GetBySystemName("eu-north-1"));
            var dbContext = new DynamoDBContext(dbClient);


            foreach (var eventRecord in snsEvent.Records)
            {
                var eventId = eventRecord.Sns.MessageId;
                var hotel = JsonSerializer.Deserialize<HotelCreatedEvent>(eventRecord.Sns.Message);

                await dbContext.SaveAsync<HotelCreatedEvent>(hotel);

                //if (foundItem == null)
                //{
                //    await table.PutItemAsync(new Document
                //    {
                //        ["eventId"] = eventId
                //    });
                //}

            }

        }
    }
}