# Misc

A basic toolkit of my frequently used utilities and helpers, built with Blazor WebAssembly and .NET 9. Started as a practice project to familiarize myself with Blazor.

## Features

- C# Class to JSON: Converts simple C# POCO classes with public properties and standard getters into JSON.
- JSON Formatter: Format JSON with/without white spaces.
- String Utilities: Join or replace strings.
- ...

## Setup

### Running with Docker

Both a `Dockerfile` and `docker-compose.yml`, as well as a basic `nginx` configuration file are included.

You need to have [Docker](https://docs.docker.com/engine/install) installed.
And then just run:

```sh
$ docker compose build # It creates the container as defined by the Dockerfile
$ docker compose up -d # It runs the container
```

The app can be accesed at http://localhost:5097.

### Development Environment Setup

To run the application, you need to install [.NET](https://learn.microsoft.com/en-us/dotnet/core/install) (version 9.0).

To run the application:

```sh
$ dotnet run # It compiles, intalls the dependencies and executes the project
```

Alternatively you can use the command `watch`, which will "watch" for changes to apply them automatically. Although depending on what changes are made, with WASM apps it's not 100% reliable.
```sh
$ dotnet watch
```
The app can be accesed at http://localhost:5096.

## Screenshots

![Home page](https://i.imgur.com/CltIUKw.png)

![C# -> JSON](https://i.imgur.com/hiQVSQM.png)