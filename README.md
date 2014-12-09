PowerToEnergy
=============

The aim of this exercise is to provide a small program that will convert power readings, in Watts, to energy values, in KWh.

* The program can be based on a console app, windows forms or (preferred) provide a web interface for the user;

* The user must be able to insert several random numeric values, simulating different power readings from a plug;

* The program must process the provided power values, and their times, and convert them into a 15 minutes kWh readings.

* The output can be on the screen or (preferred) on a database (access for example) or a file, with the following structure:

    * Start Date time (Unix time stamp format)
    * End Date time (Unix time stamp format)
    * Value (kWh)

2.3. Example input

  * 22/08/2010 15:29:15 230
  * 22/08/2010 15:30:38 200
  * 22/08/2010 15:33:50 90
  * 22/08/2010 15:36:08 0
  * 22/08/2010 15:39:12 0
  * 22/08/2010 15:42:15 100
  * 22/08/2010 15:48:12 180

2.4. Example output

  * 1282491000 1282491900 0,185
  * 1282491900 1282492800 0,172
