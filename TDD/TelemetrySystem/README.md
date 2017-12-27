## Table of contents
- [Telemetry System](#telemetry-system)
- [Resources](#resources)
- [References](#references)

# Telemetry System (C#)

Write the unit tests for the TelemetryDiagnosticControls class, refactor the code as much as you need to make the class testable.

The responsibility of the TelemetryDiagnosticControls class is to establish a connection to the telemetry server (through the TelemetryClient), send a diagnostic request and successfully receive the response that contains the diagnostic info. The TelemetryClient class provided for the exercise simulates the behavior of the real TelemetryClient class, and can respond with either the diagnostic information or a random sequence. The real TelemetryClient class would connect and communicate with the telemetry server via tcp/ip.

Good luck!

### Resources

[C# solution](https://github.com/MakingSense/coding-dojo/tree/master/TDD/TelemetrySystem/C%23%20solution)


###### Extracted from https://github.com/lucaminudel/TDDwithMockObjectsAndDesignPrinciples/tree/master/TDDMicroExercises
