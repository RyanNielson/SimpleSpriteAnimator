using UnityEngine;
using System.Collections;

namespace SimpleSpriteAnimator
{
    public class SpriteAnimationHelper
    {
        private float frameDuration = 0f;
        private float frameTimeAccumulator = 0f;
        private float totalAnimationTime = 0f;
        private bool playing = false;

        private SpriteAnimation spriteAnimation;
        private bool done = false;
        public int currentFrame = 0;

        public SpriteAnimationHelper(SpriteAnimation spriteAnimation)
        {
            this.spriteAnimation = spriteAnimation;
        }

        public SpriteAnimationFrame UpdateAnimation(float deltaTime)
        {
            if (playing)
            {
                frameDuration = 1f / spriteAnimation.FPS;
                totalAnimationTime = frameDuration * spriteAnimation.Frames.Count;

                frameTimeAccumulator += deltaTime;

                if (frameTimeAccumulator >= totalAnimationTime)
                {
                    frameTimeAccumulator = 0;
                }

                if (spriteAnimation.SpriteAnimationType == SpriteAnimationType.PlayOnce && currentFrame < spriteAnimation.Frames.Count - 1)
                {
                    currentFrame = Mathf.FloorToInt(frameTimeAccumulator / frameDuration);
                }
                else if (spriteAnimation.SpriteAnimationType == SpriteAnimationType.Looping)
                {
                    currentFrame = Mathf.FloorToInt(frameTimeAccumulator / frameDuration);
                }
            }

            return spriteAnimation.Frames[currentFrame];
        }

        public void ChangeAnimation(SpriteAnimation spriteAnimation)
        {
            frameDuration = 0f;
            frameTimeAccumulator = 0f;
            totalAnimationTime = 0f;
            done = false;
            currentFrame = 0;
            this.spriteAnimation = spriteAnimation;
        }
    }
}
