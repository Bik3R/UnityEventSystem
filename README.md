{\rtf1\ansi\ansicpg1252\cocoartf1404\cocoasubrtf340
{\fonttbl\f0\fswiss\fcharset0 Helvetica;}
{\colortbl;\red255\green255\blue255;}
\margl1440\margr1440\vieww10800\viewh8400\viewkind0
\pard\tx720\tx1440\tx2160\tx2880\tx3600\tx4320\tx5040\tx5760\tx6480\tx7200\tx7920\tx8640\pardirnatural\partightenfactor0

\f0\fs24 \cf0 *** This project is built on version 5.2.3f1 ***\
\
This repository adds features like Pointer Enter, Pointer Exit and Pointer Click to the existing PointerInputModule. These features are primarily used in VR setting.\
\
The code GazeInputModule.cs extends the PointerInputModule and adds graphic and 3d raycasting to it thereby allowing it to register events generated by interacting with UI elements and 3d objects with colliders.\
\
After the event is registered, handlers on UI and Gameobjects act according to the events occuring - pointer enter, pointer exit, pointer click.\
\
In this case, for UI elements, pointer enter triggers an animation which changes the size of the element, pointer exit reverts back to original size and pointer click displays info message on screen. For 3d objects, pointer enter changes color of material on the object to random color, pointer exit reverts back the material color to white and pointer click displays info message on screen.\
\
There are two modes of clicking which can be chosen from GazeInputModule script in inspector before running the game in Editor: 1. Gaze: A click event is simulated when a user 'looks at' a gameobject for a predefined number of seconds (default 2 seconds) 2. Click: A click is simulated by pressing SPACE/ENTER.\
\
The current mode is displayed on the top-left of the screen for convenience.\
\
To simulate a 360 view, the script "SmoothMouseLook.cs" is attached to the Main Camera which allows for the camera to follow mouse position. This allows for the user to look in all directions for objects.}