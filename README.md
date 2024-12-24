# StuAttendanceApp (Tap-In)

Tap-In is a Student Attendance mobile application designed for educators who need an efficient way to manage and track student attendance. Built with **.NET MAUI**, the application utilizes **RFID tags** for access, allowing students to tap their RFID-enabled cards to register their attendance efficiently.

## Table of Contents

- [Features](#features)
- [Screenshots](#screenshots)
- [Technologies Used](#technologies-used)
- [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Features

- **RFID Integration**: Allows students to tap their RFID-enabled cards to record attendance seamlessly.
- **Real-time Tracking**: Teachers can monitor attendance as students tap in.
- **User-friendly Interface**: Intuitive design for easy navigation by educators and students.
- **Cross-platform Support**: Built with .NET MAUI for native performance on Android and iOS devices.
- **Secure Data Handling**: Ensures that student data is handled securely and confidentially.

## Screenshots

<img src="StudentAttendanceApp/Documentation/TapInScreen1.jpg" alt="Screenshot 1" width="200"/>
<img src="StudentAttendanceApp/Documentation/TapInScreen2.jpg" alt="Screenshot 2" width="200"/>
<img src="StudentAttendanceApp/Documentation/TapInScreen3.jpg" alt="Screenshot 3" width="200"/>
<img src="StudentAttendanceApp/Documentation/TapInScreen4.jpg" alt="Screenshot 4" width="200"/>
<img src="StudentAttendanceApp/Documentation/TapInScreen5.jpg" alt="Screenshot 5" width="200"/>
<img src="StudentAttendanceApp/Documentation/TapInScreen6.jpg" alt="Screenshot 6" width="200"/>
<img src="StudentAttendanceApp/Documentation/TapInScreen7.jpg" alt="Screenshot 7" width="200"/>
<img src="StudentAttendanceApp/Documentation/TapInScreen8.jpg" alt="Screenshot 8" width="200"/>

## Technologies Used

- **.NET MAUI**: Cross-platform framework for building native mobile apps with .NET.
- **RFID Technology**: For hardware integration allowing RFID card reading.
- **C#**: Programming language used for application logic.
- **XAML**: Used for designing the user interface with rich layouts.

## Installation

To set up the StuAttendanceApp locally, follow these steps:

1. **Prerequisites**:

   - Install [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) or later.
   - Install [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) with the **.NET Multi-platform App UI development** workload.
   - For iOS development, you need a Mac with Xcode installed or configure [Hot Restart](https://docs.microsoft.com/en-us/dotnet/maui/ios/hot-restart).
   - Ensure you have the necessary emulators or devices for testing (Android Emulator, iOS Simulator, or physical devices).

2. **Clone the Repository**:

   ```bash
   git clone https://github.com/Michealdgreat/StuAttendanceApp.git
   cd StuAttendanceApp
   ```

3. **Open the Project**:

   - Open `StuAttendanceApp.sln` in Visual Studio 2022.

4. **Restore NuGet Packages**:

   - In Visual Studio, navigate to `Tools` > `NuGet Package Manager` > `Package Manager Console` and run:
     ```bash
     dotnet restore
     ```

5. **Configure RFID Integration**:

   - **Note**: RFID integration may require additional setup depending on the hardware you are using.
   - Install necessary SDKs or libraries provided by your RFID hardware manufacturer.
   - Ensure the RFID device is connected and accessible by the application.

6. **Build and Run the Application**:

   - Select your target device (Android Emulator, iOS Simulator, or physical device).
   - Run the application by clicking the `Start` button or pressing `F5`.

## Usage

- **Student Tap-In**:

  - Students tap their RFID-enabled cards on the designated reader.
  - The application registers the tap and records the student's attendance automatically.
  - Confirmation is displayed to confirm successful attendance registration.

- **Teacher Dashboard**:

  - Access attendance records in real-time.
  - View a list of students and their attendance status.
  - Generate attendance reports for classes or individual students.

## Contributing

Contributions are welcome! To contribute to this project:

1. **Fork the Repository**

2. **Create a Feature Branch**

   ```bash
   git checkout -b feature/YourFeature
   ```

3. **Commit Your Changes**

   ```bash
   git commit -m "Add your feature"
   ```

4. **Push to Your Branch**

   ```bash
   git push origin feature/YourFeature
   ```

5. **Create a Pull Request**

   - Go to the repository on GitHub and click on `Compare & pull request`.
   - Provide a clear description of your changes and submit the pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

For any questions or further information, please open an issue on the repository and I will be happy to help.
