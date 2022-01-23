using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Dultus_Library.SaveHelper
{
    public enum Pathlocation
    {
        RelativeToApplication,
        DirectPath
    }
    /// <summary>
    /// Savemanager
    /// </summary>
    public class Savemanager
    {
        #region Speichermethoden
        /// <summary>
        /// Speichert das übergebene Objekt in einer Binärdatei.
        /// </summary>
        /// <param name="Filename">Dateiname</param>
        /// <param name="Location">Relativ oder ein direkter Pfad?</param>
        /// <param name="Object">Das zu speichernde Objekt</param>
        /// <remarks>Speichert <paramref name="Object"/> als binäre Datei. Diese ist aber nicht mit einem Texteditor anpassbar. Dafür können alle Objekte abgespeichert werden.</remarks>
        public static void BinarySave(string Filename, Pathlocation Location, object Object)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                if (Location == Pathlocation.RelativeToApplication)
                    Filename = AppDomain.CurrentDomain.BaseDirectory + @"\" + Filename;
                else
                    Directory.CreateDirectory(Path.GetDirectoryName(Filename));
                FileStream fs = new FileStream(Filename, FileMode.Create);
                formatter.Serialize(fs, Object);
                fs.Close();
            }
            catch (Exception e)
            { throw e; }
        }
        /// <summary>
        /// Speichert das übergebene Objekt in einer XML-Datei.
        /// </summary>
        /// <param name="Filename">Dateiname</param>
        /// <param name="Location">Relativ oder ein direkter Pfad?</param>
        /// <param name="Object">Das zu speichernde Objekt</param>
        /// <remarks>Speichert <paramref name="Object"/> als XML Datei. XML Dateien sind via Editor anpassbar. Dafür können können einige Objekte nicht abgespeichert werden (z.B. Dictionarys).</remarks>
        public static void XMLSave(string Filename, Pathlocation Location, object Object)
        {
            try
            {
                XmlSerializer formatter = new XmlSerializer(Object.GetType());
                if (Location == Pathlocation.RelativeToApplication)
                    Filename = AppDomain.CurrentDomain.BaseDirectory + @"\" + Filename;
                else
                    Directory.CreateDirectory(Path.GetDirectoryName(Filename));
                using (FileStream fs = new FileStream(Filename, FileMode.Create))
                    formatter.Serialize(fs, Object);
            }
            catch (Exception e)
            { throw e; }
        }
        #endregion
        #region Lademethoden
        /// <summary>
        /// Lädt ein <c>object</c> aus einer binären Datei und gibt dieses aus. Das <c>object</c> muss zur Verwendung typisiert werden.
        /// </summary>
        /// <param name="Filename">Dateiname</param>
        /// <param name="Location">Relativ oder ein direkter Pfad?</param>
        /// <remarks>.</remarks>
        public static object BinaryLoad(string Filename, Pathlocation Location)
        {
            try
            {
                object loaded;
                BinaryFormatter formatter = new BinaryFormatter();
                if (Location == Pathlocation.RelativeToApplication)
                    Filename = AppDomain.CurrentDomain.BaseDirectory + @"\" + Filename;
                using (FileStream fs = new FileStream(Filename, FileMode.Open))
                    loaded = formatter.Deserialize(fs);
                return loaded;
            }
            catch (Exception e)
            { throw e; }
        }
        /// <summary>
        /// Lädt ein <c>object</c> aus einer binären Datei und gibt dieses aus. Das <c>object</c> muss zur Verwendung typisiert werden.
        /// </summary>
        /// <param name="Filename">Dateiname</param>
        /// <param name="Location">Relativ oder ein direkter Pfad?</param>
        /// <param name="refType">Typ des auszugebenden Objekts</param>
        /// <remarks>Der Typ des gewünschten Objekts muss übergeben werden. Die Ausgabe muss dennoch typisiert werden.</remarks>
        public static object XMLLoad(string Filename, Pathlocation Location, Type refType)
        {
            try
            {
                object loadedObject;
                XmlSerializer formatter = new XmlSerializer(refType);
                if (Location == Pathlocation.RelativeToApplication)
                    Filename = AppDomain.CurrentDomain.BaseDirectory + @"\" + Filename;
                using (StringReader sr = new StringReader(Filename))
                {
                    loadedObject = formatter.Deserialize(sr);
                }
                return loadedObject;
            }
            catch (Exception e)
            { throw e; }
        }
        #endregion
    }
}
