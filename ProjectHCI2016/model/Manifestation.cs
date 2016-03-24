using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Manifestation: INotifyPropertyChanged
    {
        private string idManifest;
        private string name;
        private string description;
        private ManifestationType type;
        private ServeAlcohol serveAlcosol;
        private Uri icon;
        private bool forHandicap;
        private bool smokingAllowed;
        private bool isOutside;
        private PriceCategory priceCategory;
        private string expectedAudience;
        private DateTime date;

        public event PropertyChangedEventHandler PropertyChanged;

        public Manifestation()
        {

        }

        public Manifestation(string idManifest, string name, string description, ManifestationType type, ServeAlcohol serveAlcosol, Uri icon, bool forHandicap, bool smokingAllowed, bool isOutside, PriceCategory priceCategory, string expectedAudience, DateTime date)
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
        }

        public override string ToString()
        {
            return string.Format("ID: {0}\n    Name: {1}\n    Descript.: {2}\n    Type: {3}\n    Alcosol: {4}\n    Icon: {5}\n    Handicap: {6}\n    Smoking: {7}\n    Place: {8}\n    Price: {9}\n    Audience: {10}\n    Date: {11}",
                idManifest, name, description, Type, serveAlcosol, icon, forHandicap, smokingAllowed, isOutside, priceCategory, expectedAudience, date);
        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public string IdManifest
        {
            get
            {
                return idManifest;
            }

            set
            {
                if (value != idManifest)
                {
                    idManifest = value;
                    OnPropertyChanged("IdManifest");
                }
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
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
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
                if (value != description)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
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
                if (value != type)
                {
                    type = value;
                    OnPropertyChanged("Type");
                }
            }
        }

        public ServeAlcohol ServeAlcosol
        {
            get
            {
                return serveAlcosol;
            }

            set
            {
                if (value != serveAlcosol)
                {
                    serveAlcosol = value;
                    OnPropertyChanged("ServeAlcosol");
                }
            }
        }

        public Uri Icon
        {
            get
            {
                return icon;
            }

            set
            {
                if (value != icon)
                {
                    icon = value;
                    OnPropertyChanged("Icon");
                }
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
                if (value != forHandicap)
                {
                    forHandicap = value;
                    OnPropertyChanged("ForHandicap");
                }
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
                if (value != smokingAllowed)
                {
                    smokingAllowed = value;
                    OnPropertyChanged("SmokingAllowed");
                }
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
                if (value != isOutside)
                {
                    isOutside = value;
                    OnPropertyChanged("IsOutside");
                }
            }
        }

        public PriceCategory PriceCategory
        {
            get
            {
                return priceCategory;
            }

            set
            {
                if (value != priceCategory)
                {
                    priceCategory = value;
                    OnPropertyChanged("PriceCategory");
                }
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
                if (value != expectedAudience)
                {
                    expectedAudience = value;
                    OnPropertyChanged("ExpectedAudience");
                }
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
                if (value != date)
                {
                    date = value;
                    OnPropertyChanged("Date");
                }
            }
        }

    }
}
