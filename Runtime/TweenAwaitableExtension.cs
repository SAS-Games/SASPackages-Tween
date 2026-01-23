
namespace SAS.TweenManagement
{
    public static class TweenAwaitableExtension
    {
        public static TweenAwaiter GetAwaiter(this TweenBase itween)
        {
            return new TweenAwaiter(itween);
        }
    }
}
