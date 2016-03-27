using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace model
{
    public class Tag
    {
        private string tadID;
        private Color color;
        private string descriprion;

        public Tag()
        {

        }

        public Tag(string tadID, Color color, string descriprion)
        {
            this.tadID = tadID;
            this.color = color;
            this.descriprion = descriprion;
        }

        public override string ToString()
        {
            return string.Format("ID: {0}\n    Color: {1}\n    Descript.: {2}", tadID, color, descriprion);
        }

        public string TadID
        {
            get
            {
                return tadID;
            }

            set
            {
                tadID = value;
            }
        }

        public Color Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
        }

        public string Descriprion
        {
            get
            {
                return descriprion;
            }

            set
            {
                descriprion = value;
            }
        }

    }
}
