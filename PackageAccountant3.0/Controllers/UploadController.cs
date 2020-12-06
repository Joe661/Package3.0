using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PackageAccountant3._0.Entities;
using PackageAccountant3._0.Helper;
using PackageAccountant3._0.Model;
using PackageAccountant3._0.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PackageAccountant3._0.Controllers
{
    [Route("api/upload")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IExcelBackupInofBll _upload;
        private readonly IMapper _mapper;
        private readonly IOfficeHelper _iofficeHelper;
        public UploadController(IExcelBackupInofBll upload, IMapper mapper, IOfficeHelper iofficeHelper)
        {
            _upload = upload ?? throw new ArgumentNullException(nameof(upload));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _iofficeHelper = iofficeHelper ?? throw new ArgumentNullException(nameof(iofficeHelper));
        }

        [HttpPost(Name = nameof(UploadFiles))]
        public async Task<IActionResult> UploadFiles([FromForm] IFormCollection formData)
        {
            string newFileName = ""; long fileSize = 0;
            IFormFileCollection files = formData.Files;//等价于Request.Form.Files

            long size = files.Sum(f => f.Length);
            //string webRootPath = _hostingEnvironment.WebRootPath;
            //string connectRootPath = _hostingEnvironment.ContentRootPath;
            foreach (var formFile in files)
            {
                var arry = formFile.FileName.Split('.');
                string fileExt = arry[arry.Length - 1]; //文件扩展名，不含“.”
                fileSize = formFile.Length; //获得文件大小，以字节为单位
                newFileName = System.Guid.NewGuid().ToString() + "." + fileExt; //随机生成新的文件名
                var filePath = AppSetting.excelPath + newFileName;
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
                //add the backup information

                _upload.Insert(new ExcelBackupInfor() { backupdate = DateTime.Now, size = fileSize.ToString(), backuppath = filePath });
                var data = _iofficeHelper.ReadExcelToDataTable(filePath);
                var userid = HttpContext.Session.GetString("username");
                //insert account iterm data
                //_iaccountItermDetailsBll.Insert(data, userid);
                //_iaccountTypeDetailsBll.Insert(data, userid);
                //_iincomeExpenseDetailsBll.Insert(data, userid, "");

            }

            return Ok(new
            {
                name = newFileName,
                count = fileSize
            });

        }
    }
}
