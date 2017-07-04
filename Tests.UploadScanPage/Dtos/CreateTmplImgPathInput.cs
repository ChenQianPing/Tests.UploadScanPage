using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.UploadScanPage.Dtos
{
    public class CreateTmplImgPathInput
    {
        public string ExamCourseId { get; set; }
        public int PageNo { get; set; }
        public string TmplPath { get; set; }
    }
}
