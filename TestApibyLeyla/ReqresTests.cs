using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;

namespace TestApibyLeyla;

public class ReqresTests
{
    private const string Host = "https://reqres.in";
    private const string Api = "/api/users/2";
    private Users users;
    
    
   
    [OneTimeSetUp]
    public async Task Setup()
    {
        var baseAddress = new Uri(Host + Api);
        var client = new HttpClient() { BaseAddress = baseAddress};
        var response = await client.GetAsync(baseAddress, new CancellationToken());
        var stringResponse = await response.Content.ReadAsStringAsync();
        users = JsonConvert.DeserializeObject<Users>(stringResponse);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            Assert.Fail($"{Api} отработала некорректно, дальнейшие проверки бессмысленны!");
        }
        users = JsonConvert.DeserializeObject<Users>(stringResponse);

    }

    [Test]
    public void CheckResponseIsNotEmptyTesting()
    {
        Assert.IsNotNull(users, "Ответ от api вернул пустое значение");
    }
    [Test]
    public void CheckNameTesting()
    {
        Assert.AreEqual("Janet", users.Data.First_name, "Поле name в ответе от api не соответствует ожидаемому");
    }
}