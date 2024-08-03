
namespace SAS.TweenManagement
{
    public static class TweenAwaitableExtension
    {
        public static TweenAwaiter GetAwaiter(this ITween itween)
        {
            return new TweenAwaiter(itween);
        }
    }
}
