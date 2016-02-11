FROM microsoft/aspnet:1.0.0-rc1-update1-coreclr

COPY . /app
WORKDIR /app
RUN ["dnu", "restore"]

WORKDIR /app/src/SeriesService.SeriesApi
EXPOSE 5000
ENTRYPOINT ["dnx", "-p", "project.json", "web"]