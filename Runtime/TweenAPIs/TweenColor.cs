using UnityEngine;
using UnityEngine.UI;

namespace SAS.TweenManagement
{
    public partial struct Tween
    {
        public static ITween Color(Renderer renderer, Color to, ref TweenConfig tweenConfig)
        {
            Color color = renderer.material.color;
            ITween iTween = CreateTween(color, to, renderer.SetColor, ref tweenConfig);
            iTween.Run();
            return iTween;
        }

        public static ITween Color(Graphic graphic, Color to, ref TweenConfig tweenConfig)
        {
            Color color = graphic.color;
            ITween iTween = CreateTween(color, to, graphic.SetColor, ref tweenConfig);
            iTween.Run();
            return iTween;
        }

        public static ITween Alpha(CanvasGroup canvasGroup, float to, TweenConfig tweenConfig)
        {
            return Alpha(canvasGroup, to, ref tweenConfig);
        }

        public static ITween Alpha(CanvasGroup canvasGroup, float to, ref TweenConfig tweenConfig)
        {
            return Alpha(canvasGroup, canvasGroup.alpha, to, ref tweenConfig);
        }

        public static ITween Alpha(CanvasGroup canvasGroup, float from, float to, TweenConfig tweenConfig)
        {
            return Alpha(canvasGroup, from, to, ref tweenConfig);
        }

        public static ITween Alpha(CanvasGroup canvasGroup, float from, float to, ref TweenConfig tweenConfig)
        {
            ITween iTween = CreateTween(from, to, canvasGroup.SetAlpha, ref tweenConfig);
            iTween.Run();
            return iTween;
        }
    }
}