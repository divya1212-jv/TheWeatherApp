using System.Text.Json.Serialization;

public class WeatherResponse
{
    public string Name { get; set; }
    public MainData Main { get; set; }
    public List<WeatherData> Weather { get; set; }
}

public class MainData
{
    public float Temp { get; set; }
    public int Humidity { get; set; }
}

public class WeatherData
{
    public string Description { get; set; }
}

public class ForecastResponse
{
    public List<ForecastData> List { get; set; }
}

public class ForecastData
{
    [JsonPropertyName("dt")]
    public long Dt { get; set; }
    public MainData Main { get; set; }
    public List<WeatherData> Weather { get; set; }

    public DateTime DateTime => DateTimeOffset.FromUnixTimeSeconds(Dt).DateTime;
}
