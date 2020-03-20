﻿using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using IssWebRazorApp.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IssWebRazorApp.Models
{
    public class PlaybookRepository : IPlaybookRepository
    {
        private readonly IssWebRazorApp.Data.IssWebRazorAppContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly AmazonWebServiceConfig _awsconfig;

        public PlaybookRepository(IssWebRazorApp.Data.IssWebRazorAppContext context, IWebHostEnvironment env ,IOptions<AmazonWebServiceConfig> awsconfig) 
        {
            _context = context;
            _environment = env;
            _awsconfig = awsconfig.Value;

            s3Directory = _awsconfig.S3Directory;
            bucketName = _awsconfig.S3BucketName;
            accesskey = _awsconfig.S3AccessKey;
            secretkey = _awsconfig.S3SecretKey;
        }
        public async void Add(Playbook playbook,string bucketPath) 
        {
            var data = playbook.ToData();

            try
            {
                if (playbook.PlayDesign.File.Length > 0)
                {
                    UploadFileToS3Bucket(playbook.PlayDesign, bucketPath);
                    data.PlayDesignUrl = s3Directory + bucketPath + "/" + playbook.PlayDesign.FileName;
                }
                _context.PlaybookData.Add(data);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private const string keyName = "";
        private const string filePath = null;
        private readonly string s3Directory;
        private readonly string bucketName;
        private static readonly RegionEndpoint bucketRegin = RegionEndpoint.APNortheast1;
        private readonly string accesskey;
        private readonly string secretkey;

        private void UploadFileToS3Bucket(PlayDesign playDesign,string buckectPath) 
        {
            var file = playDesign.File;
            var s3Cliant = new AmazonS3Client(accesskey,secretkey,bucketRegin);
            var fileTransferUtility = new TransferUtility(s3Cliant);
            try
            {
                if (file.Length > 0)
                {
                    var filePath = Path.Combine(_environment.ContentRootPath, "Upload", playDesign.FileName);
                    using (var fileStream = new FileStream(filePath,FileMode.Create)) 
                    {
                        file.CopyTo(fileStream);
                    }

                    var fileTransferUtilityRequest = new TransferUtilityUploadRequest
                    {
                        BucketName = bucketName +"/" + buckectPath,
                        FilePath = filePath,
                        StorageClass = S3StorageClass.Standard,
                        PartSize = 6291456,// 6 MB
                        CannedACL = S3CannedACL.PublicRead
                    };
                    fileTransferUtilityRequest.Metadata.Add("param1", "Value1");
                    fileTransferUtilityRequest.Metadata.Add("param2", "Value2");
                    fileTransferUtility.Upload(fileTransferUtilityRequest);
                    fileTransferUtility.Dispose();
                }
                Console.WriteLine("File Uploaded Successfully!!");
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                Console.WriteLine(amazonS3Exception);
            }
        }
    }
}
