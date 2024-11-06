# PLC.Commissioning.Lib.Abstractions

**PLC.Commissioning.Lib.Abstractions** provides the interfaces for commissioning PLCs, ensuring a consistent structure across manufacturer-specific libraries. This repository defines general-purpose and manufacturer-specific interfaces.

> **Note**: This repository is a submodule of the main [PLC.Commissioning.Lib](https://github.com/vformi/PLC.Commissioning.Lib) project. It is intended to be used as part of the main project and not independently.

## Overview
This library defines the following key interfaces:

- **IPLCController**: General-purpose interface for core PLC functionality.
- **IPLCControllerSiemens**: Siemens-specific interface that extends IPLCController with additional methods.
- **IPLCControllerBeckhoff**: Beckhoff-specific interface that extends IPLCController with additional methods. --in progress 
- **IPLCControllerRockwell**: Rockwell-specific interface that extends IPLCController with additional methods. --in progress 