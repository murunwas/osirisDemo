using System;
using System.Collections.Generic;
using System.Text;

namespace OSIRIS.Common.Responses.Movies
{
    public class Torrent
    {
        public string Url { get; set; }
        public string Hash { get; set; }
        public string Quality { get; set; }
        public string Type { get; set; }
        public int Seeds { get; set; }
        public int Peers { get; set; }
        public string Size { get; set; }
        public int SizeBytes { get; set; }
        public string DateUploaded { get; set; }
        public int DateUploadedUnix { get; set; }
    }
}
