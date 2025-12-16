using UnityEngine;
using UnityEngine.UI;

namespace SAS.TweenManagement
{
    public static partial class Tween
    {
        public static ITween Color(Renderer renderer, Color to, TweenConfig tweenConfig)
        {
            Color color = renderer.material.color;
            ITween iTween = CreateTween(color, to, renderer.SetColor, tweenConfig);
            iTween.Run();
            return iTween;
        }

        public static ITween Color(Graphic graphic, Color to, ref TweenConfig tweenConfig)
        {
            Color color = graphic.color;
            ITween iTween = CreateTween(color, to, graphic.SetColor, tweenConfig);
            iTween.Run();
            return iTween;
        }

        public static ITween Alpha(CanvasGroup canvasGroup, float to, TweenConfig tweenConfig)
        {
            return Alpha(canvasGroup, canvasGroup.alpha, to, tweenConfig);
        }

        public static ITween Alpha(CanvasGroup canvasGroup, float from, float to, TweenConfig tweenConfig)
        {
            ITween iTween = CreateTween(from, to, canvasGroup.SetAlpha, tweenConfig);
            iTween.Run();
            return iTween;
        }
    }
}