using SuperShopManagementSystem.BLL;
using SuperShopManagementSystem.Context;
using SuperShopManagementSystem.Models.Operation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SuperShopManagementSystem.Models
{
    public class Common
    {
        bool status;
        ShopDbContext db = new ShopDbContext();
        CommonBll commonBll = new CommonBll();

        internal byte[] ConvertImage(HttpPostedFileBase imageFile)
        {
            byte[] Image = new byte[imageFile.ContentLength];
            imageFile.InputStream.Read(Image, 0, imageFile.ContentLength);
            return Image;
        }

        public bool ImageValidation(HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null)
            {
                var extension = Path.GetExtension(ImageFile.FileName).ToLower();
                var fileName = Path.GetFileName(ImageFile.FileName);

                var allowExtension = new[]
                {
                    ".jpg",
                    ".png",
                    ".jpeg"
                };
                if (allowExtension.Contains(extension))
                {
                    status = true;
                }
            }
            return status;
        }

       internal dynamic GetItemStockById(int id)
        {
            var ItemStock = commonBll.GetItemStockById(id);
            return ItemStock;
        }

        //internal object GenerateAutoCode()
        //{
        //    string autoCode = "";
        //    string lastCode = db.ExpenseCatagories.Max(item => item.Code);

        //    string resultString = Regex.Match(lastCode, @"\d+").Value;
        //    int start = Int32.Parse(resultString);

        //    autoCode = "EC" + (start + 1).ToString("000");
        //    return autoCode;
        //}

    }
}