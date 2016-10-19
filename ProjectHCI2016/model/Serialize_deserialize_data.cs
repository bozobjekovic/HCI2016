using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace model
{
    public class Serialize_deserialize_data
    {
        public static void deserialize_data(ObservableCollection<Manifestation> manifestations, ObservableCollection<ManifestationType> manifestTypes, ObservableCollection<Tag> tags, ObservableCollection<Manifestation> manifestationsOnBoard, ObservableCollection<Manifestation> manifestationsInTree)
        {
            deserialize_tags(tags);
            deserialize_manifestation_types(manifestTypes);
            deserialize_manifestations(manifestations, manifestationsOnBoard, manifestationsInTree);
        }

        private static void deserialize_tags(ObservableCollection<Tag> tags)
        {
            XmlSerializer tagSerializer = new XmlSerializer(typeof(ObservableCollection<Tag>));

            // TAGS
            if (File.Exists("tagsData.xml"))
            {
                StreamReader file = new StreamReader("tagsData.xml");
                try
                {
                    ObservableCollection<Tag> t = (ObservableCollection<Tag>)tagSerializer.Deserialize(file);
                    foreach (Tag tag in t)
                    {
                        tags.Add(tag);
                    }
                    file.Close();
                }
                catch (Exception)
                {
                    Console.WriteLine("Tag error");
                }
            }
        }

        private static void deserialize_manifestations(ObservableCollection<Manifestation> manifestations, ObservableCollection<Manifestation> manifestationsOnBoard, ObservableCollection<Manifestation> manifestationsInTree)
        {
            XmlSerializer manifestationSerializer = new XmlSerializer(typeof(ObservableCollection<Manifestation>));

            // MANIFESTATIONS
            if (File.Exists("manifestationsData.xml"))
            {
                StreamReader file = new StreamReader("manifestationsData.xml");
                try
                {
                    ObservableCollection<Manifestation> t = (ObservableCollection<Manifestation>)manifestationSerializer.Deserialize(file);
                    foreach (Manifestation manif in t)
                    {
                        manifestations.Add(manif);
                        if (manif.X_position != -1 && manif.Y_position != -1)
                        {
                            manifestationsOnBoard.Add(manif);
                        }
                        else
                        {
                            manifestationsInTree.Add(manif);
                        }
                    }
                    file.Close();
                }
                catch (Exception)
                {
                    Console.WriteLine("Manifestation error");
                }
            }
        }

        private static void deserialize_manifestation_types(ObservableCollection<ManifestationType> manifestTypes)
        {
            XmlSerializer manifestationTypeSerializer = new XmlSerializer(typeof(ObservableCollection<ManifestationType>));

            // MANIFESTATIONSTYPE
            if (File.Exists("manifestationsTypeData.xml"))
            {
                StreamReader file = new StreamReader("manifestationsTypeData.xml");
                try
                {
                    ObservableCollection<ManifestationType> t = (ObservableCollection<ManifestationType>)manifestationTypeSerializer.Deserialize(file);
                    foreach (ManifestationType manifT in t)
                    {
                        manifestTypes.Add(manifT);
                    }
                    file.Close();
                }
                catch (Exception)
                {
                    Console.WriteLine("ManifestationType error");
                }
            }
        }

        public static void serialize_data(ObservableCollection<Manifestation> manifestations, ObservableCollection<ManifestationType> manifestTypes, ObservableCollection<Tag> tags)
        {
            serialize_manifestations(manifestations);
            serialize_manifestation_types(manifestTypes);
            serialize_tags(tags);   
        }

        private static void serialize_manifestations(ObservableCollection<Manifestation> manifestations)
        {
            XmlSerializer manifestationSerializer = new XmlSerializer(typeof(ObservableCollection<Manifestation>));

            // MANIFESTATIONS
            using (StreamWriter writer = new StreamWriter("manifestationsData.xml"))
            {
                manifestationSerializer.Serialize(writer, manifestations);
            }
        }

        private static void serialize_manifestation_types(ObservableCollection<ManifestationType> manifestTypes)
        {
            XmlSerializer manifestationTypeSerializer = new XmlSerializer(typeof(ObservableCollection<ManifestationType>));

            // MANIFESTATIONSTYPE
            using (StreamWriter writer = new StreamWriter("manifestationsTypeData.xml"))
            {
                manifestationTypeSerializer.Serialize(writer, manifestTypes);
            }
        }

        private static void serialize_tags(ObservableCollection<Tag> tags)
        {
            XmlSerializer tagSerializer = new XmlSerializer(typeof(ObservableCollection<Tag>));

            // TAGS
            using (StreamWriter writer = new StreamWriter("tagsData.xml"))
            {
                tagSerializer.Serialize(writer, tags);
            }
        }
    }
}
