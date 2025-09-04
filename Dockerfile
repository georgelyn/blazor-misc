FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY . ./

RUN dotnet publish -c Release -r browser-wasm --self-contained true /p:PublishTrimmed=true -o out

FROM nginx:alpine

COPY --from=build /app/out/wwwroot /usr/share/nginx/html
COPY nginx.conf  /etc/nginx/conf.d/default.conf

EXPOSE 80