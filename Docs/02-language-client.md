![Text Analytics](Images/TextAnalytics.png)

# Using the Client Library's LanguageClient class

In order to use the client library's `LanguageClient` class, you must obtain a Text API subscription key by following these [instructions](/01-getting-started.md).

1. Start Microsoft Visual Studio 2015 and select `File > New > Project`.

2. Create a new `C# Console Application`.

    ![New Project](Images/02-language-client/01-new-project.png)

3. Open the `Package Manager Console` and install the [Text API Package](https://www.nuget.org/packages/Microsoft.ProjectOxford.Text/) from NuGet.

    `PM> Install-Package Microsoft.ProjectOxford.Text`

4. Open the `Program.cs` file, and add the following `using` statements to the top of the file.

  ```cs
  using Microsoft.ProjectOxford.Text.Core;
  using Microsoft.ProjectOxford.Text.Language;
  ```

5. Add the following code to the `Main` method, replacing the default value with you Text Analytics API subscription key.

  ```cs
  var apiKey = "YOUR-TEXT-ANALYTICS-API-SUBSCRIPTION-KEY";
  ```

6. Below the code you just added, create a new `Document` object that contains a unique and the text you want to use for language identification.

  ```cs
  var document = new Document()
  {
    Id = "YOUR-UNIQUE-ID",
    Text = "YOUR-TEXT"
  };
  ```

7. After the `Document` is created, create a new `LanguageRequest` object and add the `Document` to it.

  ```cs
  var request = new LanguageRequest();
  request.Documents.Add(document);
  ```

8. Once the request is created, create a new `LanguageClient` object, using the Text Analytics API subscription key specified above.

  ```cs
  var client = new LanguageClient(apiKey);
  ```

9. Call the `LanguageClient`s `GetLanguages` method using the `LanguageRequest` object created earlier.

  ```cs
  var response = client.GetLanguages(request);
  ```

  _Alternatively you can declare the `Main` method as `async` and call the `GetLanguagesAsync` method with the following code._

  ```cs
  var response = await client.GetLanguagesAsync(request);
  ```

10. Process the `Response` object to display the results.

  ```cs
  foreach(var doc in response.Documents)
  {
      Console.WriteLine("Document Id: {0}", doc.Id);

      foreach(var lang in doc.DetectedLanguages)
      {
          Console.WriteLine("--Language: {0}({1})", lang.Name, lang.Iso639Name);
          Console.WriteLine("--Confidence: {0}%", (lang.Score * 100));
      }
  }
  ```

11. You should see something similar to the following.

  ![Output](Images/02-language-client/02-output.png)

## Complete Code Listings
- [`LanguageClient` (sync)](CodeListings/02-language-client-sync.md)
- [`LanguageClient` (async)](CodeListings/02-language-client-async.md)

## Developer Code of Conduct
Developers using Cognitive Services, including this client library & sample, are required to follow the “[Developer Code of Conduct for Microsoft Cognitive Services](http://go.microsoft.com/fwlink/?LinkId=698895)”.
