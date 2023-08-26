using DOC_21.Views.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace DOC_21.Util
{
    public class BusinessUtil
    {
        public static void DoAnimation(MessageDialog dialog)
        {
            DoubleAnimation da = new DoubleAnimation();
            CircleEase ease = new CircleEase() { EasingMode = EasingMode.EaseOut };

            da.From = 0;
            da.To = 50;
            da.Duration = TimeSpan.FromMilliseconds(2500);
            da.EasingFunction = ease;
            dialog.BeginAnimation(FrameworkElement.HeightProperty, da);

            DispatcherTimer timer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 2, 500) };
            timer.Tick += (sender, args) =>
            {
                da.From = 50;
                da.To = 0;
                da.Duration = TimeSpan.FromMilliseconds(1250);
                da.EasingFunction = ease;
                dialog.BeginAnimation(FrameworkElement.HeightProperty, da);
                timer.Stop();
            };
            timer.Start();
        }
    }
}
