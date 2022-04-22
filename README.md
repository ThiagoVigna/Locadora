# Structure

    - Locadora => WebApi com o serviço REST (via Swagger)
      
# Get Started:

1 - Faça o restore dos projetos (dotnet restore)

2 - Acesse a pasta principal dos projetos (backend) via terminal e execute o comando abaixo para criar a base de dados:

dotnet ef --startup-project Locadora.csproj database update

OBS.: Para executar o comando acima, é preciso instalar o pacote de ferramentas do Entity Framework Core CLI. Caso não tenha instalado, utilize o comando abaixo para instalar:

dotnet tool install --global dotnet-ef

3 - Execute o projeto MovieStore.Api com o comando abaixo:

dotnet run -p Locadora.csproj
