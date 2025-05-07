using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenovaAI.Components;

public partial class Assets : ContentView
{
    public Assets()
    {
        InitializeComponent();

        ScrollViewHorizontal.HandlerChanged += (s, e) =>
        {

#if ANDROID
    var nativeScroll = ScrollViewHorizontal.Handler.PlatformView as Android.Widget.ScrollView;
    nativeScroll.VerticalScrollBarEnabled = false;
    nativeScroll.HorizontalScrollBarEnabled = false;
#endif

#if IOS
            var nativeScroll = ScrollViewHorizontal.Handler.PlatformView as UIKit.UIScrollView;
            nativeScroll.ShowsVerticalScrollIndicator = false;
            nativeScroll.ShowsHorizontalScrollIndicator = false;
#endif
        };
    }
}