# Graphics Options Menu in Unity
Real-time graphics settings adjustment in Unity.

## How to Enable and Disable VSync
<p align="justify">You can use Unity's button interaction system along with the **graphicsOptions** script to enable and disable VSync, as demonstrated in the example below.</p>

![2024-10-12-11-38-37](https://github.com/user-attachments/assets/411d092d-5d1f-4a59-bc10-5b986ecb7f9a)

## How to Enable and Disable Post Process
<p align="justify">It works the same way as with VSync—use Unity's button interaction system. You can apply different post-processing effects from the volume component in Unity, such as motion blur, by changing the line **globalVolume.profile.TryGet(out FilmGrain filmGrain** to the desired effect:</p>
globalVolume.profile.TryGet(out MotionBlur motionBlur).
