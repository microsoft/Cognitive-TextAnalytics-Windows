![Text Analytics](Docs/Images/TextAnalytics.png)

# Text Analytics API: Windows Client Library & Sample

| Branch      | Build Status  | Package Source |
| ----------- | ------------- | -------------- |
| develop     |  [![Build Status](http://oxfordci.westus.cloudapp.azure.com:8080/buildStatus/icon?job=cognitive-textanalytics-windows-develop)](http://oxfordci.westus.cloudapp.azure.com:8080/job/cognitive-textanalytics-windows-develop/)             | [![Source](https://img.shields.io/badge/source-nuget-blue.svg?style=flat)](http://www.nuget.org/packages/Microsoft.ProjectOxford.Text/)
| master      |   [![Build Status](http://oxfordci.westus.cloudapp.azure.com:8080/buildStatus/icon?job=cognitive-textanalytics-windows-master)](http://oxfordci.westus.cloudapp.azure.com:8080/job/cognitive-textanalytics-windows-master/)            | [![Source](https://img.shields.io/badge/source-nuget-blue.svg?style=flat)](http://www.nuget.org/packages/Microsoft.ProjectOxford.Text/)

## Overview
Text Analytics API is a suite of text analytics services built with Azure Machine Learning and offers APIs for sentiment analysis, key phrase extraction and topic detection for English text, as well as language detection for 120 languages.

The solution contains the SDK and a sample application that allows you to enter your API key and text to perform the following actions:
- Language identification
- Sentiment analysis
- Key phrase detection
- Topic detection

## The Client Library
The client library is a thin C\# client wrapper for Microsoft Text Analytics API. The easiest way to use this client library is to get microsoft.projectoxford.text package from [nuget](http://nuget.org).

Please go to the [Text API Package in Nuget](https://www.nuget.org/packages/Microsoft.ProjectOxford.Text/) for more details.

For details on how to use the Client Library, refer to the following articles:
- [LanguageClient](Docs/language-client.md)
- [SentimentClient](Docs/sentiment-client.md)
- [KeyPhraseClient](Docs/keyphrase-client.md)
- [TopicClient](Docs/topic-client.md)

## The WPF Sample
This sample is a Windows WPF application to demonstrate the use of Text Analytics API. It demonstrates the following:
- Language identification
- Sentiment analysis
- Key phrase detection
- Topic detection

### Build the WPF Sample
1. Starting in the folder where you clone the repository (this folder)
2. In a git command line tool, type `git submodule init` (or do this through a UI)
3. Pull in the shared Windows code by calling `git submodule update`
4. Start Microsoft Visual Studio 2015 and select `File > Open > Project/Solution`.
5. Go to `Sample-WPF Folder`.
6. Double-click the Visual Studio 2015 Solution (.sln) file TextAPI-WPF-Samples.
7. Press Ctrl+Shift+B, or select `Build > Build Solution`.

### Run the WPF Sample
After the build is complete, press F5 to run the sample.

First, you must obtain a Text API subscription key by following these [instructions](Docs/getting-started.md).

Locate the text edit box saying "Paste your subscription key here to start" on the top right corner. Paste your subscription key. You can choose to persist your subscription key in your machine by clicking "Save Key" button. When you want to delete the subscription key from the machine, click "Delete Key" to remove it from your machine.

Click on "Select Scenario" to use samples of different scenarios, and follow the instructions on screen.

![Sample Screenshot](Docs/Images/sample-screenshot.PNG)

## Contributing
Contributions are welcome. Feel free to file issues and pull requests on the repo and we'll address them as we can. Learn more about how you can help on our [Contribution Rules & Guidelines](/CONTRIBUTING.md).

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

## License
All Microsoft Cognitive Services SDKs and samples are licensed with the MIT License. For more details, see [LICENSE](/LICENSE.md).

## Developer Code of Conduct
Developers using this project are expected to follow the “Developer Code of Conduct for Microsoft Cognitive Services” at [http://go.microsoft.com/fwlink/?LinkId=698895](http://go.microsoft.com/fwlink/?LinkId=698895).

## Disclaimer
The image, voice, video or text understanding capabilities of Microsoft.ProjectOxford.TextAnaltyics.Windows use Microsoft Cognitive Services. Microsoft will receive the images, audio, video, and other data that you upload (via this app) for service improvement purposes.

## Report Abuse
To report abuse of the Microsoft Cognitive Services to Microsoft, please visit the Microsoft Cognitive Services website at [https://www.microsoft.com/cognitive-services](https://www.microsoft.com/cognitive-services), and use the "Report Abuse" link at the bottom of the page to contact Microsoft.

## Privacy Policy
For more information about Microsoft privacy policies please see their privacy statement here: [https://go.microsoft.com/fwlink/?LinkId=521839](https://go.microsoft.com/fwlink/?LinkId=521839).
