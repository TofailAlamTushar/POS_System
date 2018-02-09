using SuperShopManagementSystem.DAL;
using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.BLL
{
    public class ExpenseCatagoryBll
    {
        ExpenseCatagoryDal expenseCatagoryDal = new ExpenseCatagoryDal();
        bool status = false;
        public bool Create (ExpenseCatagory expenseCatagory )
        {
            
            status = expenseCatagoryDal.Create(expenseCatagory);

            return status;
        }
        public bool ImageValidation (HttpPostedFileBase ImageFile)
        {
            if(ImageFile!=null)
            {
                var extension = Path.GetExtension(ImageFile.FileName).ToLower();
                var fileName = Path.GetFileName(ImageFile.FileName);

                var allowExtension = new[]
                {
                    ".jpg",
                    ".png",
                    ".jpeg"
                };
                if(allowExtension.Contains(extension))
                {
                    status = true;
                }
            }
            return status;
        }

        internal object GenerateAutoCode()
        {
            var autoCode = expenseCatagoryDal.GenerateAutoCode();
            return autoCode;
        }

        internal List<ExpenseCatagory> List()
        {
            List<ExpenseCatagory> listOfExpenseCatagory = expenseCatagoryDal.List();

            return listOfExpenseCatagory;
        }

        internal byte[] ConvertImage(HttpPostedFileBase imageFile)
        {
           byte[] Image = new byte[imageFile.ContentLength];
            imageFile.InputStream.Read(Image, 0, imageFile.ContentLength);
            return Image;           
        }

        internal ExpenseCatagory GetById(int? id)
        {
            ExpenseCatagory expenseCatagory = expenseCatagoryDal.GetById(id);
            
            return expenseCatagory;
        }

        internal bool Edit(ExpenseCatagory expenseCatagories)
        {
            status = expenseCatagoryDal.Edit(expenseCatagories);
            return status;
        }

        internal bool Delete(int id)
        {
            status = expenseCatagoryDal.Delete(id);
            return status;
        }

        internal List<ExpenseCatagory> GetParentCategories()
        {
            List<ExpenseCatagory> ExpenseCategories = expenseCatagoryDal.GetParentCategories();

            return ExpenseCategories;
        }
    }
}