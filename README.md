# Getting Started with GitHub Copilot

_Get started using GitHub Copilot in less than an hour._

## API de saludo, fecha y tiempo (.NET)

La API independiente en `src/SaludoApi` utiliza ASP.NET Core y requiere el SDK
de .NET 10. No modifica la aplicación Python del ejercicio.

Desde la raíz del repositorio:

```bash
dotnet run --project src/SaludoApi --urls http://localhost:5000
```

```bash
# Madrid por defecto
curl http://localhost:5000/

# Otra ubicación (latitud y longitud en grados decimales)
curl "http://localhost:5000/?latitud=41.3874&longitud=2.1686"
```

`GET /` devuelve JSON con `saludo`, `fecha` actual (`AAAA-MM-DD`, en UTC),
`zonaHoraria`, `ubicacion`, `fuente` y `prevision` para hoy y los dos días
siguientes. La previsión real procede de [Open-Meteo](https://open-meteo.com/),
sin clave de API, y requiere acceso a Internet. No se generan datos aleatorios.
En `prevision`, los arrays `time`, `temperature_2m_max`, `temperature_2m_min`
y `weather_code` corresponden a las mismas fechas: temperaturas en °C y
[códigos meteorológicos WMO](https://open-meteo.com/en/docs#weathervariables).

Las coordenadas omitidas usan los valores de Madrid (40.4168, -3.7038).
Los parámetros no numéricos o fuera de rango devuelven HTTP 400. Si el proveedor
no responde en diez segundos, falla o envía una respuesta no válida, la API
devuelve HTTP 502 sin inventar una previsión.

Para compilar:

```bash
dotnet build src/SaludoApi
```

## Welcome

- **Who is this for**: Developers at any experience level looking to accelerate their code workflow.
- **What you'll learn**: The different ways to interact with Copilot to explain, write, plan, and develop code.
- **What you'll build**: You will guide Copilot to update Mergington High School's extracurricular activities website.
- **Prerequisites**:
  - Skills exercise: [Introduction to GitHub](https://github.com/skills/introduction-to-github)
  - Familiarity with [VS Code](https://code.visualstudio.com/)
  - Basic coding principles
- **How long**: This exercise takes less than one hour to complete.

In this exercise, you will:

1. Use a preconfigured Codespace to run VS Code in your browser.
1. Learn different interaction options to develop and plan with GitHub Copilot.
1. Use Copilot to summarize and review your pull request.

### How to start this exercise

Simply copy the exercise to your account, then give your favorite Octocat (Mona) **about 20 seconds** to prepare the first lesson, then **refresh the page**.

[![](https://img.shields.io/badge/Copy%20Exercise-%E2%86%92-1f883d?style=for-the-badge&logo=github&labelColor=197935)](https://github.com/new?template_owner=skills&template_name=getting-started-with-github-copilot&owner=%40me&name=skills-getting-started-with-github-copilot&description=Exercise:+Get+started+using+GitHub+Copilot&visibility=public)

<details>
<summary>Having trouble? 🤷</summary><br/>

When copying the exercise, we recommend the following settings:

- For owner, choose your personal account or an organization to host the repository.

- We recommend creating a public repository, since private repositories will use Actions minutes.
   
If the exercise isn't ready in 20 seconds, please check the [Actions](../../actions) tab.

- Check to see if a job is running. Sometimes it simply takes a bit longer.

- If the page shows a failed job, please submit an issue. Nice, you found a bug! 🐛

</details>

---

&copy; 2025 GitHub &bull; [Code of Conduct](https://www.contributor-covenant.org/version/2/1/code_of_conduct/code_of_conduct.md) &bull; [MIT License](https://gh.io/mit)