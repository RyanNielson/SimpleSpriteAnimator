using UnityEngine;
using UnityEditorInternal;
using UnityEditor;

namespace SimpleSpriteAnimator
{
    [CustomEditor(typeof(SpriteAnimation))]
    public class SpriteAnimationEditor : Editor
    {
        private ReorderableList framesList;

        private SpriteAnimation selectedSpriteAnimation
        {
            get { return target as SpriteAnimation; }
        }

        private float timeTracker = 0;

        private SpriteAnimationFrame currentFrame;

        private SpriteAnimationHelper spriteAnimationHelper;

        private void OnEnable()
        {
            timeTracker = (float)EditorApplication.timeSinceStartup;

            framesList = new ReorderableList(selectedSpriteAnimation.Frames, typeof(Sprite), true, true, true, true);
            //framesList.elementHeight = EditorGUIUtility.singleLineHeight * 5f;

            framesList.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
            {
                SpriteAnimationFrame spriteAnimationFrame = selectedSpriteAnimation.Frames[index];

                EditorGUI.BeginChangeCheck();

                rect.y += 2;

                spriteAnimationFrame.Sprite = EditorGUI.ObjectField(new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight), "", spriteAnimationFrame.Sprite, typeof(Sprite), false) as Sprite;

                if (EditorGUI.EndChangeCheck())
                {
                    EditorUtility.SetDirty(target);
                }
            };

            framesList.drawHeaderCallback = (Rect rect) =>
            {
                EditorGUI.LabelField(rect, "Frames");
            };

         
            spriteAnimationHelper = new SpriteAnimationHelper(selectedSpriteAnimation);

            EditorApplication.update += OnUpdate;
        }

        private void OnDisable()
        {
            EditorApplication.update -= OnUpdate;
        }


        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            if (selectedSpriteAnimation != null && framesList != null)
            {
                selectedSpriteAnimation.Name = EditorGUILayout.TextField("Name", selectedSpriteAnimation.Name);

                // EditorGUILayout.HelpBox(selectedSpriteAnimation.Name, MessageType.None);

                framesList.DoLayoutList();
                
                selectedSpriteAnimation.FPS = Mathf.Max(EditorGUILayout.IntField("FPS", selectedSpriteAnimation.FPS), 0);
            }

            serializedObject.ApplyModifiedProperties();
        }

        public override bool HasPreviewGUI()
        {
            return HasAnimationAndFrames();
        }

        public override bool RequiresConstantRepaint()
        {
            return HasAnimationAndFrames();
        }

        private bool HasAnimationAndFrames()
        {
            return selectedSpriteAnimation != null && selectedSpriteAnimation.Frames.Count > 0;
        }

        private void OnUpdate()
        {
            float deltaTime = (float)EditorApplication.timeSinceStartup - timeTracker;
            timeTracker += deltaTime;
            currentFrame = spriteAnimationHelper.UpdateAnimation(deltaTime);
        }

        public override void OnPreviewGUI(Rect r, GUIStyle background)
        {
            if (currentFrame != null && currentFrame.Sprite != null)
            {
                Texture t = currentFrame.Sprite.texture;
                Rect tr = currentFrame.Sprite.textureRect;
                Rect r2 = new Rect(tr.x / t.width, tr.y / t.height, tr.width / t.width, tr.height / t.height);

                Rect previewRect = r;

                float targetAspectRatio = tr.width / tr.height;
                float windowAspectRatio = r.width / r.height;
                float scaleHeight = windowAspectRatio / targetAspectRatio;

                if (scaleHeight < 1f)
                {
                    previewRect.width = r.width;
                    previewRect.height = scaleHeight * r.height;
                    previewRect.x = r.x;
                    previewRect.y = r.y + (r.height - previewRect.height) / 2f;
                }
                else
                {
                    float scaleWidth = 1f / scaleHeight;

                    previewRect.width = scaleWidth * r.width;
                    previewRect.height = r.height;
                    previewRect.x = r.x + (r.width - previewRect.width) / 2f;
                    previewRect.y = r.y;
                }

                GUI.DrawTextureWithTexCoords(previewRect, t, r2, true);
            }
        }
    }
}