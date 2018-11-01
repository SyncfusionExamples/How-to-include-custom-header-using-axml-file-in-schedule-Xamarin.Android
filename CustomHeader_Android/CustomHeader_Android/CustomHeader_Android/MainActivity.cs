using Android.App;
using Android.Widget;
using Android.OS;
using Com.Syncfusion.Schedule;
using Com.Syncfusion.Schedule.Enums;
using Java.Util;
using System.Collections.Generic;
using Java.Text;

namespace CustomHeader_Android
{
    [Activity(Label = "CustomHeader_Android", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        TextView CustomHeader;
        SfSchedule Schedule;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            CustomHeader = FindViewById<TextView>(Resource.Id.customHeader);

            Schedule = FindViewById<SfSchedule>(Resource.Id.schedule);

            Schedule.HeaderHeight = 0;

            Schedule.VisibleDatesChanged += Schedule_VisibleDatesChanged;
        }

        void Schedule_VisibleDatesChanged(object sender, VisibleDatesChangedEventArgs e)
        {
            var dateList = e.VisibleDates;
            var dateFomater = new SimpleDateFormat("LLLL yyyy", Schedule.Locale);

            if (Schedule.ScheduleView == ScheduleView.MonthView)
                CustomHeader.Text = dateFomater.Format(dateList[dateList.Count / 2].Time);
            else
                CustomHeader.Text = dateFomater.Format(dateList[0].Time);
        }
    }
}

