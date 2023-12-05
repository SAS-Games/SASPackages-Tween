using UnityEngine;
using UnityEngine.UI;

namespace SAS.TweenManagment
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
            ITween iTween = CreateTween(canvasGroup.alpha, to, canvasGroup.SetAlpha, ref tweenConfig);
            iTween.Run();
            return iTween;
        }
    }
}