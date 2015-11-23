using UnityEngine;
using System.Collections;

namespace SimpleSpriteAnimator
{
    public class SpriteAnimationHelper
    {
        private float frameDuration = 0f;
        private float frameTimeAccumulator = 0f;
        private float totalAnimationTime = 0f;

        private SpriteAnimation spriteAnimation;

        public SpriteAnimationHelper(SpriteAnimation spriteAnimation)
        {
            this.spriteAnimation = spriteAnimation;
        }

        public SpriteAnimationFrame UpdateAnimation(float deltaTime)
        {
            frameDuration = 1f / spriteAnimation.FPS;
            totalAnimationTime = frameDuration * spriteAnimation.Frames.Count;

            frameTimeAccumulator += deltaTime;

            if (frameTimeAccumulator >= totalAnimationTime)
            {
                frameTimeAccumulator = 0;
            }

            int frame = Mathf.FloorToInt(frameTimeAccumulator / frameDuration);

            SpriteAnimationFrame currentFrame = spriteAnimation.Frames[frame];

            return currentFrame;
        }

        public void ChangeAnimation(SpriteAnimation spriteAnimation)
        {
            frameDuration = 0f;
            frameTimeAccumulator = 0f;
            totalAnimationTime = 0f;
            this.spriteAnimation = spriteAnimation;
        }
    }
}
