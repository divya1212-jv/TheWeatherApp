# Use the .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Copy project files and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and publish
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Use Nginx to serve the static site
FROM nginx:alpine AS final

# Remove default nginx page
RUN rm -rf /usr/share/nginx/html/*

# Copy published Blazor WebAssembly files
COPY --from=build /app/publish/wwwroot /usr/share/nginx/html

# Expose the port nginx uses
EXPOSE 80

# Start nginx
CMD ["nginx", "-g", "daemon off;"]
