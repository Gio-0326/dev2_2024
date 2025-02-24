# BUILD -----------------------------------------------
# Usa l'immagine base del SDK di .NET per la fase di build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Imposta la cartella di lavoro all'interno all'immagine Docker che verrà creata
WORKDIR /app

# Copia il file .csproj e ripristina le dipendenze
COPY *.csproj ./
RUN dotnet restore 

#RUNTIME ----------------------------------------------------

# Copia i file da una Directory locale al Container
COPY . ./

# RUN esegue un comando all'interno del container
# dotnet publish: serve a compilare e pubblicarla in una Directory di Output
# -c Release: ottimizzazione del codice per la produzione
# -o /out: indica la destinazione dentro il Container
# --no-restore : serve a non ripristinare le dipendenze ogni volta
RUN dotnet publish -c Release -o out --no-restore

# Usa l'immagine di runtime .NET 8 in modo da avere un'immagine più leggera
# AS runtime (di default: da provare velocità-dimensione)
FROM mcr.microsoft.com/dotnet/sdk:8.0

# Imposta la cartella di lavoro ALL'INTERNO dell'imaggine Docker
WORKDIR /app

# Copia il file pubblicato dall'immagine di build al container
COPY --from=build /app/out ./

# Espone la porta 8080:80 per la tua applicazione web
EXPOSE 8080:80

# DotNet.Docker.dll è il file che verrà eseguito all'avvio del container
ENTRYPOINT ["dotnet", "WebApp_Docker.dll"]
