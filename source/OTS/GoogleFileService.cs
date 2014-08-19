using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Services;

public interface IFileService
{
    bool HasFileToProcess();
    void ProcessFile();
}

public class GoogleFileService : IFileService
{
    private DriveService _service;
    private string _accessToken;
    private const string CLIENTID = "1057012666404-8lbnbd8cf45dr658c7bqa7jrufr66teo.apps.googleusercontent.com";
    private const string SECRET = "9Mkk3rCzOI2tYLsmmZqfzFec";
    private const string GDRIVEROOT = "root";
    private readonly string _localPath;
    private readonly string _pendingFilePattern;

    private string _inputSheetId;
    public string InputSheetId { get { return _inputSheetId; } }

    public GoogleFileService(string localPath, string pendingFilePattern)
    {
        _service = GetAuthenticatedDriveService();
        _pendingFilePattern = pendingFilePattern;
        _localPath = localPath;
    }

    public void DownloadFile(string fileId, string target, string fileFormat)
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
            new[] { DriveService.Scope.Drive, DriveService.Scope.DriveFile },
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
    /// Download a file and return a stream
    /// </summary>
    /// <param name="authenticator">
    /// Authenticator responsible for creating authorized web requests.
    /// </param>
    /// <param name="file">Drive File instance.</param>
    /// <returns>Stream if successful, null otherwise.</returns>
    public Stream GetGoogleDriveFileStream(string id, string exportFormat)
    {
        var file = _service.Files.Get(id).Execute();
        var url = file.DownloadUrl;
        if (exportFormat != null)
            url = file.ExportLinks[exportFormat];
        if (!String.IsNullOrEmpty(url))
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
                new Uri(url));
            _service.HttpClientInitializer.Initialize(_service.HttpClient);

            request.Headers.Add(HttpRequestHeader.Authorization, string.Format("Bearer {0}", _accessToken));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
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

    public bool HasFileToProcess()
    {
        FileInfo[] files = new DirectoryInfo(_localPath).GetFiles(string.Format("*{0}.gsheet", _pendingFilePattern));
        return files.ToList().Any();
    }

    public void UploadFile(string filePath)
    {
        using (var fs = new FileStream("input_final.xlsx", FileMode.Open, FileAccess.Read))
        {
            fs.Seek(0, SeekOrigin.Begin);

            var gfile = new Google.Apis.Drive.v2.Data.File()
            {
                Title = "input_final",
                MimeType = "application/vnd.oasis.opendocument.spreadsheet"
            };
            var request = _service.Files.Insert(gfile, fs, "application/vnd.oasis.opendocument.spreadsheet");
            request.Convert = true;
            var progress = request.Upload();
        }
    }

    public void DeleteFile(string fileId)
    {
        _service.Files.Delete(fileId).Execute();
    }

    public void ProcessFile()
    {
        DownloadFile(InputSheetId, Path.Combine(_localPath, "input.xlsx"), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
    }
}