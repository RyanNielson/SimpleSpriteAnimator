using UnityEngine;
using System.Collections;

namespace SimpleSpriteAnimator
{
    public class SpriteAnimationHelper
    {
        private float timeTracker = 0;
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
            //float deltaTime = (float)EditorApplication.timeSinceStartup - timeTracker;
            timeTracker += deltaTime;

            //Debug.Log(deltaTime);


            frameTimeAccumulator += deltaTime;

            if (frameTimeAccumulator >= totalAnimationTime)
            {
                frameTimeAccumulator = 0;
            }

            int frame = Mathf.FloorToInt(frameTimeAccumulator / frameDuration);

            SpriteAnimationFrame currentFrame = spriteAnimation.Frames[frame];

            return currentFrame;
        }

        public void Update(float deltaTime)
        {

        }

    }
}
