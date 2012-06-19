using Cirrious.MvvmCross.Platform.Diagnostics;

namespace Ahwa.Attila.Core.Android
{
    public static class TraceHelper
    {
        public const string Tag = "Attila";

        public static void Trace(string message, params object[] args)
        {
            MvxTrace.TaggedTrace(Tag, message, args);
        }
    }
}