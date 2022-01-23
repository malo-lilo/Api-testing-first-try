using Newtonsoft.Json;

namespace TestApibyLeyla;

public class Users
{
    [JsonProperty("data")]
    public Data Data { get; set; }
}

public class Data

{
    
    [JsonProperty("id")]
    public string Id { get; set; }
    
    [JsonProperty("email")]
    public string Email { get; set; }
    
    [JsonProperty("first_name")]
    public string First_name { get; set; }
    
    [JsonProperty("last_name")]
    public string Last_name { get; set; }
    
    [JsonProperty("avatar")]
    public string Avatar { get; set; }
    
}