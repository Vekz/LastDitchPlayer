using LastDitchPlayer.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace LastDitchPlayer.Playlists
{
   public class PlaylistSerializer
    {
        public List<Track> playList;

        public string name;

        public PlaylistSerializer(List<Track> playList, string name)
        {
            this.playList = playList;
            this.name = name;
        }



     public void Save()
        {
            throw new NotImplementedException();
        }

        public Playlist Load()
        {
            throw new NotImplementedException();
        }

        public void Serialize(string fileName)
        {
            List<XElement> elements = new List<XElement>();
            foreach(Track t in playList)
            {
                elements.Add(new XElement("Track", t.FilePath));
            }
            XDocument file = new XDocument(
        new XDeclaration("1.0", "utf8", "yes"),
        new XComment("This XML file contains LDP playlist"),
        new XElement("Playlists",
            new XElement("Playlist", new XAttribute("Name", name),
                new XElement("Tracks", 
                    elements)
                )

        )
        );
            file.Save($"{fileName}.xml");
        }
    }
}
