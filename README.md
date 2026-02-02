# HW4
## Devlog
Ruixuan Pan, she/her 

In this project, I structured my code to loosely follow the Model-View-Controller (MVC) pattern on the control and view aspects. First, the control side of the game is mainly handled by the PlayerController class. It reads the player's input of pressing the SPACE key and applies movement and physics to the bird, including its jumping and flapping. PlayerController does not directly interact with the UI or the score system. Instead, it raises an event (OnFlap) when the player flaps, allowing other systems, such as audio and UI, to respond without coupling to the player code.

The game's ending is managed by PlayerDeath. When the player collides with the pipe in OnCollisionEnter2D, it raises the OnPlayerDied event and stops the game by setting Time.timeScale to 0f. The view side consists of the AudioManager and ScoreManager classes. AudioManager subscribes to gameplay events such as OnFlap, OnScored, and OnPlayerDied, and plays the appropriate sound effects in response. Because it only listens for events, it remains fully decoupled from gameplay logic.

The score UI is handled by ScoreManager and implemented as a Singleton to ensure there is only one score controller in the scene. In OnEnable(), it subscribes to ScoreTrigger.OnScored. When this event is raised, the score is incremented, and the UI text is updated. This allows both the score display and scoring logic to respond to gameplay events without direct references to the Player or Pipe objects.

Overall, the use of events and a Singleton allows the control and view systems to communicate without tight coupling. This MVC-inspired structure makes the code easier to maintain and extend, while keeping each system focused on a single responsibility.


## Open-Source Assets
If you added any other assets, list them here!
- [Brackey's Platformer Bundle](https://brackeysgames.itch.io/brackeys-platformer-bundle) - sound effects
- [2D pixel art seagull sprites](https://elthen.itch.io/2d-pixel-art-seagull-sprites) - seagull sprites
