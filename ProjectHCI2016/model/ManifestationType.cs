using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace model
{
    public class ManifestationType
    {
        private string idManifestType;
        private string name;
        private ImageSource icon;
        private string description;

        public ManifestationType()
        {

        }

        public ManifestationType(string idManifestType, string name, ImageSource icon, string description)
        {
            this.idManifestType = idManifestType;
            this.name = name;
            this.icon = icon;
            this.description = description;
        }

        public override string ToString()
        {
            return string.Format("ID: {0}\n    Name: {1}\n    Icon: {2}\n    Descript.: {3}", idManifestType, name, icon, description);
        }

        public string IdManifestType
        {
            get
            {
                return idManifestType;
            }

            set
            {
                idManifestType = value;
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

        public ImageSource Icon
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

    }
}
