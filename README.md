# HW4
## Devlog
Ruixuan Pan, she/her 

In this project, I applied a model-view-controller (MVC) architecture to keep the Player code decoupled from the UI and audio systems. While the model aspect of this game is minimal, the separation between control and view is clearly implemented using C# events and a Singleton.

The control side of the system is handled by the PlayerController class. This class is responsible for detecting player input and controlling the player’s movement. In Update(), the SPACE key triggers the Flap() method, which directly modifies the Rigidbody2D velocity to push the player upward while gravity pulls the player back down. Instead of directly playing sounds, PlayerController raises the OnFlap event, allowing other systems to respond without creating direct dependencies.

Player failure is managed by the PlayerDeath class. When the player collides with an object tagged as "Pipe" in OnCollisionEnter2D, the class raises the OnPlayerDied event and stops the game using Time.timeScale = 0f. This keeps collision logic separate from audio and UI responsibilities. The view side of the system consists of the AudioManager and ScoreManager classes. AudioManager subscribes to gameplay events such as OnFlap, OnScored, and OnPlayerDied, and plays the appropriate sound effects in response. Because it only listens for events, it remains fully decoupled from gameplay logic.

The score UI is handled by ScoreManager, which is implemented as a Singleton to ensure there is only one score controller in the scene. In OnEnable(), it subscribes to ScoreTrigger.OnScored. When this event is raised, the score is incremented, and the UI text is updated. This allows both the score display and scoring logic to respond to gameplay events without direct references to the Player or Pipe objects.

Overall, the use of events and a Singleton allows the control and view systems to communicate without tight coupling. This MVC-inspired structure makes the code easier to maintain and extend, while keeping each system focused on a single responsibility.


## Open-Source Assets
If you added any other assets, list them here!
- [Brackey's Platformer Bundle](https://brackeysgames.itch.io/brackeys-platformer-bundle) - sound effects
- [2D pixel art seagull sprites](https://elthen.itch.io/2d-pixel-art-seagull-sprites) - seagull sprites
