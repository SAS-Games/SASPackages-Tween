using UnityEngine;
using UnityEngine.UI;

namespace SAS.TweenManagement
{
    public static partial class Tween
    {
        public static TweenBase Color(Renderer renderer, Color to, TweenConfig tweenConfig)
        {
            Color color = renderer.material.color;
            TweenBase iTween = CreateTween(color, to, renderer.SetColor, tweenConfig);
            iTween.Run();
            return iTween;
        }

        public static TweenBase Color(Graphic graphic, Color to, ref TweenConfig tweenConfig)
        {
            Color color = graphic.color;
            TweenBase iTween = CreateTween(color, to, graphic.SetColor, tweenConfig);
            iTween.Run();
            return iTween;
        }

        public static TweenBase Alpha(CanvasGroup canvasGroup, float to, TweenConfig tweenConfig)
        {
            return Alpha(canvasGroup, canvasGroup.alpha, to, tweenConfig);
        }

        public static TweenBase Alpha(CanvasGroup canvasGroup, float from, float to, TweenConfig tweenConfig)
        {
            TweenBase iTween = CreateTween(from, to, canvasGroup.SetAlpha, tweenConfig);
            iTween.Run();
            return iTween;
        }
    }
}