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

### Comparador XY e XZ

Implementação para comparar posições, tanto do tipo XY quanto do XZ, utilizando função Equals, ou mesmo operador == (ou operador !=).

```csharp
public bool Equals(XY xy)
public bool Equals(XZ xz)

public static bool operator ==(XZ xz, XZ xz2)
public static bool operator !=(XZ xz, XZ xz2) => !(xz == xz2);

public static bool operator ==(XY xy, XY xy2)
public static bool operator !=(XY xy, XY xy2) => !(xy == xy2);
```
