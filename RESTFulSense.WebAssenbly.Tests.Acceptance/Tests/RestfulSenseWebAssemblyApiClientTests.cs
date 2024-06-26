﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using RESTFulSense.WebAssembly.Clients;
using RESTFulSense.WebAssenbly.Tests.Acceptance.Models;
using Tynamix.ObjectFiller;
using WireMock.Server;

namespace RESTFulSense.WebAssenbly.Tests.Acceptance.Tests
{
    public partial class RestfulSenseWebAssemblyApiClientTests : IDisposable
    {
        private readonly WireMockServer wiremockServer;
        private const string relativeUrl = "/tests";
        private readonly RESTFulApiClient restfulWebAssemblyApiClient;

        public RestfulSenseWebAssemblyApiClientTests()
        {
            this.wiremockServer = WireMockServer.Start();
            this.restfulWebAssemblyApiClient = new RESTFulApiClient();

            this.restfulWebAssemblyApiClient.BaseAddress = new Uri(
                this.wiremockServer.Urls[0]);
        }

        private async Task<string> ReadStreamToEndAsync(Stream result)
        {
            var reader = new StreamReader(result, leaveOpen: false);

            return await reader.ReadToEndAsync();
        }

        private static ValueTask<string> SerializationContentFunction<TEntity>(TEntity entityContent)
        {
            string jsonContent = JsonSerializer.Serialize(entityContent);

            return new ValueTask<string>(jsonContent);
        }

        private static string CreateRandomContent()
        {
            var randomContent = new Lipsum(
                LipsumFlavor.LoremIpsum,
                minWords: 3,
                maxWords: 10);

            return randomContent.ToString();
        }

        private static Func<string, ValueTask<TEntity>> DeserializationContentFunction
        {
            get
            {
                return async (entityContent) =>
                    await Task.FromResult(JsonSerializer.Deserialize<TEntity>(
                        entityContent));
            }
        }

        private static TEntity GetRandomTEntity() =>
            CreateTEntityFiller(GetTestDateTimeOffset()).Create();

        private static string GetRandomHttpMethodName() =>
            new MnemonicString().GetValue();

        private static DateTimeOffset GetTestDateTimeOffset() =>
            new DateTimeOffset(DateTime.Now);

        private static Filler<TEntity> CreateTEntityFiller(DateTimeOffset dates)
        {
            var filler = new Filler<TEntity>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(dates);

            return filler;
        }

        public void Dispose() => this.wiremockServer.Stop();
    }
}