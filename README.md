
# Weather App

This is a weather app that allows the user to look for the weather of a specific area by city name or zipcode.
It shows the daily forecast and an hourly forecast for each day.

 ## Tech Stack

**Server:** ASP.NET Core 6.0

## Run Locally

Clone the project

```bash
  git clone https://github.com/JCGarcia96/WeatherAppBE.git
```

Go to the project directory

```bash
  cd WeatherApp/WeatherAppBE
```

Run on a specific port
**(NOTE: Frontend points to port 5170 when calling this api)**

```bash
  dotnet run --urls=http://localhost:5170/
```

For Swagger type in browser:
```bash
  http://localhost:5170/swagger
```

## Links
[Weather App Frontend](https://github.com/JCGarcia96/WeatherApp/)

## License

[MIT](https://choosealicense.com/licenses/mit/)


## Acknowledgements

 - [Open Weather Map](https://openweathermap.org/)


