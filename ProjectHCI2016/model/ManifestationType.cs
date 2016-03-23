using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class ManifestationType
    {
        private string idManifestType;
        private string name;
        private Uri icon;
        private string description;

        public ManifestationType()
        {

        }

        public ManifestationType(string idManifestType, string name, Uri icon, string description)
        {
            this.idManifestType = idManifestType;
            this.name = name;
            this.icon = icon;
            this.description = description;
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

        public Uri Icon
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
