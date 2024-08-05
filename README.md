# Robotic Control System

## Overview

This project aims to enhance the functionality of a robotic control system, making it more robust and versatile. The key updates include improved error handling, increased testing coverage, enhanced multi-room and multi-robot capabilities, and advanced monitoring and navigation features. 

## Improvement area

### Error Handling
- Updated error handling to return a result model.
- The result model covers:
  - Process success flag.
  - Messages.
  - Data object.

### Testing
- Added more tests to cover all scenarios.

### Controller Enhancements
- Support for multiple rooms and robots.
- Rooms and robots can be referred to by name.
- Monitoring service to determine the current status of all robots and rooms.

### Room Enhancements
- Support for 3D dimensions.
- Show the connection between rooms, including the location of doors between connected rooms.
- Maintain a history of all robots that entered/exited the room.
- Added room maximum and current robot capacity.
- Flag to indicate whether a robot can share a location.

### Robot Enhancements
- Maintain a history of movements.
- Analyze movements before processing commands to ensure:
  - The robot will not hit a wall.
  - The robot can move to another room (checking room availability and reserving space if possible).

### Additional Features ( make more fun with the project )
- Rooms can have cells that are active or reactive.
- Robots can be given a destination address and find the fastest way to reach it.


