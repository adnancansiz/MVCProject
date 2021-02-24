using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common
{
    public class ImageUploader
    {
        /*
         0=> dosya boş
         1=> "bu görsel daha önce eklenmiş"
         2=> "uymayan format"
         */


        public static string UploadImage(string serverPath,HttpPostedFileBase file)///Content/product/electronic
        {
            var fileName = "";
            if (file != null)
            {
                var uniqueName = Guid.NewGuid();
                serverPath = serverPath.Replace("~","");
                var fileArray = file.FileName.Split('.');
                //manzara.asdad.adaddadad.png
                string extension = fileArray[fileArray.Length - 1].ToLower();

                fileName = uniqueName + "." + extension;

                //png,jpg,jpeg,gif,

                if (extension == "png" || extension == "jpg" || extension == "jpeg" || extension == "gif")
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath+fileName)))
                    {
                        return "1";
                    }
                    else
                    {
                        try
                        {
                            var filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);
                            file.SaveAs(filePath);

                            return fileName;
                        }
                        catch (Exception ex)
                        {

                            return ex.Message;
                        }

                        
                    }
                }
                else
                {
                    return "2";
                }


            }
            else
            {
                return "0";
            }

        }
    }
}
