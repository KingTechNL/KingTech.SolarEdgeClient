# SolarEdge client

## Enabling SolarEdge TCP Modbus
1. Enable wifi direct on the inverter by switching the red toggle switch on the inverter to the 'P' position for less then 2 seconds.
2. Connect to the wifi network using the wifi password on the sticker at the right side of the inverter.
3. Open a browser and go to http://172.16.0.1 > Site Communication. From this webpage you can enable the TCP modbus.

## SolarEdge documentation:

Cloud API:
https://knowledge-center.solaredge.com/sites/kc/files/se_monitoring_api.pdf

Modbus stuff:
https://knowledge-center.solaredge.com/sites/kc/files/storedge_monitoring_and_control_using_non_solarege_gateways.pdf

Modbus registers and stuff:
https://knowledge-center.solaredge.com/sites/kc/files/sunspec-implementation-technical-note.pdf

Modbus reader based on: https://github.com/MarcusWichelmann/SolarEdgeExporter

Captured message:
83,111,108,97,114,69,100,103,101,32,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,83,69,51,48,48,48,72,45,82,87,48,48,48,66,78,78,52,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,48,48,48,52,46,48,48,49,53,46,48,49,49,57,0,0,55,52,48,49,48,50,49,68