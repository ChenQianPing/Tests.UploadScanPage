using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.UploadScanPage.Dtos
{
    public class CreateUploadImageNameInput
    {
        public virtual string ExamCourseId { get; set; }
        public virtual string BatchId { get; set; }
        public List<ScanPages> ScanPages { get; set; }

    }

    public class ScanPages
    {
        public virtual string PageId { get; set; }
        public virtual string PaperId { get; set; }
        public virtual string ImageName { get; set; }

    }
}
