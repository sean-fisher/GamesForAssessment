# Release Notes
## New Software Features for this Release (v1.0)

Since this is the first release of the game, there are several new features for this release.  A title screen opens the game up and then a character selection appears upon starting the game. Once you select your character, you start off in the town square. In the town square, there is a bulletin board that can take you directly to other rooms to complete games/quests, or you can rome through the game to different rooms completing quests as you go. With each minigame we have developed a scoring system that keeps track of various personality traits for the player.

The game can be completed by finishing all the tasks (successfully or unsuccessfully). Upon completion, the  results screen should appear, with the ability to view results as a 6-factor HEXACO score.
 
## Bug Fixes Made Since the Last Release
Since this is the first released version of the game, there were no bugs that were fixed from a previous version.
 
## Known Bugs and Defects
In our original iteration plan, we thought that there would be time to run a pilot study of the game. As the semester progressed, there were setbacks and roadblocks so we never got the chance to run a pilot study. The following issues will be fixed very soon.
- Issues with persistence across loading zones
- HEXACO Report functionality not complete
- Characters do not have descriptions of personalities yet
- Not all action measures are accessible by the personality assessment script yet


# Install Guide

## Prerequisites:
A Window or Mac PC is required to build and run the project. Unity projects can typically be built for and run on Linux and other platforms, but we do not officially support these platforms due to insufficient testing.
A minimal install of Unity version 2019.2.4f1 with the build tools for the desired platform is required. This can be installed via Unity Hub, which can be downloaded at https://unity3d.com/get-unity/download. Newer versions of Unity will likely work as well but might have varying results.

## Dependent Libraries:

No libraries are necessary for running a build of the project. For building the project, only the dependencies necessary for the Unity installation are necessary, which will be automatically installed during the Unity installation process.

## Download Instructions:
Create a clone of this GitHub repository or download it as a .zip via the green “clone or download” button.

## Build Instructions:

Open Unity Hub and click “Add” to locate the downloaded project folder, then open it. After the project has been automatically initialized and assets imported, check the Unity console for errors. If there are none, feel free to build the project now. This is accessible from File -> Build Settings, where you can also select the target platform. Click “Build” and you will be able to select a directory in which to build the project.

## Installation:

This project does not require installation.

## Run Instructions:

Double click the executable that is in your build or download folder (e.g. GamesForAssessment.exe on Windows).

## Troubleshooting

If you have trouble building the project, try these:

- Check your Unity version is 2019.2.4f1
  
- Your platform is Windows or Mac
  
- You have selected the correct target platform (make sure you use x86_64 or 64-bit for 64-bit Windows machines)
  
We have not encountered any issues with starting the game. If you have any, please create an issue or send us a message!
