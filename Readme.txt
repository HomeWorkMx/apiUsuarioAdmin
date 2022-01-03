To install this tool simply run: dotnet tool install --global Microsoft.dotnet-openapi --version 3.1.1

dotnet openapi add url https://micro-dev.bmlabs.cl/pocmsbanco/swagger/v1/swagger.json --output-file openapi/MsBanco.json
dotnet openapi add url https://micro-dev.bmlabs.cl/mssala/swagger/v1/swagger.json --output-file openapi/mssala.json mssalaClient



dotnet openapi add url https://micro-prod.bmlabs.cl/msusuario/swagger/v1/swagger.json --output-file openapi/msUsuario.json msUsuarioClient


<ItemGroup>
	<OpenApiReference Include="openapi/msUsuario.json" SourceUrl="https://micro-prod.bmlabs.cl/msUsuario/swagger/v1/swagger.json" />
</ItemGroup>

