# SimpleSpriteAnimator
Simpler 2D sprite animation in Unity.

Sprite animation in Unity is powerful, but often too complicated. You have to create animations, set up animator states, add transitions, and much more. This project aims to make sprite animation much simpler.

##### This is an early work in progress. Please report any issues you find. Also, feel free to contribute fixes or additions.

## Why Should I Use SimpleSpriteAnimator?

Sprite animation in Unity is very powerful, but often too complicated when trying to make simple 2D sprite animations. You have to create animations, set up animator states, add transitions, and much more. This project aims to make sprite animation much simpler.

## Installation

Copy the `SpriteAnimator` folder into your `Assets` folder.

## Usage

1. Right click in the project window, and create a new `Sprite Animation` asset. This will store the animation settings including name, sprite frames, frames per second, and animation type.
2. Add a game object to the scene, and add a `Sprite Animator` component. This will automatically add a `Sprite Renderer` component that the animator requires.
3. Add the desired animations to the `Sprite Animator` component. The `Sprite Animator` will be able to play any animations in this list using direct references to them, or by their animation names.

## Inspector Options

#### Sprite Animation

- `Name`: The name of the animation. This will be used to play the animation via the `Sprite Animator`.
- `Frames`: A list of sprites that make up the animation.
- `FPS (Frames per second)`: The framerate of the animation. The higher this number, the faster the animation will play.
- `Type`: The type of the animation, this can be Looping or Play Once.
  - `Looping`: Plays the animation from start to end, then repeats.
  - `Place Once`: Plays the animation from start to end, then stops on the last frame.

#### Sprite Animator
- `Sprite Animations`: A list of sprite animations the sprite animator can play.
- `Play Automatically`: If checked, the first animation will play as soon as the scene starts.

## API

#### Example

The methods below should be called on the `SpriteAnimator` component.

- `Play()`: Play the last played animation from the beginning. If not used previously, the first animation will be used.
- `Play(string name)`: Play the animation with the given name.

```csharp
public class AnimatorTester : MonoBehaviour
{
    private SpriteAnimator spriteAnimator;

	  void Start ()
    {
        spriteAnimator = GetComponent<SpriteAnimator>();
	  }

    void Update()
    {
        spriteAnimator.Play("Walk"); // Play the animation named "Walk"
    }
}
```

## Demo

This project contains a demo in the `SpriteAnimatorDemo` folder. This includes an example of two animations, and a game object with an attached `Sprite Animator` component. It demonstrates changing animations using two GUI buttons.



