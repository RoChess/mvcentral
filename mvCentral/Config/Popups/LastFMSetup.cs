﻿using mvCentral.Utils;

using System;
using System.Windows.Forms;


namespace mvCentral.ConfigScreen.Popups
{
  public partial class LastFMSetup : Form
  {
    public LastFMSetup()
    {
      InitializeComponent();
      tbLastFMUsername.Setting = mvCentralCore.Settings["last_fm_username"];
      tbLastFMPassword.Setting = mvCentralCore.Settings["last_fm_password"];
      cbShowOnLastFM.Setting = mvCentralCore.Settings["show_on_lastfm"];
      cbSubmitToLastFM.Setting = mvCentralCore.Settings["submit_to_lastfm"];

      if (tbLastFMUsername.Text.Trim() == string.Empty)
        tbLastFMUsername.Text = string.Empty;

      if (tbLastFMPassword.Text.Trim() == string.Empty)
        tbLastFMPassword.Text = string.Empty;

    }


    private void btTestLogin_Click(object sender, EventArgs e)
    {
      try
      {
        LastFMScrobble profile = new LastFMScrobble();
        if (profile.Login(tbLastFMUsername.Text,tbLastFMPassword.Text))
          MessageBox.Show("Login OK!");
        else
          MessageBox.Show("Invalid login data or no connection !");
      }
      catch (Exception exception)
      {
        MessageBox.Show(exception.Message);
      }

    }

    private void btClose_Click(object sender, EventArgs e)
    {
      this.Hide();
    }
  }
}
