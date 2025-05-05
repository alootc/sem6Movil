using UnityEngine;
using UnityEngine.Android;
using Unity.Notifications.Android;

public class NotificationManager : SingletonPersistent<NotificationManager>
{
    private const string CHANNEL_ID = "default_channel";
    private bool channelRegistered = false;

    public override void Awake()
    {
        base.Awake();
        InitializeNotifications();
    }

    private void InitializeNotifications()
    {
        RequestNotificationPermission();
        RegisterNotificationChannel();
    }


    private void RequestNotificationPermission()
    {
        if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }
    }

    public void RegisterNotificationChannel()
    {
        if (channelRegistered) return;

        var channel = new AndroidNotificationChannel
        {
            Id = CHANNEL_ID,
            Name = "Default Channel",
            Importance = Importance.High,
            Description = "Game notifications",
            EnableLights = true,
            EnableVibration = true
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);
        channelRegistered = true;
        Debug.Log("Channel created");
    }

    public void SendNotification(string title, string text, int delayInHours = 0)
    {
        if (!channelRegistered)
        {
            RegisterNotificationChannel();
        }

        var notification = new AndroidNotification
        {
            Title = title,
            Text = text,
            FireTime = System.DateTime.Now.AddHours(delayInHours),
            LargeIcon = "icon_1",
            SmallIcon = "icon_0",
            ShouldAutoCancel = true
        };

        AndroidNotificationCenter.SendNotification(notification, CHANNEL_ID);
        Debug.Log($"Notification send {title} {text}");
    }
}