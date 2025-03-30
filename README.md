# Text Filtering Application

This project is designed to filter text based on custom-defined strategies. It provides a modular and feature-based architecture, emphasising clarity, testability, and maintainability.

## Features

### Text Filtering
- The **TextFilterProcessor** processes text and applies a series of filtering strategies to remove unwanted words or phrases.
- Strategies can be easily added or modified to meet different use cases.
- The **TextFilterOrchestrator** is invoked directly by the `Program` class to coordinate the execution of text filtering logic based on strategies selected.

## Utilities

### File Reading
- The **FileReader** module reads input text files.
- Supports error handling and logging to ensure robust file reading capabilities.

---

## How to Use

### Prerequisites
- .NET 8 or higher.
- Visual Studio 2022 or any compatible IDE.

### Running the Project
1. Clone the repository:
   ```bash
   git clone https://github.com/LoisM94/TextFilter.git

2. Open the solution in Visual Studio.

3. **Optional** Add/Edit your txt file to the Resources folder.

4. **Optional** Define the FilePath in the appsettings.json file:
   ```
   {
      "FilePath": "./Resources/example_text.txt"
   }
5. Build and run the solution.

## Testing

Unit/Component tests are provided for core components:

1. Navigate to the test project directory.

2. Run the tests using the .NET CLI:
   `dotnet test`

## Configuration

The following components can be customised:

#### Filter Strategies
- Add or remove existing strategies in the **TextFilterOrchestrator** to tailor the filtering behaviour.
-  Add new strategies in Strategies folder to further extended the filtering behaviour.

#### Logging
- Modify logging settings in the appsettings.json file to adjust verbosity.

#### File
- Update the FilePath in the appsettings.json to specify which file to process.

- Provide a new text file or update exisiting one within the Resources folder.
