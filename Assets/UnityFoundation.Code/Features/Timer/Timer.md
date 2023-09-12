# Timer

Esse recurso de Timer pode ser utilizado em vários tipos de aplicações. Como controlar tempo de execução de uma habilidade, tempo de uma volta em um jogo de corrida, entre várias outras.

### Propriedades

- CurrentTime
- RemainingTime
- Completion

# Criação de Timers

Os timers podem ser instanciados de várias formas dependendo das necessidades.

### Timer loop

```csharp
// Timer em loop (defaut mode)
var loopTimer = new Timer(totalTime, callback)
    .SetName("Loop counter timer")
    .Loop()
    .Start();
```

### Timer de execução única

```csharp
// Timer que roda apenas uma vez
var runOnceTimer = new Timer(totalTime, callback)
    .SetName("Loop run once timer")
    .RunOnce()
    .Start();
```

### Instanciação de timer global
Essa instanciação permite a criação de um timer de forma global que irá executar o callback quando completar o tempo total e então se auto destruir.

```csharp
var timer = TimersReference.I.Create(totalTime, callback);
```