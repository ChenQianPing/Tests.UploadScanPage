using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.UploadScanPage
{
    public class CreateUploadScanPageInput
    {
        /// <summary>
        /// 考试科目Id
        /// </summary>
        public virtual string ExamCourseId { get; set; }

        /// <summary>
        /// 批次Id,Guid，扫描端自动生成
        /// </summary>
        public virtual string BatchId { get; set; }

        /// <summary>
        /// 扫端端机器Ip
        /// </summary>
        public virtual string MachineIp { get; set; }

        /// <summary>
        /// 扫描用户Id
        /// </summary>
        public virtual string ScanUserId { get; set; }

        /// <summary>
        /// 学生考号列表
        /// </summary>
        public List<StudentTestNoInput> StudentTestNos { get; set; }

        /// <summary>
        /// 扫描页面列表
        /// </summary>
        public List<ScanPageInput> ScanPages { get; set; }

    }

    public class StudentTestNoInput
    {
        /// <summary>
        /// 试卷Id
        /// </summary>
        public virtual string PaperId { get; set; }

        /// <summary>
        /// 学生考号，扫描端识别，可以为空；
        /// </summary>
        public virtual string TestNo { get; set; }

        /// <summary>
        /// OMR识别值，扫描端识别
        /// </summary>
        public virtual string RcgOmr { get; set; }
    }

    public class ScanPageInput
    {


        /// <summary>
        /// 页面Id，Guid，扫描端生成
        /// </summary>
        public virtual string PageId { get; set; }

        /* 新增 PaperId*/
        public virtual string PaperId { get; set; }

        /// <summary>
        /// 学生考号
        /// </summary>
        public virtual string TestNo { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        public virtual int PageNo { get; set; }

        /// <summary>
        /// 扫描序号
        /// </summary>
        public virtual int ScanNo { get; set; }

        /// <summary>
        /// 文件名
        /// </summary>
        public virtual string ImageName { get; set; }

        /// <summary>
        /// 文件Md5
        /// </summary>
        public virtual string ImageMd5 { get; set; }


    }
}
