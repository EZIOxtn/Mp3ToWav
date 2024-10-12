# Mp3ToWav Converter

Mp3ToWav is a simple, user-friendly application designed for Windows PCs that allows users to convert MP3 files to WAV format. Built using VB.NET, the app provides an easy-to-navigate graphical user interface (GUI) for smooth and efficient audio conversion.

## Features

- **Simple and Intuitive GUI**: The app is designed with a clean and straightforward interface, making it easy for users to load MP3 files and convert them to WAV format with just a few clicks.
- **Fast Conversion**: Leverages efficient algorithms to ensure quick conversion without compromising audio quality.
- **Batch Conversion**: Allows users to select multiple MP3 files and convert them all at once.
- **Error Handling**: Displays error messages if a file is not supported or the conversion fails.
- **Progress Indicator**: Visual progress bar to track conversion status in real-time.

## Installation

### Prerequisites
- Windows 10 or higher
- .NET Framework 4.7.2 or higher
- VB.NET-compatible IDE (Visual Studio)

## Setup and Run

1. **Open the Solution**:
   - Navigate to the `Mp3ToWav` directory.
   - Open the solution in Visual Studio.

2. **Build the Application**:
   - In Visual Studio, build the solution to generate the executable file.

3. **Run the Application**:
   - Once built, launch the executable to open the Mp3ToWav converter.

## How It Works

1. **Load MP3 Files**:
   - Users can select one or multiple MP3 files from their system using the 'Load' button.

2. **Convert to WAV**:
   - After loading the files, click the 'Convert' button to start the conversion process.
   - The app will display a progress bar to show the status of each conversion.

3. **Save Output**:
   - The converted WAV files will be saved in the specified directory chosen by the user.

## Technologies Used

- **VB.NET**: The core programming language used to develop the application.
- **.NET Framework**: Provides the base for running the application on Windows.
- **Windows Forms**: Used for creating the user interface.
- **NAudio Library**: A powerful audio library to handle MP3 to WAV conversion.

## Future Enhancements

- **Additional Formats**: Support for more audio formats like FLAC, OGG, etc.
- **Audio Editing Features**: Basic editing options like trimming, volume adjustments, etc.
- **Custom Output Settings**: Allow users to configure WAV file settings (bitrate, sample rate, etc.).
