using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Lantern
{
    public enum survivorStatus
    {
        CANT_SURVIVE  = 0x0001,
        CANT_HUNT     = 0x0002,
        CAN_ENCOURAGE = 0x0004,
        CAN_SURGE     = 0x0008,
        CAN_DASH      = 0x0010,
        CANT_USE_ARTS  = 0x0020,
        CAN_DODGE     = 0x0040
    }

    public enum survivorAttributes
    {
        MOV = 0, ACC, STR, EVA, LUC, SPD, SUR, INS
    }
    public enum experience
    {
        HUNT_XP = 0, COUR, UNDERS, WEAPON
    }


    public class Survivor
    {
        public string Name;
        public bool Gender;
        public int Status;
        public int[] Attributes;
        public int[] EXP;
        public string BoldSkill;
        public string InsightSkill;
        public string WeaponType;
        public string[] FightArts;
        public string[] Disorders;
        public string Notes;


        public Survivor(string newName, bool newGender)
        {
            Name = newName;
            Gender = newGender;
            Status = (int) survivorStatus.CAN_ENCOURAGE | (int) survivorStatus.CAN_DODGE;
            EXP = new int[4] { 0, 0, 0, 0 };
            BoldSkill = "";
            InsightSkill = "";
            WeaponType = "";
            Attributes = new int[8] {5, 0, 0, 0, 0, 0, 1, 0};
            FightArts = new string[3] { "None", "", "" };
            Disorders = new string[3] { "None", "", "" };
            Notes = "N/A";
            saveSurvivor();
        }
        public Survivor() { }

        public bool saveSurvivor()
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, this);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(Name + ".lantern");
                    stream.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        static public Survivor LoadSurvivor(string surName)
        {
            string fileName = surName + ".lantern";
            if (string.IsNullOrEmpty(fileName)) { return null; }

            Survivor objectOut = null;

            try
            {
                string attributeXml = string.Empty;

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(Survivor);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (Survivor)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return objectOut;
        }
    }
}
