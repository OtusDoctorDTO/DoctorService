FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /DoctorService

COPY ./DoctorService.API ./DoctorService.API
COPY ./DoctorService.Data ./DoctorService.Data
COPY ./DoctorService.Domain ./DoctorService.Domain

RUN dotnet restore ./DoctorService.API
RUN dotnet publish ./DoctorService.API -c Release -o publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /DoctorService
COPY --from=base DoctorService/publish ./
EXPOSE 8080
ENTRYPOINT [ "dotnet", "DoctorService.API.dll", "--environment=Test" ]