# Specify the base image
FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-env

# Specify the working directory
WORKDIR /src

# copy file csproj to the src and restore all the necessary dependency
COPY src/*.csproj .
RUN dotnet restore

# copy the rest of source code into the image
COPY src .

# Build the project and Done the build stage
RUN dotnet publish -c Release -o /publish

# Specify the image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime

# Specify that working the the publish folder
WORKDIR /publish

# copy /publish directory from the build-env stage into the runtime image 
COPY --from=build-env /publish .

# EXPOSE 80

ENTRYPOINT ["dotnet", "myWebApp.dll"]