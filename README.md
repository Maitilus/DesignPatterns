# DesignPatterns
 
## State

Se utiliza la StateMachine en todo el comportamiento del enemigo, cambiando entre:

- Deambular
- Persecucion
- Ataque

Este patron, a pesar de ser complicado de implementar, una vez hecho ya es posible expandirlo facilmente con mas estados.

## Object Pool

El object pool se utiliza tambien en el enemigo al momento de disparar.

Cuando el enemigo esta en rango de ataque, instancia un proyectil siempre que lo necesite. en caso de haber un proyectil disponible, lo reutiliza para optimizar.

## Observer

El patron observer se utiliza en la logica de movimiento del jugador junto con el InputSystem para hacer un dash

## Singleton

El Manager de Audio utiliza un Singleton para poder llamar al metodo PlaySound desde cualquier clase.

En este caso se utiliza para dar un sonido al disparo del enemigo.

## Command

Command es utilizado para ejecutar el dash del jugador. esto permitiria, dado un cooldown, poner las acciones en una cola.
