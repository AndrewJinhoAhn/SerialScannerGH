# SerialScanner

A Grasshopper component that lists the serial (COM) devices connected to your PC,
with their human-readable names — so you can find the right port for any USB-serial hardware without opening Device Manager.

Part of the **AppendageTools** suite for Rhino Grasshopper.

<!-- ![SerialScanner in Grasshopper](docs/screenshot.png) -->

## Features
- Lists every connected serial device as **COM port + friendly name**
  (e.g. `COM4` → `USB-SERIAL CH340 (COM4)`).
- **Refresh** input to re-scan on demand — wire a button or toggle.
- Names are read straight from Windows WMI, matching Device Manager.

## Inputs / Outputs
| Name | Dir | Type | Description |
|------|-----|------|-------------|
| Refresh | in  | bool | Trigger a re-scan |
| Port    | out | list | COM identifiers, e.g. `COM3`, `COM4` |
| Name    | out | list | Full friendly device name for each port |

Find it under the **Appendage › Devices** tab.

## Requirements
- Rhino 8 (Windows)
- Windows only — device names come from WMI (`Win32_PnPEntity`)

## Installation
**Rhino Package Manager (recommended)**
1. In Rhino, run `_PackageManager`
2. Search for **serialscanner** and install

**Manual Installation**
1. Download `SerialScanner.gha` from the [latest release](../../releases/latest)
2. Right-click it → Properties → **Unblock** (if shown)
3. Copy it into `%APPDATA%\Grasshopper\Libraries`
4. Restart Rhino / Grasshopper

## License
MIT   <!-- 원하는 라이선스로 -->
