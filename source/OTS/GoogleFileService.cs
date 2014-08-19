using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Services;

namespace OTS
{
    public class GoogleFileService : IFileService
    {
        private DriveService _service;

        //used to update request header to indicate that session was authenticated
        private string _accessToken;

        private const string CLIENTID = "1057012666404-8lbnbd8cf45dr658c7bqa7jrufr66teo.apps.googleusercontent.com";
        private const string SECRET = "9Mkk3rCzOI2tYLsmmZqfzFec";
        private const string EXPORTFORMAT = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        private readonly string _localGoogleDrivePath;
        private readonly string _pendingFilePattern;
        private readonly string _excelInputFile;
        private readonly string _gsheetFilePattern;

        /// <summary>
        /// Constructs Google File Service
        /// </summary>
        /// <param name="localPath">Local path to Google Drive folder</param>
        /// <param name="pendingFilePattern">Pattern for detecting files to be processed</param>
        /// <param name="excelInputFile">Local path for saving the converted Google Spreadsheet</param>
        public GoogleFileService(string localPath, string pendingFilePattern, string excelInputFile)
        {
            _service = GetAuthenticatedDriveService();
            _pendingFilePattern = pendingFilePattern;
            _excelInputFile = excelInputFile;
            _localGoogleDrivePath = localPath;
            _gsheetFilePattern = string.Format("*{0}.gsheet", _pendingFilePattern);
        }

        /// <summary>
        /// Downloads Google file from Google Service
        /// </summary>
        /// <param name="fileId">Id of Google file to download</param>
        /// <param name="target">Destination where to save file</param>
        /// <param name="fileFormat">Format of file to convert from Google file</param>
        private void DownloadFile(string fileId, string target, string fileFormat)
        {
            using (var gDriveStream = GetGoogleDriveFileStream(fileId, fileFormat))
            {
                using (var fs = new FileStream(target, FileMode.Create, FileAccess.ReadWrite))
                {
                    gDriveStream.CopyTo(fs);
                }
            }
        }

        /// <summary>
        /// Main Google Drive Authentication
        /// </summary>
        /// <returns>Authenticated Google Drive Service</returns>
        private DriveService GetAuthenticatedDriveService()
        {
            UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = CLIENTID,
                    ClientSecret = SECRET,
                },
                new[] {DriveService.Scope.Drive, DriveService.Scope.DriveFile},
                "user",
                CancellationToken.None).Result;
            _accessToken = credential.Token.AccessToken;

            // Create the service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "fcereporting"
            });
            return service;
        }

        /// <summary>
        /// Return stream for file on GoogleDrive
        /// </summary>
        /// <param name="id">File id</param>
        /// <param name="exportFormat">Format to convert from Google file</param>
        /// <returns>Stream if successful, null otherwise.</returns>
        private Stream GetGoogleDriveFileStream(string id, string exportFormat)
        {
            var file = _service.Files.Get(id).Execute();
            var url = file.DownloadUrl;
            if (exportFormat != null)
                url = file.ExportLinks[exportFormat];
            if (!String.IsNullOrEmpty(url))
            {
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(
                    new Uri(url));
                _service.HttpClientInitializer.Initialize(_service.HttpClient);

                request.Headers.Add(HttpRequestHeader.Authorization, string.Format("Bearer {0}", _accessToken));
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return response.GetResponseStream();
                }
                else
                {
                    Console.WriteLine("An error occurred: " + response.StatusDescription);
                    return null;
                }
            }
            else
            {
                // The file doesn't have any content stored on Drive.
                return null;
            }
        }

        /// <summary>
        /// Checks if files ending with specified pattern exists
        /// </summary>
        /// <returns>
        /// </returns>
        /// <remarks>Throws exception if _localPath directory does not exist</remarks>
        public bool HasFileToProcess()
        {
            if (Directory.Exists(_localGoogleDrivePath))
            {
                FileInfo[] files =
                    new DirectoryInfo(_localGoogleDrivePath).GetFiles(_gsheetFilePattern);
                return files.ToList().Any();
            }
            throw new DirectoryNotFoundException(string.Format("Directory '{0}' does not exist", _localGoogleDrivePath));
        }

        private string GetIdFromLocalGoogleDrive(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string jsonString = sr.ReadToEnd();
                    var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<LocalGSheet>(jsonString);
                    return obj.resource_id.Split(new[] {":"}, StringSplitOptions.RemoveEmptyEntries)[1];
                }
            }
        }

        public void ProcessFile()
        {
            string fileName = Directory.GetFiles(_localGoogleDrivePath, _gsheetFilePattern).First();
            DownloadFile(GetIdFromLocalGoogleDrive(fileName), Path.Combine(_localGoogleDrivePath, _excelInputFile),EXPORTFORMAT);
        }
    }
}