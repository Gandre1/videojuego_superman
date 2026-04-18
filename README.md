# Superman vs Nubes

Juego hecho en Unity donde controlas un personaje que vuela mientras esquivas nubes, sobrevives y consigues la mayor distancia posible.

---

## Controles

- W A S D → Mover el personaje
- ESC → Pausar / Reanudar

---

## Mecánicas del juego

- Sistema de vida (3 corazones)
- Daño al tocar nubes
- Invulnerabilidad temporal después de recibir daño
- Game Over con pantalla final y récord
- Score basado en distancia (metros)
- Animación de inicio (intro fly sequence)
- Cámara con transición entre intro y gameplay
- Scroll infinito de cielo
- Sistema de audio:
  - Música de fondo
  - Sonido de intro
  - SFX de menú y golpes
---

## Sistemas principales (Unity)

### AudioManager
Controla música de fondo y sonidos del juego.

### CameraFollow
- Movimiento suave siguiendo al jugador
- Modo intro con cámara ascendiendo

### SkyScroller
- Fondo infinito con repetición de sprites

### GameManager
- Control de estados:
  - Idle
  - Intro
  - Gameplay
- Activa player, cámara y spawner
- Controla inicio de partida

### Player
- Movimiento libre dentro de la pantalla
- Sistema de vida + invulnerabilidad
- Colisiones con nubes

### UI System
- Corazones de vida
- Score en tiempo real
- Game Over con récord guardado

---

## Sistema de puntuación

- El score se basa en metros recorridos
- Se guarda el mejor récord usando PlayerPrefs

---

---

## Capturas de Juego

<p align="center">
  <img src="capturas/captura1.png" width="600"/>
</p>
---

## Descarga

https://github.com/Gandre1/videojuego_superman/releases/tag/1.0

---

## Hecho con

- Unity Engine
- C#
- Input System de Unity
