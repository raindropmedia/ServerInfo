using ServerInfo.Properties;
using System;
using System.Windows.Forms;

namespace ServerInfo
{
    public class TaskTrayContext : ApplicationContext
    {
        NotifyIcon notifyIcon = new NotifyIcon();
        Configuration configWindow = new Configuration();
        Globalfunc globalfunc = new Globalfunc();

        public TaskTrayContext()
        {
            MenuItem configMenuItem = new MenuItem("Configuration", new EventHandler(ShowConfig));
            MenuItem startAppMenuItem = new MenuItem("startApp", new EventHandler(StartApp));
            MenuItem connectComItem = new MenuItem("connectCom", new EventHandler(ConnectCom));
            MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));

            notifyIcon.Icon = ServerInfo.Properties.Resources.AppIcon;
            notifyIcon.DoubleClick += new EventHandler(ShowMessage);
            notifyIcon.ContextMenu = new ContextMenu(new MenuItem[] { configMenuItem, connectComItem, startAppMenuItem, exitMenuItem });
            notifyIcon.Visible = true;
            Settings.Default.comPortOpen = false;
        }

        void ShowMessage(object sender, EventArgs e)
        {
            // Only show the message if the settings say we can.
            if (ServerInfo.Properties.Settings.Default.ShowMessage)
                MessageBox.Show("Hello World");
        }

        void ShowConfig(object sender, EventArgs e)
        {
            // If we are already showing the window meerly focus it.
            if (configWindow.Visible)
                configWindow.Activate();
            else
                configWindow.ShowDialog();
        }

        void ConnectCom(object sender, EventArgs e)
        {
            configWindow.connectCom();
        }

        void StartApp(object sender, EventArgs e)
        {
            globalfunc.StartApp(Settings.Default.Application);
        }

        void Exit(object sender, EventArgs e)
        {
            // We must manually tidy up and remove the icon before we exit.
            // Otherwise it will be left behind until the user mouses over.
            notifyIcon.Visible = false;

            Application.Exit();
        }
    }
}
