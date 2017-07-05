using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.UploadScanPage.Dtos;
using Tests.UploadScanPage.Helper;

namespace Tests.UploadScanPage
{
    public static class TestUploadHelper
    {
        public static void TestUpLoadTmplPages()
        {
            var baseAddress = "http://192.168.2.100:9001";
            var postUrl = "/api/tpl/CreateTmplImgPath";

            var tmplImg1 = new CreateTmplImgPathInput
            {
                ExamCourseId = "3208075F3F8A4BD19032B41331A1C133",
                PageNo = 1,
                TmplPath = @"e:\10001003\1.jpg"
            };

            var tmplImg2 = new CreateTmplImgPathInput
            {
                ExamCourseId = "3208075F3F8A4BD19032B41331A1C133",
                PageNo = 2,
                TmplPath = @"e:\10001003\2.jpg"
            };


            var listTmplImg = new List<CreateTmplImgPathInput> { tmplImg1, tmplImg2 };


            new UploadHelper().UpLoadTmplPages(baseAddress, postUrl, listTmplImg);
        }

        public static void TestUploadScanPage()
        {
            /* 
             * @param baseAddress 请示服务器地址
             * @param postUrl 请求Url
             * @param imagesPath 本地图片路径
             */
            // var baseAddress = "http://192.168.2.100:9001";
            var baseAddress = "http://localhost:7427";
            var postUrl3 = "/api/scn/ReUploadScanPage";
            // var imagesPath = @"e:\10001004\";

            /* @brief 模拟请求数据，学生考号列表
             * @param PaperId 试卷Id
             * @param TestNo 考号，考虑到先上传后识别的情况，可以为空；
             * @param RcgOmr OMR识别值，考虑到先上传后识别的情况，可以为空；
             */
            /*
            var s1 = new StudentTestNoInput
            {
                PaperId = Guid.NewGuid().ToString("N").ToUpper(),
                TestNo = "1610603",
                RcgOmr = "D,B,B,D,C,A,D,C,A,B,B,#",
                RcgStatus = 0,
                IsCheat = 0,
                IsMiss = 0
            };

            var s2 = new StudentTestNoInput
            {
                PaperId = Guid.NewGuid().ToString("N").ToUpper(),
                TestNo = "1610619",
                RcgOmr = "#,B,B,D,C,A,D,D,A,C,B,B",
                RcgStatus = 0,
                IsCheat = 0,
                IsMiss = 0
            };

            var s3 = new StudentTestNoInput
            {
                PaperId = Guid.NewGuid().ToString("N").ToUpper(),
                TestNo = "1610631",
                RcgOmr = "D,B,B,C,D,A,#,C,A,C,B,B",
                RcgStatus = 0,
                IsCheat = 0,
                IsMiss = 0
            };

            var s4 = new StudentTestNoInput
            {
                PaperId = Guid.NewGuid().ToString("N").ToUpper(),
                TestNo = "1610627",
                RcgOmr = "#,A,A,C,C,A,#,D,A,C,B,C",
                RcgStatus = 0,
                IsCheat = 0,
                IsMiss = 0
            };

            var s5 = new StudentTestNoInput
            {
                PaperId = Guid.NewGuid().ToString("N").ToUpper(),
                TestNo = "1610615",
                RcgOmr = "D,A,A,C,C,A,#,C,A,C,B,B",
                RcgStatus = 0,
                IsCheat = 0,
                IsMiss = 0
            };

            var listStudent = new List<StudentTestNoInput> { s1, s2, s3, s4, s5 };
            */

            var listStudent = new List<StudentTestNoInput>();

            /* @brief 试卷页面数据
             * @param PaperId 新增一列传PaperId，代替考号，这样子的考号可以为空；
             * @param PageId 页面Id
             * @param TestNo 考号，可以为空，传"";
             * @param PageNo 页码
             * @param ScanNo 扫描序号，流水号
             * @param ImageName 图片文件名，带后缀，如1.jpg
             * @param ImageMd5 图片Md5值
             */

            var imagesPath = @"e:\\10001004\\";

            var lstImageNames = @"1,2,3,4,5,6,7,8,9,10";

            var lstImages = lstImageNames.Split(Convert.ToChar(",")).ToList();

            var lstPage = new List<ScanPageInput>();

            foreach (var image in lstImages)
            {
                var p = new ScanPageInput
                {
                    PaperId = Guid.NewGuid().ToString("N").ToUpper(),
                    PageId = Guid.NewGuid().ToString("N").ToUpper(),
                    ImageName = imagesPath + image + ".jpg",
                    ImageMd5 = Md5CheckerHelper.GetMd5HashFromFile(imagesPath + image + ".jpg")
                };

                lstPage.Add(p);
            }

            var input = new CreateUploadScanPageInput
            {
                ExamCourseId = Guid.NewGuid().ToString("N").ToUpper(),
                BatchId = Guid.NewGuid().ToString("N").ToUpper(),
                StudentTestNos = listStudent,
                ScanPages = lstPage
            };

            new UploadHelper().UploadScanPage(baseAddress, postUrl3, input);

        }
    }
}
