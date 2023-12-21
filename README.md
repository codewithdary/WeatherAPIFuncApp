## WeatherAPIFuncApp Documentation

The WeatherAPIFuncApp is an Azure Function that consists of the following 5 functions:

- DownloadImage - This function is responsible for downloading an image from a given source.
- DownloadImageSAS - The DownloadImageSAS function provides a secure way to download an image using a Shared Access Signature (SAS).
- FetchWeatherData - The FetchWeatherData function retrieves weather data from a specified source.
- GetStatus - The GetStatus function returns the status of the WeatherAPIFuncApp.
- ImageProcessor - The ImageProcessor function processes the downloaded image and performs any necessary image manipulation or analysis (behind the scenes).

In case you want to run the application on localhost, you have to create a `local.settings.json` file in the root of your project.

It contains the necessary configuration settings for the application. These settings include the connection string for Azure storage, the URLs for the image and weather APIs, the container name for storing weather images, and the authentication credentials. 

```c
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "DefaultEndpointsProtocol=https;AccountName=weatherapifuncapp;AccountKey=HfHvYmw4eMqG5L/g6tG0FfBxV6q5cIKMTWzIF43LWU2967c+M/a7P4HEBuOrKDnJqs/MSFRRHHUI+AStUFax4Q==;EndpointSuffix=core.windows.net",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "ImageAPIURL": "https://api.unsplash.com/photos/random/?client_id=-yTWZv8HAim5OKsD9zuKCTXxtxaeqBtRY3aDYC_Ch3M",
    "WeatherAPIURL": "https://data.buienradar.nl/2.0/feed/json",
    "ContainerName": "weatherimages",
	  "BlobBaseUrl": "https://weatherapifuncapp.blob.core.windows.net",
    "APIUsername": "TestUser",
    "APIPassword": "testpwd"
  }
}
```

### Authentication

All functions have authentication enabled, and I have added a username and password in the application settings of the function app. The configuration settings are named `APIPassword` and `APIUsername`. All functions will retrieve these credentials from the configuration and include them as a `?code=` parameter in all URLs.

### FetchWeatherData

The `FetchWeatherData` method is responsible for generating a list of `guid` (globally unique identifiers) of the images from Unsplash. These `guid` values can later be used to download images with text on them. Please perform a `GET` or `POST` request in Postman.

```java
https://weatherapifuncapp.azurewebsites.net/api/FetchWeatherData?code=5DDCp0yU0tdl-N73b3bKFy4CDlkYK2Hz6OHbv0aZemU4AzFuXX30Ew==
```

### DownloadImage

The `DownloadImage` function is used to download an image based on a `guid` generated in the `FetchWeatherData` function. 

This function requires two parameters. The `code` parameter is set by Azure for authentication, while the second parameter, named `file`, is the image `guid` generated with the `.jpg` file extension attached to it. Here's an example:

```php
https://weatherapifuncapp.azurewebsites.net/api/DownloadImage?code=1jxVLE4T-ih3ncMg-y-oFFnAAIrNER6Wtj5pCgik0-v4AzFufvxyUA==&file=bb784b93-ae36-4592-9fe9-3fe3dfa47015
```

### GetStatus

The `GetStatus` function is used to retrieve the status of the image. It requires one parameter, which is the `rowKey` parameter. This parameter should be the `GUID generated from the steps above.`

```php
https://weatherapifuncapp.azurewebsites.net/api/GetStatus?code=ELvm1R4XJN165Sh6NCp0dZtQ1NH5EWwPzpZK05dWS71NAzFuAVBgHw==&rowKey=bb784b93-ae36-4592-9fe9-3fe3dfa47015
```

This should return the following message:

```php
Status for RowKey bb784b93-ae36-4592-9fe9-3fe3dfa47015: Complete
```