using System.Globalization;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient("weather", client =>
{
    client.BaseAddress = new Uri("https://api.open-meteo.com/");
    client.Timeout = TimeSpan.FromSeconds(10);
});

var app = builder.Build();

app.MapGet("/", async (double? latitud, double? longitud,
    IHttpClientFactory clients, CancellationToken cancellationToken) =>
{
    var latitude = latitud ?? 40.4168;
    var longitude = longitud ?? -3.7038;
    if (!double.IsFinite(latitude) || latitude is < -90 or > 90 ||
        !double.IsFinite(longitude) || longitude is < -180 or > 180)
    {
        return Results.BadRequest(new
        {
            error = "La latitud debe estar entre -90 y 90 y la longitud entre -180 y 180."
        });
    }

    var url = FormattableString.Invariant(
        $"v1/forecast?latitude={latitude}&longitude={longitude}&daily=weather_code,temperature_2m_max,temperature_2m_min&timezone=UTC&forecast_days=3");

    try
    {
        var forecast = await clients.CreateClient("weather")
            .GetFromJsonAsync<JsonElement>(url, cancellationToken);

        if (forecast.ValueKind != JsonValueKind.Object ||
            !forecast.TryGetProperty("daily", out var daily) ||
            daily.ValueKind != JsonValueKind.Object)
        {
            return Results.Problem("El proveedor devolvió una previsión no válida.", statusCode: 502);
        }

        return Results.Ok(new
        {
            saludo = "¡Hola!",
            fecha = DateTimeOffset.UtcNow.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
            zonaHoraria = "UTC",
            ubicacion = new { latitud = latitude, longitud = longitude },
            fuente = "Open-Meteo",
            prevision = daily
        });
    }
    catch (Exception exception) when (exception is HttpRequestException or JsonException ||
        exception is OperationCanceledException && !cancellationToken.IsCancellationRequested)
    {
        return Results.Problem(
            "No se pudo obtener la previsión del tiempo. Inténtalo de nuevo más tarde.",
            statusCode: 502);
    }
});

app.Run();
