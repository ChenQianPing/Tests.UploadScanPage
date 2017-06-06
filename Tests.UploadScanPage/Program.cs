using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.UploadScanPage
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
             * @param baseAddress 请示服务器地址
             * @param postUrl 请求Url
             * @param imagesPath 本地图片路径
             */
            var baseAddress = "http://192.168.2.100:9001";
            var postUrl1 = "/api/scn/UploadScanPage";
            var postUrl2 = "/api/scn/UploadScanPageWithoutImages";
            // var imagesPath = @"e:\10001004\";

            /* @brief 模拟请求数据，学生考号列表
             * @param PaperId 试卷Id
             * @param TestNo 考号 
             * @param RcgOmr OMR识别值
             */
            var s1 = new StudentTestNoInput
            {
                PaperId = Guid.NewGuid().ToString("N").ToUpper(),
                TestNo = "1610603",
                RcgOmr = "D,B,B,D,C,A,D,C,A,B,B,#"
            };

            var s2 = new StudentTestNoInput
            {
                PaperId = Guid.NewGuid().ToString("N").ToUpper(),
                TestNo = "1610619",
                RcgOmr = "#,B,B,D,C,A,D,D,A,C,B,B"
            };

            var s3 = new StudentTestNoInput
            {
                PaperId = Guid.NewGuid().ToString("N").ToUpper(),
                TestNo = "1610631",
                RcgOmr = "D,B,B,C,D,A,#,C,A,C,B,B"
            };

            var s4 = new StudentTestNoInput
            {
                PaperId = Guid.NewGuid().ToString("N").ToUpper(),
                TestNo = "1610627",
                RcgOmr = "#,A,A,C,C,A,#,D,A,C,B,C"
            };

            var s5 = new StudentTestNoInput
            {
                PaperId = Guid.NewGuid().ToString("N").ToUpper(),
                TestNo = "1610615",
                RcgOmr = "D,A,A,C,C,A,#,C,A,C,B,B"
            };

            var listStudent = new List<StudentTestNoInput> { s1, s2, s3, s4, s5 };

            /* @brief 试卷页面数据
             * @param PageId 页面Id
             * @param TestNo 考号
             * @param PageNo 页码
             * @param ScanNo 扫描序号，流水号
             * @param ImageName 图片文件名，带后缀，如1.jpg
             * @param ImageMd5 图片Md5值
             */
            var p1 = new ScanPageInput
            {
                PageId = Guid.NewGuid().ToString("N").ToUpper(),
                TestNo = "1610603",
                PageNo = 1,
                ScanNo = 1,
                ImageName = @"e:\10001004\1.jpg",
                // ImageName = "1.jpg",
                ImageMd5 = Md5CheckerHelper.GetMd5HashFromFile("e:\\10001004\\1.jpg")
            };

            var p2 = new ScanPageInput
            {
                PageId = Guid.NewGuid().ToString("N").ToUpper(),
                TestNo = "1610603",
                PageNo = 2,
                ScanNo = 2,
                ImageName = @"e:\10001004\2.jpg",
                // ImageName = "2.jpg",
                ImageMd5 = Md5CheckerHelper.GetMd5HashFromFile("e:\\10001004\\2.jpg")
            };

            var p3 = new ScanPageInput
            {
                PageId = Guid.NewGuid().ToString("N").ToUpper(),
                TestNo = "1610619",
                PageNo = 1,
                ScanNo = 3,
                ImageName = @"e:\10001004\3.jpg",
                // ImageName = "3.jpg",
                ImageMd5 = Md5CheckerHelper.GetMd5HashFromFile("e:\\10001004\\3.jpg")
            };

            var p4 = new ScanPageInput
            {
                PageId = Guid.NewGuid().ToString("N").ToUpper(),
                TestNo = "1610619",
                PageNo = 2,
                ScanNo = 4,
                ImageName = @"e:\10001004\4.jpg",
                // ImageName = "4.jpg",
                ImageMd5 = Md5CheckerHelper.GetMd5HashFromFile("e:\\10001004\\4.jpg")
            };

            var p5 = new ScanPageInput
            {
                PageId = Guid.NewGuid().ToString("N").ToUpper(),
                TestNo = "1610631",
                PageNo = 1,
                ScanNo = 5,
                ImageName = @"e:\10001004\5.jpg",
                // ImageName = "5.jpg",
                ImageMd5 = Md5CheckerHelper.GetMd5HashFromFile("e:\\10001004\\5.jpg")
            };

            var p6 = new ScanPageInput
            {
                PageId = Guid.NewGuid().ToString("N").ToUpper(),
                TestNo = "1610631",
                PageNo = 2,
                ScanNo = 6,
                ImageName = @"e:\10001004\6.jpg",
                // ImageName = "6.jpg",
                ImageMd5 = Md5CheckerHelper.GetMd5HashFromFile("e:\\10001004\\6.jpg")
            };

            var p7 = new ScanPageInput
            {
                PageId = Guid.NewGuid().ToString("N").ToUpper(),
                TestNo = "1610627",
                PageNo = 1,
                ScanNo = 7,
                ImageName = @"e:\10001004\7.jpg",
                // ImageName = "7.jpg",
                ImageMd5 = Md5CheckerHelper.GetMd5HashFromFile("e:\\10001004\\7.jpg")
            };

            var p8 = new ScanPageInput
            {
                PageId = Guid.NewGuid().ToString("N").ToUpper(),
                TestNo = "1610627",
                PageNo = 2,
                ScanNo = 8,
                ImageName = @"e:\10001004\8.jpg",
                // ImageName = "8.jpg",
                ImageMd5 = Md5CheckerHelper.GetMd5HashFromFile("e:\\10001004\\8.jpg")
            };

            var p9 = new ScanPageInput
            {
                PageId = Guid.NewGuid().ToString("N").ToUpper(),
                TestNo = "1610615",
                PageNo = 1,
                ScanNo = 9,
                ImageName = @"e:\10001004\9.jpg",
                // ImageName = "9.jpg",
                ImageMd5 = Md5CheckerHelper.GetMd5HashFromFile("e:\\10001004\\9.jpg")
            };

            var p10 = new ScanPageInput
            {
                PageId = Guid.NewGuid().ToString("N").ToUpper(),
                TestNo = "1610615",
                PageNo = 2,
                ScanNo = 10,
                ImageName = @"e:\10001004\10.jpg",
                // ImageName = "10.jpg",
                ImageMd5 = Md5CheckerHelper.GetMd5HashFromFile("e:\\10001004\\10.jpg")
            };


            var listPage = new List<ScanPageInput> { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };

            // 1.End.

            /*  
             * @param ExamCourseId 考试科目Id
             * @param BatchId 批次Id，Guid值，本地创建
             * @param MachineIp 上传机器Ip地址
             * @param ScanUserId 当前登录用户Id
             */

            var input = new CreateUploadScanPageInput
            {
                ExamCourseId = "3208075F3F8A4BD19032B41331A1C133",
                BatchId = Guid.NewGuid().ToString("N").ToUpper(),
                MachineIp = "192.168.2.100",
                ScanUserId = "C8F1E422F2C14E55B8F05756708CE994",

                StudentTestNos = listStudent,
                ScanPages = listPage
            };

            new UploadScanPageHelper().UploadScanPage(baseAddress, postUrl1, input);
            // new UploadScanPageHelper().UploadScanPageWithoutImages(baseAddress, postUrl2, input);

        }
    }
}
