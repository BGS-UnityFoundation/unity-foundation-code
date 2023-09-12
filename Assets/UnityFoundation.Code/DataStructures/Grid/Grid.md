#estrutura_dados/grid

# Grid

## Funcionalidades

### Forçar atribuição de valores

Para forçar a atribuição de valores podemos utilizar o método `SetValueForce()` definido na interface `IGrid`.

```csharp
// Exemplo
var grid = new GridXZ<int>(limits);
var position = new XZ(0, 0);
grid.SetValueForce(position, 123);
```

### Inicialização de células 

Implementação para que cada filho do BaseGrid possa inicializar as células de uma maneira específica.

```csharp
protected abstract void InitializeCells(Dictionary<int, TGridCell> cells);  
```
