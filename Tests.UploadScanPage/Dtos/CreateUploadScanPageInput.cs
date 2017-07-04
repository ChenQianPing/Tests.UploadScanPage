using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.UploadScanPage.Dtos
{
    public class CreateUploadScanPageInput
    {
        public virtual string ExamCourseId { get; set; }
        public virtual string BatchId { get; set; }
        public virtual string MachineIp { get; set; }
        public virtual string ScanUserId { get; set; }

        public List<StudentTestNoInput> StudentTestNos { get; set; }
        public List<ScanPageInput> ScanPages { get; set; }

    }

    public class StudentTestNoInput
    {
        public virtual string PaperId { get; set; }
        public virtual string TestNo { get; set; }  /* 考虑到可以先扫描后识别，该字段可以为空；*/
        public virtual string RcgOmr { get; set; }
        public virtual int RcgStatus { get; set; }
        public virtual int IsCheat { get; set; }
        public virtual int IsMiss { get; set; }
    }

    public class ScanPageInput
    {
        public virtual string PageId { get; set; }
        public virtual string PaperId { get; set; } /* 试卷Id，该字段不能为空； */
        public virtual string TestNo { get; set; }  /* 考虑到可以先扫描后识别，该字段可以为空；*/
        public virtual int PageNo { get; set; }
        public virtual int ScanNo { get; set; }
        public virtual string ImageName { get; set; }
        public virtual string ImageMd5 { get; set; }
        public virtual int OffsetX { get; set; }
        public virtual int OffsetY { get; set; }
        public virtual decimal K { get; set; }


    }
}
