using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Tests.UploadScanPage.Dtos;

namespace Tests.UploadScanPage.Helper
{
    public class UploadHelper
    {
        #region UploadScanPageWithoutImages
        public void UploadScanPageWithoutImages(string baseAddress, string postUrl, 
            CreateUploadScanPageInput inputs)
        {
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(inputs), System.Text.Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                var result = client.PostAsync(postUrl, httpContent).Result;

                var str = result.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result.StatusCode);
                Console.WriteLine(str);
                Console.ReadLine();

            }
        }
        #endregion

        #region UploadScanPage
        public void UploadScanPage(string baseAddress, string postUrl, CreateUploadScanPageInput inputs)
        {

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));

                using (var content = new MultipartFormDataContent())
                {
                    // Make sure to change API address  
                    client.BaseAddress = new Uri(baseAddress);

                    var count = 1;

                    foreach (var input in inputs.ScanPages)
                    {
                        var imageName = input.ImageName;

                        // Add file content   
                        // var filePath = imagesPath + imageName;
                        var filePath = imageName;
                        var fileContent = new ByteArrayContent(File.ReadAllBytes(@filePath));
                        fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                        {
                            // 注意，这里修改一下，只获取文件名；
                            FileName = System.IO.Path.GetFileName(imageName),   // 文件名
                            FileNameStar = inputs.ExamCourseId,                 // 考试科目Id
                            Name = input.PaperId
                            /*
                             * 注意：
                             * 注释掉这一句，Name = input.TestNo 
                             * 新加 Name = input.PaperId，改成PaperId
                                                            
                            */

                        };
                        content.Add(fileContent);

                        Console.WriteLine((count++) + "/" + inputs.ScanPages.Count);
                    }

                    var d = new NameValueCollection { { "inputs", JsonConvert.SerializeObject(inputs) } };
                    var fromData = GetFormDataByteArrayContent(d);
                    foreach (var item in fromData)
                    {
                        content.Add(item);
                    }

                    // Make a call to Web API  
                    var result = client.PostAsync(postUrl, content).Result;

                    var str = result.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(result.StatusCode);
                    Console.WriteLine(str);
                    Console.ReadLine();
                }
            }
        }
        #endregion

        #region UpLoadTmplPages
        public string UpLoadTmplPages(string baseAddress, string postUrl, List<CreateTmplImgPathInput> inputs)
        {

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));

                using (var content = new MultipartFormDataContent())
                {
                    // Make sure to change API address  
                    client.BaseAddress = new Uri(baseAddress);
                    var count = 1;

                    foreach (var input in inputs)
                    {
                        var imageName = input.TmplPath;

                        // Add file content   
                        var filePath = imageName;
                        var fileContent = new ByteArrayContent(File.ReadAllBytes(@filePath));
                        fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                        {
                            FileName = imageName
                        };
                        content.Add(fileContent);

                        Console.WriteLine((count++) + "/" + inputs.Count);
                    }

                    var d = new NameValueCollection { { "inputs", JsonConvert.SerializeObject(inputs) } };
                    var fromData = GetFormDataByteArrayContent(d);
                    foreach (var item in fromData)
                    {
                        content.Add(item);
                    }

                    // Make a call to Web API  
                    return client.PostAsync(postUrl, content).Result.Content.ReadAsStringAsync().Result; ;

                }
            }
        }
        #endregion

        #region GetFormDataByteArrayContent
        /// <summary>
        /// 获取键值集合对应的ByteArrayContent集合
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        private List<ByteArrayContent> GetFormDataByteArrayContent(NameValueCollection collection)
        {
            var list = new List<ByteArrayContent>();
            foreach (var key in collection.AllKeys)
            {
                var dataContent = new ByteArrayContent(Encoding.UTF8.GetBytes(collection[key]));
                dataContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    Name = key
                };
                list.Add(dataContent);
            }
            return list;
        }
        #endregion
    }
}
