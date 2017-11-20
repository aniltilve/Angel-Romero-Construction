using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARC.Classes;
using System.Linq;
using System.Collections.Generic;
namespace ARC.Models
{
    public class SiteLanguage
    {
        private string m_width = string.Empty;
        private string m_height = string.Empty;

        [Key]
        public int id { get; set; }
        public string code { get; set; }
        public string text { get; set; }

        [NotMapped]
        public byte[] image
        {
            get
            {

                if (code.Trim().ToUpper() == Constant.Con_HomeImageTypeCode.Trim().ToUpper())
                {
                    using (DAC.Database database = new DAC.Database())
                    {
                        ARCImage ARCImage = (from it in database.ImageType
                                             join img in database.ARCImage on it.id equals img.typeID
                                             where it.code.ToUpper().Trim() == Classes.Constant.Con_SiteLanguageOverviewCode.ToUpper().Trim()
                                             select img).SingleOrDefault();
                        m_width = ARCImage.width;
                        m_height = ARCImage.height;
                        return (ARCImage != null) ? ARCImage.image : null;
                    }
                }
                return null;
            }
        }

        [NotMapped]
        public string Width
        {
            get
            {
                return m_width;
            }
        }

        [NotMapped]
        public string Height
        {
            get
            {
                return m_height;
            }
        }
    }
}