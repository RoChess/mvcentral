﻿using mvCentral.Database;
using mvCentral.SignatureBuilders;

using NLog;

using System;
using System.Collections.Generic;

namespace mvCentral.DataProviders
{
    public class ManualProvider : IMusicVideoProvider
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        // we should be using the MusicVideo object but we have to assign it before locking which 
        // is not good if the thread gets interupted after the asssignment, but before it gets 
        // locked. So we use this dumby var.
//        private String lockObj = "";     

        public string Name {
            get {
                return "Manual Dummy Data";
            }
        }

        public string Version {
            get {
                return "Internal";
            }
        }

        public string Author {
            get { return "Music Videos Team"; }
        }

        public string Description {
            get { return "Dummo provider for manual addition."; }
        }

        public string Language {
            get { return ""; }
        }

        public string LanguageCode {
            get { return ""; }
        }

        public List<string> LanguageCodeList
        {
          get
          {
            List<string> supportLanguages = new List<string>();
            return supportLanguages;
          }
        }


        public bool ProvidesTrackDetails
        {
            get { return false; }
        }

        public bool ProvidesArtistDetails
        {
          get { return false; }
        }

        public bool ProvidesAlbumDetails
        {
          get { return false; }
        }

        public bool ProvidesAlbumArt {
            get { return false; }
        }

        public bool ProvidesArtistArt {
            get { return false; }
        }

        public bool ProvidesTrackArt
        {
            get { return false; }
        }

        public bool GetArtistArt(DBArtistInfo mv)
        {
            return false;
        }

        public bool GetAlbumArt(DBAlbumInfo mv)
        {
                return false;
        }

        public bool GetTrackArt(DBTrackInfo mv)
        {
                return false;
        }

       

        public bool GetArtwork(DBTrackInfo mv)
        {
            return false;
        }

        public DBTrackInfo GetArtistDetail(DBTrackInfo mv)
        {
          throw new NotImplementedException();
        }

        public DBTrackInfo GetAlbumDetail(DBTrackInfo mv)
        {
          throw new NotImplementedException();
        }

        public bool GetDetails(DBBasicInfo mv)
        {
            throw new NotImplementedException();
        }

        public bool GetAlbumDetails(DBBasicInfo basicInfo, string albumTitle, string albumMbid)
        {
          throw new NotImplementedException();
        }

        public List<DBTrackInfo> GetTrackDetail(MusicVideoSignature mvSignature) {
            throw new NotImplementedException();
        }

        public UpdateResults UpdateTrack(DBTrackInfo mv) {
            throw new NotImplementedException();
        }

        public event EventHandler ProgressChanged;

        private void ReportProgress(string text)
        {
          if (ProgressChanged != null)
          {
            ProgressChanged(this, new ProgressEventArgs { Text = "Manual: " + text });
          }
        }
    }
}
