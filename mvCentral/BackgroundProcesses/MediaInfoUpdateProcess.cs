﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cornerstone.Tools;
using mvCentral.Database;
using NLog;
using System.Threading;

namespace mvCentral.BackgroundProcesses
{
    internal class MediaInfoUpdateProcess: AbstractBackgroundProcess {
        private static Logger logger = mvCentralCore.MyLogManager.Instance.GetCurrentClassLogger();

        public override string Name {
            get { return "MediaInfo Updater"; }
        }

        public override string Description {
            get {
                return "This process updates MediaInfo details for all media in the " +
                       "database that currently does not have MediaInfo retrieved.";
            }
        }

        public override void Work() {
            if (!mvCentralCore.Settings.AutoRetrieveMediaInfo)
                return;

            logger.Info("Begining background media info update process.");

            List<DBLocalMedia> allLocalMedia = DBLocalMedia.GetAll();
            foreach (DBLocalMedia lm in allLocalMedia) {
                if (lm.ID != null && !lm.HasMediaInfo) {
                    lm.UpdateMediaInfo();
                    lm.Commit();
                }
            }

            logger.Info("Background media info update process complete.");
        }
    }
}
