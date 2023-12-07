using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifly
{
    internal class Song : Base
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Length { get; set; } 
        public DateTime ReleaseDate { get; set; }
        public List<Artist> Artists { get; set; }

        public override string ToString()
        {
            return $"Title: {Title}\n Genre: {Genre}\nLength: {GetTimeFromSeconds()}\nArtists:\n{ShowArtists()};";
        }

        private string ShowArtists()
        {
            string s = "";
            foreach (var artist in Artists) 
            {
                s += artist;//.ToString();
            }
            return s;
        }

        private TimeSpan GetTimeFromSeconds()
            {
                return TimeSpan.FromSeconds(Length);
               
        }
       
    }
}
