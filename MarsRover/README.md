## Version: 1.4, Last updated: 2021-02-02 ##

## TECH STACK: ##
Program was created with .Net 6.0 framework and IDE 2022 Professional.
Program was tested on Windows 10 x64 computer.

## LAUNCH PROGRAM: ##
To run program just execute command:

`MarsRover\MarsRover\bin\Release\net6.0>MarsRover.exe 2,1,west fffflbbbb`

or execute command: 

`MarsRover\MarsRover\bin\Release\net6.0>MarsRover.exe`

and then provide start coordinations and commands as one string.

## PROBLEM SOLUTION: ##

1. Architecture.
	* Program is build as monolit and consits of 3 project
	 ** MarsRover - console application, program entrypoint
	 ** MarsRover.Core - domain layer
	 ** MarsRover.Tests - unit and integration tests
	* There is no database and any other external depedencies required

2. Simplicity
	* As simplicity is a key value for you I haven't implemented any patterns I would to use like: 
		** Strategy, for moving or rotating Rover
		** Builder, to build test data with predefined values
		** Interpreter, to translate input commands onto Rover actions

3. Test Coverage
	* TDD techniques was applied
	* TestResultsReport.xml file contains report of all implemented tests