using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Interfaces.Patterns.FileStore
{
    public static class StorageKeys_
    {
        public static class Images
        {
            //public static readonly StorageKey Root = new("images");

            public const string Profile = "profile";
            public const string Avatar = "avatar";
            public const string Banner = "banner";
        }

        public static class Videos
        {
            //public static readonly StorageKey Root = new("videos");

            public const string Event = "event";
            public const string Training = "training";
        }
    }
}
