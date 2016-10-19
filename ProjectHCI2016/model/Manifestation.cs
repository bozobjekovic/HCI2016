using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace model
{
    public class Manifestation
    {
        private string idManifest;
        private string name;
        private string description;
        private ManifestationType type;
        private string serveAlcosol;
        private string icon;
        private bool forHandicap;
        private bool smokingAllowed;
        private bool isOutside;
        private string priceCategory;
        private string expectedAudience;
        private DateTime date;
        private double x_position;
        private double y_position;
        private int marginR;
        private int marginB;
        public ObservableCollection<Tag> manifTags = new ObservableCollection<Tag>();

        public Manifestation()
        {
            this.x_position = -1;
            this.y_position = -1;
        }

        public Manifestation(string idManifest, string name, string description, ManifestationType type, string serveAlcosol, string icon, bool forHandicap, bool smokingAllowed, bool isOutside, string priceCategory, string expectedAudience, DateTime date, ObservableCollection<Tag> manifTAGS)
        {
            this.IdManifest = idManifest;
            this.Name = name;
            this.Description = description;
            this.Type = type;
            this.ServeAlcosol = serveAlcosol;
            this.Icon = icon;
            this.ForHandicap = forHandicap;
            this.SmokingAllowed = smokingAllowed;
            this.IsOutside = isOutside;
            this.PriceCategory = priceCategory;
            this.ExpectedAudience = expectedAudience;
            this.Date = date;
            this.x_position = -1;
            this.y_position = -1;
            this.manifTags = manifTAGS;
        }

        public override string ToString()
        {
            return string.Format("ID: {0}\n    Name: {1}\n    Descript.: {2}\n    Type: {3}\n    Alcosol: {4}\n    Icon: {5}\n    Handicap: {6}\n    Smoking: {7}\n    Place: {8}\n    Price: {9}\n    Audience: {10}\n    Date: {11}",
                idManifest, name, description, type, serveAlcosol, icon, forHandicap, smokingAllowed, isOutside, priceCategory, expectedAudience, date);
        }

        public string IdManifest
        {
            get
            {
                return idManifest;
            }

            set
            {
                idManifest = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public ManifestationType Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public string ServeAlcosol
        {
            get
            {
                return serveAlcosol;
            }

            set
            {
                serveAlcosol = value;
            }
        }

        public string Icon
        {
            get
            {
                return icon;
            }

            set
            {
                icon = value;
            }
        }

        public bool ForHandicap
        {
            get
            {
                return forHandicap;
            }

            set
            {
                forHandicap = value;
            }
        }

        public bool SmokingAllowed
        {
            get
            {
                return smokingAllowed;
            }

            set
            {
                smokingAllowed = value;
            }
        }

        public bool IsOutside
        {
            get
            {
                return isOutside;
            }

            set
            {
                isOutside = value;
            }
        }

        public string PriceCategory
        {
            get
            {
                return priceCategory;
            }

            set
            {
                priceCategory = value;
            }
        }

        public string ExpectedAudience
        {
            get
            {
                return expectedAudience;
            }

            set
            {
                expectedAudience = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public ObservableCollection<Tag> ManifTags
        {
            get
            {
                return manifTags;
            }

            set
            {
                manifTags = value;
            }
        }

        public double X_position
        {
            get
            {
                return x_position;
            }

            set
            {
                x_position = value;
            }
        }

        public double Y_position
        {
            get
            {
                return y_position;
            }

            set
            {
                y_position = value;
            }
        }

        public int MarginR
        {
            get
            {
                return marginR;
            }

            set
            {
                marginR = value;
            }
        }

        public int MarginB
        {
            get
            {
                return marginB;
            }

            set
            {
                marginB = value;
            }
        }
    }
}
