using LastDitchPlayer.Classes;
using NAudio.Wave;
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


        #region Redundand // TODO:: I feel like following methods wont benefit us at all
        public void Save()
        {
            throw new NotImplementedException();
        }

        public Playlist Load()
        {
            throw new NotImplementedException();

            // return new Playlist() { Tracks = playList, Name = name };
        }

        #endregion

        #region Serialization 
        /// <summary>
        /// Serialize playlist state to XML file.
        /// </summary>
        /// <param name="fileName">A filepath with name where file should be saved</param>
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
            file.Save($"{fileName}{(fileName.EndsWith(".xml") ? String.Empty :".xml")}");
        }

        // TO DO: Check if xml is a playlist holder at all ASAP
        /// <summary>
        /// This method returns previously saved playlist.
        /// </summary>
        /// <param name="filePath">Path of file to deserialize</param>
        /// <returns>Playlist parsed from deserialized XML file</returns>
        public static Playlist Deserialize(string filePath)
        {
            XDocument file = XDocument.Load(filePath);
            Playlist playlist = new Playlist();
            XElement xmlPlaylist = file.Element("Playlists").Element("Playlist");
            playlist.Name= xmlPlaylist.Attribute("Name").Value;
            foreach (XElement Track in xmlPlaylist.Element("Tracks").Elements("Track"))
            {
                AudioFileReader audioFile = new AudioFileReader(Track.Value);
                playlist.addTrack(new Track(Track.Value.Remove(Track.Value.LastIndexOf(".")), Track.Value, audioFile.TotalTime.TotalMinutes));
                audioFile.Dispose();
            }

            return playlist;
        }

        #endregion
    }
}
